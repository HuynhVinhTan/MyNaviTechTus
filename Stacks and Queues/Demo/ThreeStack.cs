namespace Demo {
    public class ThreeStacks {
        private int stackSize = 100;
        private int[] values = new int[300];
        private int[] pointers = { -1, -1, -1 };

        public void Push(int stackNum, int value) {
            int index = stackNum * stackSize + ++pointers[stackNum];
            values[index] = value;
        }

        public int Pop(int stackNum) {
            int index = stackNum * stackSize + pointers[stackNum]--;
            return values[index];
        }

        public int Peek(int stackNum) {
            return values[stackNum * stackSize + pointers[stackNum]];
        }
    }
}