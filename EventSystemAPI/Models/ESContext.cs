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

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Event GetEvent(int event_id)
        {
            string sql = "CALL GetEvent(@Event_ID);";
            Event even;
            using(var con = GetConnection())
            {
                even = con.QuerySingleOrDefault<Event>(sql, new { Event_ID = event_id});
            }
            return even;
        }

        public List<Event> GetEventsList()
        {
            string sql = "CALL GetAllEvents();";
            List<Event> events;
            using(var con = GetConnection())
            {
                events = con.Query<Event>(sql).ToList();
            }
            return new List<Event>();
        }

        public List<Event> GetEventsList(int user_id)
        {
            string sql = "CALL GetUsersEvents(@User_ID);";
            List<Event> events;
            using (var con = GetConnection())
            {
                events = con.Query<Event>(sql, new { User_ID = user_id}).ToList();
            }
            return events;
        }

        public Session GetSession(int session_id)
        {
            string sql = "CALL GetSession(@Session_ID);";
            Session session;
            using (var con = GetConnection())
            {
                session = con.QuerySingleOrDefault<Session>(sql, new { Session_ID = session_id });
            }
            return new Session();
        }

        public List<Session> GetSessionsByEvent(int event_id)
        {
            string sql = "CALL GetSessionsByEvent(@Event_ID);";
            List<Session> sessions;
            using (var con = GetConnection())
            {
                sessions = con.Query<Session>(sql, new { Event_ID = event_id }).ToList();
            }
            return sessions;
        }

        public List<Team> GetTeamsByEvent(int event_id)
        {
            string sql = "CALL GetEventTeams(@Event_ID);";
            List<Team> teams;
            using (var con = GetConnection())
            {
                teams = con.Query<Team>(sql, new { Event_ID = event_id }).ToList();
            }
            return teams;
        }

        public Team GetTeam(int team_id)
        {
            string sql = "CALL GetTeam(@Team_ID);";
            Team team;
            using (var con = GetConnection())
            {
                team = con.QuerySingleOrDefault<Team>(sql, new { Team_ID = team_id });
            }
            return team;
        }

        public Announcment GetAnnouncment(int announcement_id)
        {
            string sql = "CALL GetAnnouncement(@Announcement_ID);";
            Announcment announcment;
            using (var con = GetConnection())
            {
                announcment = con.QuerySingleOrDefault<Announcment>(sql, new { Announcement_ID = announcement_id });
            }
            return announcment;
        }

        public List<Announcment> GetAnnouncmentsByEvent(int event_id)
        {

            string sql = "CALL GetAnnouncementsForEvent(@Event_ID);";
            List<Announcment> announcments;
            using (var con = GetConnection())
            {
                announcments = con.Query<Announcment>(sql, new { Event_ID = event_id }).ToList();
            }
            return announcments;
        }

        public List<Announcment> GetAnnouncementsList(int user_id)
        {
            //TODO
            return new List<Announcment>();
        }

        public User GetUser(int user_id)
        {
            string sql = "CALL GetUser(@User_ID);";
            User user;
            using (var con = GetConnection())
            {
                user = con.QuerySingleOrDefault<User>(sql, new { User_ID = user_id });
            }
            return user;
        }

        public List<User> GetTeamUsers(int team_id)
        {
            string sql = "CALL GetTeamUsers(@Team_ID);";
            List<User> users;
            using (var con = GetConnection())
            {
                users = con.Query<User>(sql, new { Team_ID = team_id }).ToList();
            }
            return users;
        }

        public List<User> GetSessionUsers(int session_id)
        {
            string sql = "CALL GetSessionUsers(@Session_ID);";
            List<User> users;
            using (var con = GetConnection())
            {
                users = con.Query<User>(sql, new { Session_ID = session_id }).ToList();
            }
            return users;
        }
    }
}