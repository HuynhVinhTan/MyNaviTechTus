using System;
using System.Globalization;
using BitManipulation;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Bài tập xử lý bit ===");
            Console.WriteLine("1. Bài 5.1: Chèn M vào N (ví dụ: N=10000000000, M=10011)");
            Console.WriteLine("2. Bài 5.2: Chuyển số thập phân sang nhị phân (ví dụ: 0.625)");
            Console.WriteLine("3. Bài 5.3: Tìm chuỗi bit 1 dài nhất (ví dụ: 1775 = 11011101111)");
            Console.WriteLine("4. Bài 5.4: Tìm số lớn hơn và nhỏ hơn (ví dụ: 13948)");
            Console.WriteLine("5. Bài 5.5: Kiểm tra lũy thừa của 2 (ví dụ: 16 = 10000)");
            Console.WriteLine("6. Bài 5.6: Đếm số bit cần đổi (ví dụ: A=29, B=15)");
            Console.WriteLine("7. Bài 5.7: Đổi bit chẵn lẻ (ví dụ: 10110110)");
            Console.WriteLine("8. Bài 5.8: Vẽ đường thẳng (ví dụ: width=32, x1=3, x2=29, y=1)");
            Console.WriteLine("0. Thoát");
            Console.Write("\nChọn bài (0-8): ");

            try
            {
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 8)
                {
                    Console.WriteLine("⚠ Vui lòng nhập số từ 0-8!");
                    continue;
                }

                switch (choice)
                {
                    case 0: return;
                    case 1: RunInsertBits();          break;
                    case 2: RunBinaryToString();      break;
                    case 3: RunFlipBitToWin();        break;
                    case 4: RunNextNumber();          break;
                    case 5: RunPowerOfTwo();          break;
                    case 6: RunBitSwapsRequired();    break;
                    case 7: RunSwapOddEvenBits();     break;
                    case 8: RunDrawLine();            break;
                }

                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n⚠ Lỗi: {ex.Message}");
                Console.WriteLine("Nhấn Enter để thử lại...");
                Console.ReadLine();
            }
        }
    }

