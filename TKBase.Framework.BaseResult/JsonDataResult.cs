﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TKBase.Framework.BaseResult
{
    /// <summary>
    /// 返回结果，object 类型
    /// </summary>
    public class JsonDataResult : JsonDataBase
    {
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        public JsonDataResult()
        {
            Code = 0;//成功
            Msg = "";
            Data = new object();
        }
    }

    /// <summary>
    ///  返回结果 T 类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonDataResult<T> : JsonDataBase where T : new()
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JsonDataResult()
        {
            Code = 0;//成功
            Msg = "";
            Data = new T();
        }
    }

}
