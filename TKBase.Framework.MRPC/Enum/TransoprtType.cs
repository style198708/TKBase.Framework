﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBase.Framework.MRPC.Enum
{
    public enum TransoprtType
    {
        Init = 1,

        /// <summary>
        /// 初始化 应答
        /// </summary>
        Ans = 2,

        Request = 3,

        Response = 4,

        Heartbeat = 5
    }
}
