using System;
using System.Collections.Generic;
using AgileRunnerAPI;

namespace AgileRunner
{
	public class BacklogItem : IEditForm
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

		public Dictionary<string, FormTools.ValueSetter> GetFormInputs()
		{
			Dictionary<string, FormTools.ValueSetter> formInputs = new Dictionary<string, FormTools.ValueSetter>();

			formInputs.Add(titleLabel, TitleSetter);
			formInputs.Add(descriptionLabel, DescriptionSetter);
			formInputs.Add(orderLabel, OrderSetter);
			formInputs.Add(estimateWorkAmountLabel, EstimateWorkAmountSetter);
			formInputs.Add(valueLabel, ValueSetter);
			formInputs.Add(acceptationConditionLabel, AcceptationConditionSetter);

			return formInputs;
		}

		public Dictionary<string, FormTools.ValueGetter> GetFormCurrentInputValues()
		{
			Dictionary<string, FormTools.ValueGetter> formGetters = new Dictionary<string, FormTools.ValueGetter>();

			formGetters.Add(titleLabel, TitleGetter);
			formGetters.Add(descriptionLabel, DescriptionGetter);
			formGetters.Add(orderLabel, OrderGetter);
			formGetters.Add(estimateWorkAmountLabel, EstimateWorkAmountGetter);
			formGetters.Add(valueLabel, ValueGetter);
			formGetters.Add(acceptationConditionLabel, AcceptationConditionGetter);

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
		private FormTools.ValueSetter WrapInAttributeSetter<T>(T attribute)
		{
			return delegate (object value) { return InputHandler.SetIfCompatibleTypes(ref attribute, value); };
		}

		private bool TitleSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref title, value);

		private bool DescriptionSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref description, value);
		
		private bool OrderSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref order, value);
		
		private bool EstimateWorkAmountSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref estimateWorkAmount, value);
		
		private bool ValueSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref this.value, value);
		
		private bool AcceptationConditionSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref acceptationCondition, value);
		
		private bool IsDoneSetter(object value)
			=> InputHandler.SetIfCompatibleTypes(ref isDone, value);
		#endregion
		#region getters
		private object TitleGetter() => title;
		private object DescriptionGetter() => description;
		private object OrderGetter() => order;
		private object EstimateWorkAmountGetter() => estimateWorkAmount;
		private object ValueGetter() => value;
		private object AcceptationConditionGetter() => acceptationCondition;
		private object isDoneGetter() => isDone;
		
		#endregion
	}
}
