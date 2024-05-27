namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => Count == 0;

        public void AddRange(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                Push(item);
            }
        }
    }
}
