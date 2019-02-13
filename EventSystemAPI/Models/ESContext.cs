using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                even = con.QuerySingleOrDefault<Event>(sql, new { event_id = event_id});
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
            string sql = "SELECT * FROM EVENT";
            List<Event> events;
            using (var con = GetConnection())
            {
                events = con.Query<Event>(sql).ToList();
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
            return new List<Team>();
        }

        public Team GetTeam(int team_id)
        {
            return new Team();
        }

        public Announcment GetAnnouncment(int id)
        {
            string sql = "SELECT * FROM ANNOUNCEMENT WHERE ANNOUNCEMENT_ID = @Announcement_ID;";
            Announcment announcment;
            using (var con = GetConnection())
            {
                announcment = con.QuerySingleOrDefault<Announcment>(sql, new { Announcement_ID = id });
            }
            return announcment;
        }

        public List<Announcment> GetAnnouncmentsByEvent(int event_id)
        {
            return new List<Announcment>();
        }

        public List<Announcment> GetAnnouncementsList(int length, int page)
        {
            return new List<Announcment>();
        }

        public User GetUser(int user_id)
        {
            return new User();
        }

        public List<User> GetTeamUsers(int team_id)
        {
            return new List<User>();
        }

        public List<User> GetSessionUsers(int session_id)
        {
            return new List<User>();
        }
    }
}