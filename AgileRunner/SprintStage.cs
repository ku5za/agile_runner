using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunner
{
	class SprintStage : IExtendableList
	{
		private string stageLabel;
		Backlog backlog;
		private List<IForm> issues;
		public SprintStage(string stageLabel, Backlog backlog)
		{
			this.stageLabel = stageLabel;
			this.backlog = backlog;
			this.issues = new List<IForm>();
		}

		public List<IForm> GetListElements()
		{
			return issues;
		}

		public string GetListLabel()
		{
			return stageLabel;
		}

		public IForm GetNewItemForm()
		{
			IForm newBacklogItem = backlog.GetNewItemForm();
			issues.Add(newBacklogItem);
			return newBacklogItem;
		}

		public void RemoveItem(IForm item)
		{
			backlog.RemoveItem(item);
		}
	}
}