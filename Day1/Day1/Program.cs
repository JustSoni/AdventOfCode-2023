using System.Globalization;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\input.txt";
            int total = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {

                while (sr.Peek() >= 0)
                {
                    string code = sr.ReadLine();
                    int first = -1;
                    int last = -1;
                    int count = 0;
                    foreach(char c in code)
                    {
                        if(Char.IsDigit(c))
                        {
                            count++;
                            if (count == 1)
                                first = (c - 48) * 10;
                            else
                                last = c - 48;
                        }
                        if (count == 1)
                            last = first / 10;
                    }
                    int sum = first + last;
                    Console.WriteLine(code);
                    Console.WriteLine($"{first} + {last} = {sum}");
                    total += sum;
                }
            }
            Console.WriteLine($"Total = {total}");
        }
    }
}