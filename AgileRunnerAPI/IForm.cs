using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunnerAPI
{
	public interface IForm
	{
		string GetFormLabel();
		Dictionary<string, FormTools.ValueSetter> GetFormInputs();
		Dictionary<string, FormTools.ValueGetter> GetFormCurrentInputValues();

	}
}
