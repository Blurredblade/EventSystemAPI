using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using Dapper;

namespace EventSystemAPI.Models
{
    public class ESContext : IContext
    {
        const string ConnectionString = "server=brogrammersdb.cfizdv12jry6.us-west-2.rds.amazonaws.com;port=3306;database=scheduler;user=zac;password=Brogrammers2019";


        /* \\\\\\\\\\\\\\\\\\\\\\\\\\\\\
         * \\\\\\\GET Functions\\\\\\\\\
         * \\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Event GetEvent(int event_id)
        {
            string sql = "SELECT * FROM EVENT WHERE event_id = @Event_ID;";
            Event even;
            using (var con = GetConnection())
            {
                even = con.QuerySingleOrDefault<Event>(sql, new { Event_ID = event_id });

            }
            return even;
        }

        public List<Event> GetEventsList()
        {
            string sql = "SELECT * FROM EVENT WHERE end_date >= CURDATE();";
            List<Event> events;
            using (var con = GetConnection())
            {
                events = con.Query<Event>(sql).ToList();
            }
            return events;
        }

        public List<Event> GetEventsList(int user_id)
        {
            string sql = "SELECT * FROM EVENT WHERE event_id IN (" +
                            "SELECT event_id FROM SESSION WHERE session_id IN (" +
                            "SELECT session_id FROM REGISTRATION WHERE user_id = @User_ID)) AND end_date >= CURDATE() ORDER BY start_date ASC; ";
            List<Event> events;
            using (var con = GetConnection())
            {
                events = con.Query<Event>(sql, new { User_ID = user_id }).ToList();
            }
            return events;
        }

        public List<Event> GetRecentEvents(int user_id)
        {
            string sql = "SELECT * FROM EVENT WHERE event_id IN (" +
                            "SELECT event_id FROM SESSION WHERE session_id IN (" +
                            "SELECT session_id FROM REGISTRATION WHERE user_id = @User_ID)) AND end_date >= CURDATE() ORDER BY start_date ASC LIMIT 2; ";
            List<Event> events;
            using (var con = GetConnection())
            {
                events = con.Query<Event>(sql, new { User_ID = user_id }).ToList();
            }
            return events;
        }

        public List<Session> GetUsersSessionsList(int user_id)
        {
            string sql = "SELECT * FROM SESSION WHERE session_id IN (SELECT session_id FROM REGISTRATION WHERE user_id = @User_ID); ";
            List<Session> sessions;
            using (var con = GetConnection())
            {
                sessions = con.Query<Session>(sql, new { User_ID = user_id }).ToList();

            }
            return sessions;
        }

        public Session GetSession(int session_id)
        {
            string sql = "SELECT * FROM SESSION WHERE session_id = @Session_ID;";
            Session session;
            using (var con = GetConnection())
            {
                session = con.QuerySingleOrDefault<Session>(sql, new { Session_ID = session_id });
            }
            return session;
        }

        public List<Session> GetSessionsByEvent(int event_id)
        {
            string sql = "SELECT * FROM SESSION WHERE event_id = @Event_ID;";
            List<Session> sessions;
            using (var con = GetConnection())
            {
                sessions = con.Query<Session>(sql, new { Event_ID = event_id }).ToList();
            }
            return sessions;
        }

        public List<User> GetUsersWithoutTeam(int event_id)
        {
            string sql = "SELECT * FROM USER WHERE user_id IN " +
                            "(SELECT user_id FROM REGISTRATION WHERE session_id IN" +
                            "(SELECT session_id FROM SESSION WHERE event_id = @Event_ID)) AND user_id NOT IN " +
                            "(SELECT user_id FROM USER_TEAM where team_id IN " +
                            "(SELECT team_id FROM TEAM WHERE event_id = @Event_ID)); ";
            List<User> users;
            using (var con = GetConnection())
            {
                users = con.Query<User>(sql, new { Event_ID = event_id }).ToList();
            }
            return users;
        }

        public List<Team> GetTeamsByEvent(int event_id)
        {
            string sql = "SELECT * FROM TEAM WHERE event_id = @Event_ID ORDER BY team_id;";
            string countsql = "SELECT COUNT(ut.team_id) FROM USER_TEAM as ut RIGHT JOIN TEAM as t ON ut.team_id = t.team_id WHERE t.team_id IN(SELECT team_id FROM TEAM WHERE event_id = @Event_ID) GROUP BY t.team_id ORDER BY t.team_id; ";
            List<Team> teams;
            int[] count;
            using (var con = GetConnection())
            {
                teams = con.Query<Team>(sql, new { Event_ID = event_id }).ToList();
                count = con.Query<int>(countsql, new { Event_ID = event_id }).ToArray();
            }
            for(int x = 0; x < count.Length; x++)
            {
                teams[x].memberCount = count[x];
            }
            return teams;
        }

        public List<User> GetRegisteredTeamUsers(int user_id, int session_id)
        {
            string sql = "SELECT * FROM USER WHERE user_id IN " +
                            "(SELECT user_id FROM REGISTRATION where session_id = 13) AND user_id IN " +
                            "(SELECT user_id FROM USER_TEAM WHERE team_id = (SELECT team_id FROM USER_TEAM where user_id = 1));";
            List<User> users;
            using (var con = GetConnection())
            {
                users = con.Query<User>(sql, new { User_ID = user_id, Session_ID = session_id }).ToList();
            }
            return users;
        }

        public Team GetTeam(int team_id)
        {
            string sql = "SELECT * FROM TEAM WHERE team_id = @Team_ID";
            Team team;
            using (var con = GetConnection())
            {
                team = con.QuerySingleOrDefault<Team>(sql, new { Team_ID = team_id });
            }
            //team.members = GetTeamUsers(team_id);
            return team;
        }

        public Announcement GetAnnouncement(int announcement_id)
        {
            string sql = "SELECT * FROM ANNOUNCEMENT WHERE announcement_id = @Announcement_ID;";
            Announcement announcment;
            using (var con = GetConnection())
            {
                announcment = con.QuerySingleOrDefault<Announcement>(sql, new { Announcement_ID = announcement_id });
            }
            return announcment;
        }

        public List<Announcement> GetAnnouncementsByEvent(int event_id)
        {

            string sql = "SELECT * FROM ANNOUNCEMENT WHERE event_id = @Event_ID ORDER BY date_time DESC;";
            List<Announcement> announcments;
            using (var con = GetConnection())
            {
                announcments = con.Query<Announcement>(sql, new { Event_ID = event_id }).ToList();
            }
            return announcments;
        }

        public List<Announcement> GetRecentAnnouncementsByUser(int user_id)
        {
            string sql = "SELECT * FROM ANNOUNCEMENT WHERE announcement_id IN" +
                            "(SELECT MAX(announcement_id) FROM ANNOUNCEMENT WHERE event_id IN " +
                            "(SELECT event_id FROM " +
                            "(SELECT* FROM EVENT WHERE event_id IN " +
                            "(SELECT event_id FROM SESSION WHERE session_id IN " +
                            "(SELECT session_id FROM REGISTRATION WHERE user_id = @User_ID)) AND end_date >= CURDATE() ORDER BY start_date ASC LIMIT 2) as e) GROUP BY event_id);";
            List<Announcement> announcments;
            using (var con = GetConnection())
            {
                announcments = con.Query<Announcement>(sql, new { User_ID = user_id }).ToList();
            }
            return announcments;
        }

        public List<Announcement> GetGlobalAnnouncements()
        {
            string sql = "SELECT * FROM ANNOUNCEMENT WHERE event_id = -1;";
            List<Announcement> announcements;
            using (var con = GetConnection())
            {
                announcements = con.Query<Announcement>(sql).ToList();
            }
            return announcements;
        }

        public User GetUser(int user_id)
        {
            string sql = "SELECT * FROM USER WHERE user_id = @User_ID;";
            User user;
            using (var con = GetConnection())
            {
                user = con.QuerySingleOrDefault<User>(sql, new { User_ID = user_id });
            }
            return user;
        }

        public User GetUser(string email, string password)
        {
            string sql = "SELECT * FROM USER WHERE email = @Email AND password = @Password";
            User user;
            using (var con = GetConnection())
            {
                user = con.QuerySingleOrDefault<User>(sql, new { Email = email, Password = password });
            }
            return user;
        }

        public List<User> GetTeamUsers(int team_id)
        {
            string sql = "SELECT * FROM USER where user_id in (SELECT user_id from USER_TEAM where team_id = @Team_ID);";
            List<User> users;
            using (var con = GetConnection())
            {
                users = con.Query<User>(sql, new { Team_ID = team_id }).ToList();
            }
            return users;
        }

        public List<User> GetEventUsers(int event_id)
        {
            string sql = "SELECT * FROM USER WHERE user_id IN (SELECT user_id FROM REGISTRATION WHERE session_id IN (SELECT session_id FROM SESSION WHERE event_id = @Event_ID));";
            List<User> users;
            using(var con = GetConnection())
            {
                users = con.Query<User>(sql, new { Event_ID = event_id }).ToList();
            }
            return users;
        }

        public List<User> GetSessionUsers(int session_id)
        {
            string sql = "SELECT * FROM USER WHERE user_id IN (SELECT user_id FROM REGISTRATION WHERE session_id = @Session_ID);";
            List<User> users;
            using (var con = GetConnection())
            {
                users = con.Query<User>(sql, new { Session_ID = session_id }).ToList();
            }
            return users;
        }

        public List<int> GetCheckedInUsers(int session_id)
        {
            string sql = "SELECT user_id FROM REGISTRATION WHERE session_id = @Session_ID AND checked_in = 1;";
            List<int> users;
            using (var con = GetConnection())
            {
                users = con.Query<int>(sql, new { Session_ID = session_id }).ToList();
            }
            return users;
        }


        /*\\\\\\\\\\\\\\\\\\\\\\
         *\\\CREATE Functions\\\
         *\\\\\\\\\\\\\\\\\\\\\\*/

