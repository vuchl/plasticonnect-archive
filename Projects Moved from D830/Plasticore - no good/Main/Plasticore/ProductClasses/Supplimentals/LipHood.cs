using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Indicates whether the product has a Lip or Hood and if whether the Hood is in or out
	/// </summary>
	public class LipHood
	{
		/// <summary>
		/// gets/sets the type of the Lip or Hood of the product
		/// </summary>
		public HoodType Type { get; set; }

		/// <summary>
		/// gets/set the size of lip in inches
		/// </summary>
		public decimal LipSize { get; set; }

		/// <summary>
		/// gets/set the size of hood in inches
		/// </summary>
		public decimal HoodSize { get; set; }

		/// <summary>
		/// string representation of Lip/Hood
		/// </summary>
		public override string ToString()
		{
			string returnValue = "";
			if (Type == HoodType.HoodIn || Type == HoodType.HoodOut)
				returnValue = string.Format("{0}\" {1}, ", HoodSize, RichEnum.GetDescription(Type));

			if (LipSize > 0)
				returnValue += string.Format("+{0}\" lip, ", LipSize);

			return returnValue;
		}

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Invalid Hood Size")]
		private bool AddValidationRules()
		{
			return (Type == HoodType.None) || (HoodSize > 0.0m);
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}
