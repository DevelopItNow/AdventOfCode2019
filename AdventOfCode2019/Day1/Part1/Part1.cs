﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day1.Part1
{
	public class Part1
	{
		public Part1()
		{
			// Get the content of the input file
			string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Day1\\Part1\\Input.txt"));

			// Split input to a list of integers
			List<int> inputList = input.Split('\n').Select(Int32.Parse).ToList();

			int totalRequiredFuel = 0;
			
			inputList.ForEach(i => totalRequiredFuel += CalculateRequiredFuel(i));
			
			Console.WriteLine(totalRequiredFuel);

		}

		private int CalculateRequiredFuel(double mass)
		{
			// Do the math for the fuel usage
			return Convert.ToInt32(Math.Floor(mass / 3) - 2); ;
		}
	}
}