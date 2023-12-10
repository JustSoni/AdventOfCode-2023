namespace Day4Task2
{
    internal class Program
    {
        public static int totalScratchcards = 0;

        static void Main(string[] args)
        {
            string filePath = @"..\..\..\input.txt";


            List<string[]> lines = new List<string[]>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string inputLine = sr.ReadLine();
                    string[] split = inputLine.Split(": ");

                    string[] halves = split[1].Split(" | ");

                    int[] myNumbers = System.Text.RegularExpressions.Regex.Split(halves[0].Trim(), @"\s+").Select(int.Parse).ToArray();
                    int[] winningNumbers = System.Text.RegularExpressions.Regex.Split(halves[1].Trim(), @"\s+").Select(int.Parse).ToArray();
                    lines.Add(halves);
                }

            }

            foreach (var line in lines)
            {
                int[] myNumbers = System.Text.RegularExpressions.Regex.Split(line[0].Trim(), @"\s+").Select(int.Parse).ToArray();
                int[] winningNumbers = System.Text.RegularExpressions.Regex.Split(line[1].Trim(), @"\s+").Select(int.Parse).ToArray();
                CallMe(myNumbers, winningNumbers);
            }

            Console.WriteLine($"Total Scratchcards: {totalScratchcards}");
        }

        public static void CallMe(int[] myNumbers, int[] winningNumbers)
        {

            foreach (var number in myNumbers)
            {
                if (winningNumbers.Contains(number))
                {
                    CallMe(myNumbers, winningNumbers);
                }
            }
        }
    }
}