using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019.Day3.Part2
{
	public class Part2
	{
		public Part2() {
			string inputString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
				"..\\..\\Day3\\Part1\\Input.txt"));

			string[] inputArray = inputString.Split('\n');

			string inputStringPath1 = inputArray[0];
			string inputStringPath2 = inputArray[1];
			
//			string inputStringPath1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
//			string inputStringPath2 = "U62,R66,U55,R34,D71,R55,D58,R83";
			
			Console.WriteLine("Step1");
			List<(int x, int y)> path1 = CalculatePath(inputStringPath1);
			List<(int x, int y)> path2 = CalculatePath(inputStringPath2);

			int closestDistance = 0; 
			Console.WriteLine("Step2");


			for(int i = 0; i < path1.Count; i++) {
				(int, int) posLoc = path1[i];
				if(path2.Contains(posLoc)) {
					int steps = 2 + i + path2.FindIndex(0, (el) => el == posLoc);
					if(closestDistance > steps || closestDistance == 0) {
						closestDistance = steps; 
					} 
				}
			}
			
			Console.WriteLine(closestDistance);

		}

		private List<(int x, int y)> CalculatePath(string input)
		{
			Console.WriteLine("Step1 part1");

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
			Console.WriteLine("Step1 part2");

			return newPath;
		}
		
		private int CalculateManhattanDistance((int x, int y) path1, (int x, int y) path2)
		{
			return Math.Abs(path1.x - path2.x) + Math.Abs(path1.y - path2.y);
		}
	}
}