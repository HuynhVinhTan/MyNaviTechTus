namespace Demo {
    public class Stackofplates {
        private List<Stack<int>> stacks = new List<Stack<int>>();
        private int threshold;

        public Stackofplates(int threshold) {
            this.threshold = threshold;
            stacks.Add(new Stack<int>());
        }

        public void Push(int value) {
            Stack<int> last = stacks[^1];
            if (last.Count >= threshold) {
                last = new Stack<int>();
                stacks.Add(last);
            }
            last.Push(value);
        }

        public int Pop() {
            Stack<int> last = stacks[^1];
            int val = last.Pop();
            if (last.Count == 0 && stacks.Count > 1)
                stacks.RemoveAt(stacks.Count - 1);
            return val;
        }

        public int PopAt(int index) => stacks[index].Pop();
    }
} 