﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunnerAPI
{
	public abstract class EditElementButton : Button
	{
		protected IForm target;
		public EditElementButton(string label, IForm target) : base(label)
			=> this.target = target;
	}
}
