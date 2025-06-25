using System;
using System.Collections.Generic;

namespace Demo {
    class Program {
        static void Main() {
            while (true) {
                Console.WriteLine("\nSelect a problem to run:");
                Console.WriteLine("1. Three in One");
                Console.WriteLine("2. Stack Min");
                Console.WriteLine("3. Stack of Plates");
                Console.WriteLine("4. Queue via Stacks");
                Console.WriteLine("5. Sort Stack");
                Console.WriteLine("6. Animal Shelter");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");
                string? input = Console.ReadLine();

                switch (input) {
                    case "1": RunThreeInOne(); break;
                    case "2": RunStackMin(); break;
                    case "3": RunStackOfPlates(); break;
                    case "4": RunQueueViaStacks(); break;
                    case "5": RunSortStack(); break;
                    case "6": RunAnimalShelter(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        static void RunThreeInOne() {
            Console.WriteLine("\n=== Three in One Stack ===");
            var stacks = new ThreeInone();
            Console.WriteLine("Pushing values:");
            Console.WriteLine("Stack 0: Push(10), Push(11)");
            Console.WriteLine("Stack 1: Push(20), Push(23)");
            Console.WriteLine("Stack 2: Push(30), Push(35)");
            
            stacks.Push(0, 10);
            stacks.Push(1, 20);
            stacks.Push(1, 23);
            stacks.Push(2, 30);
            stacks.Push(2,35);
            stacks.Push(0, 11);
            
            Console.WriteLine("\nResults:");
            Console.WriteLine("Pop stack 0 → " + stacks.Pop(0));
            Console.WriteLine("Peek stack 1 → " + stacks.Peek(1));
            Console.WriteLine("Peek stack 2 → " + stacks.Peek(2));
        }

        static void RunStackMin() {
            Console.WriteLine("\n=== Stack Min ===");
            var stack = new StackMin();
            Console.WriteLine("Pushing values: 2, 10, 5, 3, 7, 1");
            
            stack.Push(2);
            stack.Push(10);
            stack.Push(5);
            stack.Push(3);
            stack.Push(7);
            stack.Push(1);
            
            Console.WriteLine("\nResults:");
            Console.WriteLine("Min value: " + stack.Min());
            Console.WriteLine("Pop → " + stack.Pop());
            Console.WriteLine("Min value after pop: " + stack.Min());
        }

        static void RunStackOfPlates() {
            Console.WriteLine("\n=== Stack of Plates ===");
            var plates = new Stackofplates(3);
            Console.WriteLine("Threshold per stack: 3"); // nguong toi da moi stack la 3 phan tu 
            Console.WriteLine("Pushing values: 0 to 9");
            
            for (int i = 0; i < 10; i++) {
                plates.Push(i);
            }
            
            Console.WriteLine("\nResults:");
            Console.WriteLine("Pop → " + plates.Pop()); 
            Console.WriteLine("PopAt(0) → " + plates.PopAt(0)); //Pop một phần tử từ stack số 0, pop ra 2 
            Console.WriteLine("PopAt(1) → " + plates.PopAt(1));
        }

        static void RunQueueViaStacks() {
            Console.WriteLine("\n=== Queue via Stacks ===");
            var queue = new QueueViaStacks();
            Console.WriteLine("Enqueue values: 1, 2, 3");
            
            queue.Enqueue(1); //day truc tiep 1,2,3 vao stack in
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            Console.WriteLine("\nResults:");
            Console.WriteLine("Dequeue → " + queue.Dequeue()); //rong thi pop tat ca tu in sang out
            Console.WriteLine("Dequeue → " + queue.Dequeue());
            Console.WriteLine("Dequeue → " + queue.Dequeue());
        }

        static void RunSortStack() {
            Console.WriteLine("\n=== Sort Stack ===");
            var stack = new SortStack();
            Console.WriteLine("Pushing values: 5, 3, 7");
            
            stack.Push(5);
            stack.Push(3);
            stack.Push(7);
            
            Console.WriteLine("\nBefore sorting:");
            Console.WriteLine("Top value: " + stack.Peek());
            
            stack.Sort();
            
            Console.WriteLine("\nAfter sorting:");
            Console.WriteLine("Top value: " + stack.Peek());
            Console.WriteLine("Pop → " + stack.Pop());
            Console.WriteLine("Pop → " + stack.Pop());
            Console.WriteLine("Pop → " + stack.Pop());
        }

        static void RunAnimalShelter() {
            Console.WriteLine("\n=== Animal Shelter ===");
            var shelter = new AnimalShelter();
            Console.WriteLine("Thêm động vật vào trại:Chó Poodle, Mèo Siamese, Chó Corgi, Mèo Ragdoll");
            
            shelter.Enqueue("Chó Poodle"); 
            shelter.Enqueue("Mèo Siamese");
            shelter.Enqueue("Chó Corgi");
            shelter.Enqueue("Mèo Ragdoll");
            
            Console.WriteLine("\nKết quả:");
            Console.WriteLine("Lấy con vật đến sớm nhất → " + shelter.DequeueAny().Name);
            Console.WriteLine("Lấy chó đến sớm nhất → " + shelter.DequeueDog().Name);
            Console.WriteLine("Lấy mèo đến sớm nhất → " + shelter.DequeueCat().Name);
        }
    }
}