using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunner
{
	class ScrumSprint : IForm
	{
		private string definitionOfDoneLabel = "Definicja ukonczenia";

		private static int sprintNumber = 0;
		private string sprintName;
		private string definitionOfDone;
		private DateTime sprintStartDate;
		private DateTime sprintEndDate;
		private List<SprintStage> sprintStages;
		
		public ScrumSprint(ProductBacklog backlog)
		{
			sprintName = getSprintName();
			sprintStages = new List<SprintStage>();

			sprintStages.Add(new SprintStage("Zaplanowane", backlog));
			sprintStages.Add(new SprintStage("W toku", backlog));
			sprintStages.Add(new SprintStage("Zakonczone", backlog));
		}

		private static string getSprintName()
		{
			sprintNumber++;
			string newSprintName = $"Sprint {sprintNumber}";
			return newSprintName;
		}

		public Dictionary<string, FormTools.ValueSetter> GetFormInputs()
		{
			Dictionary<string, FormTools.ValueSetter> inputs = new Dictionary<string, FormTools.ValueSetter>();
			
			inputs.Add(definitionOfDoneLabel, DefinitionOfDoneSetter);
			
			return inputs;
		}

		public Dictionary<string, FormTools.ValueGetter> GetFormCurrentInputValues()
		{
			Dictionary<string, FormTools.ValueGetter> values = new Dictionary<string, FormTools.ValueGetter>();

			values.Add(definitionOfDoneLabel, DefinitionOfDoneGetter);

			return values;
		}

		public string GetFormLabel()
			=> sprintName;

		#region setters
		public bool DefinitionOfDoneSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref definitionOfDone, value);
		#endregion

		#region getters
		public object DefinitionOfDoneGetter() => definitionOfDone;
		#endregion
	}
}
