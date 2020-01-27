using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class InteractiveList : Menu
	{
		public InteractiveList(string label)
			: base(label)
		{

		}

		public InteractiveList(string label, List<Button> buttons)
			: base(label, buttons.ToArray())
		{

		}

		public bool HasButton(string label)
		{
			foreach(var button in buttons)
			{
				if(button.Key == label)
				{
					return true;
				}
			}
			return false;
		}
	}
}
