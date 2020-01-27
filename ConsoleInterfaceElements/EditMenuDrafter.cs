using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class EditMenuDrafter : EditElementButton
	{
		public enum EditMenuOptions{Edit, Delete, Exit};
		string[] options = { "Edytuj element", "Usun element" };
		private EditMenuOptions selected = EditMenuOptions.Edit;

		public EditMenuDrafter(string label, IForm target) : base(label, target) { }

		public override void Action()
		{
			var option = Draw();
			if(option == EditMenuOptions.Edit)
			{
				var editElement = new EditElementFormDrafter(options[0], target);
				editElement.Action();
			}
			else
			{
				return;
			}
		}

		public EditMenuOptions Draw()
		{
			Console.Clear();
			Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
			Console.CursorVisible = false;
			Console.WriteLine();

			if(selected == EditMenuOptions.Edit)
			{
				DrawingTools.WriteInColor($"{options[0]}", ConsoleColor.Black, ConsoleColor.DarkYellow);
				Console.WriteLine($" {options[1]}");
			}
			else
			{
				Console.Write($"{options[0]} ");
				DrawingTools.WriteLineInColor($"{options[1]}", ConsoleColor.Black, ConsoleColor.DarkRed);
			}

			ReactToKey();
			return selected;
		}

		protected virtual void ReactToKey()
		{
			var clicked = Console.ReadKey(true);
			switch (clicked.Key)
			{
				case ConsoleKey.Enter:
					break;
				case ConsoleKey.LeftArrow:
					ReactToArrow();
					break;
				case ConsoleKey.RightArrow:
					ReactToArrow();
					break;
				case ConsoleKey.Escape:
					selected = EditMenuOptions.Exit;
					break;
				default:
					Draw();
					break;
			}
		}

		protected void ReactToArrow()
		{
			if(selected == EditMenuOptions.Edit)
			{
				selected = EditMenuOptions.Delete;
			}
			else
			{
				selected = EditMenuOptions.Edit;
			}
			Draw();
		}
	}
}
