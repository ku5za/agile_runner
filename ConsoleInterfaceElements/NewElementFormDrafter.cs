using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	public class NewElementFormDrafter : NewElementButton
	{
		public NewElementFormDrafter(string label, IForm target) : base(label, target)
		{ }

		public override void Action()
		{
			Draw();
		}

		public void Draw()
		{
			Dictionary<string, FormTools.ValueSetter> inputs = target.GetFormInputs();
			string[] keys = new string[inputs.Count];
			inputs.Keys.CopyTo(keys, 0);
			int longest = FormTools.FindLongest(keys);

			for (byte i = 0; i < inputs.Count; i++)
			{
				DrawFormInput(FormTools.MatchToLongest(keys[i], longest), inputs[keys[i]]);
			}
		}

		public void DrawFormInput(string label, FormTools.ValueSetter valueSetter)
		{
			bool currentCursorVisibility = Console.CursorVisible;
			
			Console.Write($"{label}: ");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.ResetColor();

			Console.CursorVisible = true;
			bool writingSuccess = false;
			byte tries = 0;
			while(writingSuccess != true)
			{
				if(tries++ > 0) FormTools.AddSpacing($"{label}: ".Length);
				object value = Console.ReadLine();
				try
				{
					writingSuccess = valueSetter(value);
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