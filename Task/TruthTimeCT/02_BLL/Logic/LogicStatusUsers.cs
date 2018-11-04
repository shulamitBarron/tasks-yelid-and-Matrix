using _00_DAL;
using _01_BOL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BLL
{
    public static class LogicStatusUsers
    {
       
        public static List<StatusUser> GetAllStatusUsers()
        {
            string query = $"SELECT * FROM truth_time_ct.status_users";

            Func<MySqlDataReader, List<StatusUser>> func = (reader) =>
            {
                List<StatusUser> status = new List<StatusUser>();
                while (reader.Read())
                {
                    status.Add(new StatusUser
                    {
                        IdStatus = (int)reader[0],
                        StatusName = (string)reader[1]
                    });
                }
                return status;
            };

            return DBUse.RunReader(query, func);
        }

        public static string GetStatusName(int id)
        {
            string query = $"SELECT statusName FROM truth_time_ct.status_users WHERE idStatus={id}";
            return DBUse.RunScalar(query).ToString();
        }
     
    }
}
