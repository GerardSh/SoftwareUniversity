using CarDealer.DTOs.Import;
using System.Xml.Serialization;

namespace CarDealer.Utilities
{
    public class XmlHelper
    {
        public static T? Deserialize<T>(string inputXml, string rootName)
            where T : class
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            var xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader strReader = new StringReader(inputXml);

            object? deserializedObject = xmlSerializer
                .Deserialize(strReader);

            if (deserializedObject == null)
            {
                return null;
            }

            return (T)(deserializedObject);
        }

        public static T? Deserialize<T>(Stream inputXmlStream, string rootName)
            where T : class
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            var xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            object? deserializedObject = xmlSerializer
                .Deserialize(inputXmlStream);

            if (deserializedObject == null)
            {
                return null;
            }

            return (T)(deserializedObject);
        }
    }
}
