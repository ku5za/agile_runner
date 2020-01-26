using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileRunner;
using AgileRunnerAPI;
using ConsoleInterfaceElements;

namespace ConsoleInterfaceElements
{
	class Program
	{
		static public void Main()
		{
			BacklogItem backlogItem = new BacklogItem();
			Button drawNewBacklogElementButton = new NewElementFormDrafter("Nowy element backlogu", backlogItem);
			Button editBacklogElementButton = new EditElementFormDrafter("Edytuj element", backlogItem);

			Menu backlogElementMenu = new Menu("Element backlogu", drawNewBacklogElementButton, editBacklogElementButton);

			backlogElementMenu.Draw();

			//drawNewBacklogElementButton.Action();
			//Console.WriteLine();
			//editBacklogElementButton.Action();

			//Console.ReadKey();
		}
	}
}
