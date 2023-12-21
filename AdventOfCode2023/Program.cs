﻿// See https://aka.ms/new-console-template for more information
using AdventOfCode2023.Day1;
using AdventOfCode2023.Day2;
using System.Threading;

var calculator = new PowerColorSetCalculator(
    ("1 green, 1 blue, 1 red; " +
     "1 green, 8 red, 7 blue; " +
     "6 blue, 10 red; " +
     "4 red, 9 blue, 2 green;" +
     " 1 green, 3 blue; " +
     "4 red, 1 green, 10 blue").Split(";"));
//Console.WriteLine(calculator.CalculateFewestColorSet().ToString());
Console.WriteLine(Day2.GetPowerSum());

