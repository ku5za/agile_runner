using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class EditElementFormDrafter : EditElementButton
	{
		public EditElementFormDrafter(string label, IForm target) : base(label, target)
		{ }

		public override void Action()
		{
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Draw();
		}
		public void Draw()
		{
			DrawingTools.WriteLineInColor($"{target.GetFormLabel()}\n", ConsoleColor.Black, ConsoleColor.DarkYellow);
			Dictionary<string, FormTools.ValueSetter> inputs = target.GetFormInputs();
			string[] keys = new string[inputs.Count];
			Dictionary<string, FormTools.ValueGetter> inputValues = target.GetFormCurrentInputValues();
			inputs.Keys.CopyTo(keys, 0);
			int longest = DrawingTools.FindLongest(keys);

			for (byte i = 0; i < inputs.Count; i++)
			{
				DrawFormInput(DrawingTools.MatchToLongest(keys[i], longest), inputs[keys[i]], inputValues[keys[i]]);
			}
		}

		private static void DrawFormInput(string label, FormTools.ValueSetter valueSetter, FormTools.ValueGetter valueGetter)
		{
			bool currentCursorVisibility = Console.CursorVisible;

			Console.Write($"{label}: ");
			DrawingTools.WriteLineInColor($"<obecnie: \"{valueGetter()}\">", ConsoleColor.DarkGray);

			Console.CursorVisible = true;
			bool writingSuccess = false;
			while (writingSuccess != true)
			{
				DrawingTools.AddSpacing($"{label}: ".Length);
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
					DrawingTools.AddSpacing($"{label}: ".Length);
					DrawingTools.WriteLineInColor(e.Message, ConsoleColor.DarkRed);
				}
			}

			Console.CursorVisible = currentCursorVisibility;
		}
	}
}
