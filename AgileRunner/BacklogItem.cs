using System;
using System.Collections.Generic;
using AgileRunnerAPI;

namespace AgileRunner
{
	public class BacklogItem : IForm
	{
		#region fields
		private string title;
		private string description;
		private byte order;
		private byte estimateWorkAmount;
		private byte value;
		private string acceptationCondition;
		private bool isDone;
		#endregion
	
		#region inputLabels
		const string titleLabel = "tytul";
		const string descriptionLabel = "opis";
		const string orderLabel = "pozycja";
		const string estimateWorkAmountLabel = "przewidywana ilosc pracy";
		const string valueLabel = "wartosc";
		const string acceptationConditionLabel = "warunek akceptacji";
		const string isDoneLabel = "zakonczone";
		#endregion

		public BacklogItem()
		{
			title = "Nowy element backlogu";
			description = "Wprowadz opis";
			order = 1;
			estimateWorkAmount = 2;
			value = 3;
			acceptationCondition = "Warunek akceptacji";
			isDone = false;
		}

		public BacklogItem(byte order) : base()
		{
			this.order = order;
		}

		public Dictionary<string, FormTools.ValueSetter> GetFormInputs()
		{
			Dictionary<string, FormTools.ValueSetter> formInputs = new Dictionary<string, FormTools.ValueSetter>
			{
				{ titleLabel, TitleSetter },
				{ descriptionLabel, DescriptionSetter },
				{ orderLabel, OrderSetter },
				{ estimateWorkAmountLabel, EstimateWorkAmountSetter },
				{ valueLabel, ValueSetter },
				{ acceptationConditionLabel, AcceptationConditionSetter }
			};

			return formInputs;
		}

		public Dictionary<string, FormTools.ValueGetter> GetFormCurrentInputValues()
		{
			Dictionary<string, FormTools.ValueGetter> formGetters = new Dictionary<string, FormTools.ValueGetter>
			{
				{ titleLabel, TitleGetter },
				{ descriptionLabel, DescriptionGetter },
				{ orderLabel, OrderGetter },
				{ estimateWorkAmountLabel, EstimateWorkAmountGetter },
				{ valueLabel, ValueGetter },
				{ acceptationConditionLabel, AcceptationConditionGetter }
			};

			return formGetters;
		}

		public string GetFormLabel()
		{
			return "Nowy element backlogu";
		}

		#region internalProperties
		internal string TitleLabel => titleLabel;
		internal string DescriptionLabel => descriptionLabel;
		#endregion

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
		private object IsDoneGetter() => isDone;
		
		#endregion
	}
}
