namespace Plasticonnect.Engine
{
	/// <summary>
	/// Gauge keeps the measurable thickness of a product.
	/// </summary>
	public class Gauge
	{
		private bool AddValidationRules()
		{
			// "Gauge has to be between 0.0007mil and 0.01mil"
			return Size >= .0007m && Size <= .01m;
		}

		/// <summary>
		/// Size of the Gauge
		/// </summary>
		public decimal Size { get; set; }

		/// <summary>
		/// Indicates whether the gauge is full or not
		/// </summary>
		public bool FullGauge { get; set; }

		/// <summary>
		/// Returns the netSize of the Gauge
		/// </summary>
		public decimal Net
		{
			get
			{
				decimal netSize = FullGauge ? Size : (Size * 0.9m);
				return netSize < .0007m ? .0007m : netSize;
			}
		}

		/// <summary>
		/// Returns a string that represents the Gauge in product description
		/// </summary>
		/// <returns>Examples: 
		///				if fullGauge: 0.00125 mil (Full)
		///				else: 0.00125 mil
		/// </returns>
		public override string ToString()
		{
			return Size.ToString("0.#######") + " mil" + (FullGauge ? " (Full)" : "");
		}

		/// <summary>
		/// Conversion map of Gauge and Thickness
		/// </summary>
		internal static Thickness ConvertToThickness(decimal gaugeValue)
		{
			if (gaugeValue == 0.00085m)
				return Thickness.Light;
			if (gaugeValue == 0.00265m)
				return Thickness.Heavy;
			if (gaugeValue == 0.00165m)
				return Thickness.Medium;
			if (gaugeValue == 0.0007m)
				return Thickness.Utility;
			if (gaugeValue == 0.00672m)
				return Thickness.Super;
			if (gaugeValue == 0.006m)
				return Thickness.Cgsb;
			return Thickness.Unknown;
		}

		/// <summary>
		/// Conversion map of Gauge and Thickness
		/// </summary>
		internal static decimal ConvertToDecimal(Thickness value)
		{
			switch (value)
			{
				case Thickness.Light:
					return 0.00085m;
				case Thickness.Heavy:
					return 0.00265m;
				case Thickness.Medium:
					return 0.00165m;
				case Thickness.Utility:
					return 0.0007m;
				case Thickness.Super:
					return 0.00672m;
				case Thickness.Cgsb:
					return 0.006m;
				default:
					return 0.0m;
			}
		}
	}
}
