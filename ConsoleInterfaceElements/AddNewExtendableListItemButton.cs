using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	public class AddNewExtendableListItemButton : Button
	{
		IExtendableList target;
		public AddNewExtendableListItemButton(string label, IExtendableList target)
			: base(label)
		{
			this.target = target;
		}

		public override void Action()
		{
			NewElementDrafter newElement = new NewElementFormDrafter("Nowy element", target.GetNewItemForm());
			newElement.Action();
		}
	}
}
