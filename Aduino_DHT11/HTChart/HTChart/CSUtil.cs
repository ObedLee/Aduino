using System;

namespace CSUtil
{
    public static class CSUtil
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static byte[] Str2Hex(string data)
        {
            string str = data.Replace(" ", string.Empty);

            if (str.Length % 2 == 0)
            {
                int hexLen = str.Length / 2;
                byte[] hex = new byte[hexLen];

                for (int i = 0; i < hexLen; i++)
                {
                    hex[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                }

                
                return hex;
            }
            else
            {
                return null;
            }

        }
    }
}
