using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day2.Part1
{
	public class Part1
	{
		public Part1()
		{
			string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
				"..\\..\\Day2\\Part1\\Input.txt"));
			int[] inputArray = input.Split(',').Select(Int32.Parse).ToArray();

			inputArray[1] = 12;
			inputArray[2] = 2;

			int location = 0;
			int length = inputArray.Length;
			bool done = false;
			while (!done)
			{
				if (location >= length)
					break;

				switch (inputArray[location])
				{
					case 1:
						inputArray[inputArray[(location + 3)]] =
							(inputArray[inputArray[location + 1]] + inputArray[inputArray[location + 2]]);
						location += 4;
						break;
					case 2:
						inputArray[inputArray[(location + 3)]] =
							(inputArray[inputArray[location + 1]] * inputArray[inputArray[location + 2]]);
						location += 4;
						break;
					case 99:
						done = true;
						break;
					default:
						done = true;
						break;
				}
			}

			Console.WriteLine(inputArray[0]);
		}
	}
}