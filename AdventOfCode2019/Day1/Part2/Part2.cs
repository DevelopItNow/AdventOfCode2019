using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day1.Part2
{
	public class Part2
	{
		public Part2()
		{
			// Get the content of the input file
			string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Day1\\Part2\\Input.txt"));

			// Split input to a list of integers
			List<int> inputList = input.Split('\n').Select(Int32.Parse).ToList();

			int totalRequiredFuel = 0;
			inputList.ForEach(i =>
			{
				int totalNewFuel = 0;
				int lastFuelUsage = i;

				// Loop through it as long as the fuel usage isn't negative 
				while (true)
				{
					int calculateRequiredFuel = CalculateRequiredFuel(lastFuelUsage);
					if (calculateRequiredFuel == -1)
						break;

					lastFuelUsage = calculateRequiredFuel;
					totalNewFuel += lastFuelUsage;

				}

				totalRequiredFuel += totalNewFuel;
			});
			
			Console.WriteLine(totalRequiredFuel);
		}
		
		private int CalculateRequiredFuel(double mass)
		{
			// Check if the fuel usage is going to be negative
			if ((mass / 3) < 1)
				return -1;
			
			// Do the math for the fuel usage
			return Convert.ToInt32(Math.Floor(mass / 3) - 2); ;
		}
	}
}