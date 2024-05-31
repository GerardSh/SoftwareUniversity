namespace ClassBoxData
{
    public class Box
    {
        private double width;
        private double height;
        private double length;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;

            private set
            {
                IsValid(value, "Length");
                length = value;
            }
        }

        public double Width
        {
            get => width;

            private set
            {
                IsValid(value, "Width");
                width = value;
            }
        }

        public double Height
        {
            get => height;

            private set
            {
                IsValid(value, "Height");
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Height * Width;
        }

        public double LateralSurfaceArea()
        {
            return 2 * Height * (Length + Width);
        }

        public double Volume()
        {
            return Length * Width * Height;
        }

        void IsValid(double value, string dimension)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{dimension} cannot be zero or negative.");
            }
        }
    }
}
