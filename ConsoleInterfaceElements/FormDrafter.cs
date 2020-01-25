﻿using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	public class FormDrafter
	{
		public void Draw(Dictionary<string, FormTools.ValueSetter> inputs)
		{
			string[] keys = new string[inputs.Count];
			inputs.Keys.CopyTo(keys, 0);
			FormTools.ValueSetter[] valueSetters = new FormTools.ValueSetter[inputs.Count];
			inputs.Values.CopyTo(valueSetters, 0);
			int longest = FindLongest(keys);

			for (byte i = 0; i < inputs.Count; i++)
			{
				DrawFormInput(MatchToLongest(keys[i], longest), valueSetters[i]);
			}
		}
  
		public void Draw(Dictionary<string, FormTools.ValueSetter> inputs, Dictionary<string, FormTools.ValueGetter> inputValues)
		{
			string[] keys = new string[inputs.Count];
			inputs.Keys.CopyTo(keys, 0);
			FormTools.ValueSetter[] valueSetters = new FormTools.ValueSetter[inputs.Count];
			inputs.Values.CopyTo(valueSetters, 0);
			int longest = FindLongest(keys);

			for (byte i = 0; i < inputs.Count; i++)
			{
				DrawFormInput(MatchToLongest(keys[i], longest), valueSetters[i], inputValues[keys[i]]);
			}
		}

		public void DrawFormInput(string label, FormTools.ValueSetter valueSetter)
		{
			bool currentCursorVisibility = Console.CursorVisible;
			
			Console.Write($"{label}: ");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			//Console.WriteLine($"<obecnie: \"{label}\">");
			Console.ResetColor();

			Console.CursorVisible = true;
			bool writingSuccess = false;
			byte tries = 0;
			while(writingSuccess != true)
			{
				if(tries++ > 0) AddSpacing($"{label}: ".Length);
				object value = Console.ReadLine();
				try
				{
					writingSuccess = valueSetter(value);
				}
				catch (Exception e)
				{
					AddSpacing($"{label}: ".Length);
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine(e.Message);
					Console.ResetColor();
				}
			}

			Console.CursorVisible = currentCursorVisibility;
		}

		private static void DrawFormInput(string label, FormTools.ValueSetter valueSetter, FormTools.ValueGetter valueGetter)
		{
			bool currentCursorVisibility = Console.CursorVisible;

			Console.Write($"{label}: ");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine($"<obecnie: \"{valueGetter()}\">");
			Console.ResetColor();

			Console.CursorVisible = true;
			bool writingSuccess = false;
			while (writingSuccess != true)
			{
				AddSpacing($"{label}: ".Length);
				object value = Console.ReadLine();
				try
				{
					if (value.ToString().Length != 0)
					{
						writingSuccess = valueSetter(value);
					}
					else
					{
						writingSuccess = true;
					}
				}
				catch (Exception e)
				{
					AddSpacing($"{label}: ".Length);
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine(e.Message);
					Console.ResetColor();
				}
			}

			Console.CursorVisible = currentCursorVisibility;
		}

		protected static void AddSpacing(int size)
		{
			for (byte i = 0; i < size; i++)
			{
				Console.Write(" ");
			}
		}

		protected static int FindLongest(string[] labels)
		{
			int longest = 0;
			for(int i = 0; i < labels.Length; i++)
			{
				if (labels[i].Length > longest) longest = labels[i].Length;
			}

			return longest;
		}

		protected static string MatchToLongest(string label, int longest)
		{
			string matching = "";
			for(int i = 0; i < longest - label.Length; i++)
			{
				matching += " ";
			}

			matching += label;

			return matching;
		}
	}
}