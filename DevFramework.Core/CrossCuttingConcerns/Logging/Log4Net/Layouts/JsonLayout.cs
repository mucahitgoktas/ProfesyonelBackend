using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout:LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            throw new NotImplementedException();
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logevent = new SerializableLogEvent(loggingEvent); // SerializableLogEvent.cs den gelen log event bilgilerini aktarıyoruz.
            var json = JsonConvert.SerializeObject(logevent,Formatting.Indented); // loglarımızı json formatında yazdırmak için.
            writer.WriteLine(json); // writer ile json'a yazacağımızı belirtiyoruz.
        }
    }
}
