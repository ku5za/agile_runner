using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunnerAPI
{
	public interface IEditForm : IForm
	{ 
		Dictionary<string, FormTools.ValueGetter> GetFormCurrentInputValues();
	}
}
