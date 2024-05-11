namespace GenericScale
{
    public class EqualityScale<T>
        where T : struct
    {
        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        internal T Left { get; set; }

        internal T Right { get; set; }

        public bool AreEqual()
        {
            return Left.Equals(Right);
        }
    }
}
