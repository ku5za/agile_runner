using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	static class DrawingTools
	{
		public static void AddSpacing(int size)
		{
			for (byte i = 0; i < size; i++)
			{
				Console.Write(" ");
			}
		}

		public static int FindLongest(string[] labels)
		{
			int longest = 0;
			for (int i = 0; i < labels.Length; i++)
			{
				if (labels[i].Length > longest) longest = labels[i].Length;
			}

			return longest;
		}

		public static string MatchToLongest(string label, int longest)
		{
			string matching = "";
			for (int i = 0; i < longest - label.Length; i++)
			{
				matching += " ";
			}

			matching += label;

			return matching;
		}

		public static void WriteInColor(object element, ConsoleColor FgColor)
		{
			Console.ForegroundColor = FgColor;
			Console.Write(element);
			Console.ResetColor();
		}
		public static void WriteInColor(object element, ConsoleColor FgColor, ConsoleColor BgColor)
		{
			Console.BackgroundColor = BgColor;
			Console.ForegroundColor = FgColor;
			Console.Write(element);
			Console.ResetColor();
		}

		public static void WriteLineInColor(object line, ConsoleColor FgColor)
		{
			Console.ForegroundColor = FgColor;
			Console.WriteLine(line);
			Console.ResetColor();
		}

		public static void WriteLineInColor(object line, ConsoleColor FgColor, ConsoleColor BgColor)
		{
			Console.BackgroundColor = BgColor;
			Console.ForegroundColor = FgColor;
			Console.WriteLine(line);
			Console.ResetColor();
		}
	}
}
