using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	public class InterfaceElementSettings
	{
		public InterfaceElementSettings()
		{
			HasBorder = false;
			LabelPadding = 0;
			LabelMargin = 0;
			ContentPadding = 0;
			ContentMargin = 0;
			FgColor = ConsoleColor.Gray;
			BgColor = ConsoleColor.Black;
			LabelFgColor = ConsoleColor.Gray;
			LabelBgColor = ConsoleColor.DarkGreen;
			MarkedElementFgColor = ConsoleColor.DarkGreen;
			MarkedElementBgColor = ConsoleColor.Black;
		}
		public bool HasBorder { get; set; }
		public byte LabelPadding { get; set; }
		public byte LabelMargin { get; set; }
		public byte ContentPadding { get; set; }
		public byte ContentMargin { get; set; }
		public ConsoleColor FgColor{ get; set; }
		public ConsoleColor BgColor { get; set; }
		public ConsoleColor LabelFgColor { get; set; }
		public ConsoleColor LabelBgColor { get; set; }
		public ConsoleColor MarkedElementFgColor { get; set; }
		public ConsoleColor MarkedElementBgColor { get; set; }
	}
}
