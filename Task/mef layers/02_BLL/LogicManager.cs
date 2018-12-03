using _00_DAL;
using _01_BOL;

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;

namespace _02_BLL
{
    [Export(typeof(IAllUser))]
    public  class LogicManager: IAllUser
    {

       public  List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM [dbo].[User]";

            Func<SqlDataReader, List<User>> func = (reader)=>{
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id =reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        Age = reader.GetInt32(2)
                    });
                }
                return users;
             };

            return DBAccess.RunReader(query, func);
        }

        public static string GetUserName(int id)
        {
            string query = $"SELECT Name FROM [dbo].[User] WHERE Id={id}";
            return DBAccess.RunScalar(query).ToString();
        }

        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM [dbo].[User] WHERE Id={id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool UpdateUser(User user)
        {
            string query = $"UPDATE [dbo].[User] SET Name='{user.UserName}', Age={user.Age}  WHERE Id={user.Id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool AddUser(User user)
        {
            string query = $"INSERT INTO [dbo].[User] VALUES ({user.Id},'{user.UserName}',{user.Age})";
            return DBAccess.RunNonQuery(query) == 1;
        }
    }
}
