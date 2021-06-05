using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent // Logları json formatında tutabilmek için yapılan operasyon
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName; // loglama bilgisine sebep olaran kişi kimdir? (sadece Get aldı, set almadı) expression body ile çevirildi.
        public object MessageObject => _loggingEvent.MessageObject; // hangi metot hangi parametrelerle çevirildi?
    }
}
