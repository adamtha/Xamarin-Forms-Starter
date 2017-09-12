using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Helpers
{
    public static class ByteStringHelper
    {
        public static byte[] ToAsciiBytes(string s)
        {
            //return Encoding.UTF8.GetBytes(s);

            var retval = new byte[s.Length];
            for(int i = 0; i < s.Length; ++i)
            {
                var ch = s[i];
                if(ch <= 0x7f)
                {
                    retval[i] = (byte)ch;
                }
                else
                {
                    retval[i] = (byte)'?';
                }
            }
            return retval;
        }

        public static string FromAsciiBytes(IEnumerable<byte> data)
        {
            var sb = new StringBuilder();
            foreach(var @byte in data)
            {
                sb.Append((char)@byte);
            }
            return sb.ToString();
        }

        public static byte[] FromHexString(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for(int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public static string ToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static string ToHexString(byte[] ba, int length)
        {
            return BitConverter.ToString(ba, 0, length).Replace("-", "");
        }

        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
        {
            T[] array = null;
            int count = 0;
            foreach(T item in source)
            {
                if(array == null)
                {
                    array = new T[size];
                }
                array[count] = item;
                count++;
                if(count == size)
                {
                    yield return new ReadOnlyCollection<T>(array);
                    array = null;
                    count = 0;
                }
            }
            if(array != null)
            {
                Array.Resize(ref array, count);
                yield return new ReadOnlyCollection<T>(array);
            }
        }
    }
}
