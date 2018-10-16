using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _00_DAL
{
    public static class DBAccess
    {
        static SqlConnection Connection = new SqlConnection(@"Data Source=.;Initial Catalog=securityModel;Integrated Security=True");
        public static int? RunNonQuery(string query)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }

        }

        public static object RunScalar(string query)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                return command.ExecuteScalar();
            }
            catch(Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
            
        }

        public static List<T> RunReader<T>(string query, Func<SqlDataReader, List<T>> func)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();
                return func(reader);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }

        }

    }
}
