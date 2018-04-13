using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GeradorDeTestes.Infra.XML
{
    static class XMLExtension
    {
        /// <summary>
        /// Gera uma string serializada em xml de qualquer objeto não estático.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>String in XML format</returns>
        public static string Serialize<T>(this IList<T> obj)
        {
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Converte uma string em xml para objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this string obj)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(obj)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
