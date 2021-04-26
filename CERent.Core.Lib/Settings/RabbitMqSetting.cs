using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Core.Lib.Settings
{
    public class RabbitMqSetting
    {
        public string Url { get; set; }

        public string VirtualHost { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string LoginQueue { get; set; }

    }
}
