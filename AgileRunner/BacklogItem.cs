using System;
using System.Collections.Generic;
using AgileRunner;

namespace ConsoleInterfaceElements
{
	//internal class BacklogItem : IForm
	class BacklogItem : IForm
	{
		const string titleLabel = "tytul";
		const string descriptionLabel = "opis";
		const string orderLabel = "pozycja";
		const string estimateWorkAmountLabel = "przewidywana ilosc pracy";
		const string valueLabel = "wartosc";
		const string acceptationConditionLabel = "warunek akceptacji";
		const string isDoneLabel = "zakonczone";

		private string title;
		private string description;
		private byte order;
		private byte estimateWorkAmount;
		private byte value;
		private string acceptationCondition;
		private bool isDone;

 		public Dictionary<string, FormDrafter.ValueSetter> GetFormInputs()
		{
			Dictionary<string, FormDrafter.ValueSetter> formInputs = new Dictionary<string, FormDrafter.ValueSetter>();

			//FormDrafter.ValueSetter titleSetter = this.TitleSetter;
			//FormDrafter.ValueSetter descriptionSetter = this.DescriptionSetter;
			//FormDrafter.ValueSetter orderSetter = this.OrderSetter;
			//FormDrafter.ValueSetter estimateWorkAmontuSetter = this.EstimateWorkAmountSetter;
			//FormDrafter.ValueSetter valueSetter = this.ValueSetter;
			//FormDrafter.ValueSetter accceptationConditionSetter = this.AcceptationConditionSetter;
			//FormDrafter.ValueSetter isDoneSetter = this.IsDoneSetter;

			formInputs.Add(titleLabel, TitleSetter);
			formInputs.Add(descriptionLabel, DescriptionSetter);
			formInputs.Add(orderLabel, OrderSetter);
			formInputs.Add(estimateWorkAmountLabel, EstimateWorkAmountSetter);
			formInputs.Add(valueLabel, ValueSetter);
			formInputs.Add(acceptationConditionLabel, AcceptationConditionSetter);
			formInputs.Add(isDoneLabel, IsDoneSetter);

			return formInputs;
		}

		public Dictionary<string, FormDrafter.ValueGetter> GetFormCurrentValues()
		{
			Dictionary<string, FormDrafter.ValueGetter> formGetters = new Dictionary<string, FormDrafter.ValueGetter>();

			return formGetters;
		}


		public BacklogItem()
		{
			this.title = "Nowy element backlogu";
			this.description = "Wprowadz opis";
			this.order = 1;
			this.estimateWorkAmount = 2;
			this.value = 3;
			this.acceptationCondition = "Warunek akceptacji";
			this.isDone = false;
		}

		public string GetFormLabel()
		{
			return "Nowy element backlogu";
		}

		#region setters
		private bool TitleSetter(object value)
		{
			return InputHandler.SetIfCompatibleTypes(ref title, value);
		}
		private bool DescriptionSetter(object value)
		{
			return InputHandler.SetIfCompatibleTypes(ref description, value);
		}
		private bool OrderSetter(object value)
		{
			return InputHandler.SetIfCompatibleTypes(ref order, value);
		}
		private bool EstimateWorkAmountSetter(object value)
		{
			return InputHandler.SetIfCompatibleTypes(ref estimateWorkAmount, value);
		}
		private bool ValueSetter(object value)
		{
			return InputHandler.SetIfCompatibleTypes(ref value, value);
		}
		private bool AcceptationConditionSetter(object value)
		{
			return InputHandler.SetIfCompatibleTypes(ref acceptationCondition, value);
		}
		private bool IsDoneSetter(object value)
		{
			return InputHandler.SetIfCompatibleTypes(ref isDone, value);
		}
		#endregion
	}
}
