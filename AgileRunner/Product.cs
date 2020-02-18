using AgileRunnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRunner
{
	public class Product : IForm
	{
		private string formLabel = "Produkt";

		private string name;
		private Backlog backlog;
		private List<ScrumSprint> scrumSprints;
		private List<PartialIncrement> productIncrement;
		
		private byte standardSprintDuration;
		#region inputLabels
		private string nameLabel = "nazwa";
		private string standardSprintDuraionLabel = "standardowy czas trwania sprintu";
		#endregion

		public Product(string name)
		{
			this.name = name;
			backlog = new Backlog();
			scrumSprints = new List<ScrumSprint>();
			ScrumSprint sprint = new ScrumSprint(backlog);
			scrumSprints.Add(sprint);
			productIncrement = new List<PartialIncrement>();
		}

		public Dictionary<string, FormTools.ValueSetter> GetFormInputs()
		{
			Dictionary<string, FormTools.ValueSetter> inputs = new Dictionary<string, FormTools.ValueSetter>();

			inputs.Add(nameLabel, NameSetter);
			inputs.Add(standardSprintDuraionLabel, StandardSprintDurationSetter);

			return inputs;
		}
		public Dictionary<string, FormTools.ValueGetter> GetFormCurrentInputValues()
		{
			Dictionary<string, FormTools.ValueGetter> currentValues = new Dictionary<string, FormTools.ValueGetter>();

			currentValues.Add(nameLabel, NameGetter);
			currentValues.Add(standardSprintDuraionLabel, StandardSprintDurationGetter);

			return currentValues;
		}

		public string GetFormLabel()
		{
			return formLabel;
		}

		#region setters
		public bool NameSetter(object name)
			=> InputHandler.SetIfCompatibleTypes(ref this.name, name);
		
		public bool StandardSprintDurationSetter(object standardSprintDuration)
			=> InputHandler.SetIfCompatibleTypes(ref this.standardSprintDuration, standardSprintDuration);
		#endregion

		#region getters
		public object NameGetter() => name;
		public object StandardSprintDurationGetter() => standardSprintDuration;
		#endregion
	}
}