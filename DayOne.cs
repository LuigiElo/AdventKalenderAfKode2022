namespace AdventKalenderAfKode2022
{
    public static class DayOne
    {
        /**This list represents the Calories of the food carried by five Elves:

The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
The second Elf is carrying one food item with 4000 Calories.
The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
The fifth Elf is carrying one food item with 10000 Calories.

In case the Elves get hungry and need extra snacks, they need to know which Elf to ask: they'd like to know how many Calories are being carried by the Elf carrying the most Calories.
In the example above, this is 24000 (carried by the fourth Elf).
Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
        **/

        private static List<List<int>>? readInput()
        {
            string text = System.IO.File.ReadAllText(@"inputDay1.txt");
            string[] lines = text.Split(new string[] { Environment.NewLine+ Environment.NewLine }, StringSplitOptions.None);
            List<List<int>> linesList = lines.ToList().Select((line) => line.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().Select((item) => Int32.Parse(item)).ToList()).ToList();

            return linesList;
        }

        public static int getHungriestElfCalories()
        {
            List<List<int>>? elfList = readInput();
            List<int> list = elfList.ToList()
                .OrderByDescending((elf) => elf.Sum())
                .First();

            return list.Sum();
        }

        public static int getTopHungriestElfCalories(int top)
        {
            List<List<int>>? elfList = readInput();
            List<int> list = elfList.Select((elf) => elf.Sum()).ToList().OrderByDescending((elf) => elf ).Take(top).ToList();

            return list.Sum();
        }

    }
}