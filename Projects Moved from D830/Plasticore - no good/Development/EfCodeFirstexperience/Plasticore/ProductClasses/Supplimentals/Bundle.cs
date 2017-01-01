using System.ComponentModel.DataAnnotations;
using Plasticonnect;

namespace Plasticore
{
	/// <summary>
	/// Defines all the properties of a bundle 
	/// LooseBags can be Bundled
	/// </summary>
	public class Bundle
	{
		/// <summary>
		/// Indicates type of the bundle
		/// Refer to BundleType enumerator for possible choices
		/// </summary>
		public BundleType BundleType
		{
			get { return (BundleType) EnumHelper_BundleType; }
			set { EnumHelper_BundleType = (int) value; }
		}

		[Column("Bundle_Type")]
		public int EnumHelper_BundleType { get; internal set; }

		/// <summary>
		/// Number of bags per bundle
		/// </summary>
		public short BagCount { get; set; }

		/// <summary>
		/// Size of the wicket (if wicketted)
		/// Refer to <see cref="WicketSize"/> for possible choices
		/// </summary>
		public WicketSize WicketSize
		{
			get { return (WicketSize) EnumHelper_WicketSize; }
			set { EnumHelper_WicketSize = (int) value; }
		}

		[Column("Bundle_WicketSize")]
		public int EnumHelper_WicketSize { get; internal set; }

		/// <summary>
		/// Creates a string that is the written presentation of the Bundle class
		/// This string is the description that is used in the product description text
		/// </summary>
		/// <returns>string presentation of the Bundle class</returns>
		public override string ToString()
		{
			switch (BundleType)
			{
				case BundleType.HotRod:
					string bagCountString = BagCount == 0 ? "" : string.Format("{0} bags ", BagCount);
					return string.Format("[Bundle: {0}Hot-Rod] ", bagCountString);

				case BundleType.Wicketed:
					if (BagCount == 0)
						return
							string.Format("[Bundle: wicketted {0}] ",
										  (WicketSize != WicketSize.SelectWicket ? (" bags on " + RichEnum.GetDescription(WicketSize)) : ""));
					return string.Format("[Bundle: {0} wicketted bags on {1}] ", BagCount, RichEnum.GetDescription(WicketSize));

				default:
					return "";
			}
		}
	}
}
