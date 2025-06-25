namespace Demo {
    public class StackMin {
        private class StackNode {
            public int Data { get; set; }
            public StackNode? Next { get; set; }
            
            public StackNode(int data) {
                Data = data;
            }
        }

        private StackNode? top;
        private StackNode? minTop;
        private int count = 0;

        public void Push(int value) {
            StackNode node = new StackNode(value);
            node.Next = top;
            top = node;

            
            if (minTop == null || value <= minTop.Data) {
                StackNode minNode = new StackNode(value);
                minNode.Next = minTop;
                minTop = minNode;
            }
            count++;
        }

        public int Pop() {
            if (top == null)
                throw new InvalidOperationException("Stack is empty");

            int value = top.Data;
            top = top.Next;

        
            if (value == minTop?.Data) {
                minTop = minTop.Next;
            }
            count--;
            return value;
        }

        public int Peek() {
            if (top == null)
                throw new InvalidOperationException("Stack is empty");
            return top.Data;
        }

        public int Min() {
            if (minTop == null)
                throw new InvalidOperationException("Stack is empty");
            return minTop.Data;
        }

        public int Count => count;
        public bool IsEmpty => top == null;
    }
}
