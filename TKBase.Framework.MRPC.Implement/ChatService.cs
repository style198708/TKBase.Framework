﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBase.Framework.MRPC.Attributes;
using TKBase.Framework.MRPC.Contracts;

namespace TKBase.Framework.MRPC.Implement
{
    [MService]
    public class ChatService : IChatService
    {
        public string Hi(string name)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1024 * 10; i++)
            {
                sb.Append("XX");
            }
            //return name + ":你好 世界";
            return name + ":" + sb.ToString();
        }

        public string Hi(string name, string content)
        {
            return name + ":" + content;
        }

        public string Hello(int age)
        {
            return "int:" + age;
        }

        public string Hello(double age)
        {
            return "double:" + age;
        }
    }
}
