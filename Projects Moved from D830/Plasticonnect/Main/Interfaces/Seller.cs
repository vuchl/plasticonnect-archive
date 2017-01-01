namespace Plasticonnect.Engine
{
	public class Seller
	{
		public int MaximumWidth { get; set; }
		public int MinimumWidth { get; set; }
		public bool ProvidesMicrovents { get; set; }
		public bool ProvidesProductHoles { get; set; }
		public bool ProvidesPrinting { get; set; }
		public string PrintingProperties { get; set; } // todo: define printing properties
	}
}
