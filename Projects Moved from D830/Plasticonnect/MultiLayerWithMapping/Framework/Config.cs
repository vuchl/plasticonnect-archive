using System.Data.SqlClient;

namespace Plasticonnect.DataAccess
{

    /// <summary>
    /// This class provide developers with Connection strings to the new and old databases
    /// </summary>
	public static class Config
	{
		public static string GetConnectionString()
		{
			return Properties.Settings.Default.connRegency;
		}

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(GetConnectionString());
		}

		public static string GetRegencyRefConnectionString()
		{
			return Properties.Settings.Default.connRegencyRef;
		}
	}
}