using NLog;
using System;

namespace SM.Core.Framework.Diagnostics.Logging.NLog
{
    public class NLogImpl : ILogging
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(Exception exception, string message)
        {
            _log.Info(exception, message);
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
            _log.Error(exception, message);
        }

        public void Warning(string message)
        {
            _log.Warn(message);
        }

        public void Warning(Exception exception, string message)
        {
            _log.Warn(exception, message);
        }
    }
}