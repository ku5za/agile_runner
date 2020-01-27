using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunnerAPI
{
	public interface IExtendableList
	{
		string GetListLabel();
		List<IForm> GetListElements();
		IForm GetNewItemForm();
		void RemoveItem(IForm item);
	}
}
