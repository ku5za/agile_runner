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
			Dictionary<string, FormTools.ValueSetter> formInputs = backlogItem.GetFormInputs();
			Dictionary<string, FormTools.ValueGetter> formCurrentValues = backlogItem.GetFormCurrentInputValues();
			FormDrafter formDrafter = new FormDrafter();

			formDrafter.Draw(formInputs, formCurrentValues);
			Console.WriteLine();
			formDrafter.Draw(formInputs, formCurrentValues);

			Console.ReadKey();
		}
	}
}
