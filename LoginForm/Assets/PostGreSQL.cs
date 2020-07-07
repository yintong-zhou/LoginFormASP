using System;
using System.Data;
using Npgsql;
using NLog;

namespace LoginForm
{ 
    class PostGreSQL
    {
        Helper helper = new Helper();
        public NpgsqlConnection conn;

        public PostGreSQL()
        {
        }

        ~PostGreSQL()
        {
        }

        public void ConnectDB(string ConnectionString)
        {

            if (conn != null)
                conn.Close();

            conn = new NpgsqlConnection(ConnectionString);

            try
            {
                //Apro la connessione
                conn.Open();
            }
            catch (Exception ex)
            {
                helper.ExceptionWriter(ex.Message, ex.StackTrace);
            }
        }

        public void DisconnectDB()
        {
            if (conn != null)
                conn.Close();
        }

        /// <summary>
        /// Select User Status
        /// </summary>
        /// <param name="username">Insert login username</param>
        /// <param name="password">Insert login crypted password</param>
        /// <returns></returns>
        public DataTable SelectUser(string username, string password)
        {
            DataTable DT = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            string Sql = $"SELECT status FROM public.\"UsersASP\" WHERE username='{username}' and pwd='{password}'";

            try
            {
                Sql = String.Format(Sql);
                adapter.SelectCommand = new NpgsqlCommand(Sql, conn);
                adapter.Fill(DT);
            }
            catch (Exception ex)
            {
                helper.ExceptionWriter(ex.Message, ex.StackTrace);
            }
            return DT;
        }

        public void UpdateUser(string ColumnName, string NewContent, string NasName)
        {
            try
            {
                string Sql = "UPDATE PUBLIC.\"NASInfo\" SET {0}='{1}' WHERE nas_name='{2}'";
                Sql = String.Format(Sql, ColumnName, NewContent, NasName);
                NpgsqlCommand myCommand = new NpgsqlCommand(Sql, conn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                helper.ExceptionWriter(ex.Message, ex.StackTrace);
            }
        }

        /// <summary>
        /// Inserire i valori delle colonne all'interno della tabella Users
        /// </summary>
        /// <param name="firstname">User Firstname</param>
        /// <param name="lastname">User Lastname</param>
        /// <param name="username">Type Username</param>
        /// <param name="password">Type Password</param>
        /// <param name="status">Insert Status like [valid, blocked]</param>
        /// <param name="email">Type Email</param>
        /// <param name="created">Insert created time</param>
        /// <param name="lastLogin">Insert User last login time</param>
        /// <param name="account">Account Group like [1=Administrators, 2=Users, 3=Guests]</param>
        public void InsertUser(string firstname, string lastname, string username, string password, string status, string email, DateTime created, DateTime lastLogin, int account)
        {
            DateTime now = DateTime.Now;
            try
            {
                string Sql = $"INSERT INTO public.\"UsersASP\"(firstname, lastname, username, pwd, status, email, created, last_login, account) " +
                    $"VALUES ('{firstname}','{lastname}','{username}', '{password}', '{status}', '{email}', {created}, {lastLogin}, '{account}')";
                NpgsqlCommand myCommand = new NpgsqlCommand(Sql, conn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                helper.ExceptionWriter(ex.Message, ex.StackTrace);
            }
        }
    }
}
