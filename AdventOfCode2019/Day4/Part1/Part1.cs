using System;

namespace AdventOfCode2019.Day4.Part1
{
	public class Part1
	{
		public Part1()
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
			if (number.Length == 6)
			{
				int prev = number[0];
				bool dup = false;
				for (int i = 1; i < 6; i++)
				{
					if (prev > number[i])
						return false;
					if (prev == number[i])
						dup = true;

					prev = number[i];
				}

				return dup;
			}

			return false;
		}
	}
}