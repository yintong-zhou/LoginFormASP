using System;
using System.Data;
using Npgsql;
using NLog;

namespace LoginForm
{ 
    class PostGreSQL
    {
        Logger logger = LogManager.GetCurrentClassLogger();
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
                logger.Info("---EX MESSAGE SQL Conn---");
                logger.Info(ex.Message);
                logger.Info("---EX STACKTRACE---");
                logger.Info(ex.StackTrace);
                throw ex;
            }
        }

        public void DisconnectDB()
        {
            if (conn != null)
                conn.Close();
        }

        public DataTable SelectUser(string id_call)
        {
            DataTable DT = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            string Sql = $"SELECT location, company FROM calls WHERE id_call = '{id_call}'";

            try
            {
                Sql = String.Format(Sql);
                adapter.SelectCommand = new NpgsqlCommand(Sql, conn);
                adapter.Fill(DT);
            }
            catch (Exception ex)
            {
                logger.Info("---EX MESSAGE Select Replay Query---");
                logger.Info(ex.Message);
                logger.Info("---EX STACKTRACE---");
                logger.Info(ex.StackTrace);
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
                logger.Info("---EX MESSAGE Updade Query---");
                logger.Info(ex.Message);
                logger.Info("---EX STACKTRACE---");
                logger.Info(ex.StackTrace + Environment.NewLine);
            }
        }

        public void InsertUser(string description, string log_type)
        {
            DateTime now = DateTime.Now;
            try
            {
                //INSERT INTO public."UsersASP" (username, pwd, status, email, createAt, lastLogin, account) VALUES('admin', 'MWXoz/IVd1hZQWyQbSeOBA==', 'valid', 'zhouyintong96@gmail.com', current_timestamp, NULL, '1')
                string Sql = $"INSERT INTO logs(log_time, description, log_type) VALUES ('{now}','{description}','{log_type}')";
                NpgsqlCommand myCommand = new NpgsqlCommand(Sql, conn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Info("---EX MESSAGE InsertLogs Query---");
                logger.Info(ex.Message);
                logger.Info("---EX STACKTRACE---");
                logger.Info(ex.StackTrace + Environment.NewLine);
            }
        }
    }
}
