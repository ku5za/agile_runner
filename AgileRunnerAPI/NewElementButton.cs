using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgileRunnerAPI
{
	public abstract class NewElementButton : Button
	{
		protected IForm target;
		public NewElementButton(string label, IForm target) : base(label) => this.target = target;
		public abstract void Action();
	}
}
