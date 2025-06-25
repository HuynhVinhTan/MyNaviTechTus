using System;

namespace BitManipulation
{
    public class InsertBits
    {
        /// <summary>
        /// Chèn M vào N sao cho bit thấp nhất của M nằm ở vị trí i
        /// và bit cao nhất ở vị trí j (i ≤ j).  
        /// </summary>
        /// <remarks>
        /// ▸ Bảo vệ các trường hợp biên (j == 31, i == 0, i > j …)  
        /// ▸ Tận dụng kiểu ulong để tránh tràn / sign-extension rồi ép
        ///     về int ở bước cuối.  
        /// ▸ Mask thêm M để chắc chắn chỉ (j-i+1) bit của M được chèn.  
        /// </remarks>
        public int Execute(int n, int m, int i, int j)
        {
            // 1. Kiểm tra tham số
            if (i < 0 || j > 31 || i > j)
                throw new ArgumentOutOfRangeException(
                    $"Tham số không hợp lệ: i = {i}, j = {j}");

            // 2. Tạo mặt nạ phủ kín vùng [j..i] cần xoá trong N
            //    Dùng ulong để không bị rút gọn khi dịch trái 32 bit.
            ulong allOnes = ~0UL;

            // Nếu j = 31, (j + 1) = 32 – dịch trái 32 bit sẽ trả về 0.
            ulong leftMask  = (j == 31) ? 0UL : (allOnes << (j + 1));
            ulong rightMask =  ((1UL << i) - 1);          // các bit thấp hơn i
            ulong fullMask  = leftMask | rightMask;       // 1 ...1 0...0 1...1

            // 3. Xoá vùng cần chèn trong N
            int nCleared = (int)((ulong)n & fullMask);

            // 4. Cắt M vừa đúng (j-i+1) bit rồi dịch về vị trí i
            int numBits    = j - i + 1;
            int mMasked    = m & ((1 << numBits) - 1);    // giữ lại phần hợp lệ
            int mShifted   = mMasked << i;

            // 5. Gộp kết quả
            return nCleared | mShifted;
        }
    }
}