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