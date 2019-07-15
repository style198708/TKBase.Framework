using Microsoft.Extensions.Configuration;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TKBase.Framework.CLI
{
   public class SFTPHelper
    {
        #region 字段或属性
        private SftpClient sftp;

        /// <summary>
        /// SFTP连接状态
        /// </summary>
        public bool Connected { get { return sftp.IsConnected; } }
        #endregion

        #region 构造
        public SFTPHelper(string config)
        {
            ConfigurationBuilder bulider = new ConfigurationBuilder();
            bulider.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(config);
            IConfigurationRoot configuration = bulider.Build();
            configuration.Bind(new SSHConfig());

            sftp = new SftpClient(SSHConfig.Host, 22, SSHConfig.User, SSHConfig.PassWord);
        }
        #endregion

        #region 连接SFTP
        /// <summary>
        /// 连接SFTP
        /// </summary>
        /// <returns>true成功</returns>
        public bool Connect()
        {
            try
            {
                if (!Connected)
                {
                    sftp.Connect();
                }
                return true;
            }
            catch (Exception ex)
            {
                // TxtLog.WriteTxt(CommonMethod.GetProgramName(), string.Format("连接SFTP失败，原因：{0}", ex.Message));
                throw new Exception(string.Format("连接SFTP失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 断开SFTP
        /// <summary>
        /// 断开SFTP
        /// </summary> 
        public void Disconnect()
        {
            try
            {
                if (sftp != null && Connected)
                {
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            {
                // TxtLog.WriteTxt(CommonMethod.GetProgramName(), string.Format("断开SFTP失败，原因：{0}", ex.Message));
                throw new Exception(string.Format("断开SFTP失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region SFTP上传文件
        /// <summary>
        /// SFTP上传文件
        /// </summary>
        /// <param name="localPath">本地路径</param>
        /// <param name="remotePath">远程路径</param>
        public void Put(string localPath, string remotePath, string fileName)
        {
            try
            {
                using (var file = File.OpenRead(localPath))
                {
                    Connect();
                    //判断路径是否存在
                    if (!sftp.Exists(remotePath))
                    {
                        CreateDirectory(remotePath);
                    }
                    sftp.UploadFile(file, remotePath + fileName);
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SFTP文件上传失败，原因：{0}", ex.Message));
            }
        }

        /// <summary>
        /// SFTP上传文件
        /// </summary>
        /// <param name="File">本地路径</param>
        /// <param name="remotePath">远程路径</param>
        public void Put(string filePath, string remotePath)
        {
            try
            {
                using (var file = File.OpenRead(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    Connect();
                    //判断路径是否存在
                    if (!sftp.Exists(remotePath))
                    {
                        CreateDirectory(remotePath);
                    }
                    sftp.UploadFile(file, remotePath + fileInfo.Name);
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SFTP文件上传失败，原因：{0}", ex.Message));
            }
        }

        #endregion

        #region SFTP获取文件
        /// <summary>
        /// SFTP获取文件
        /// </summary>
        /// <param name="remotePath">远程路径</param>
        /// <param name="localPath">本地路径</param>
        public void Get(string remotePath, string localPath)
        {
            try
            {
                Connect();
                var byt = sftp.ReadAllBytes(remotePath);
                Disconnect();
                File.WriteAllBytes(localPath, byt);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SFTP文件获取失败，原因：{0}", ex.Message));
            }

        }
        #endregion

        #region 获取SFTP文件列表
        /// <summary>
        /// 获取SFTP文件列表
        /// </summary>
        /// <param name="remotePath">远程目录</param>
        /// <param name="fileSuffix">文件后缀</param>
        /// <returns></returns>
        public ArrayList GetFileList(string remotePath, string fileSuffix)
        {
            try
            {
                Connect();
                var files = sftp.ListDirectory(remotePath);
                Disconnect();
                var objList = new ArrayList();
                foreach (var file in files)
                {
                    string name = file.Name;
                    if (name.Length > (fileSuffix.Length + 1) && fileSuffix == name.Substring(name.Length - fileSuffix.Length))
                    {
                        objList.Add(name);
                    }
                }
                return objList;
            }
            catch (Exception ex)
            {
                // TxtLog.WriteTxt(CommonMethod.GetProgramName(), string.Format("SFTP文件列表获取失败，原因：{0}", ex.Message));
                throw new Exception(string.Format("SFTP文件列表获取失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 移动SFTP文件
        /// <summary>
        /// 移动SFTP文件
        /// </summary>
        /// <param name="oldRemotePath">旧远程路径</param>
        /// <param name="newRemotePath">新远程路径</param>
        public void Move(string oldRemotePath, string newRemotePath)
        {
            try
            {
                Connect();
                sftp.RenameFile(oldRemotePath, newRemotePath);
                Disconnect();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SFTP文件移动失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 删除SFTP文件
        public void Delete(string remoteFile)
        {
            try
            {
                Connect();
                sftp.Delete(remoteFile);
                Disconnect();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SFTP文件删除失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 创建目录
        /// <summary>
        /// 循环创建目录
        /// </summary>
        /// <param name="remotePath">远程目录</param>
        private void CreateDirectory(string remotePath)
        {
            try
            {
                string[] paths = remotePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string curPath = "/";
                for (int i = 0; i < paths.Length; i++)
                {
                    curPath += paths[i];
                    if (!sftp.Exists(curPath))
                    {
                        sftp.CreateDirectory(curPath);
                    }
                    if (i < paths.Length - 1)
                    {
                        curPath += "/";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("创建目录失败，原因：{0}", ex.Message));
            }
        }
        #endregion
    }
}
