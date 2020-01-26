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
			Button formDrafter = new NewElementFormDrafter("Nowy element backlogu", backlogItem);
			Button editFormDrafter = new EditElementFormDrafter("Edytuj element", backlogItem);
			
			formDrafter.Action();
			Console.WriteLine();
			editFormDrafter.Action();

			Console.ReadKey();
		}
	}
}
