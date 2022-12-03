namespace AdventKalenderAfKode2022
{
    class Program
    {
        static void Main(string[] args)
        {  
            Console.WriteLine("Day 1 - 1st challenge");
            Console.WriteLine(DayOne.getHungriestElfCalories());

            Console.WriteLine("Day 1 - 2nd challenge");
            Console.WriteLine(DayOne.getTopHungriestElfCalories(3));

            Console.WriteLine("Day 2 - 1st challenge");
            System.Console.WriteLine(Shape.calculateRockPaperScissorsPoints());
        }
    }
}