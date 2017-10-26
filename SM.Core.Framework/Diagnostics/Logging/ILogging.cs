using System;

namespace SM.Core.Framework.Diagnostics.Logging
{
    public interface ILogging
    {
        void Info(string message);

        void Info(Exception exception, string message);

        void Debug(string message);

        void Error(string message);

        void Error(Exception exception, string message);

        void Warning(string message);

        void Warning(Exception exception, string message);
    }
}