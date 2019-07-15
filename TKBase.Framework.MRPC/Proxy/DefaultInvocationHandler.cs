﻿/******************************************************
* author :  Lenny
* email  :  niel@dxy.cn 
* function: 
* time:	2017/8/6 15:10:30 
* clrversion :	4.0.30319.42000
******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DXY.Rpc;
using DXY.Rpc.Models;
using TKBase.Framework.MRPC.Exceptions;
using TKBase.Framework.MRPC.Models;
using TKBase.Framework.MRPC.Netty;
using TKBase.Framework.MRPC.Socket;
using Newtonsoft.Json;

namespace TKBase.Framework.MRPC.Proxy
{
    public class DefaultInvocationHandler<T> : INvocationHandler
    {
        public object InvokeMember(object obj, int rid, string statement, params object[] args)
        {
            MethodInfo met = (MethodInfo)typeof(T).Module.ResolveMethod(rid);
            List<string> parameterList = new List<string>();
            List<string> parameterTypeList = new List<string>();
            List<ParameterInfo> parameterInfos = met.GetParameters().ToList();
            string result;
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                ParameterInfo parameterInfo = parameterInfos[i];
                parameterList.Add(JsonConvert.SerializeObject(arg));
                parameterTypeList.Add(parameterInfo.ParameterType.FullName);
            }
            string[] statements = statement.Split('+');
            string parameter = JsonConvert.SerializeObject(parameterList);
            string parameterType = JsonConvert.SerializeObject(parameterTypeList);
            RpcRequest request = RpcRequest.BuildRequest(statements[0], statements[1], parameter, parameterType);

            if (statements.Length != 2)
            {
                throw new RpcArgumentException("非法接口请求");
            }

            try
            {
                using (DotNettyClient client = new DotNettyClient())
                {
                    TransportMessage message = client.SendMessage(JsonConvert.SerializeObject(request));
                    result = message.Message;
                }

                // 0.1 版本采用底层socket来通信  0.1版本以后已经弃用
                // result = SyncTcpClient.SendMessage(ClientContainer.Client, JsonConvert.SerializeObject(request));
            }
            catch (System.Exception e)
            {
                throw new RpcRequestException("rpc调用失败，请检查服务器是否状态正常", e);
            }

            try
            {
                RpcResponse response = JsonConvert.DeserializeObject<RpcResponse>(result);
                if (response.Code != 0)
                {
                    throw new System.Exception(response.Message);
                }
                if (met.ReturnType == typeof(void))
                    return null;
                return JsonConvert.DeserializeObject(response.Response, met.ReturnType);
            }
            catch (System.Exception e)
            {
                throw new DeserializeException("rpc反序列化失败", e);
            }
        }
    }
}
