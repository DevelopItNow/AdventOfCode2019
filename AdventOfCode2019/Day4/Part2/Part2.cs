using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day4.Part2
{
	public class Part2
	{
		public Part2()
		{
			int min = 171309, max = 643603, correctCounter = 0;

			for (int i = min; i < max; i++)
			{
				bool theTest = Test(i.ToString());
				if (theTest)
					correctCounter++;
			}

			Console.WriteLine(correctCounter);
		}

		private bool Test(string number)
		{
			Dictionary<int, int> listFound = new Dictionary<int, int>();
			if (number.Length == 6)
			{
				int prev = number[0];
				for (int i = 1; i < 6; i++)
				{
					if (prev > number[i])
						return false;
					if (prev == number[i])
					{
						if (listFound.ContainsKey(number[i]))
							listFound[number[i]]++;
						else
							listFound.Add(number[i], 1);
					}

					prev = number[i];
				}

				return listFound.Values.Any(i => i == 1);
			}

			return false;
		}
	}
}