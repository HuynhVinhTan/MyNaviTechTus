namespace BitManipulation
{
    /// <summary>
    /// 5.7 - Hoán đổi các bit chẵn và lẻ của một số nguyên
    /// 
    /// Cách tiếp cận:
    /// 1. Tạo hai mặt nạ:
    ///    - ODD_MASK  = 0xAAAAAAAA = 10101010...  (các bit lẻ)
    ///    - EVEN_MASK = 0x55555555 = 01010101...  (các bit chẵn)
    /// 
    /// 2. Tách và dịch bit:
    ///    - Lấy các bit chẵn và dịch trái 1 vị trí
    ///    - Lấy các bit lẻ và dịch phải 1 vị trí
    /// 
    /// 3. Kết hợp kết quả bằng phép OR
    /// 
    /// Ví dụ:
    /// x = 10110110
    /// 
    /// Tách bit:
    /// Bit chẵn: 0 1 1 1 = 0111
    /// Bit lẻ:   1 1 0 0 = 1100
    /// 
    /// Dịch bit:
    /// Bit chẵn dịch trái:  01110000
    /// Bit lẻ dịch phải:    00110000
    /// 
    /// Kết quả = 01110000 | 00110000 = 01110110
    /// 
    /// Lưu ý:
    /// - Sử dụng uint để tránh vấn đề với dấu
    /// - Cần ép kiểu về int ở cuối với unchecked
    /// </summary>
    public class SwapOddEvenBits
    {
        // Mặt nạ cho các bit lẻ (1010...)
        private const uint ODD_MASK = 0xAAAAAAAAu;
        
        // Mặt nạ cho các bit chẵn (0101...)
        private const uint EVEN_MASK = 0x55555555u;

        /// <summary>
        /// Hoán đổi các bit chẵn và lẻ của một số nguyên
        /// </summary>
        /// <param name="x">Số nguyên cần hoán đổi bit</param>
        /// <returns>Số nguyên sau khi hoán đổi các bit chẵn lẻ</returns>
        public int Execute(int x)
        {
            // Chuyển sang uint để tránh vấn đề với dấu
            uint ux = (uint)x;

            // Tách và dịch các bit
            uint even = (ux & EVEN_MASK) << 1;  // lấy bit chẵn và dịch trái
            uint odd = (ux & ODD_MASK) >> 1;    // lấy bit lẻ và dịch phải

            // Kết hợp kết quả và ép về int
            return unchecked((int)(even | odd));
        }
    }
}
