using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunner
{
	class SprintStage
	{
		private string stageLabel;
		IExtendableList backlogElements;
		public SprintStage(string stageLabel) => this.stageLabel = stageLabel;
	}
}