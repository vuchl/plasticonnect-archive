using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace Regency.Persistent
{
	internal class _SalesActivityStatistics: DataSet
	{
		#region Private Properties
		private DataRow currentRow;
		#endregion

		#region Public Properties
		internal int iCountCallSWC
		{
			get 
			{
				return (Int32)(currentRow["CallSWC"]);
			}
		}
		internal int iCountCallDSC
		{
			get 
			{
				return (Int32)(currentRow["CallDSC"]);
			}
		}
		internal int iCountAppointmentSWC
		{
			get 
			{
				return (Int32)(currentRow["ApptSWC"]);
			}
		}
		internal int iCountAppointmentDSC
		{
			get 
			{
				return (Int32)(currentRow["ApptDSC"]);
			}
		}

		internal int iCountQTS 
		{
			get 
			{
				return (Int32)(currentRow["QTS"]);
			}
		}
		internal int iYear
		{
			get 
			{
				return (Int32)(currentRow["Year"]);
			}
		}
		internal int iMonth
		{
			get 
			{
				return (Int32)(currentRow["Month"]);
			}
		}
		internal int iDay
		{
			get 
			{
				return (Int32)(currentRow["Day"]);
			}
		}
		#endregion

		#region initialization
		private SqlDataAdapter daSaleActivityStatistics;
		private SqlCommand scGetSalesActivityStatistics;
		private SqlConnection connRegency;

		private void InitializeComponent()
		{
			this.daSaleActivityStatistics = new SqlDataAdapter();
			this.connRegency = new SqlConnection();
			this.scGetSalesActivityStatistics = new SqlCommand();
			((ISupportInitialize)(this)).BeginInit();

			daSaleActivityStatistics.SelectCommand = scGetSalesActivityStatistics;
			// 
			// scGetSalesActivityStatistics
			// 
			this.scGetSalesActivityStatistics.CommandText = 
			" select " + 
			" 	year, " +   
			" 	month, " +   
			" 	day, " +    
			" 	isnull(CallSWC,0) as CallSWC, " +   
			" 	isnull(CallDSC,0) as CallDSC, " + 
			" 	isnull(ApptSWC,0) as ApptSWC, " +	
			" 	isnull(ApptDSC,0) as ApptDSC, " +
			" 	0 as QTS " +   
			" from " +
			" ( " +
			" 	select " + 
			" 		isnull(result012.year, result3.year) as year, " +   
			" 		isnull(result012.month, result3.month) as month, " +   
			" 		isnull(result012.day, result3.day) as day, " +    
			" 		result012.CallSWC, " +   
			" 		result012.CallDSC, " +
			" 		result012.ApptSWC, " +	
			" 		countResult3 as ApptDSC, " +
			" 		0 as QTS " +   
			" 	from " +
			" 	( " +	
			" 		select " + 
			" 			isnull(result01.year, result2.year) as year, " +   
			" 			isnull(result01.month, result2.month) as month, " +   
			" 			isnull(result01.day, result2.day) as day, " +    
			" 			result01.CallSWC, " +   
			" 			result01.CallDSC, " +
			" 			countResult2 as ApptSWC, " +
			" 			0 as QTS " +   
			" 		from " + 
			" 		( " +
			" 			select " + 
			" 				isnull(result0.year, result1.year) as year, " +   
			" 				isnull(result0.month, result1.month) as month, " +   
			" 				isnull(result0.day, result1.day) as day, " +    
			" 				countResult0 as CallSWC, " +   
			" 				countResult1 as CallDSC, " +
			" 				0 as QTS " +  
			" 			from " +   
			" 			( " +  
			" 				select " +   
			" 					datepart(year, completed) as year, " +   
			" 					datepart(month, completed) as month, " +   
			" 					datepart(day, completed) as day, " +   
			" 					count(*) as countResult0 " +   
			" 				from " +   
			" 					salesActivities " +   
			" 				where " +   
			" 					status = 1 and " +
            " 					(SalesRepNumber = @SalesRepNumber) and " +   
			" 					(completed between @fromDate and @toDate) and " +   
			" 					typeid=0 and resultid=1 " + 
			" 				group by " +   
			" 					datepart(year, completed), " +  
			" 					datepart(month, completed), " +   
			" 					datepart(day, completed) " +  
			" 			) result0 " +   
			" 			full outer join " +   
			" 			( " +  
			" 				select " +   
			" 					datepart(year, completed) as year, " +   
			" 					datepart(month, completed) as month, " +   
			" 					datepart(day, completed) as day, " +   
			" 					count(*) as countResult1 " +   
			" 				from " +   
			" 					salesActivities " +   
			" 				where " +   
			" 					status = 1 and " +
            " 					(SalesRepNumber = @SalesRepNumber) and " +   
			" 					(completed between @fromDate and @toDate) and " +   
			" 					typeid=0 and resultid=0 " + 
			" 				group by " +   
			" 					datepart(year, completed), " +   
			" 					datepart(month, completed), " +   
			" 					datepart(day, completed) " +  
			" 			) result1 " +   
			" 			on " +   
			" 			(result0.[year] = result1.[year] and " +   
			" 			result0.[month] = result1.[month] and " +   
			" 			result0.[day] = result1.[day]) " +   
			" 		) result01 " +
			" 		full outer join " +   
			" 		( " +  
			" 			select " +   
			" 				datepart(year, completed) as year, " +   
			" 				datepart(month, completed) as month, " +   
			" 				datepart(day, completed) as day, " +   
			" 				count(*) as countResult2 " +   
			" 			from " +   
			" 				salesActivities " +   
			" 			where " +   
			" 				status = 1 and " +
            " 				(SalesRepNumber = @SalesRepNumber)  and " +   
			" 				(completed between @fromDate and @toDate) and " +   
			" 				typeid=1 and resultid=1 " + 
			" 			group by " +   
			" 				datepart(year, completed), " +   
			" 				datepart(month, completed), " +   
			" 				datepart(day, completed) " +  
			" 		) result2 " +   
			" 		on " +   
			" 		(result01.[year] = result2.[year] and " +   
			" 		result01.[month] = result2.[month] and " +   
			" 		result01.[day] = result2.[day]) " +   
			" 	) result012 " +
			" 	full outer join " +   
			" 	( " +  
			" 		select " +   
			" 			datepart(year, completed) as year, " +   
			" 			datepart(month, completed) as month, " +   
			" 			datepart(day, completed) as day, " +   
			" 			count(*) as countResult3 " +   
			" 		from " +   
			" 			salesActivities " +   
			" 		where " +   
			" 			status = 1 and " +
            " 			(SalesRepNumber = @SalesRepNumber)  and " +   
			" 			(completed between @fromDate and @toDate) and " +   
			" 			typeid=1 and resultid=0 " + 
			" 		group by " +   
			" 			datepart(year, completed), " +   
			" 			datepart(month, completed), " +   
			" 			datepart(day, completed) " +  
			" 	) result3 " + 
			" 	on " +   
			" 	(result012.[year] = result3.[year] and " +   
			" 	result012.[month] = result3.[month] and " +   
			" 	result012.[day] = result3.[day]) " + 
			" ) result0123 ";
			this.scGetSalesActivityStatistics.Connection = this.connRegency;
            this.scGetSalesActivityStatistics.Parameters.Add(new SqlParameter("@SalesRepNumber", SqlDbType.SmallInt, 2, "SalesRepNumber"));
			this.scGetSalesActivityStatistics.Parameters.Add(new SqlParameter("@fromDate", SqlDbType.DateTime));
			this.scGetSalesActivityStatistics.Parameters.Add(new SqlParameter("@toDate", SqlDbType.DateTime));

			((ISupportInitialize)(this)).EndInit();
		}
	
		#endregion

		#region Constructors
		internal _SalesActivityStatistics(short salesRepNumber, DateTime fromDate, DateTime toDate)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();

            scGetSalesActivityStatistics.Parameters["@SalesRepNumber"].Value = salesRepNumber;
			scGetSalesActivityStatistics.Parameters["@fromDate"].Value = fromDate;
			scGetSalesActivityStatistics.Parameters["@toDate"].Value = toDate;
			daSaleActivityStatistics.Fill(this);
		}

		#endregion

		#region Actions
		internal bool selectDay(DateTime day)
		{
			DataRow[] drRetCollection = Tables[0].Select("day = " + day.Day.ToString() + " and month = " + day.Month.ToString() + " and year = " + day.Year.ToString());
			if (drRetCollection.Length > 0)
			{
				currentRow = drRetCollection[0];
				return true;
			}
			else
			{
				currentRow = null;
				return false;
			}
		}
		#endregion
	}
}