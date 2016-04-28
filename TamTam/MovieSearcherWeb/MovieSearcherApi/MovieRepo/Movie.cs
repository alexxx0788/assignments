using System;
using System.Web.Configuration;
using System.Xml;
using MovieSearcherApi.Common;

namespace MovieSearcherApi.MovieRepo
{
    public abstract class Movie
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public string IdImdb { get; set; }
        public string Year { get; set; }
        public string UrlImdb { get; set; }
        public string Plot { get; set; }
        

        protected Movie(XmlNode xml)
        {
            InitializeFields(xml);
        }

        private void InitializeFields(XmlNode xml)
        {
            var currType = GetType();
            var baseType = currType.BaseType;
            var apiName = currType.Name.Replace(baseType.Name, string.Empty);
            var props = currType.GetProperties();
            foreach (var prop in props)
            {
                var xPath = WebConfigurationManager.AppSettings[String.Format("{0}.item.{1}", apiName, prop.Name)];
                if (!String.IsNullOrEmpty(xPath))
                {
                    var value = Utils.GetXmlValue(xml, xPath);
                    currType.GetProperty(prop.Name).SetValue(this, value, null);
                }
            }
        }
    }
}
