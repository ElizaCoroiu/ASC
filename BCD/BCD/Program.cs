using System;

namespace BCD
{
    class Program
    {
        static void Main(string[] args)
        {
            int input, digit;
            string result = "";

            input = int.Parse(Console.ReadLine());

            while (input > 0)
            {
                digit = input % 10;
                input /= 10;

                result = Convert.ToString(digit, 2).PadLeft(4, '0') + " " + result;
            }

            Console.Write(result + " ");
        }
    }
}
