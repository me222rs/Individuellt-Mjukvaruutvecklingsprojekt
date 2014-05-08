using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace WebbsidaFotograf.Pages.AdminPages
{
    public class Utility
    {
        public static string GetString(byte[] value) 
        {
            var convertedByte = System.Text.Encoding.Default.GetString(value);
            return convertedByte; 
        }
        public static byte[] GetBytes(string str) 
        {
            //var convertedString = System.Text.Encoding.Default.GetBytes(value);
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}