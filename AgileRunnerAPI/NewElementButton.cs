using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgileRunnerAPI
{
	public abstract class NewElementDrafter : Button
	{
		protected IForm target;
		public NewElementDrafter(string label, IForm target) : base(label) => this.target = target;
	}
}
