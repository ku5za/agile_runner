﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	abstract class Button
	{
		private string label;
		public Button(string label) => this.label = label;
	}
}
