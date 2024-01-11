using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model.Utils
{
    internal class PasswordGenerator
    {
        public static string GenerateSimplePassword(int length = 8)
        {
            length = Math.Max(length, 8);

            char[] allowedLower = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] allowedDigits = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] allowedUpper = allowedLower.Select(x => char.ToUpper(x)).ToArray();

            Random random = new Random();
            string generatedCode = "";
            generatedCode += allowedLower[random.Next(0, allowedLower.Length)];
            generatedCode += allowedDigits[random.Next(0, allowedDigits.Length)];
            generatedCode += allowedUpper[random.Next(0, allowedUpper.Length)];
            char[][] arrays = new[] { allowedLower, allowedUpper, allowedDigits };
            for (int i = 0; i < length - 3; i++)
            {
                char[] array = arrays[random.Next(0, arrays.Length)];
                generatedCode += array[random.Next(0, array.Length)];
            }
            return String.Join("", generatedCode.OrderBy(x => random.Next()));
        }
    }
}
