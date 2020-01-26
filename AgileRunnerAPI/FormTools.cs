using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunnerAPI
{
	public static class FormTools
	{
		public delegate bool ValueSetter(object value);
		public delegate object ValueGetter();

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
	}
}
