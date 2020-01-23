using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class Button
	{
		public delegate void Action();
		private string label;
		private Action action;
		public Button(string label, Action action)
		{
			this.label = label;
			this.action = action;
		}

		public string Label => label;
	}
}
