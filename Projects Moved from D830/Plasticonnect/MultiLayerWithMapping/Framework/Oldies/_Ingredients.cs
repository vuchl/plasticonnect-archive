using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Common;

namespace Regency.Persistent
{
	/// <summary>
	/// Summary description for _Ingredients.
	/// </summary>
	internal class _Ingredients : Schema.Ingredients
	{
		
		private SqlConnection regencyRefConnection;
		private SqlDataAdapter ingredientDataAdapter;
		private SqlCommand selectCommand;
		
		internal int iCount 
		{
			get {return ingredientsDataTable.Rows.Count;}
		}

		private void InitializeComponent()
		{
			regencyRefConnection = new SqlConnection(Config.GetRegencyRefConnectionString());
			ingredientDataAdapter = new SqlDataAdapter();
			selectCommand = new SqlCommand();
			BeginInit();
			// 
			// ingredientDataAdapter
			// 
			ingredientDataAdapter.SelectCommand = selectCommand;
			ingredientDataAdapter.SelectCommand.Connection = regencyRefConnection;
			ingredientDataAdapter.TableMappings.AddRange(new DataTableMapping[] {
					new DataTableMapping("Table", "Ingredients", new DataColumnMapping[] {
							new DataColumnMapping("sorter", "sorter"),
							new DataColumnMapping("orderDetailNumber", "orderDetailNumber"),
							new DataColumnMapping("component", "component"),
							new DataColumnMapping("percentage", "percentage"),
							new DataColumnMapping("cost", "cost"),
							new DataColumnMapping("inventoryClass", "inventoryClass")})});
			// 
			// selectCommand
			// 
			selectCommand.CommandText = "SELECT * FROM Ingredients where orderDetailNumber = @orderDetailNumber order by sorter";
			selectCommand.Connection = regencyRefConnection;
			selectCommand.Parameters.Add(new SqlParameter("@orderDetailNumber", SqlDbType.Int, 4, "orderDetailNumber"));
			EndInit();
		}

		public void fillByOrderDetailNumber(int orderDetailNumber)
		{
			InitializeComponent();
			selectCommand.Parameters["@orderDetailNumber"].Value = orderDetailNumber;
			ingredientDataAdapter.Fill(this);
		}
	}
}
