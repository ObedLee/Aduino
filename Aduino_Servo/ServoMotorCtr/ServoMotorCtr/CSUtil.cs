using System;
using System.Text;

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

        public static byte[] Str16ToByte(string data)
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

        public static byte[] StrToByte(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);

            return bytes;

        }

    }
}
