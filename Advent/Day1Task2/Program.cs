using System.Text.RegularExpressions;

namespace Day1Task2
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

                    int result = ExtractNumbers(code);

                    total += result;
                }
            }
            Console.WriteLine($"Total = {total}");
        }

        static int ExtractNumbers(string input)
        {
            Dictionary<string, string> numberMap = new Dictionary<string, string>
        {
            {"one", "1"}, {"two", "2"}, {"three", "3"}, {"four", "4"}, {"five", "5"},
            {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"}, {"zero", "0"},
            {"1ight","18" },
            {"2ne","21" },
            {"3ight","38"},
            {"5ight", "58"},
            {"7ine",""},
            {"8hree","83"}, {"8wo","82"},
            {"9ight","98"}
        };

            //one
            //two
            //three
            //four
            //five
            //six
            //seven
            //eight
            //nine
            //zero
            string pattern = string.Join("|", numberMap.Keys);

            string regexResult = Regex.Replace(input, pattern, match => numberMap[match.Value.ToLower()]);

            regexResult = Regex.Replace(regexResult, pattern, match => numberMap[match.Value.ToLower()]);




            string code = regexResult;
            int first = -1;
            int last = -1;
            int count = 0;
            foreach (char c in code)
            {
                if (Char.IsDigit(c))
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
            Console.WriteLine($"Original -> {input}");
            Console.WriteLine($"   Regex -> {code}");
            Console.WriteLine($"{first} + {last} = {sum}");



            return sum;
        }
    }
}