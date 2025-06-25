using System;

public class Program
{
    public static void Main(string[] args)
    {
        int numBottles = 1000;
        int numTestStrips = 10;

        // Chọn một chai ngẫu nhiên để làm chai độc (ID 0-based)
        Random random = new Random();
        int actualPoisonedBottleId = random.Next(0, numBottles);

        // Hoặc bạn có thể chọn một ID cụ thể để kiểm tra:
        // int actualPoisonedBottleId = 0;    // Nhị phân ...0000000000
        // int actualPoisonedBottleId = 5;    // Nhị phân ...0000000101 (Que 0 và 2 dương tính)
        // int actualPoisonedBottleId = 999;  // Nhị phân ...1111100111

        PoisonTest.RunSimulation(numBottles, numTestStrips, actualPoisonedBottleId);

        Console.WriteLine("\n--------------------------------------------\n");

        // Thử một ví dụ khác nhỏ hơn
        Console.WriteLine("Thử nghiệm với số lượng chai và que thử ít hơn:");
        PoisonTest.RunSimulation(numBottles: 1000, numTestStrips: 10, actualPoisonedBottleId: 13);
        // 13 trong hệ nhị phân 4-bit là 1101.
        // Que thử 0 (bit 0 = 1), Que thử 2 (bit 2 = 1), Que thử 3 (bit 3 = 1) sẽ dương tính.

    }
}