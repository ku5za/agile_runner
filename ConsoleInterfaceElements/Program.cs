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
			Product product = new Product("AgileRunner");
			Button productButton = new NewElementFormDrafter("Nowy produkt", product);
			productButton.Action();
			//ProductBacklog backlog = new ProductBacklog();
			//Button button = new ExtendableListDrafter("Backlog", backlog);
			//button.Action();
		}
	}
}