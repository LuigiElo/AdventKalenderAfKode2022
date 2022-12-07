namespace AdventKalenderAfKode2022;

/// <summary>
/// --- Day 5: Supply Stacks ---
/// The expedition can depart as soon as the final supplies have been unloaded from the ships. 
/// Supplies are stored in stacks of marked crates, but because the needed supplies are buried under many other crates, the crates need to be rearranged.
/// The ship has a giant cargo crane capable of moving crates between stacks. 
/// To ensure none of the crates get crushed or fall over, the crane operator will rearrange them in a series of carefully-planned steps. ~
/// After the crates are rearranged, the desired crates will be at the top of each stack.
/// The Elves don't want to interrupt the crane operator during this delicate procedure, but they forgot to ask her which crate will end up where,
///  and they want to be ready to unload them as soon as possible so they can embark.
/// They do, however, have a drawing of the starting stacks of crates and the rearrangement procedure (your puzzle input). For example:
///     [D]    
/// [N] [C]    
/// [Z] [M] [P]
///  1   2   3 
/// move 1 from 2 to 1
/// move 3 from 1 to 3
/// move 2 from 2 to 1
/// move 1 from 1 to 2
/// In this example, there are three stacks of crates. Stack 1 contains two crates: crate Z is on the bottom, and crate N is on top.
///  Stack 2 contains three crates; from bottom to top, they are crates M, C, and D. Finally, stack 3 contains a single crate, P.
/// Then, the rearrangement procedure is given. In each step of the procedure, a quantity of crates is moved from one stack to a different stack. 
/// In the first step of the above rearrangement procedure, one crate is moved from stack 2 to stack 1, resulting in this configuration:
/// [D]        
/// [N] [C]    
/// [Z] [M] [P]
///  1   2   3 
/// In the second step, three crates are moved from stack 1 to stack 3. Crates are moved one at a time, so the first crate to be moved (D) ends up below the second and third crates:
///         [Z]
///         [N]
///     [C] [D]
///     [M] [P]
///  1   2   3
/// Then, both crates are moved from stack 2 to stack 1. Again, because crates are moved one at a time, crate C ends up below crate M:
///         [Z]
///         [N]
/// [M]     [D]
/// [C]     [P]
///  1   2   3
/// Finally, one crate is moved from stack 1 to stack 2:
///         [Z]
///         [N]
///         [D]
/// [C] [M] [P]
///  1   2   3
/// The Elves just need to know which crate will end up on top of each stack; in this example, the top crates are C in stack 1, M in stack 2, and Z in stack 3, so you should combine these together and give the Elves the message CMZ.
/// After the rearrangement procedure completes, what crate ends up on top of each stack?
/// </summary>
public static class DayFive
{
    private static List<List<int>> readInput()
    {
        string text = System.IO.File.ReadAllText(@"DayFive\input.txt");
        List<string> lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

        return lines.Select((item) => item.Split(new string[] { "move ", " to ", " from " }, StringSplitOptions.RemoveEmptyEntries).Select((item) => Int32.Parse(item)).ToList()).ToList();
    }

    public static string stackTop(bool movesMultipleCrates = false)
    {
        var inputMoves = readInput();
        var resultList = new List<List<char>>(){
        new List<char>(){'B','L','D','T','W','C','F','M'},
        new List<char>(){'N','B','L'},
        new List<char>(){'J','C','H','T','L','V'},
        new List<char>(){'S','P','J','W'},
        new List<char>(){'Z','S','C','F','T','L','R'},
        new List<char>(){'W','D','G','B','H','N','Z'},
        new List<char>(){'F','M','S','P','V','G','C','N'},
        new List<char>(){'W','Q','R','J','F','V','C','Z'},
        new List<char>(){'R','P','M','L','H'},
        };

        inputMoves.ForEach((item) =>
        {
            var sourceColumn = resultList[item[1] - 1];
            var rangeToMove = sourceColumn.GetRange(sourceColumn.Count() - item[0], item[0]);

            if(!movesMultipleCrates)  rangeToMove.Reverse();   

            resultList[item[2] - 1].AddRange(rangeToMove);
            resultList[item[1] - 1].RemoveRange(resultList[item[1] - 1].Count() - item[0], item[0]);
        });

        return new string(resultList.Select((item)=> item.Last()).ToArray());
    }


}