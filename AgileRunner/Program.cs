using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleInterfaceElements;

namespace AgileRunner
{
	class Program
	{
		static void Main(string[] args)
		{
			BacklogItem backlogItem = new BacklogItem();
			Dictionary<string, FormDrafter.ValueSetter> formInputs = backlogItem.GetFormInputs();
			Dictionary<string, FormDrafter.ValueGetter> formCurrentValues = backlogItem.GetFormCurrentValues();
			FormDrafter formDrafter = new FormDrafter();

			formDrafter.Draw(formInputs, formCurrentValues);
			Console.WriteLine();
			formDrafter.Draw(formInputs, formCurrentValues);

			Console.ReadKey();
		}
	}
}
