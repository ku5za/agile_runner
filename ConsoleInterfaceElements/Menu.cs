using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class Menu
	{
		protected InterfaceElementSettings settings;
		protected string menuLabel;
		protected Dictionary<string, Button> buttons;
		protected string selected;

		public Menu(string menuLabel)
		{
			this.menuLabel = menuLabel;
			buttons = new Dictionary<string, Button>();
			settings = new InterfaceElementSettings();
			settings.FgColor = ConsoleColor.DarkGreen;
			settings.LabelFgColor = ConsoleColor.Black;
		}
		
		public Menu(string menuLabel, params Button[] buttons) : this(menuLabel)
		{
			for (int i = 0; i < buttons.Length; i++)
			{
				AddButton(buttons[i]);
			}
		}

		public virtual bool AddButton(Button newButton)
		{
			if (!buttons.Values.Contains(newButton))
			{
				buttons.Add(newButton.Label, newButton);
				selected = buttons.Keys.First();
				return true;
			}
			return false;
		}
		public void RemoveButton(byte index)
		{
			if(buttons.Count > index)
			{
				var button = buttons.Keys.ToArray()[index];
				buttons.Remove(button);
			}
		}

		public virtual void Draw(char markChar = '>')
		{
			Console.SetCursorPosition(0, 0);
			Console.Clear();
			DrawingTools.WriteLineInColor($"{menuLabel}", settings.LabelFgColor, settings.LabelBgColor);
		
			Console.CursorVisible = false;
			Console.WriteLine();

			foreach(var button in buttons)
			{
				Console.Write(" ");
				if (button.Key == selected)
				{
					Console.Write($"{markChar} ");
					DrawingTools.WriteLineInColor(button.Key, settings.FgColor);
				}
				else
				{
					Console.Write("  ");
					Console.WriteLine(button.Key);
				}
			}

			ReactToKey();
		}

		protected virtual void ReactToKey()
		{
			var clicked = Console.ReadKey(true);
			switch (clicked.Key)
			{
				case ConsoleKey.Enter:
					buttons[selected].Action();
					break;
				case ConsoleKey.DownArrow:
					ReactToDownArrow();
					break;
				case ConsoleKey.UpArrow:
					ReactToUpArrow();
					break;
				case ConsoleKey.Escape:
					break;
				default:
					Draw();
					break;
			}
		}

		protected virtual void ReactToUpArrow()
		{
			string[] buttonsLabels = buttons.Keys.ToArray();
			for(byte i = 0; i < buttonsLabels.Length; i++)
			{
				if(buttonsLabels[i] == selected)
				{
					if(i - 1 < 0)
					{
						selected = buttonsLabels[buttonsLabels.Length - 1];
					}
					else
					{
						selected = buttonsLabels[i - 1];
					}
					break;
				}
			}
			Draw();
		}

		protected virtual void ReactToDownArrow()
		{
			string[] buttonsLabels = buttons.Keys.ToArray();
			for (byte i = 0; i < buttonsLabels.Length; i++)
			{
				if (buttonsLabels[i] == selected)
				{
					if (i + 1 == buttonsLabels.Length)
					{
						selected = buttonsLabels[0];
					}
					else
					{
						selected = buttonsLabels[i + 1];
					}
					break;
				}
			}
			Draw();
		}

		public string ReturnSelectedLabel() => selected;
		public Button ReturnSelectedButton() => buttons[selected];
	}
 }
