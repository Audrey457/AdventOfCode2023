// See https://aka.ms/new-console-template for more information
using AdventOfCode2023.Day1;
using AdventOfCode2023.Day2;
using AdventOfCode2023.Day3;
using AdventOfCode2023.Day4;
using System.Threading;

TransformFile transformFile = new TransformFile(@"..\..\..\Day4\Input.txt");
transformFile.ToIntDictionnary(1);
WiningCards winingCards = new WiningCards(transformFile);
Console.WriteLine(winingCards.GetPileScratchCards());

//Console.WriteLine(Day3.GetRatioSum());

