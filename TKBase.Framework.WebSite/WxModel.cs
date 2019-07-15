using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKBase.Framework.WebSite
{

    public class WxConfig
    {
        public static string appid = "wx718f493b03ba0a6c";
        public static string secret = "5b59a850336af45ff39cf466c2b9fc02";
    }

    public class access_token
    {
        public string appid { get; set; }
        public string secret { get; set; }
        public string code { get; set; }

        public string grant_type { get { return "authorization_code"; } }
    }

    public class access_tokenresult
    {
        public string access_token { get; set; }

        public string expires_in { get; set; }

        public string refresh_token { get; set; }

        public string openid { get; set; }

        public string scope { get; set; }
    }
}
