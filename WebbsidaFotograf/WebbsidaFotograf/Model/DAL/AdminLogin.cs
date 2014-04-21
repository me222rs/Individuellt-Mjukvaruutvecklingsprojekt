using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebbsidaFotograf.Model.DAL
{
    public class AdminLogin
    {
        private static string _connectionString;
        static AdminLogin()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public bool UserLogin(string userName, string password)
        {

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("appSchema.AdminLoginProcedure", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Skickar in lösenord och anvnamn i den lagrade proceduren
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                connection.Open();

                string result = Convert.ToString(cmd.ExecuteScalar());

                if (string.IsNullOrEmpty(result))
                {
                    //Om lösenordet är fel returnera falskt
                    return false;
                }
                else
                {
                    // annars true
                    return true;
                }
            }
        }
    }
}