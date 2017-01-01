using System;


namespace ConsoleTester
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Triggers.BindWorkFlowTriggers();


			const string accountNumber = "12345";

/*
			var draft = Scenarios.GetTheActiveDraftForAnAccountNumber(accountNumber);
			Scenarios.EditDraft(draft);
*/
		}
	}
}
