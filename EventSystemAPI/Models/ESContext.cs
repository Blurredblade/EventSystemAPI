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
        const string ConnectionString = "server=brogrammersdb.cfizdv12jry6.us-west-2.rds.amazonaws.com;port=3306;database=scheduler;user=zac;password=Brogrammers2019";

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
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
    }
}
