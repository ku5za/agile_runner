﻿using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunner
{
	public interface IForm
	{
		string GetFormLabel();
		Dictionary<string, FormTools.ValueSetter> GetFormInputs();
	}
}
