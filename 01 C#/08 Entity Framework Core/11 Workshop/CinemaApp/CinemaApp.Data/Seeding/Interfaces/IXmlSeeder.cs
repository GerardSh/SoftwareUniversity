using CinemaApp.Data.Utilities.Interfaces;

namespace CinemaApp.Data.Seeding.Interfaces
{
    public interface IXmlSeeder
    {
        public string RootName { get; }

        public IXmlHelper XmlHelper { get; }
    }
}
