using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKBase.Framework.WebSite
{
    public class RechargeTempMessage
    {
        public Key first { get; set; }

        public Key DateTime { get; set; }

        public Key PayAmount { get; set; }

        public Key Location { get; set; }

        public Key remark { get; set; }
    }
    public class Key
    {
        public string value { get; set; }

        public string color { get; set; }
    }
}
