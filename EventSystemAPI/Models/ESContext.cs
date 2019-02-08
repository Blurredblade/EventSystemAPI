using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace EventSystemAPI.Models
{
    public class ESContext
    {
        public string ConnectionString { get; set; }
        public ESContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Announcment GetAnnouncment()
        {
            string sql = "SELECT * FROM ANNOUNCEMENT WHERE ANNOUNCEMENT_ID = @Announcement_ID;";
            Announcment announcment;
            using (var con = GetConnection())
            {
                announcment = con.QuerySingleOrDefault<Announcment>(sql, new { Announcement_ID = 1 });
            }
            return announcment;
        }
    }
}
