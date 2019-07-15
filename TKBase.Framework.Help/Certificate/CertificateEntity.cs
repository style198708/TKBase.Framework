using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.Helper
{
    /// <summary>
    /// 证书
    /// </summary>
    public class CertificateEntity
    {
        /// <summary>
        /// 证书文件路径
        /// </summary>
        public string CFileName { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        public string PassWord { get; set; }
    }
}
