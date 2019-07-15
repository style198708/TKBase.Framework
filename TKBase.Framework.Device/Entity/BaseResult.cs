﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.Device
{
    public class BaseResult
    {
        /// <summary>
        /// 执行包
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 回调路径
        /// </summary>
        public string CallBack { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Cmd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CmdStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 执行数据
        /// </summary>
        public BaseAction ActionData { get; set; }


    }
}
