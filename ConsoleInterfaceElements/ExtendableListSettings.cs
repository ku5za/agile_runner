using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class ExtendableListSettings : InterfaceElementSettings
	{
		private ConsoleColor newElementButtonFgColor;

		public ConsoleColor NewElementButtonFgColor
		{
			get { return newElementButtonFgColor; }
			set { newElementButtonFgColor = value; }
		}

		private ConsoleColor newElementButtonBgColor;

		public ConsoleColor NewElementButtonBgColor
		{
			get { return newElementButtonBgColor; }
			set { newElementButtonBgColor = value; }
		}

	}
}
