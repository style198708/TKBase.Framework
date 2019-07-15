using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace TKBase.Framework.Extension
{
    /// <summary>
    /// 对Xml的一些对像扩展
    /// </summary>
    public static class XmlExtentions
    {
        /// <summary>
        /// XDocument转化成String
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static string WriteToString(this XDocument doc)
        {
            StringBuilder v = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(v))
            {
                doc.WriteTo(writer);
                writer.Flush();
            }
            return v.ToString();
        }


        /// <summary>
        /// XElemet转化成String
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string WriteToString(this XElement element)
        {
            StringBuilder v = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(v))
            {
                element.WriteTo(writer);
                writer.Flush();
            }
            return v.ToString();
        }

        /// <summary>
        /// XElement生成报文
        /// </summary>
        /// <param name="element"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static bool WriteToFile(this XElement element, string FileName)
        {
            string xml = element.ToString(SaveOptions.DisableFormatting);
            FileInfo info = new FileInfo(FileName);
            if (!Directory.Exists(info.Directory.FullName))
                Directory.CreateDirectory(info.Directory.FullName);
            if (info.Exists) //删除原来的
                info.Delete();
            using (XmlWriter writer = XmlWriter.Create(FileName))
            {
                element.WriteTo(writer);
                writer.Flush();
            }
            return File.Exists(FileName);
        }

        /// <summary>
        /// XDocument生成报文
        /// </summary>
        /// <param name="element"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static bool WriteToFile(this XDocument doc, string FileName)
        {
            string xml = doc.ToString(SaveOptions.DisableFormatting);
            FileInfo info = new FileInfo(FileName);
            if (!Directory.Exists(info.Directory.FullName))
                Directory.CreateDirectory(info.Directory.FullName);
            if (info.Exists) //删除原来的
                info.Delete();
            using (XmlWriter writer = XmlWriter.Create(FileName))
            {
                doc.WriteTo(writer);
                writer.Flush();
            }
            return File.Exists(FileName);
        }

        /// <summary>
        /// 对XElement赋值的扩展
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        public static void AddElementValue(this XElement ele, string Name, object Value)
        {
            if (ele == null)
                return;
            XElement sele = ele.Element(Name);
            if (sele != null && Value != null)
            {
                sele.Value = Value.ToString();
            }
        }
    }
}
