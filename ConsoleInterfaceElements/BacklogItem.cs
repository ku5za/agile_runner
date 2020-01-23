using System;
using System.Collections.Generic;

namespace ConsoleInterfaceElements
{
	class BacklogItem
	{
		private string name;
		private int age;
		private double weight;
		private double height;
 		public Dictionary<string, FormDrafter.ValueSetter> GetFormInputs()
		{
			Dictionary<string, FormDrafter.ValueSetter> formInputs = new Dictionary<string, FormDrafter.ValueSetter>();

			FormDrafter.ValueSetter nameSetter = this.NameSetter;
			FormDrafter.ValueSetter ageSetter = this.AgeSetter;
			FormDrafter.ValueSetter weightSetter = this.WeightSetter;
			FormDrafter.ValueSetter heightSetter = this.HeightSetter;

			formInputs.Add("name", nameSetter);
			formInputs.Add("age", ageSetter);
			formInputs.Add("weight", weightSetter);
			formInputs.Add("height", heightSetter);

			return formInputs;
		}

		public BacklogItem(string name = "", byte age = 18, double weight = 70, double height = 1.70)
		{
			this.name = name;
			this.age = age;
			this.weight = weight;
			this.height = height;
		}

		private bool NameSetter(object newValue)
		{
			return InputHandler.SetIfCompatibleTypes<string>(ref this.name, newValue);
		}

		private bool AgeSetter(object newValue)
		{
			return InputHandler.SetIfCompatibleTypes<int>(ref this.age, newValue);
		}

		private bool WeightSetter(object newValue)
		{
			return InputHandler.SetIfCompatibleTypes<double>(ref this.weight, newValue);
		}

		private bool HeightSetter(object newValue)
		{
			return InputHandler.SetIfCompatibleTypes<double>(ref this.height, newValue);
		}

	}
}
