using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleInterfaceElements;

namespace AgileRunner
{
	public interface IForm
	{
		string GetFormLabel();
		Dictionary<string, FormDrafter.ValueGetter> GetFormCurrentValues();
		Dictionary<string, FormDrafter.ValueSetter> GetFormInputs();
	}
}
