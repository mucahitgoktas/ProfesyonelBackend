using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerService
    {
        ILog _log;

        public LoggerService(ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;


        public void Info(object logMessage)
        {
            if (IsInfoEnabled) // eğer info enabled ise
            {
                _log.Info(logMessage); // info olarak logla
            }
        }

        public void Debug(object logMessage)
        {
            if (IsDebugEnabled) // eğer Debug enabled ise
            {
                _log.Debug(logMessage); // debug olarak logla
            }
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled) // eğer Warn enabled ise
            {
                _log.Warn(logMessage); // warn olarak logla
            }
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled) // eğer Error enabled ise
            {
                _log.Error(logMessage); // error olarak logla
            }
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled) // eğer Fatal enabled ise
            {
                _log.Fatal(logMessage); // fatal olarak logla
            }
        }

    }
}