        public Event CreateEvent(Event e) {
            string sql = "INSERT into EVENT (address, start_date, end_date, event_name, description) " +
                            "VALUES(@Address, @Start_Date, @End_Date, @Event_Name, @Description); "+
                            "SELECT * FROM EVENT WHERE event_id = LAST_INSERT_ID();";
            Event new_event;
            using (var con = GetConnection())
            {
                new_event = con.Query<Event>(sql, new
                {
                    Address = e.address,
                    Start_Date = e.start_date,
                    End_Date = e.end_date,
                    Event_Name = e.event_name,
                    Description = e.description
                }).First();
            }
            return new_event;
        }

        public Session CreateSession(Session s)
        {
            string sql = "INSERT INTO SESSION(session_name, capacity, open_slots, start_date_time, end_date_time, event_id) " +
                            "SELECT @Session_Name, @Capacity, @Open_Slots, @Start_Date_Time, @End_Date_Time, event_id " +
                            "FROM EVENT WHERE event_id = @Event_ID;"+
                            "SELECT * FROM SESSION WHERE session_id = LAST_INSERT_ID();";
            Session session;
            using (var con = GetConnection())
            {
                session = con.Query<Session>(sql, new
                {
                    Session_Name = s.session_name,
                    Capacity = s.capacity,
                    Open_Slots = s.capacity,
                    Start_Date_Time = s.start_date_time,
                    End_Date_Time = s.end_date_time,
                    Event_ID = s.event_id
                }).First();
            }
            return session;
        }

