using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EventSystemAPI.Models
{
    interface IContext
    {
        List<Event> GetEventsList();
        List<Event> GetEventsList(int user_id);
        Event GetEvent(int event_id);
        List<Session> GetSessionsByEvent(int event_id);
        Session GetSession(int session_id);
        List<Team> GetTeamsByEvent(int event_id);
        Team GetTeam(int team_id);
        List<Announcment> GetAnnouncmentsByEvent(int event_id);
        Announcment GetAnnouncment(int announcment_id);
        User GetUser(int user_id);
        List<User> GetTeamUsers(int team_id);
        List<User> GetSessionUsers(int session_id);
    }
}
