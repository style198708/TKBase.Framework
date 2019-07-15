using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.RestSharp;
using TKBase.Framework.BaseResult;
using TKBase.Framework.Camera.Entity;
using TKBase.Framework.RestSharp.Extensions;
using System.IO;
using TKBase.Framework.Scheduler;
using System.Threading.Tasks;

namespace TKBase.Framework.Camera
{
    public class CameraHelp
    {
        /// <summary>
        /// 开始任务
        /// </summary>
        /// <param name="DeviceSerial"></param>
        public static  bool Start(string DeviceSerial)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>
            {
                { "DeviceSerial", DeviceSerial }
            };
            ScheduleManage.Instance.AddScheduleList(new ScheduleEntity()
            {
                BeginTime = DateTime.Now,
                EndTime = DateTime.Now.AddMonths(1),
                JobGroup = "PicGroup",
                JobName = DeviceSerial,
                AssemblyName = "TKBase.Framework.Camera",
                ClassName = "CameraJob",
                Cron = CameraConfig.Cron,
            });

            var task = SchedulerHelper.Instance.RunScheduleJob<ScheduleManage>("PicGroup", DeviceSerial);
            return true;
        }

        /// <summary>
        /// 结束任务
        /// </summary>
        /// <param name="DeviceSerial"></param>
        public static bool Stop(string DeviceSerial)
        {
            var task = SchedulerHelper.Instance.StopScheduleJob<ScheduleManage>("PicGroup", DeviceSerial);
            return true;
        }


        /// <summary>
        /// 取图片
        /// </summary>
        /// <returns></returns>
        public static JsonDataResult<CameraPicResult> GetCameraPic(string DeviceSerial)
        {
            JsonDataResult<CameraPicResult> result = new JsonDataResult<CameraPicResult>();
            AccessResult access = GetAccessToken();
            if (string.IsNullOrEmpty(access.AccessToken))
            {
                result.Code = 100;
                result.Msg = "验权失败";
                return result;
            }
            RestClient client = new RestClient("https://open.ys7.com/api/lapp/device/capture");
            IRestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddQueryParameter("accessToken", access.AccessToken);
            request.AddQueryParameter("deviceSerial", DeviceSerial);
            request.AddQueryParameter("channelNo", "1");
            IRestResponse<JsonDataResult<CameraPicResult>> response = client.Execute<JsonDataResult<CameraPicResult>>(request);
            if (response.Data.Code == 200)
            {
                RestClient pic = new RestClient(response.Data.Data.PicUrl);
                IRestRequest picrequest = new RestRequest(Method.GET);
                string dir = Path.Combine(CameraConfig.ImgFile, DeviceSerial, DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                Console.Out.WriteLineAsync(Path.Combine(dir, DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg"));
                pic.DownloadData(picrequest).SaveAs(Path.Combine(dir, DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg"));
            }
            
            return response.Data;
        }

        /// <summary>
        /// 验权
        /// </summary>
        /// <returns></returns>
        private static AccessResult GetAccessToken()
        {
            RestClient client = new RestClient("https://open.ys7.com/api/lapp/token/get");
            IRestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddQueryParameter("appKey", CameraConfig.AppKey);
            request.AddQueryParameter("appSecret", CameraConfig.AppSecret);
            IRestResponse<JsonDataResult<AccessResult>> response = client.Execute<JsonDataResult<AccessResult>>(request);
            return response.Data.Data;
        }
    }
}