/* -------------------- BÀI 5.1 -------------------- */
private static void RunInsertBits()
{
    Console.WriteLine("\n=== Bài 5.1: Chèn M vào N ===");

    try
    {
        // 1. Nhập N
        Console.Write("Nhập N (chuỗi nhị phân, ví dụ 10000000000): ");
        string nBin = Console.ReadLine()?.Trim() ?? "";
        if (!IsBinary(nBin))  throw new FormatException("N phải là chuỗi nhị phân hợp lệ.");
        int n = Convert.ToInt32(nBin, 2);

        // 2. Nhập M
        Console.Write("Nhập M (chuỗi nhị phân, ví dụ 10011): ");
        string mBin = Console.ReadLine()?.Trim() ?? "";
        if (!IsBinary(mBin)) throw new FormatException("M phải là chuỗi nhị phân hợp lệ.");
        int m = Convert.ToInt32(mBin, 2);

        // 3. Nhập i và j
        Console.Write("Nhập i (bit thấp nhất): ");
        int i = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhập j (bit cao nhất): ");
        int j = int.Parse(Console.ReadLine() ?? "0");

        // 4. Thực thi
        int result = new InsertBits().Execute(n, m, i, j);

        // 5. In kết quả
        Console.WriteLine($"\nN  = {ToBin(n)}");
        Console.WriteLine($"M  = {ToBin(m)}");
        Console.WriteLine($"i  = {i}, j = {j}");
        Console.WriteLine($"→ Kết quả: {ToBin(result)}  (số thập phân: {result})");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Lỗi: {ex.Message}");
    }

    /* helpers */
    static bool IsBinary(string s) => s.Length > 0 && s.TrimEnd('0', '1') == "";
    static string ToBin(int v) => Convert.ToString(v, 2);
}

   /* -------------------- BÀI 5.2 -------------------- */
    private static void RunBinaryToString()
    {
        Console.WriteLine("\n=== Bài 5.2: Chuyển số thập phân (0-1) sang nhị phân ===");
        Console.Write("Nhập số (0.25 hoặc 0,25): ");
        string raw = Console.ReadLine()?.Trim() ?? "";
        string norm = raw.Replace(',', '.');
        if (!double.TryParse(norm, NumberStyles.Float, CultureInfo.InvariantCulture, out double num))
        {
            Console.WriteLine("⚠ Giá trị không hợp lệ!");
            return;
        }
        string bin = new BinaryToString().Execute(num);
        Console.WriteLine($"Bạn nhập  : {raw}");
        Console.WriteLine($"Đã hiểu là: {num.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Kết quả   : {bin}");
    }

    /* -------------------- BÀI 5.3 -------------------- */
    private static void RunFlipBitToWin()
    {
        Console.WriteLine("\n=== Bài 5.3: Tìm chuỗi bit 1 dài nhất ===");
        try
        {
            Console.Write("Nhập số nguyên: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            var algo = new FlipBitToWin();
            Console.WriteLine($"Chuỗi 1 dài nhất: {algo.Execute(n)}");
        }
        catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
    }

    /* -------------------- BÀI 5.4 -------------------- */
    private static void RunNextNumber()
    {
        Console.WriteLine("\n=== Bài 5.4: Số lớn hơn & nhỏ hơn ===");
        try
        {
            Console.Write("Nhập số nguyên dương: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            var nextNumber = new NextNumber();
            int next = nextNumber.GetNext(n);
            int prev = nextNumber.GetPrev(n);
            Console.WriteLine($"Số lớn hơn : {(next == -1 ? "Không tồn tại" : next)}");
            Console.WriteLine($"Số nhỏ hơn : {(prev == -1 ? "Không tồn tại" : prev)}");
        }
        catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
    }

    /* -------------------- BÀI 5.5 -------------------- */
    private static void RunPowerOfTwo()
    {
        Console.WriteLine("\n=== Bài 5.5: Kiểm tra lũy thừa của 2 ===");
        try
        {
            Console.Write("Nhập số nguyên: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine(n != 0 && (n & (n - 1)) == 0
                ? "ĐÚNG: là lũy thừa của 2"
                : "KHÔNG: không phải lũy thừa của 2");
        }
        catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
    }

    /* -------------------- BÀI 5.6 -------------------- */
    private static void RunBitSwapsRequired()
    {
        Console.WriteLine("\n=== Bài 5.6: Đếm số bit cần đổi ===");
        try
        {
            Console.Write("Nhập A: ");
            int a = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập B: ");
            int b = int.Parse(Console.ReadLine() ?? "0");
            var bs = new BitSwapsRequired();
            Console.WriteLine($"Số bit khác nhau: {bs.Execute(a, b)}");
        }
        catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
    }

    /* -------------------- BÀI 5.7 -------------------- */
    private static void RunSwapOddEvenBits()
    {
        Console.WriteLine("\n=== Bài 5.7: Đổi bit chẵn lẻ ===");
        try
        {
            Console.Write("Nhập số nguyên: ");
            int x = int.Parse(Console.ReadLine() ?? "0");
            var swap = new SwapOddEvenBits();
            Console.WriteLine($"Kết quả: {swap.Execute(x)}");
        }
        catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
    }

    /* -------------------- BÀI 5.8 -------------------- */
    private static void RunDrawLine()
    {
        Console.WriteLine("\n=== Bài 5.8: Vẽ đường thẳng ===");
        try
        {
            Console.Write("Chiều rộng (chia hết cho 8): ");
            int width = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Chiều cao: ");
            int height = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("x1: "); int x1 = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("x2: "); int x2 = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("y : "); int y  = int.Parse(Console.ReadLine() ?? "0");

            byte[] screen = new byte[width * height / 8];
            new DrawLine().Execute(screen, width, x1, x2, y);

            Console.WriteLine("\n(1 = pixel sáng, 0 = pixel tối)");
            for (int row = 0; row < height; row++)
            {
                for (int colByte = 0; colByte < width / 8; colByte++)
                {
                    string bits = Convert.ToString(screen[row * (width / 8) + colByte], 2)
                                      .PadLeft(8, '0');
                    Console.Write(bits + " ");
                }
                Console.WriteLine();
            }
        }
        catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
    }
}