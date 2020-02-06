﻿using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class ExtendableListDrafter : ExtendableListButton
	{
		List<IForm> elementsList;
		InteractiveList interactiveList;
		
		public ExtendableListDrafter(string label, IExtendableList target) : base(label, target)
		{
			elementsList = target.GetListElements();
			var listLabel = target.GetListLabel();
			interactiveList = new InteractiveList(listLabel);

			UpdateElementsList();
		}

		public override void Action()
		{
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Draw();
		}

		protected void AppendNewElementButton()
		{
			Button addItemButton = new AddNewExtendableListItemButton("[+] dodaj nowy element", target);
			interactiveList.AddButton(addItemButton);
		}

		public void UpdateElementsList()
		{
			var listLabel = target.GetListLabel();
			interactiveList = new InteractiveList(listLabel);

			foreach (var listElement in elementsList)
			{
				var newMenuButton = CreateNewMenuButton(listElement);
				interactiveList.AddButton(newMenuButton);
			}

			AppendNewElementButton();
		}

		internal virtual EditElementButton CreateNewMenuButton(IForm button)
		{
			Dictionary<string, FormTools.ValueGetter> buttonsInfo = button.GetFormCurrentInputValues();
			FormTools.ValueGetter buttonLabelGetter = buttonsInfo["tytul"];
			string buttonLabel = (string)buttonLabelGetter();
			return new EditMenuDrafter(buttonLabel, button);
		}

		public void Draw()
		{
			UpdateElementsList();
			interactiveList.Draw();

			ConsoleKeyInfo pressedKey = Console.ReadKey(true);
			while(pressedKey.Key != ConsoleKey.Escape)
			{
				Draw();
				pressedKey = Console.ReadKey(true);
			}
		}
	}
}