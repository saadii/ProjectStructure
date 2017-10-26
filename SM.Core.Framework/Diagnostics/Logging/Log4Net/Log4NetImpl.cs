using log4net;
using System;
using System.Reflection;

namespace SM.Core.Framework.Diagnostics.Logging.Log4Net
{
    public class Log4NetImpl : ILogging
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(Exception exception, string message)
        {
            _log.Info(message, exception);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(Exception exception, string message)
        {
            _log.Error(message, exception);
        }

        public void Warning(string message)
        {
            _log.Warn(message);
        }

        public void Warning(Exception exception, string message)
        {
            _log.Warn(message, exception);
        }
    }
}