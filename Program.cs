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
            Console.WriteLine(Shape.calculateRockPaperScissorsPoints(1));
            
            Console.WriteLine("Day 2 - 2nd challenge");
            Console.WriteLine(Shape.calculateRockPaperScissorsPoints(2));

            Console.WriteLine("Day 3 - 1st challenge ---->");
            Console.Write(DayThree.calculatePriorities());
            
            Console.WriteLine("Day 3 - 2nd challenge ----> " + DayThree.calculatePrioritiesByBadge());

            Console.WriteLine("Day 4 - 1st challenge ----> " + DayFour.getRange());

            Console.WriteLine("Day 4 - 2nd challenge ----> " + DayFour.getOverlaps());

            Console.WriteLine("Day 5 - 1st challenge ----> " + DayFive.stackTop());
            
            Console.WriteLine("Day 5 - 2nd challenge ----> " + DayFive.stackTop(true));
        }
    }
}