
public class PoisonTest
{
    public static bool[] GetPositiveStrips(int poisonedBottleId, int numStrips)
    {
        bool[] positiveStrips = new bool[numStrips];
        for (int i = 0; i < numStrips; i++)
        {
            // Kiểm tra bit thứ i của poisonedBottleId (tính từ phải sang trái, LSB là bit 0)
            // Nếu bit thứ i là 1, que thử i sẽ dương tính.
            if (((poisonedBottleId >> i) & 1) == 1)
            {
                positiveStrips[i] = true;
            }
            else
            {
                positiveStrips[i] = false;
            }
        }
        return positiveStrips;
    }

    public static int DecodePoisonedBottle(bool[] positiveStrips)
    {
        int identifiedPoisonedBottleId = 0;
        for (int i = 0; i < positiveStrips.Length; i++)
        {
            if (positiveStrips[i]) // Nếu que thử i dương tính
            {
                identifiedPoisonedBottleId |= (1 << i); // Đặt bit thứ i của ID thành 1
            }
        }
        return identifiedPoisonedBottleId;
    }
    public static void RunSimulation(int numBottles, int numTestStrips, int actualPoisonedBottleId)
    {
        Console.WriteLine($"--- Bắt đầu mô phỏng bài toán Thuốc Độc ---");
        Console.WriteLine($"Số lượng chai: {numBottles}");
        Console.WriteLine($"Số lượng que thử: {numTestStrips}");
        Console.WriteLine($"Chai bị nhiễm độc thực tế (ID 0-based): {actualPoisonedBottleId}");
        Console.WriteLine();

        // 1. Kiểm tra xem số que thử có đủ không
        int minStripsNeeded = 0;
        if (numBottles > 0) // Tránh Log2(0) hoặc Log2(1) nếu chỉ có 1 chai
        {
             minStripsNeeded = (int)Math.Ceiling(Math.Log2(numBottles));
             if (numBottles == 1) minStripsNeeded = 1; // Cần ít nhất 1 que cho 1 chai (hoặc 0 nếu không cần thử)
        }


        if (numTestStrips < minStripsNeeded && numBottles > 1) // Nếu chỉ có 1 chai thì không cần que thử cũng được.
        {
            Console.WriteLine($"Lỗi: Không đủ que thử. Cần ít nhất {minStripsNeeded} que thử cho {numBottles} chai.");
            Console.WriteLine($"--- Kết thúc mô phỏng ---");
            return;
        }
         if (numBottles == 0)
        {
            Console.WriteLine("Không có chai nào để thử nghiệm.");
            Console.WriteLine($"--- Kết thúc mô phỏng ---");
            return;
        }


        if (actualPoisonedBottleId < 0 || actualPoisonedBottleId >= numBottles)
        {
            Console.WriteLine($"Lỗi: ID chai nhiễm độc ({actualPoisonedBottleId}) không hợp lệ. ID phải từ 0 đến {numBottles - 1}.");
            Console.WriteLine($"--- Kết thúc mô phỏng ---");
            return;
        }

        Console.WriteLine("Ngày 1: Bắt đầu tiến hành 1 lần xét nghiệm duy nhất.");
        Console.WriteLine("Kế hoạch thử nghiệm (chai nào vào que thử nào dựa trên mã nhị phân của ID chai):");
        Console.WriteLine("(Giả sử que thử 0 tương ứng với bit có trọng số thấp nhất - LSB)");

        // Minh họa cách một vài chai đầu tiên được gán vào các que thử
        for(int bottleId = 0; bottleId < Math.Min(numBottles, 5); bottleId++)
        {
            Console.Write($"  Chai {bottleId} (nhị phân {Convert.ToString(bottleId, 2).PadLeft(numTestStrips == 0 ? 1 : numTestStrips, '0')}): đặt vào que thử ");
            List<int> stripsForThisBottle = new List<int>();
            for(int stripIndex = 0; stripIndex < numTestStrips; stripIndex++)
            {
                if(((bottleId >> stripIndex) & 1) == 1) // Nếu bit thứ stripIndex của bottleId là 1
                {
                    stripsForThisBottle.Add(stripIndex);
                }
            }
            if (stripsForThisBottle.Any())
            {
                Console.WriteLine(string.Join(", ", stripsForThisBottle) + ".");
            }
            else
            {
                Console.WriteLine("không đặt vào que nào (nếu ID là 0 và có que thử).");
            }
        }
        if (numBottles > 5) Console.WriteLine("  ... và tương tự cho các chai khác.");
        Console.WriteLine();

        Console.WriteLine("Tiến hành nhỏ dung dịch từ các chai vào các que thử theo kế hoạch...");
        Console.WriteLine("Chờ 7 ngày để có kết quả...");
        Console.WriteLine();

        // Sau 7 ngày:
        // 2. Mô phỏng kết quả que thử dựa trên chai bị nhiễm độc thực tế
        bool[] stripResults = GetPositiveStrips(actualPoisonedBottleId, numTestStrips);

        Console.WriteLine("Sau 7 ngày, đọc kết quả từ các que thử:");
        for (int i = 0; i < numTestStrips; i++)
        {
            Console.WriteLine($"  Que thử {i}: {(stripResults[i] ? "Dương tính (+)" : "Âm tính (-)")}");
        }
        Console.WriteLine();

        // 3. Giải mã kết quả từ que thử để tìm ra chai bị nhiễm độc
        int identifiedPoisonedBottleId = DecodePoisonedBottle(stripResults);
        Console.WriteLine($"Chai được xác định là nhiễm độc (ID 0-based): {identifiedPoisonedBottleId}");

        // 4. Kiểm tra kết quả mô phỏng
        if (identifiedPoisonedBottleId == actualPoisonedBottleId)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("KẾT QUẢ MÔ PHỎNG: Chính xác! Chai nhiễm độc đã được tìm thấy.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("KẾT QUẢ MÔ PHỎNG: Sai! Có lỗi trong logic hoặc mô phỏng.");
            Console.ResetColor();
        }
        Console.WriteLine();
        Console.WriteLine($"Tổng cộng mất 7 ngày để có kết quả cuối cùng sau khi bắt đầu lần xét nghiệm duy nhất.");
        Console.WriteLine($"--- Kết thúc mô phỏng ---");
    }
}