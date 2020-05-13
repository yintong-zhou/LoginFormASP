using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using NLog;

namespace LoginForm
{
    class Helper
    {
        public string db_ip { get; set; }
        public string db_port { get; set; }
        public string db_name { get; set; }
        public string db_username { get; set; }
        public string db_pwd { get; set; }

        public void LoadConfigFILE()
        {
            db_ip = ConfigurationManager.AppSettings["Host"];
            db_port = ConfigurationManager.AppSettings["Port"];
            db_name = ConfigurationManager.AppSettings["Name"];
            db_username = ConfigurationManager.AppSettings["User"];
            db_pwd = ConfigurationManager.AppSettings["Pwd"];
        }

        public void ExceptionWriter(string message, string stackTrace)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info("----EXCEPTION Message----");
            logger.Info(message);
            logger.Info("----END Message----");
            logger.Info("----EXCEPTION StackTrace----");
            logger.Info(stackTrace);
            logger.Info("----END StackTrace----");
        }
    }
}