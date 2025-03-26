namespace CinemaApp.Data.Utilities.Interfaces
{
    public interface IXmlHelper
    {
        T? Deserialize<T>(string inputXml, string rootName)
            where T : class;

        T? Deserialize<T>(Stream inputXmlStream, string rootName)
            where T : class;

        string Serialize<T>(T obj, string rootName, Dictionary<string, string>? namespaces = null);

        void Serialize<T>(T obj, string rootName, Stream outputStream, Dictionary<string, string>? namespaces = null);
    }
}
