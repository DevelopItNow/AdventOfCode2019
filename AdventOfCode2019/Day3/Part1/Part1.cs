using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day3.Part1
{
	public class Part1
	{
		
		public Part1()
		{
			string inputString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
				"..\\..\\Day3\\Part1\\Input.txt"));

			string[] inputArray = inputString.Split('\n');
			
			string inputStringPath1 = inputArray[0];
			string inputStringPath2 = inputArray[1];
			
//			string inputStringPath1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";
//			string inputStringPath2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";
			List<(int x, int y)> path1 = CalculatePath(inputStringPath1);
			List<(int x, int y)> path2 = CalculatePath(inputStringPath2);

			int closestDistance = 0; 


			foreach ((int x, int y) path in path1)
			{
				if (path2.Contains(path))
				{
					int distance = CalculateManhattanDistance((0,0), path);
					if (closestDistance > distance || closestDistance == 0)
						closestDistance = distance;
				}
			}
			
			Console.WriteLine(closestDistance);

		}

		private List<(int x, int y)> CalculatePath(string input)
		{
			var newPath = new List<(int x, int y)>();
			(int x, int y) pos = (0,0);

			foreach (var inp in input.Split(','))
			{
				switch (inp[0])
				{
					case 'U':
						for (int i = 0; i < int.Parse(inp.Substring(1)); i++)
						{
							pos.y++;
							newPath.Add(pos);
						}
						break;
					case 'R':
						for (int i = 0; i < int.Parse(inp.Substring(1)); i++)
						{
							pos.x++;
							newPath.Add(pos);
						}
						break;
					case 'D':
						for (int i = 0; i < int.Parse(inp.Substring(1)); i++)
						{
							pos.y--;
							newPath.Add(pos);
						}
						break;
					case 'L':
						for (int i = 0; i < int.Parse(inp.Substring(1)); i++)
						{
							pos.x--;
							newPath.Add(pos);
						}
						break;
				}
			}

			return newPath;
		}
		
		private int CalculateManhattanDistance((int x, int y) path1, (int x, int y) path2)
		{
			return Math.Abs(path1.x - path2.x) + Math.Abs(path1.y - path2.y);
		}
	}
}