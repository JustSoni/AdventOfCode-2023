namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\input.txt";

            int totalPoints = 0;

            using (StreamReader sr = new StreamReader(filePath))
            {
                int current = 0;
                while (sr.Peek() >= 0)
                {
                    current = 0;
                    string inputLine = sr.ReadLine();
                    string[] split = inputLine.Split(": ");

                    string[] halves = split[1].Split(" | ");

                    int[] myNumbers = System.Text.RegularExpressions.Regex.Split(halves[0].Trim(), @"\s+").Select(int.Parse).ToArray();
                    int[] winningNumbers = System.Text.RegularExpressions.Regex.Split(halves[1].Trim(), @"\s+").Select(int.Parse).ToArray();

                    Console.WriteLine(halves[0]);
                    Console.WriteLine(halves[1]);

                    foreach (var number in myNumbers)
                    {
                        if (winningNumbers.Contains(number))
                        {
                            if (current == 0)
                                current = 1;
                            else
                                current *= 2;
                        }
                    }


                    totalPoints += current;

                }

            }
            Console.WriteLine($"Total points: {totalPoints}");
        }
    }
}