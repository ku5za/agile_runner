﻿using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunner
{
	public interface IMenu
	{
		string GetMenuLabel();
		MenuButton[] GetMenuButtons();
	}
}