        public Team CreateTeam(Team t)
        {
            string sql = "INSERT INTO TEAM(team_name, event_id)" +
                            "SELECT @Team_Name, event_id " +
                            "FROM EVENT where event_id = @Event_ID;";
            string getid = "SELECT LAST_INSERT_ID();";
            string teamcheck = "SELECT COUNT(1) FROM TEAM WHERE team_id = @Team_ID AND Team_Name = @Team_Name;";
            string usersql = "INSERT INTO USER_TEAM(user_id, team_id) VALUES (@User_ID, @Team_ID);";
            Team team = t;
            int team_id;
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Team_Name = t.team_name,
                    Event_ID = t.event_id
                });

                team_id = con.QueryFirstOrDefault<int>(getid);

                if(con.ExecuteScalar<bool>(teamcheck, new { Team_ID = team_id, Team_Name = t.team_name }))
                {
                    List<User> users = GetEventUsers(t.event_id);
                    for(int x = 0; x < team.members.Length; x++)
                    {
                        if (users.Exists((user) => user.user_id == team.members[x]))
                        {
                            con.Execute(usersql, new
                            {
                                User_ID = team.members[x],
                                Team_ID = team_id
                            });
                        }
                        else
                        {
                            team.members[x] = -1;
                        }
                    }
                }

            }
            return team;
        }

        public void CreateAnnouncement(Announcement a)
        {
            string sql = "INSERT INTO ANNOUNCEMENT(date_time, title, message, event_id) VALUES(@Date_Time, @Title, @Message, @Event_ID);";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Date_Time = a.date_time,
                    Title = a.title,
                    Message = a.message,
                    Event_ID = a.event_id
                });
            }
        }

        public User CreateUser(User u)
        {
            string sql = "INSERT INTO USER (first_name, last_name, email, password, phone, is_admin)" +
                            "VALUES(@First_Name, @Last_Name, @Email, @Password, @Phone, @IsAdmin);" +
                            "SELECT * FROM USER WHERE user_id = LAST_INSERT_ID();";
            User user;
            using (var con = GetConnection())
            {
                user = con.Query<User>(sql, new
                {
                    First_Name = u.first_name,
                    Last_Name = u.last_name,
                    Email = u.email,
                    Password = u.password,
                    Phone = u.phone,
                    IsAdmin = u.is_admin
                }).First();
            }
            return user;
        }

        public void RegisterUser(int session_id, int user_id)
        {
            string sql = "INSERT INTO REGISTRATION (user_id, session_id, checked_in)" +
                            "SELECT @User_ID, session_id, 0 " +
                            "FROM SESSION WHERE session_id = @Session_ID AND open_slots > 0;" +
                            "UPDATE SESSION SET open_slots = open_slots - 1 WHERE session_id = @Session_ID AND open_slots > 0;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    User_ID = user_id,
                    Session_ID = session_id,
                });
            }
        }

        public void AddUserToTeam(int team_id, int user_id)
        {
            string sql = "INSERT INTO USER_TEAM VALUES (@Team_ID, @User_ID);";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Team_ID = team_id,
                    User_ID = user_id
                });
            }
        }


        /*\\\\\\\\\\\\\\\\\\\\\\
         *\\\UPDATE functions\\\
         *\\\\\\\\\\\\\\\\\\\\\\*/

        public void UpdateEvent(Event e)
        {
            string sql = "UPDATE EVENT SET address = @Address, start_date = @Start_Date, end_date = @End_Date, event_name = @Event_Name, description = @Description WHERE event_id = @Event_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Address = e.address,
                    Start_Date = e.start_date,
                    End_Date = e.end_date,
                    Event_Name = e.event_name,
                    Description = e.description,
                    Event_ID = e.event_id
                });
            }
        }

        public void UpdateSession(Session s)
        {
            string sql = "UPDATE SESSION SET session_name = @Session_Name, capacity = @Capacity, open_slots = @Open_Slots, start_date_time = @Start_Date_Time, end_date_time = @End_Date_Time WHERE session_id = @Session_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Session_Name = s.session_name,
                    Capacity = s.capacity,
                    Open_Slots = s.capacity,
                    Start_Date_Time = s.start_date_time,
                    End_Date_Time = s.end_date_time,
                    Session_ID = s.session_id
                });
            }
        }

        public void UpdateTeam(Team t)
        {
            string sql = "UPDATE TEAM SET team_name = @Team_Name WHERE team_id = @Team_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Team_Name = t.team_name,
                    Team_ID = t.team_id
                });
            }
        }

        public Announcement UpdateAnnouncement(Announcement a)
        {
            string sql = "UPDATE ANNOUNCEMENT SET date_time = @Date_Time, title = @Title, message = @Message WHERE announcement_id = @A_ID;";
            string callback = "SELECT * FROM ANNOUNCEMENT WHERE announcement_id = @A_ID;";
            Announcement announcement = null;
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Date_Time = a.date_time,
                    Title = a.title,
                    Message = a.message,
                    A_ID = a.announcement_id
                });
                announcement = con.QueryFirstOrDefault<Announcement>(callback, new { A_ID = a.announcement_id });
            }
            return announcement;
        }

        public User UpdateUser(User u)
        {
            string sql = "UPDATE USER SET first_name = @First_Name, last_name = @Last_Name, email = @Email, password = @Password, phone = @Phone, is_admin = @Is_Admin WHERE user_id = @U_ID;";
            string callback = "SELECT* FROM USER WHERE user_id = @U_ID";
            User user = null;
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    First_Name = u.first_name,
                    Last_Name = u.last_name,
                    Email = u.email,
                    Password = u.password,
                    Phone = u.phone,
                    Is_Admin = u.is_admin,
                    U_ID = u.user_id
                });
                user = con.QueryFirstOrDefault<User>(callback, new { U_ID = u.user_id });
            }
            return user;
        }

        public void CheckInUser(int session_id, int user_id)
        {
            string sql = "UPDATE REGISTRATION SET checked_in = 1 WHERE session_id = @Session_ID AND user_id = @User_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Session_ID = session_id,
                    User_ID = user_id
                });
            }
        }


        /*\\\\\\\\\\\\\\\\\\\\\\
         *\\\DELETE FUNCTIONS\\\
         *\\\\\\\\\\\\\\\\\\\\\\*/
        
        //Deletes Event along with all sessions, teams, and announcements for that event
        public void DeleteEvent(int event_id)
        {
            string sql = "DELETE FROM USER_TEAM WHERE team_id IN (SELECT team_id FROM TEAM WHERE event_id = @Event_ID);" +
                            "DELETE FROM REGISTRATION WHERE session_id IN (SELECT session_id FROM SESSION WHERE event_id = @Event_ID);" +
                            "DELETE FROM SESSION WHERE event_id = @Event_ID;" +
                            "DELETE FROM ANNOUNCEMENT WHERE event_id = @Event_ID;" +
                            "DELETE FROM TEAM WHERE event_id = @Event_ID;" +
                            "DELETE FROM EVENT WHERE event_id = @Event_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Event_ID = event_id
                });
            }
        }

        public void DeleteSession(int session_id)
        {
            string sql = "DELETE FROM SESSION WHERE session_id = @Session_ID;" +
                            "DELETE FROM REGISTRATION WHERE session_id = @Session_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Session_ID = session_id
                });
            }
        }

        public void DeleteTeam(int team_id)
        {
            string sql = "DELETE FROM TEAM WHERE team_id = @Team_ID;" +
                            "DELETE FROM USER_TEAM WHERE team_id = @Team_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Team_ID = team_id
                });
            }
        }

        public void DeleteAnnouncement(int announcement_id)
        {
            string sql = "DELETE FROM ANNOUNCEMENT WHERE announcement_id = @Announcement_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    Announcement_ID = announcement_id
                });
            }
        }

        public void DeleteUser(int user_id)
        {
            string sql = "DELETE FROM USER WHERE user_id = @User_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    User_ID = user_id
                });
            }
        }

        public void RemoveUserFromSession(int session_id, int user_id)
        {
            string sql = "UPDATE SESSION SET open_slots = open_slots + 1 WHERE session_id = @Session_ID;" + 
                            "DELETE FROM REGISTRATION WHERE user_id = @User_ID AND session_id = @Session_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    User_ID = user_id,
                    Session_ID = session_id
                });
            }
        }

        public void RemoveUserFromTeam(int team_id, int user_id)
        {
            string sql = "DELETE FROM USER_TEAM WHERE user_id = @User_ID AND team_id = @Team_ID;";
            using (var con = GetConnection())
            {
                con.Execute(sql, new
                {
                    User_ID = user_id,
                    Team_ID = team_id
                });
            }
        }
    }
}