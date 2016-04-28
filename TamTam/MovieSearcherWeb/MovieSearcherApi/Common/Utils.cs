using System;
using System.Net;
using System.Xml;

namespace MovieSearcherApi.Common
{
    public static class Utils
    {
        public static XmlDocument RequestXmlFeed(string requestUrl)
        {
            XmlDocument xmlDoc = null;
            try
            {
                var request = WebRequest.Create(requestUrl) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
            }
            catch (Exception e)
            {
                return xmlDoc;
            }
            return xmlDoc;
        }

        public static string GetXmlValue(XmlNode doc,string xPath)
        {
            var node = doc.SelectSingleNode(xPath);
            if (node != null)
            {
                return node.InnerText;
            }
            return string.Empty;
        }
    }
}
