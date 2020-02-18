using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AgileRunner
{
	public class PartialIncrement
	{
		private readonly ScrumSprint origin;
		private readonly List<BacklogItem> increment;

		public PartialIncrement(ScrumSprint origin, List<BacklogItem> increment)
		{
			this.origin = origin;
			this.increment = increment;
		}

		public bool GeneratePartialIncrementRaport()
		{
			bool success = false;
			string sprintName = origin.GetSprintName();
			string filePath = $"./raports/{sprintName}.txt";

			if(!File.Exists(filePath))
			{
				using(var stream = File.CreateText(filePath))
				{
					var separatorLength = sprintName.Length;
					stream.WriteLine(new string('_', separatorLength));
					stream.WriteLine($"{sprintName}");
					stream.WriteLine(new string('-', separatorLength));

					foreach(var incrementItem in increment)
					{
						stream.WriteLine(
							GetPartialIncrementItemInformation(incrementItem)
						);
					}

					stream.WriteLine(new string('_', separatorLength));
				}
			}

			return success;
		}

		private string GetPartialIncrementItemInformation(BacklogItem item)
		{
			string itemInformation = "";

			var itemInputs = item.GetFormCurrentInputValues();

			itemInformation += $"{itemInputs[item.TitleLabel]()}\n";
			itemInformation += $"{itemInputs[item.DescriptionLabel]()}\n";

			return itemInformation;
		}
	}
}