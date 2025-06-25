using System;

namespace BitManipulation
{
    /// <summary>
    /// 5.8 - Vẽ đường thẳng ngang trên màn hình đơn sắc
    /// 
    /// Màn hình được biểu diễn bằng mảng byte, mỗi pixel là 1 bit
    /// - Chiều rộng (width) phải chia hết cho 8 (1 byte = 8 pixel)
    /// - Vẽ đường thẳng từ (x1,y) đến (x2,y)
    /// 
    /// Cách tiếp cận:
    /// 1. Tính vị trí byte bắt đầu và kết thúc:
    ///    - startByte = x1 / 8
    ///    - endByte = x2 / 8
    /// 
    /// 2. Xử lý các byte ở giữa:
    ///    - Các byte nằm hoàn toàn trong đoạn → set tất cả bit = 1 (0xFF)
    /// 
    /// 3. Xử lý byte đầu/cuối:
    ///    Trường hợp 1: x1 và x2 nằm cùng byte
    ///    - Tạo mask chỉ có bit 1 từ x1 đến x2
    ///    - Áp dụng mask vào byte đó
    /// 
    ///    Trường hợp 2: x1 và x2 nằm khác byte
    ///    - Byte đầu: set bit 1 từ x1 đến hết byte
    ///    - Byte cuối: set bit 1 từ đầu byte đến x2
    /// 
    /// Ví dụ: width = 32, x1 = 3, x2 = 29, y = 1
    /// - Mỗi dòng có 4 byte (32/8)
    /// - Dòng y=1 bắt đầu từ byte thứ 4
    /// - x1=3 nằm ở byte 0 của dòng (3/8)
    /// - x2=29 nằm ở byte 3 của dòng (29/8)
    /// 
    /// Kết quả:
    /// Byte 0: 11111000 (từ bit 3 đến hết)
    /// Byte 1: 11111111 (tất cả)
    /// Byte 2: 11111111 (tất cả)
    /// Byte 3: 11111110 (từ đầu đến bit 29)
    /// </summary>
    public class DrawLine
    {
        /// <summary>
        /// Vẽ đường thẳng ngang từ (x1,y) đến (x2,y)
        /// </summary>
        /// <param name="screen">Mảng byte biểu diễn màn hình</param>
        /// <param name="width">Chiều rộng màn hình (phải chia hết cho 8)</param>
        /// <param name="x1">Toạ độ x bắt đầu</param>
        /// <param name="x2">Toạ độ x kết thúc</param>
        /// <param name="y">Toạ độ y của đường thẳng</param>
        public void Execute(byte[] screen, int width, int x1, int x2, int y)
        {
            // Kiểm tra điều kiện đầu vào
            if (width % 8 != 0)
                throw new ArgumentException("width phải chia hết cho 8");

            // Đảm bảo x1 <= x2
            if (x1 > x2)
                (x1, x2) = (x2, x1);

            // Tính offset của dòng y và vị trí byte bắt đầu/kết thúc
            int bytesPerRow = width / 8;
            int rowOffset = y * bytesPerRow;
            int startByte = x1 / 8;
            int endByte = x2 / 8;

            // Xử lý các byte nằm hoàn toàn trong đoạn
            for (int b = startByte + 1; b < endByte; b++)
                screen[rowOffset + b] = 0xFF;

            // Xử lý byte đầu và cuối
            if (startByte == endByte)
            {
                // x1 và x2 nằm trong cùng một byte
                byte mask = (byte)(0xFF >> (x1 % 8));         // 111... từ x1
                mask &= (byte)(~(0xFF >> ((x2 % 8) + 1)));   // ...111 đến x2
                screen[rowOffset + startByte] |= mask;
            }
            else
            {
                // Byte đầu: set bit 1 từ x1 đến hết byte
                byte startMask = (byte)(0xFF >> (x1 % 8));
                screen[rowOffset + startByte] |= startMask;

                // Byte cuối: set bit 1 từ đầu byte đến x2
                byte endMask = (byte)(~(0xFF >> ((x2 % 8) + 1)));
                screen[rowOffset + endByte] |= endMask;
            }
        }
    }
}
// === Bài 5.8: Vẽ đường thẳng ===
// Chiều rộng (chia hết cho 8): 32
// Chiều cao: 4
// x1: 3
// x2: 29
// y: 1