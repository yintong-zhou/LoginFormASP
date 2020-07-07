using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace LoginForm
{
    class DatabaseInfo
    {
        public string ip { get; set; }
        public string port { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public string connStringSQL { get; set; }

        void LoadConfigFILE()
        {
            ip = ConfigurationManager.AppSettings["Host"];
            port = ConfigurationManager.AppSettings["Port"];
            name = ConfigurationManager.AppSettings["Name"];
            username = ConfigurationManager.AppSettings["User"];
            pwd = ConfigurationManager.AppSettings["Pwd"];
        }

        public string connString()
        {
            Cryptography crypto = new Cryptography();

            //loading web config fields
            LoadConfigFILE();

            //decrypt password from web config file
            string _pwd = crypto.DecryptText(pwd);
            
            connStringSQL = "Server={0};Username={1};Database={2};Port={3};Password={4};";
            connStringSQL = string.Format(connStringSQL, ip, username, name, port, _pwd);
            return connStringSQL;
        }
    }
}