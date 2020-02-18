using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunner
{
	public class Backlog : IExtendableList
	{
		private string label;
		private List<IForm> backlogItems;
		public Backlog()
		{
			label = "Backlog";
			backlogItems = new List<IForm>();
		}

		public List<IForm> GetListElements() => backlogItems;

		public string GetListLabel() => label;

		public IForm GetNewItemForm()
		{
			IForm newBacklogItem = new BacklogItem();
			backlogItems.Add(newBacklogItem);
			return newBacklogItem;
		}

		public void RemoveItem(IForm item) => backlogItems.Remove(item);
	}
}