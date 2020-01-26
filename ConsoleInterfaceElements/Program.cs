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
			NewElementFormDrafter formDrafter = new NewElementFormDrafter("Nowy element backlogu", backlogItem);
			EditElementFormDrafter editFormDrafter = new EditElementFormDrafter("Edytuj element", backlogItem);
			
			formDrafter.Draw();
			Console.WriteLine();
			editFormDrafter.Draw();

			Console.ReadKey();
		}
	}
}
