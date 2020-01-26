using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunnerAPI
{
	public abstract class EditElementButton : Button
	{
		protected IEditForm target;
		public EditElementButton(string label, IEditForm target) : base(label)
			=> this.target = target;

		public abstract void Action();
	}
}
