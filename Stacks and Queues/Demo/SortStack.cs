namespace Demo {
    public class SortStack {
        private Stack<int> stack = new Stack<int>();

        public void Push(int value) {
            stack.Push(value);
        }

        public int Pop() {
            return stack.Pop();
        }

        public int Peek() {
            return stack.Peek();
        }

        public void Sort() {
            Stack<int> temp = new Stack<int>();
            while (stack.Count > 0) {
                int val = stack.Pop();
                while (temp.Count > 0 && temp.Peek() > val)
                    stack.Push(temp.Pop());
                temp.Push(val);
            }
            while (temp.Count > 0)
                stack.Push(temp.Pop());
        }
    }

    // // static void RunSortStack() {
    //     var stack = new Stack<int>();
    //     stack.Push(3); stack.Push(1); stack.Push(4); stack.Push(2);
    //     SortStack(stack);
    //     Console.WriteLine("Sorted Stack: ");
    //     while (stack.Count > 0)
    //         Console.WriteLine(stack.Pop());
    // }
}