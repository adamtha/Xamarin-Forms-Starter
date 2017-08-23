using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Helpers
{
    public class ByteStringHelper
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
    }
}
