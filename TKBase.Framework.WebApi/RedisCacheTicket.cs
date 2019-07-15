using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Redis;

namespace TKBase.Framework.WebApi
{
    /// <summary>
    /// 获取缓存用户票据
    /// </summary>
    public class RedisCacheTicket
    {

        public string sid = null;

        public RedisCacheTicket(string sid)
        {
            this.sid = sid;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        public TicketEntity CurrUserInfo
        {
            get
            {
                string errMsg = "";
                TicketEntity result = new TicketEntity();
                if (!string.IsNullOrWhiteSpace(sid))
                {

                    TicketEntity userTicket = RedisHelper.Get<TicketEntity>(sid);
                    if (userTicket != null)
                    {
                        if (!string.IsNullOrEmpty(userTicket.MemberName))
                        {
                            DateTime dateExp = userTicket.ExpDate;
                            DateTime dateNow = DateTime.Now;
                            TimeSpan diff = dateNow - dateExp;
                            long days = diff.Days;
                            if (days > 30)//APP用户票据缓存30天
                            {
                                // 用户票据缓存时间超时，重新登录
                                RedisHelper.Remove(sid);
                                errMsg = string.Format("用户票据缓存时间超时，sid={0},userid={1},username={2},days={3}", sid, userTicket.MemberID, userTicket.MemberName, days);
                                //Log.Logger.Info(errMsg);
                            }
                            else
                            {
                                //获取用户票据成功，正常票据
                                //errMsg = string.Format("获取用户票据成功，正常票据,sid={0},userid={1},username={2},days={3}", sid, userTicket.UserID, userTicket.UserName, days);
                                //Log.Logger.Info(errMsg);
                                return userTicket;
                            }
                        }
                        else
                        {
                            //获取用户票据成功，但用户名称为空，重新登录
                            errMsg = string.Format("获取用户票据成功，但用户名为空，sid={0}", sid);
                            //Log.Logger.Info(errMsg);
                        }

                    }
                    else
                    {
                        //获取用户票据为空，重新登录
                        errMsg = string.Format("获取用户票据为空，sid={0}", sid);
                        //Log.Logger.Info(errMsg);
                    }

                }
                return result;
            }
        }



    }
}
