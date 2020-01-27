using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	public class NewElementFormDrafter : NewElementDrafter
	{
		public NewElementFormDrafter(string label, IForm target) : base(label, target)
		{ }

		public override void Action()
		{
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Draw();
		}

		public void Draw()
		{
			DrawingTools.WriteLineInColor($"{target.GetFormLabel()}\n", ConsoleColor.Black, ConsoleColor.DarkGreen);
			Dictionary<string, FormTools.ValueSetter> inputs = target.GetFormInputs();
			string[] keys = new string[inputs.Count];
			inputs.Keys.CopyTo(keys, 0);
			int longest = DrawingTools.FindLongest(keys);

			for (byte i = 0; i < inputs.Count; i++)
			{
				DrawFormInput(DrawingTools.MatchToLongest(keys[i], longest), inputs[keys[i]]);
			}
		}

		public void DrawFormInput(string label, FormTools.ValueSetter valueSetter)
		{
			bool currentCursorVisibility = Console.CursorVisible;

			DrawingTools.WriteInColor($"{label}: ", ConsoleColor.DarkGray);

			Console.CursorVisible = true;
			bool writingSuccess = false;
			byte tries = 0;
			while(writingSuccess != true)
			{
				if(tries++ > 0) DrawingTools.AddSpacing($"{label}: ".Length);
				object value = Console.ReadLine();
				try
				{
					writingSuccess = valueSetter(value);
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