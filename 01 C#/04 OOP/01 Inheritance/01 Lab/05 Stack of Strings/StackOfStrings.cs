namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => Count == 0;

        public void AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }
    }
}
