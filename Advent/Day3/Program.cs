namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\input.txt";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string inputLine = sr.ReadLine();
                }
            }
        }
    }
}