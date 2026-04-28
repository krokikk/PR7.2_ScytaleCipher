using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7._2_ScytaleCipher
{
    public static class ScytaleCipher
    {
        public static string Encrypt(string input, int diameter)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (diameter <= 0)
                throw new ArgumentException("Диаметр должен быть > 0");

            if (input.Length == 0)
                return string.Empty;

            int rows = diameter;
            int cols = (int)Math.Ceiling((double)input.Length / rows);

            var result = new StringBuilder();

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    int index = i * cols + j;

                    if (index < input.Length)
                        result.Append(input[index]);
                }
            }

            return result.ToString();
        }


        public static string Decrypt(string input, int diameter)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (diameter <= 0)
                throw new ArgumentException("Диаметр должен быть > 0");

            if (input.Length == 0)
                return string.Empty;

            int rows = diameter;
            int cols = (int)Math.Ceiling((double)input.Length / rows);

            char[] result = new char[input.Length];

            int index = 0;

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    int pos = i * cols + j;

                    if (pos < input.Length)
                    {
                        result[pos] = input[index++];
                    }
                }
            }

            return new string(result);
        }
    }
}
