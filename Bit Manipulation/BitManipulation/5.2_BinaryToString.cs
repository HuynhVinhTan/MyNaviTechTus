// BitManipulation/5.2_BinaryToString.cs
using System.Text;
using System;

namespace BitManipulation
{
    /// <summary>
    /// 5.2 - Chuyển số thực trong khoảng (0,1) sang dạng nhị phân
    /// Ví dụ: 0.625 → 0.101
    /// Nếu không thể biểu diễn chính xác trong 32 bit → trả về "ERROR"
    /// </summary>
    public class BinaryToString
    {
        private const int MAX_BITS = 32;
        private const double EPSILON = 1e-15;  // độ chính xác cho phép

        public string Execute(double num)
        {
            // 1. Kiểm tra giới hạn đầu vào
            if (num <= 0 || num >= 1)
                return "ERROR";

            // 2. Chuyển đổi sang nhị phân
            var sb = new StringBuilder("0.");
            double frac = num;
            
            while (frac > 0)
            {
                // Kiểm tra độ dài
                if (sb.Length > MAX_BITS + 2)  // +2 cho "0."
                    return "ERROR";

                // Nhân 2 và kiểm tra phần nguyên
                frac *= 2;
                if (frac >= 1)
                {
                    sb.Append('1');
                    frac -= 1;
                }
                else
                {
                    sb.Append('0');
                }

                // Dừng nếu đã chính xác
                if (Math.Abs(frac) < EPSILON)
                    break;
            }

            return sb.ToString();
        }
    }
}
