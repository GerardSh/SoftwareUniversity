namespace GenericScale
{
    public class EqualityScale<T>
        where T : struct
    {
        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        T left;

        T right;

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}