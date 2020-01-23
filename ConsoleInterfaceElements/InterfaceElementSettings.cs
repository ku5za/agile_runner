using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	class InterfaceElementSettings
	{
		public bool HasBorder { get; set; }
		public byte LabelPadding { get; set; }
		public byte LabelMargin { get; set; }
		public byte ContentPadding { get; set; }
		public byte ContentMaring { get; set; }
		public ConsoleColor FgColor{ get; set; }
		public ConsoleColor BgColor { get; set; }

	}
}
