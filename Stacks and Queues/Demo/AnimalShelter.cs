using System;

namespace Demo {
    public abstract class Animal {
        public required string Name { get; set; }
        public int Order { get; set; }
        public abstract string Type { get; }
    }

    public class Dog : Animal {
        public override string Type => "dog";
    }

    public class Cat : Animal {
        public override string Type => "cat";
    }

    public class AnimalShelter {
        private int order = 0; 

        private class AnimalQueue {
            private class QueueNode {
                public Animal Data { get; set; }
                public QueueNode? Next { get; set; }

                public QueueNode(Animal data) {
                    Data = data;
                }
            }

            private QueueNode? first;
            private QueueNode? last;

            public void Enqueue(Animal animal) {
                QueueNode node = new QueueNode(animal);
                if (last != null) {
                    last.Next = node;
                }
                last = node;
                if (first == null) {
                    first = last;
                }
            }

            public Animal Dequeue() {
                if (first == null)
                    throw new InvalidOperationException("Hàng đợi đang trống");

                Animal data = first.Data;
                first = first.Next;
                if (first == null) {
                    last = null;
                }
                return data;
            }

            public Animal Peek() {
                if (first == null)
                    throw new InvalidOperationException("Hàng đợi đang trống");
                return first.Data;
            }

            public bool IsEmpty() => first == null;
        }

        private readonly AnimalQueue dogs = new AnimalQueue();
        private readonly AnimalQueue cats = new AnimalQueue();

        public void Enqueue(string name) {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Tên động vật không được để trống");

            Animal animal;
            if (name.StartsWith("Chó", StringComparison.OrdinalIgnoreCase)) {
                animal = new Dog { Name = name };
            } else if (name.StartsWith("Mèo", StringComparison.OrdinalIgnoreCase)) {
                animal = new Cat { Name = name };
            } else {
                throw new ArgumentException("Tên động vật phải bắt đầu bằng 'Chó' hoặc 'Mèo'", nameof(name));
            }

            animal.Order = order++; 
            if (animal is Dog) dogs.Enqueue(animal);
            else cats.Enqueue(animal);
        }

        public Animal DequeueAny() {
            if (dogs.IsEmpty() && cats.IsEmpty())
                throw new InvalidOperationException("Không còn động vật nào trong trại");

            if (dogs.IsEmpty()) return cats.Dequeue();
            if (cats.IsEmpty()) return dogs.Dequeue();

            return (dogs.Peek().Order < cats.Peek().Order) ? dogs.Dequeue() : cats.Dequeue();
        }

        public Dog DequeueDog() {
            if (dogs.IsEmpty())
                throw new InvalidOperationException("Không còn chó nào trong trại");
            return (Dog)dogs.Dequeue();
        }

        public Cat DequeueCat() {
            if (cats.IsEmpty())
                throw new InvalidOperationException("Không còn mèo nào trong trại");
            return (Cat)cats.Dequeue();
        }
    }

}
