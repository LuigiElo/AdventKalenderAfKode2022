namespace AdventKalenderAfKode2022
{

    public enum Shapes
    {
        Rock = 'X',
        RockElf = 'A',
        Paper = 'Y',
        PaperElf = 'B',
        Scissors = 'Z',
        ScissorsElf = 'C'
    }
    public enum MatchPoints
    {
        Loss = 0,
        Draw = 3,
        Win = 6
    }
    public enum ShapePoints
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public static class Shape
    {
        private static int shapesAsPoints(Shapes shape)
        {
            return shape switch
            {
                Shapes.Paper => 2,
                Shapes.PaperElf => 2,
                Shapes.Rock => 1,
                Shapes.RockElf => 1,
                Shapes.Scissors => 3,
                Shapes.ScissorsElf => 3,
                _ => 0
            };
        }

        private static List<List<Shapes>>? readInput()
        {
            string text = System.IO.File.ReadAllText(@"DayTwo\input.txt");
            string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            List<List<Shapes>> linesList = lines.ToList().Select((line) => line.Split(new string[] { " " }, StringSplitOptions.None).ToList().Select((item) => (Shapes)Char.Parse(item)).ToList()).ToList();

            return linesList;
        }

        private static int getPoints(Shapes yourShape, Shapes elfShape)
        {
            int matchPoints = (int)(shapesAsPoints(yourShape) == shapesAsPoints(elfShape) + 1 || shapesAsPoints(yourShape) == shapesAsPoints(elfShape) - 2 ? MatchPoints.Win :
                                 shapesAsPoints(yourShape) == shapesAsPoints(elfShape) ? MatchPoints.Draw : MatchPoints.Loss);
            return matchPoints + shapesAsPoints(yourShape);
        }
        public static int calculateRockPaperScissorsPoints(int challenge)
        {
            return challenge switch {
                1 => readInput().Select((line) => getPoints(line[1],line[0])).Sum(),
                2 => readInput().Select((line) => getDesiredResultPoints(line[0],(Result)line[1])).Sum()
            };
        }

        /**
        --- Part Two ---
The Elf finishes helping with the tent and sneaks back over to you. "Anyway, the second column says how the round needs to end: X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. Good luck!"

The total score is still calculated in the same way, but now you need to figure out what shape to choose so the round ends as indicated. The example above now goes like this:

In the first round, your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4.
In the second round, your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1.
In the third round, you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7.
Now that you're correctly decrypting the ultra top secret strategy guide, you would get a total score of 12.

Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?


        */


        public enum Result
        {
            Loss = 'X',
            Draw = 'Y',
            Win = 'Z'
        }
        private static int getShapeForExpectedResult(Shapes shape,Result result)
        {
            var shapeExpected = result switch
            {
                Result.Win => shape switch {
                 Shapes.ScissorsElf => Shapes.Rock,
                 Shapes.RockElf => Shapes.Paper,
                 Shapes.PaperElf => Shapes.Scissors
                },
                Result.Loss => shape switch {
                 Shapes.ScissorsElf => Shapes.Paper,
                 Shapes.RockElf => Shapes.Scissors,
                 Shapes.PaperElf => Shapes.Rock
                },
                _ => shape
            };
            return shapesAsPoints(shapeExpected);
        }
        public static int getDesiredResultPoints(Shapes shape,Result result) {
            return result switch {
                Result.Win => getShapeForExpectedResult(shape,result) + (int)MatchPoints.Win,
                Result.Draw => getShapeForExpectedResult(shape,result) + (int)MatchPoints.Draw,
                _ => getShapeForExpectedResult(shape, result)
            };
        }

    }
}