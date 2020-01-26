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
		public EditElementFormDrafter(string label, IEditForm target) : base(label, target)
		{ }

		public override void Action()
		{
			Draw();
		}
		public void Draw()
		{
			Dictionary<string, FormTools.ValueSetter> inputs = target.GetFormInputs();
			string[] keys = new string[inputs.Count];
			Dictionary<string, FormTools.ValueGetter> inputValues = target.GetFormCurrentInputValues();
			inputs.Keys.CopyTo(keys, 0);
			int longest = FormTools.FindLongest(keys);

			for (byte i = 0; i < inputs.Count; i++)
			{
				DrawFormInput(FormTools.MatchToLongest(keys[i], longest), inputs[keys[i]], inputValues[keys[i]]);
			}
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
				FormTools.AddSpacing($"{label}: ".Length);
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
					FormTools.AddSpacing($"{label}: ".Length);
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine(e.Message);
					Console.ResetColor();
				}
			}

			Console.CursorVisible = currentCursorVisibility;
		}
	}
}
