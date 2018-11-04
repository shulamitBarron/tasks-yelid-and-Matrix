using _00_DAL;
using _01_BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;

namespace _02_BLL
{
    public class LogicUsers
    {

        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM truth_time_ct.users";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    int p = (int)reader[0];
                    string p1 = (string)reader[1];
                    string p2 = (string)reader[2];
                    int p3 = (int)reader[3];
                    string p4 = (string)reader[4];
                    double p5 = (double)reader[5];
                    int p6 = 0;
                    int.TryParse(reader[6].ToString(), out p6);
                    bool p7 = reader.GetBoolean(7);


                    //StatusUser s = new StatusUser() { IdStatus = p3, StatusName = LogicStatusUsers.GetStatusName(p3) };
                    users.Add(new User
                    {
                        IdUser = p,
                        UserName = p1,
                        Password = p2,
                        IdStatus = p3,
                        EmailUser = p4,
                        SumHours = p5,
                        IdTeamLeader = p6,
                        IsActive = p7
                    });
                }
                return users;
            };

            return DBUse.RunReader(query, func);
        }

        public static string GetUserName(int id)
        {
            string query = $"SELECT userName FROM truth_time_ct.users WHERE idUser={id}";
            return DBUse.RunScalar(query).ToString();
        }

        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM truth_time_ct.users WHERE idUser={id}";
            return DBUse.RunNonQuery(query) == 1;
        }

        public static bool UpdateUser(User user)
        {
            string query = $"UPDATE truth_time_ct.users SET userName='{user.UserName}',password='{user.Password}',idStatus={user.IdStatus},emailUser='{user.EmailUser}',sumHours={user.SumHours},idTeamLeader={user.IdTeamLeader},isActive={user.IsActive} WHERE idUser={user.IdUser}";
            return DBUse.RunNonQuery(query) == 1;
        }


        public static bool AddUser(User user)
        {

            string query = $"INSERT INTO truth_time_ct.users VALUES (0,'{user.UserName}','{user.Password}'" +
                $",{user.IdStatus},'{user.EmailUser}',{user.SumHours},{user.IdTeamLeader},{user.IsActive})";
            return DBUse.RunNonQuery(query) == 1;
        }
        //return all users under TeamLeader
        public static List<User> GetAllUsersUnderTeamLeader(int IdTeamLeader)
        {
            string query = $"SELECT * FROM truth_time_ct.users WHERE idTeamLeader={IdTeamLeader}";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    int p = (int)reader[0];
                    string p1 = (string)reader[1];
                    string p2 = (string)reader[2];
                    int p3 = (int)reader[3];
                    string p4 = (string)reader[4];
                    double p5 = (double)reader[5];
                    int p6 = 0;
                    int.TryParse(reader[6].ToString(), out p6);
                    bool p7 = reader.GetBoolean(7);
                    users.Add(new User
                    {
                        IdUser = p,
                        UserName = p1,
                        Password = p2,
                        IdStatus = p3,
                        //StatusUserFK =s,
                        EmailUser = p4,
                        SumHours = p5,
                        IdTeamLeader = p6,
                        IsActive = p7

                    });


                }
                return users;
            };

            return DBUse.RunReader(query, func);
        }
        //get user by idUser
        public static User GetUserByIdUser(int idUser)
        {
            string query = $"SELECT * FROM truth_time_ct.users WHERE idUser={idUser}";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    int p6 = 0;
                    int.TryParse(reader[6].ToString(), out p6);
                    bool p7 = reader.GetBoolean(7);
                    users.Add(new User
                    {
                        IdUser = (int)reader[0],
                        UserName = (string)reader[1],
                        Password = (string)reader[2],
                        IdStatus = (int)reader[3],
                        EmailUser = (string)reader[4],
                        SumHours = (double)reader[5],
                        IdTeamLeader = p6,
                        IsActive = p7
                    });
                }
                return users;
            };
            User myUser = DBUse.RunReader(query, func)[0];
            return myUser;
        }
        //all users that worked on specipic project
        public static List<User> GetUsersOfProject(int idProject)
        {
            string query = $"SELECT * FROM truth_time_ct.users u join truth_time_ct.users_projects up on u.idUser=up.idUser where up.idProject={idProject}";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> Users = new List<User>();
                while (reader.Read())
                {
                    int p6 = 0;
                    int.TryParse(reader[6].ToString(), out p6);
                    bool p7 = reader.GetBoolean(7);
                    Users.Add(new User
                    {
                        IdUser = (int)reader[0],
                        UserName = (string)reader[1],
                        Password = (string)reader[2],
                        IdStatus = (int)reader[3],
                        EmailUser = (string)reader[4],
                        SumHours = (double)reader[5],
                        IdTeamLeader = p6,
                        IsActive = p7
                    });
                }
                return Users;
            };
            return DBUse.RunReader(query, func);
        }
        //all users by getting name of project
        public static List<User> GetUsersByNameOfProject(string nameProject)
        {
            string query = $"SELECT DISTINCT * FROM truth_time_ct.users u join truth_time_ct.users_projects up on u.idUser=up.idUser join truth_time_ct.projects p on up.idProject=p.idProject where p.projectName={nameProject}";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> Users = new List<User>();
                while (reader.Read())
                {
                    int p6 = 0;
                    int.TryParse(reader[6].ToString(), out p6);
                    bool p7 = reader.GetBoolean(7);
                    Users.Add(new User
                    {
                        IdUser = (int)reader[0],
                        UserName = (string)reader[1],
                        Password = (string)reader[2],
                        IdStatus = (int)reader[3],
                        //StatusUserFK =s,
                        EmailUser = (string)reader[4],
                        SumHours = (double)reader[5],
                        IdTeamLeader = p6,
                        IsActive = p7
                    });
                }
                return Users;
            };

            return DBUse.RunReader(query, func);
        }
        //return all team leader
        public static List<User> GetAllTeamLeader()
        {
            string query = $"SELECT  * FROM truth_time_ct.users u join truth_time_ct.status_users s on u.idStatus = s.idStatus where s.statusName LIKE '%leader%'";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> Users = new List<User>();
                while (reader.Read())
                {
                    int p6 = 0;
                    int.TryParse(reader[6].ToString(), out p6);
                    bool p7 = reader.GetBoolean(7);
                    Users.Add(new User
                    {
                        IdUser = (int)reader[0],
                        UserName = (string)reader[1],
                        Password = (string)reader[2],
                        IdStatus = (int)reader[3],
                        EmailUser = (string)reader[4],
                        SumHours = (double)reader[5],
                        IdTeamLeader = p6,
                        IsActive = p7
                    });
                }
                return Users;
            };

            return DBUse.RunReader(query, func);
        }


    }
}
