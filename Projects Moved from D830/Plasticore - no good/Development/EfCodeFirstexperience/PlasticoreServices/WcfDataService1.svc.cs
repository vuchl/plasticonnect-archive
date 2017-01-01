using System.Data.Services;
using System.Data.Services.Common;

namespace PlasticoreServices
{
	[System.ServiceModel.ServiceBehavior(
	IncludeExceptionDetailInFaults = true)]
	public class WcfDataService1 : DataService<Plasticore.TestingContext>
	{
		// This method is called only once to initialize service-wide policies.
		public static void InitializeService(DataServiceConfiguration config)
		{
			// TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
			// Examples:
			//config.SetEntitySetAccessRule("Rfqs", EntitySetRights.AllRead);
			// config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
			config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
		}
	}
}
