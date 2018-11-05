using _00_DAL;
using _01_BOL;
using _01_BOL.HelpDepartment;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BLL
{
    public static class LogicDailyPresence
    {
        public static List<DailyPresence> GetAllDailyPresence()
        {
            string query = $"SELECT * FROM truth_time_ct.daily_presence";

            Func<MySqlDataReader, List<DailyPresence>> func = (reader) =>
                {
                    List<DailyPresence> DailyPresences = new List<DailyPresence>();
                    while (reader.Read())
                    {
                        DailyPresences.Add(new DailyPresence
                        {
                            IdDaliyPresence = (int)reader[0],
                            EndDatePresence = (DateTime)reader[1],
                            StartDatePresence=(DateTime)reader[2],
                            IdUserProjectFK = (int)reader[3]
                        
                        });
                    }
                    return DailyPresences;
                };
            return DBUse.RunReader(query, func);
        }
        public static bool RemoveDailyPresence(int id)
        {
            string query = $"DELETE FROM truth_time_ct.daily_presence WHERE idDaliyPresence={id}";
            return DBUse.RunNonQuery(query) == 1;
        }

        public static bool UpdateDailyPresence(DailyPresence daliyPresence)
        {
            //check if first time or only update end time
         
            string query=$"SELECT distinct d2.idDaliyPresence into @a FROM truth_time_ct.daily_presence as d2 where d2.idUserProject = 2 and d2.startDatePresence = d2.endDatePresence;UPDATE truth_time_ct.daily_presence as d SET d.endDatePresence = NOW() where d.idDaliyPresence = @a";
            return DBUse.RunNonQuery(query) == 1;
        }

        public static bool AddDailyPresence(DailyPresence daliyPresence)
        {
            string formatForMySqlEndDatePresence = daliyPresence.EndDatePresence.ToString("yyyy-MM-dd HH:mm:ss");
            string formatForMySqlStartDatePresence = daliyPresence.StartDatePresence.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"INSERT INTO truth_time_ct.daily_presence VALUES ({daliyPresence.IdDaliyPresence},'{formatForMySqlEndDatePresence}','{formatForMySqlStartDatePresence}'" +
                $",{daliyPresence.IdUserProjectFK})";
            return DBUse.RunNonQuery(query) == 1;
        }
        public static List<DailyPresence> GetAllDailyPresenceByUser(int userId)
        {
            string query = $"SELECT * FROM truth_time_ct.daily_presence";

            Func<MySqlDataReader, List<DailyPresence>> func = (reader) =>
            {
                List<DailyPresence> DailyPresencesOfUsers = new List<DailyPresence>();
                while (reader.Read()&& (int)reader[3]== userId)
                {
                    DailyPresencesOfUsers.Add(new DailyPresence
                    {
                        IdDaliyPresence = (int)reader[0],
                        EndDatePresence = (DateTime)reader[1],
                        StartDatePresence = (DateTime)reader[2],
                        IdUserProjectFK = (int)reader[3]
                    });
                }
                return DailyPresencesOfUsers;
            };
            return DBUse.RunReader(query, func);
        }
        public static List<DailyPresence> GetDailyPresenceOfUserOfTheTeamLeader(int IdTeamLeader)
        {
            string query = $"SELECT * FROM truth_time_ct.daily_presence d JOIN truth_time_ct.users u ON d.idUser=u.idUser WHERE u.idUser={IdTeamLeader}";

            Func<MySqlDataReader, List<DailyPresence>> func = (reader) =>
            {
                List<DailyPresence> DailyPresencesOfUsers = new List<DailyPresence>();
                while (reader.Read())
                {
                    DailyPresencesOfUsers.Add(new DailyPresence
                    {
                        IdDaliyPresence = (int)reader[0],
                        EndDatePresence = (DateTime)reader[1],
                        StartDatePresence = (DateTime)reader[2],
                        IdUserProjectFK = (int)reader[3]
                    });
                }
                return DailyPresencesOfUsers;
            };
            return DBUse.RunReader(query, func);
        }
        public static List<UserProjectHelp> GetNamesProjectsAndIdUPTodayForUser(int IdUser)
        {
            string query = $"SELECT idUserProject,projectName FROM truth_time_ct.users_projects as up join truth_time_ct.projects as p " +
                $"on p.idProject=up.idProject where up.idUser={IdUser} and up.idProject " +
                $"in(SELECT idProject from truth_time_ct.projects where startDate <= DATE(NOW()) and endDate>= DATE(NOW()) and idProject " +
                $"in (select idProject from truth_time_ct.users_projects where idUser = {IdUser}))";
            Func<MySqlDataReader, List<UserProjectHelp>> func = (reader) =>
            {
                List<UserProjectHelp> TasksForTodayOfCurrentUsers = new List<UserProjectHelp>();
                while (reader.Read())
                {
                    TasksForTodayOfCurrentUsers.Add(new UserProjectHelp() {
                        IdUserProject= int.Parse(reader[0].ToString()),
                         NameProject=  reader[1].ToString()
                         });                      
                }
                return TasksForTodayOfCurrentUsers;
            };
            return DBUse.RunReader(query, func);
        }
      

    }
}

