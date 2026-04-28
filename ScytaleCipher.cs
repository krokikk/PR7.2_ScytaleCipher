using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7._2_ScytaleCipher
{
    public static class ScytaleCipher
    {
        public static string Encrypt(string text, int diameter)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (diameter <= 0)
                throw new ArgumentException("Диаметр должен быть > 0");

            int rows = (int)Math.Ceiling((double)text.Length / diameter);
            char[,] table = new char[rows, diameter];

            int index = 0;

            // Заполнение по строкам
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < diameter; j++)
                {
                    if (index < text.Length)
                        table[i, j] = text[index++];
                    else
                        table[i, j] = ' ';
                }
            }

            // Чтение по столбцам
            string result = "";
            for (int j = 0; j < diameter; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    result += table[i, j];
                }
            }

            return result.TrimEnd();
        }

        public static string Decrypt(string text, int diameter)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (diameter <= 0)
                throw new ArgumentException("Диаметр должен быть > 0");

            int rows = (int)Math.Ceiling((double)text.Length / diameter);
            char[,] table = new char[rows, diameter];

            int index = 0;

            // Заполнение по столбцам
            for (int j = 0; j < diameter; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (index < text.Length)
                        table[i, j] = text[index++];
                }
            }

            // Чтение по строкам
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < diameter; j++)
                {
                    result += table[i, j];
                }
            }

            return result.TrimEnd();
        }
    }
}
