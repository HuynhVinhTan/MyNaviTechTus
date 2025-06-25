namespace Demo {
    public class QueueViaStacks {
        private Stack<int> inStack = new Stack<int>();
        private Stack<int> outStack = new Stack<int>();

        public void Enqueue(int value) => inStack.Push(value);

        public int Dequeue() {
            ShiftStacks();
            return outStack.Pop();
        }

        private void ShiftStacks() {
            if (outStack.Count == 0)
                while (inStack.Count > 0)
                    outStack.Push(inStack.Pop());
        }
    }
}