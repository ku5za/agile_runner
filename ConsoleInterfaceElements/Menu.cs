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
		private InterfaceElementSettings settings;
		private string menuLabel;
		private Dictionary<string, Button> buttons;
		private string selected;
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

		public void AddButton(Button newButton)
		{
			buttons.Add(newButton.Label, newButton);
			selected = buttons.Keys.First();
		}

		public void Draw(char markChar = '>')
		{
			Console.SetCursorPosition(0, 0);
			Console.Clear();
			Console.CursorVisible = false;
			WriteLineInColor($"{menuLabel}\n", settings.LabelFgColor, settings.LabelBgColor);

			foreach(var button in buttons)
			{
				Console.Write(" ");
				if (button.Key == selected)
				{
					Console.Write($"{markChar} ");
					WriteLineInColor(button.Key, settings.FgColor);
				}
				else
				{
					Console.Write("  ");
					Console.WriteLine(button.Key);
				}
			}

			ReactToKey();
		}

		private void WriteLineInColor(object line, ConsoleColor FgColor)
		{
			Console.ForegroundColor = FgColor;
			Console.WriteLine(line);
			Console.ResetColor();
		}

		private void WriteLineInColor(object line, ConsoleColor FgColor, ConsoleColor BgColor)
		{
			Console.BackgroundColor = BgColor;
			Console.ForegroundColor = FgColor;
			Console.WriteLine(line);
			Console.ResetColor();
		}

		protected virtual void ReactToKey()
		{
			var clicked = Console.ReadKey(true);
			switch (clicked.Key)
			{
				case ConsoleKey.Enter:
					buttons[selected].Action();
					Draw();
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

		protected void ReactToUpArrow()
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

		protected void ReactToDownArrow()
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
	}
 }
