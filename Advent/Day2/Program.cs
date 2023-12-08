namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\input.txt";
            int idSum = 0;

            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;
            int totalPower = 0;

            List<int> validIds = new List<int>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    Dictionary<string, int> bag = new Dictionary<string, int>()
                    {
                        {"red",0 },
                        {"green",0 },
                        {"blue",0 }
                    };
                    string inputLine = sr.ReadLine();
                    string[] splitGame = inputLine.Split(": ");
                    int gameId = int.Parse(splitGame[0].Split(' ').LastOrDefault());

                    string[] sets = splitGame[1].Split("; ");
                    bool flag = true;

                    int bestRed = 0;
                    int bestGreen = 0;
                    int bestBlue = 0;
                    foreach (string set in sets)
                    {
                        bag["red"] = 0;
                        bag["green"] = 0;
                        bag["blue"] = 0;

                        string[] ballsInSet = set.Split(", ");
                        foreach (string balls in ballsInSet)
                        {
                            string[] pair = balls.Split(" ");
                            int count = int.Parse(pair[0]);
                            string color = pair[1];
                            bag[color] += count;

                            if (color == "red" && count > bestRed)
                            {
                                bestRed = count;
                            }

                            if (color == "green" && count > bestGreen)
                            {
                                bestGreen = count;
                            }

                            if (color == "blue" && count > bestBlue)
                            {
                                bestBlue = count;
                            }
                        }

                        if (bag["red"] > maxRed || bag["green"] > maxGreen || bag["blue"] > maxBlue)
                        {
                            flag = false;
                        }
                    }


                    if (flag)
                    {
                        idSum += gameId;
                        validIds.Add(gameId);
                    }

                    int currentPower = bestRed * bestGreen * bestBlue;
                    totalPower += currentPower;

                    Console.WriteLine(inputLine);
                    Console.WriteLine($"Current Power = {currentPower}");
                }
            }
            Console.WriteLine($"Game ids sum = {idSum}");
            Console.WriteLine($"Total power = {totalPower}");
        }
    }
}