using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day2.Part2
{
	public class Part2
	{
		public Part2()
		{
			string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
				"..\\..\\Day2\\Part1\\Input.txt"));
			int[] inputArray = input.Split(',').Select(Int32.Parse).ToArray();

			bool stop = false;
			int index1 = -1, index2 = -1, nullValue = 0;
			for (int i = 0; (i < 99) && !stop; i++)
			{
				for (int j = 0; (j < 99) && !stop; j++)
				{
					nullValue = NullValue((int[]) inputArray.Clone(), i, j);
					if (nullValue == 19690720)
					{
						stop = true;
						index1 = i;
						index2 = j;
					}
				}
			}

			Console.WriteLine(index1 + " - " + index2);
		}

		private int NullValue(int[] inputArrayInner, int index1, int index2)
		{
			inputArrayInner[1] = index1;
			inputArrayInner[2] = index2;
			bool done = false;
			int location = 0;
			int length = inputArrayInner.Length;
			while (!done)
			{
				if (location >= length)
					break;

				switch (inputArrayInner[location])
				{
					case 1:
						inputArrayInner[inputArrayInner[(location + 3)]] =
							(inputArrayInner[inputArrayInner[location + 1]] +
							 inputArrayInner[inputArrayInner[location + 2]]);
						location += 4;
						break;
					case 2:
						inputArrayInner[inputArrayInner[(location + 3)]] =
							(inputArrayInner[inputArrayInner[location + 1]] *
							 inputArrayInner[inputArrayInner[location + 2]]);
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

			return inputArrayInner[0];
		}
	}
}