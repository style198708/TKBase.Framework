﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.MongoDB
{
    public partial class IMongoModel
    {
        /// <summary>
        /// 基础ID
        /// </summary>
        public ObjectId _id { get; set; }
    }


}
