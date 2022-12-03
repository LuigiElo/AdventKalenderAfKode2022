namespace AdventKalenderAfKode2022 {
    
    public enum Shapes{
        Rock = 'X',
        RockElf = 'A',
        Paper = 'Y',
        PaperElf = 'B',
        Scissors = 'Z',
        ScissorsElf = 'C'
    }
    public enum MatchPoints{
        Loss = 0,
        Draw = 3,
        Win = 6
    }
    public enum ShapePoints{
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public static class Shape {
        private static int shapesAsPoints(Shapes shape){
            return shape switch {
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
            string[] lines = text.Split(new string[] { "\n" }, StringSplitOptions.None);
            List<List<Shapes>> linesList = lines.ToList().Select((line) => line.Split(new string[] { " " }, StringSplitOptions.None).ToList().Select((item) => (Shapes)Char.Parse(item)).ToList()).ToList();

            return linesList;
        }

        private  static int getPoints(Shapes yourShape, Shapes elfShape){
           int matchPoints = (int)(shapesAsPoints(yourShape) > shapesAsPoints(elfShape) ?  MatchPoints.Win : 
                                shapesAsPoints(yourShape) == shapesAsPoints(elfShape) ? MatchPoints.Draw : MatchPoints.Loss);
           return matchPoints + shapesAsPoints(yourShape);
        }
        public static int calculateRockPaperScissorsPoints(){
            return readInput().Select((line) => getPoints(line[1],line[0])).Sum();
        }

    }
}