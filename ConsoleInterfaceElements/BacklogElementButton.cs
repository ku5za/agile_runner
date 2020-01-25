using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileRunner;
using AgileRunnerAPI;

namespace ConsoleInterfaceElements 
{
	public class BacklogElementButton : Button
	{
		protected IForm target;
		public BacklogElementButton(string buttonLabel) : base(buttonLabel)
		{ }


	}
}
