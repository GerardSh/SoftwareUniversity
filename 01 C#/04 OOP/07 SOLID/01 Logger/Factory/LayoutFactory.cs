using SOLID.Layouts;

namespace SOLID.Factory
{
    public class LayoutFactory
    {
        public ILayout Create(string layoutType)
        {
            ILayout layout = null;

            if (layoutType == nameof(SimpleLayout))
            {
                layout = new SimpleLayout();
            }
            else if (layoutType == nameof(XmlLayout))
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new ArgumentException();
            }

            return layout;
        }
    }
}
