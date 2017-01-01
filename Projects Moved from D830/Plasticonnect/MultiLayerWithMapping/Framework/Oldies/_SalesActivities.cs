using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Common;
using Crm;
using Mapping;
using Plasticonnect.DataAccess;

namespace Regency.Persistent
{
	internal class _SalesActivities: Crm.DataAccess.SchemaSalesActivities
	{
		// ------------------ Private Properties -----------------------------
		private readonly string FixSelectStatement1 = 	
			@"Select * from (
			select
					sa.AccountNumber,
					c.accountName as customername,
					c.status as accountStatus,
					a.recordstate as AddressRecordState, 
					c.SalesRepNumber as salesrep, 
					a.type as addresstype, 
					sa.Author as Author,
					a.postalcode,
					sa.contact as contactname, 
					sa.[id] as ID,
					sa.TypeID, 
					sa.ReferenceID,
					sa.Scheduled, 
					sa.Duration,
					sa.ResultID, 
					sa.SchedulingNotes, 
					sa.CompletionNotes,
					sa.RecordState as SalesActivityRecordState, 
					sa.Status, 
					sa.completed,
					sa.ts,
					sa.SalesRepNumber,
					case when sa.status=0 then scheduled else completed end as ActivityDate,
					case when sa.status=0 then schedulingnotes else completionnotes end as Notes,
					case when sa.status=0 then 'S' else 'C' end as ST,
					case when sa.status=0 then -1 else sa.ResultID end as Result
				from 
					salesactivities sa  
						left join RAM..Accounts c on c.accountNumber=sa.AccountNumber 
						left join RAM..addresses a on a.Accountnumber=c.accountnumber) SalesActivity " ;
		private WhereClause iWhereClause;
		// ------------------ Public Properties -----------------------------
		internal int iCount 
		{
			get 
			{
				return this.SalesActivitiesTable.Rows.Count;
			}
		}

		private SqlConnection connRegency;
		private SqlCommand scBasedonCustomerPageByPage;
		private SqlCommand scBasedonCustomerAndDate;
		private SqlCommand scBasedonUser;
		private SqlCommand scBasedonUserAndCustomer;
		private SqlCommand scBasedonUserAndCustomerPageByPage;
		private SqlCommand scBasedonUserAndDate;
		private SqlCommand scBasedonUserCustomerAndDate;
		private SqlDataAdapter daSalesActivities;
		private SqlCommand sqlSelectCommand1;
		private SqlCommand sqlInsertCommand1;
		private SqlCommand sqlUpdateCommand1;
		private SqlCommand sqlDeleteCommand1;
		private SqlCommand scBasedonDate;

		// ------------------ Initialization -----------------------------
		private void InitializeComponent()
		{
			this.connRegency = new SqlConnection();
			this.scBasedonCustomerPageByPage = new SqlCommand();
			this.scBasedonUser = new SqlCommand();
			this.scBasedonUserAndCustomer = new SqlCommand();
			this.scBasedonUserAndCustomerPageByPage = new SqlCommand();
			this.scBasedonUserAndDate = new SqlCommand();
			this.scBasedonUserCustomerAndDate = new SqlCommand();
			this.scBasedonCustomerAndDate = new SqlCommand();
			this.scBasedonDate = new SqlCommand();
			this.daSalesActivities = new SqlDataAdapter();
			this.sqlDeleteCommand1 = new SqlCommand();
			this.sqlInsertCommand1 = new SqlCommand();
			this.sqlSelectCommand1 = new SqlCommand();
			this.sqlUpdateCommand1 = new SqlCommand();
			((ISupportInitialize)(this)).BeginInit();
			// 
			// scBasedonUser
			// 
            this.scBasedonUser.CommandText = "SELECT ID, case when Status=0 then 'S' else 'C' end as ST, AccountNumber, Author, TypeID, ReferenceID, Scheduled, Completed, Duration, ResultID, SchedulingNotes, CompletionNotes, DateTimeStamp, Recordstate, contact,Status, SalesRepNumber FROM SalesActivities WHERE (Author = @Author) and recordstate=1";
			this.scBasedonUser.Connection = this.connRegency;
			this.scBasedonUser.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			// 
			// scBasedonUserAndCustomer
			// 
            this.scBasedonUserAndCustomer.CommandText = @"SELECT ID, , case when Status=0 then 'S' else 'C' end as ST, AccountNumber, Author, TypeID, ReferenceID, Scheduled, Completed, Duration, ResultID, SchedulingNotes, CompletionNotes,  DateTimeStamp, Recordstate, contact, Status, SalesRepNumber FROM SalesActivities WHERE (Author = @Author) and (AccountNumber=@AccountNumber) and recordstate=1";
			this.scBasedonUserAndCustomer.Connection = this.connRegency;
			this.scBasedonUserAndCustomer.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			this.scBasedonUserAndCustomer.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			// 
			// scBasedonUserAndCustomerPageByPage
			// 
			this.scBasedonUserAndCustomerPageByPage.CommandText = @"declare @top int;select @top=@pagesize*@pagenumber;exec ('select * from (select top ' + @PageSize + ' * from (select top ' + @top + ' * from (SELECT sa.*,c.[Name] as CustomerName FROM SalesActivities sa INNER Join RAM..Accounts c on c.AccountNumber = sa.AccountNumber) aList where Author=' + @Author + ' and AccountNumber=' + @AccountNumber + ' order by Scheduled) t1 '  + ' order by Scheduled desc) t2  order by Scheduled')";
			this.scBasedonUserAndCustomerPageByPage.Connection = this.connRegency;
			this.scBasedonUserAndCustomerPageByPage.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			this.scBasedonUserAndCustomerPageByPage.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			this.scBasedonUserAndCustomerPageByPage.Parameters.Add(new SqlParameter("@pagesize", SqlDbType.Int, 4));
			this.scBasedonUserAndCustomerPageByPage.Parameters.Add(new SqlParameter("@pagenumber", SqlDbType.Int, 4));
			// 
			// scBasedonUserAndDate
			// 
			this.scBasedonUserAndDate.CommandText = @"SELECT duration, Author, sa.*, case when sa.status=0 then 'S' else 'C' end as ST, c.[Name] as CustomerName,a.postalcode as PostalZipCode,c.state as State FROM SalesActivities sa INNER Join RAM..Accounts c on c.AccountNumber = sa.AccountNumber INNER JOIN RAM..addresses a on a.Accountnumber=c.accountnumber where sa.Author=@Author and Scheduled<(@dateto+1) and Scheduled>=@datefrom and a.type=0 and a.recordstate=1 order by Scheduled";
			this.scBasedonUserAndDate.Connection = this.connRegency;
			this.scBasedonUserAndDate.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			this.scBasedonUserAndDate.Parameters.Add(new SqlParameter("@datefrom", SqlDbType.DateTime, 8, "Scheduled"));
			this.scBasedonUserAndDate.Parameters.Add(new SqlParameter("@dateto", SqlDbType.DateTime, 8, "Scheduled"));
			// 
			// scBasedonUserCustomerAndDate
			// 

			this.scBasedonUserCustomerAndDate.CommandText = @"Select duration, Author ,sa.*, case when sa.status=0 then 'S' else 'C' end as ST,c.[Name] as CustomerName, a.postalcode as PostalZipCode,c.state as State FROM SalesActivities sa INNER Join RAM..Accounts c on c.AccountNumber = sa.AccountNumber INNER JOIN addresses a on a.OwnerAccountnumber=c.accountnumber where sa.Author=@Author and AccountNumber=@AccountNumber and Scheduled<(@dateto+1) and Scheduled>=@datefrom and a.type=0  and a.recordstate=1 order by Scheduled";
			this.scBasedonUserCustomerAndDate.Connection = this.connRegency;
			this.scBasedonUserCustomerAndDate.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			this.scBasedonUserCustomerAndDate.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			this.scBasedonUserCustomerAndDate.Parameters.Add(new SqlParameter("@datefrom", SqlDbType.DateTime, 8, "Scheduled"));
			this.scBasedonUserCustomerAndDate.Parameters.Add(new SqlParameter("@dateto", SqlDbType.DateTime, 8, "Scheduled"));
			// 
			// scBasedonCustomerPageByPage
			// 
			this.scBasedonCustomerPageByPage.CommandText = @"declare @top int;select @top=@pagesize*@pagenumber;exec ('select * from (select top ' + @PageSize + ' * from (select top ' + @top + ' * from (sa.*,c.[Name] as CustomerName FROM SalesActivities sa INNER Join RAM..Accounts c on c.AccountNumber = sa.AccountNumber ) aList where AccountNumber=' + @AccountNumber + ' order by Scheduled desc) t1 '  + ' order by Scheduled) t2  order by Scheduled desc')";
			this.scBasedonCustomerPageByPage.Connection = this.connRegency;
			this.scBasedonCustomerPageByPage.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			this.scBasedonCustomerPageByPage.Parameters.Add(new SqlParameter("@pagesize", SqlDbType.Int, 4));
			this.scBasedonCustomerPageByPage.Parameters.Add(new SqlParameter("@pagenumber", SqlDbType.Int, 4));
			// 
			// scBasedonCustomerAndDate
			// 
			this.scBasedonCustomerAndDate.CommandText = @"Select duration, sa.*, case when sa.status=0 then 'S' else 'C' end as ST, c.[Name] as CustomerName, a.postalcode as PostalZipCode,c.state as State FROM SalesActivities sa INNER Join RAM..Accounts c on c.AccountNumber = sa.AccountNumber INNER JOIN addresses a on a.Accountnumber=c.accountnumber where AccountNumber=@AccountNumber and Scheduled<(@dateto+1) and Scheduled>=@datefrom and a.type=0 and a.recordstate=1 order by Scheduled";
			this.scBasedonCustomerAndDate.Connection = this.connRegency;
			this.scBasedonCustomerAndDate.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			this.scBasedonCustomerAndDate.Parameters.Add(new SqlParameter("@datefrom", SqlDbType.DateTime, 8, "Scheduled"));
			this.scBasedonCustomerAndDate.Parameters.Add(new SqlParameter("@dateto", SqlDbType.DateTime, 8, "Scheduled"));
			// 
			// scBasedonDate
			// 
			this.scBasedonDate.CommandText = @"Select duration, sa.*, case when sa.status=0 then 'S' else 'C' end as ST, c.[Name] as CustomerName, a.postalcode as PostalZipCode,c.state as State FROM SalesActivities sa INNER Join RAM..Accounts c on c.AccountNumber = sa.AccountNumber INNER JOIN addresses a on a.Accountnumber=c.accountnumber where Scheduled<(@dateto+1) and Scheduled>=@datefrom and a.type=0 and a.recordstate=1 order by Scheduled";
			this.scBasedonDate.Connection = this.connRegency;
			this.scBasedonDate.Parameters.Add(new SqlParameter("@datefrom", SqlDbType.DateTime, 8, "Scheduled"));
			this.scBasedonDate.Parameters.Add(new SqlParameter("@dateto", SqlDbType.DateTime, 8, "Scheduled"));

			// 
			// daSalesActivities
			// 
			this.daSalesActivities.DeleteCommand = this.sqlDeleteCommand1;
			this.daSalesActivities.InsertCommand = this.sqlInsertCommand1;
			this.daSalesActivities.SelectCommand = this.sqlSelectCommand1;
			this.daSalesActivities.TableMappings.AddRange(new DataTableMapping[] {
				new DataTableMapping("Table", "SalesActivities", new DataColumnMapping[] {
					new DataColumnMapping("ID", "ID"),
					new DataColumnMapping("AccountNumber", "AccountNumber"),
					new DataColumnMapping("Author", "Author"),
					new DataColumnMapping("contact", "contact"),
					new DataColumnMapping("TypeID", "TypeID"),
					new DataColumnMapping("ReferenceID", "ReferenceID"),
					new DataColumnMapping("Scheduled", "Scheduled"),
					new DataColumnMapping("Duration", "Duration"),
					new DataColumnMapping("ResultID", "ResultID"),
					new DataColumnMapping("SchedulingNotes", "SchedulingNotes"),
					new DataColumnMapping("CompletionNotes", "CompletionNotes"),
					new DataColumnMapping("RecordState", "RecordState"),
					new DataColumnMapping("Status", "Status"),
					new DataColumnMapping("Completed", "Completed"),
					new DataColumnMapping("SalesRepNumber", "SalesRepNumber")})});
			this.daSalesActivities.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
            this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.SalesActivities WHERE (ID = @Original_ID) AND (Completed = @Original_Completed OR @Original_Completed IS NULL AND Completed IS NULL) AND (CompletionNotes = @Original_CompletionNotes OR @Original_CompletionNotes IS NULL AND CompletionNotes IS NULL) AND (contact = @Original_contact) AND (AccountNumber = @Original_AccountNumber) AND (Duration = @Original_Duration) AND (RecordState = @Original_RecordState) AND (ReferenceID = @Original_ReferenceID) AND (ResultID = @Original_ResultID) AND (Scheduled = @Original_Scheduled OR @Original_Scheduled IS NULL AND Scheduled IS NULL) AND (SchedulingNotes = @Original_SchedulingNotes OR @Original_SchedulingNotes IS NULL AND SchedulingNotes IS NULL) AND (Status = @Original_Status) AND (TypeID = @Original_TypeID) AND (SalesRepNumber = @Original_SalesRepNumber)";
			this.sqlDeleteCommand1.Connection = this.connRegency;
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ID", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_Completed", SqlDbType.DateTime, 8, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Completed", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_CompletionNotes", SqlDbType.VarChar, 2000, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "CompletionNotes", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_contact", SqlDbType.VarChar, 65, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "contact", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_AccountNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "AccountNumber", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_Duration", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Duration", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_RecordState", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "RecordState", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_ReferenceID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ReferenceID", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_ResultID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ResultID", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_Author", SqlDbType.VarChar, 70, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Author", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_Scheduled", SqlDbType.DateTime, 8, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Scheduled", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_SchedulingNotes", SqlDbType.VarChar, 2000, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "SchedulingNotes", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Status", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_TypeID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "TypeID", DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_SalesRepNumber", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "SalesRepNumber", DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
            this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.SalesActivities(AccountNumber, Author, contact, TypeID, ReferenceID, Scheduled, Duration, ResultID, SchedulingNotes, CompletionNotes, RecordState, Status, Completed, SalesRepNumber) VALUES (@AccountNumber, @Author, @contact, @TypeID, @ReferenceID, @Scheduled, @Duration, @ResultID, @SchedulingNotes, @CompletionNotes, @RecordState, @Status, @Completed, @SalesRepNumber); SELECT ID, AccountNumber, Author, contact, TypeID, ReferenceID, Scheduled, Duration, ResultID, SchedulingNotes, CompletionNotes, RecordState, Status, Completed, SalesRepNumber FROM dbo.SalesActivities WHERE (ID = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.connRegency;
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@contact", SqlDbType.VarChar, 65, "contact"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.SmallInt, 2, "TypeID"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@ReferenceID", SqlDbType.SmallInt, 2, "ReferenceID"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@Scheduled", SqlDbType.DateTime, 8, "Scheduled"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@Duration", SqlDbType.Int, 4, "Duration"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@ResultID", SqlDbType.SmallInt, 2, "ResultID"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@SchedulingNotes", SqlDbType.VarChar, 2000, "SchedulingNotes"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@CompletionNotes", SqlDbType.VarChar, 2000, "CompletionNotes"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@RecordState", SqlDbType.Int, 4, "RecordState"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@Status", SqlDbType.SmallInt, 2, "Status"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@Completed", SqlDbType.DateTime, 8, "Completed"));
            this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@SalesRepNumber", SqlDbType.SmallInt, 2, "SalesRepNumber"));
			// 
			// sqlSelectCommand1
			// 
            this.sqlSelectCommand1.CommandText = "SELECT ID, AccountNumber, Author, contact, TypeID, ReferenceID, Scheduled, Duration, ResultID, SchedulingNotes, CompletionNotes, RecordState, Status, Completed, SalesRepNumber FROM dbo.SalesActivities WHERE (AccountNumber = @AccountNumber)";
			this.sqlSelectCommand1.Connection = this.connRegency;
			this.sqlSelectCommand1.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			// 
			// sqlUpdateCommand1
			// 
            this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.SalesActivities SET AccountNumber = @AccountNumber, Author = @Author, contact = @contact, TypeID = @TypeID, ReferenceID = @ReferenceID, Scheduled = @Scheduled, Duration = @Duration, ResultID = @ResultID, SchedulingNotes = @SchedulingNotes, CompletionNotes = @CompletionNotes, RecordState = @RecordState, Status = @Status, Completed = @Completed, SalesRepNumber = @SalesRepNumber WHERE (ID = @Original_ID) AND (Completed = @Original_Completed OR @Original_Completed IS NULL AND Completed IS NULL) AND (CompletionNotes = @Original_CompletionNotes OR @Original_CompletionNotes IS NULL AND CompletionNotes IS NULL) AND (contact = @Original_contact) AND (AccountNumber = @Original_AccountNumber) AND (Duration = @Original_Duration) AND (RecordState = @Original_RecordState) AND (ReferenceID = @Original_ReferenceID) AND (ResultID = @Original_ResultID) AND (Author = @Original_Author) AND (Scheduled = @Original_Scheduled OR @Original_Scheduled IS NULL AND Scheduled IS NULL) AND (SchedulingNotes = @Original_SchedulingNotes OR @Original_SchedulingNotes IS NULL AND SchedulingNotes IS NULL) AND (Status = @Original_Status) AND (TypeID = @Original_TypeID AND (SalesRepNumber = @Original_SalesRepNumber); SELECT ID, AccountNumber, Author, contact, TypeID, ReferenceID, Scheduled, Duration, ResultID, SchedulingNotes, CompletionNotes, RecordState, Status, Completed, SalesRepNumber FROM dbo.SalesActivities WHERE (ID = @ID)";
			this.sqlUpdateCommand1.Connection = this.connRegency;
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Author", SqlDbType.VarChar, 70, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Author", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@contact", SqlDbType.VarChar, 65, "contact"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.SmallInt, 2, "TypeID"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@ReferenceID", SqlDbType.SmallInt, 2, "ReferenceID"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Scheduled", SqlDbType.DateTime, 8, "Scheduled"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Duration", SqlDbType.Int, 4, "Duration"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@ResultID", SqlDbType.SmallInt, 2, "ResultID"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@SchedulingNotes", SqlDbType.VarChar, 2000, "SchedulingNotes"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@CompletionNotes", SqlDbType.VarChar, 2000, "CompletionNotes"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@RecordState", SqlDbType.Int, 4, "RecordState"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Status", SqlDbType.SmallInt, 2, "Status"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Completed", SqlDbType.DateTime, 8, "Completed"));
            this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@SalesRepNumber", SqlDbType.SmallInt, 2, "SalesRepNumber"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ID", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Completed", SqlDbType.DateTime, 8, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Completed", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_CompletionNotes", SqlDbType.VarChar, 2000, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "CompletionNotes", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_contact", SqlDbType.VarChar, 65, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "contact", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_AccountNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "AccountNumber", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Duration", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Duration", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_RecordState", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "RecordState", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_ReferenceID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ReferenceID", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_ResultID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ResultID", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Scheduled", SqlDbType.DateTime, 8, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Scheduled", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_SchedulingNotes", SqlDbType.VarChar, 2000, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "SchedulingNotes", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Status", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_TypeID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "TypeID", DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_SalesRepNumber", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "SalesRepNumber", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, "ID"));
			((ISupportInitialize)(this)).EndInit();
		}
	
		
		// ------------------ Constructors Section -------------------------
		internal _SalesActivities()
		{
		}

		internal void findByStatus(FilterSalesActivitiesStatus pStatus)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
		}
		internal void findByStatusFromToDate(FilterSalesActivitiesStatus pStatus, DateTime pDateFrom, DateTime pDateTo)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
			iWhereClause.Add("ActivityDate<cast('" + pDateTo.ToString("MMMM dd yyyy") + "' as datetime) + 1");
			iWhereClause.Add("ActivityDate>=cast('" + pDateFrom.ToString("MMMM dd yyyy") + "' as datetime)");
		}
		internal void findByStatusOwnerAccount(FilterSalesActivitiesStatus pStatus, int accountNumber)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
			iWhereClause.Add("AccountNumber =" + accountNumber);
		}
		internal void findByStatusOwnerAccountFromToDate(FilterSalesActivitiesStatus pStatus, int ownerAccountNumber, DateTime pDateFrom, DateTime pDateTo)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
			iWhereClause.Add("AccountNumber =" + ownerAccountNumber);
			iWhereClause.Add("ActivityDate<cast('" + pDateTo.ToString("MMMM dd yyyy") + "' as datetime) + 1");
			iWhereClause.Add("ActivityDate>=cast('" + pDateFrom.ToString("MMMM dd yyyy") + "' as datetime)");
		}
		internal void findByStatusOwnerAccountOwnerAuthor(FilterSalesActivitiesStatus pStatus, int ownerAccountNumber, string pOwnerAuthor)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
			iWhereClause.Add("AccountNumber =" + ownerAccountNumber);
			iWhereClause.Add("Author ='" + pOwnerAuthor + "'");
		}
		internal void findByStatusOwnerAccountOwnerAuthorFromToDate(FilterSalesActivitiesStatus pStatus, int ownerAccountNumber, string pOwnerAuthor, DateTime pDateFrom, DateTime pDateTo)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
			iWhereClause.Add("AccountNumber =" + ownerAccountNumber);
			iWhereClause.Add("Author ='" + pOwnerAuthor + "'");
			iWhereClause.Add("ActivityDate<cast('" + pDateTo.ToString("MMMM dd yyyy") + "' as datetime) + 1");
			iWhereClause.Add("ActivityDate>=cast('" + pDateFrom.ToString("MMMM dd yyyy") + "' as datetime)");
		}

		internal void findByStatusOwnerSalesRep(FilterSalesActivitiesStatus pStatus, short salesRepNumber)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
			iWhereClause.Add("salesRepNumber ='" + salesRepNumber + "'");
		}

        internal void findByStatusOwnerSalesRepFromToDate(FilterSalesActivitiesStatus pStatus, string author, DateTime pDateFrom, DateTime pDateTo)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  
					
			iWhereClause = new WhereClause();
			iWhereClause.Add((int)pStatus);
//			iWhereClause.Add("salesRepNumber ='" + salesRepNumber + "'");
			iWhereClause.Add("author ='" + author + "'");
			iWhereClause.Add("ActivityDate<cast('" + pDateTo.ToString("MMMM dd yyyy") + "' as datetime) + 1");
			iWhereClause.Add("ActivityDate>=cast('" + pDateFrom.ToString("MMMM dd yyyy") + "' as datetime)");
		}
		

		// ------------------ Actions Section -------------------------------
		internal void Save(int ownerAccountNumber, string pAuthor)
		{
			try
			{
				foreach (DataRow dr in this.Tables[0].Rows)
				{
					dr["AccountNumber"] = ownerAccountNumber;
					dr["Author"]=pAuthor;
				}
				daSalesActivities.Update(this);
			}
			catch(IndexOutOfRangeException)
			{
				// TODO: add system log here
			}
			catch(NullReferenceException)
			{
				// TODO: add system log here
			}
			// TODO: add system log here
		}

		// -------------------------------------------------
		internal void Fill(bool pDescending)
		{
			getDataAdapter(pDescending).Fill(this, SalesActivitiesTable.TableName);
		}

		internal void Fill(int PageSize, int PageNumber, bool pDescending)
		{
			getDataAdapter(pDescending).Fill(this, (((PageNumber-1)*PageSize)), PageSize, SalesActivitiesTable.TableName);
		}

		private SqlDataAdapter getDataAdapter(bool pDescending)
		{
			iWhereClause.Add("addressType=0");
			iWhereClause.Add("addressRecordState=1");

			string selectStatement = FixSelectStatement1;
			selectStatement += iWhereClause.ToString();

			SqlDataAdapter da = new SqlDataAdapter();
			SqlCommand sc = new SqlCommand();
			sc.Connection = connRegency;
			sc.CommandType = CommandType.Text;
			string scGetCountStatement = selectStatement;
			sc.CommandText = selectStatement + " order by ActivityDate " + (pDescending?"desc":"") + ", [ID] ;select count(*) from (" + scGetCountStatement + ") t0";
			da.SelectCommand = sc;

			return da;
		}

		/// <summary>
		/// counts activty due to given parameters
		/// </summary>
        /// <param name="salesRepNumber">count activity of salesRep with this salesRepNumber, pass -1 for don't care</param>
		/// <param name="activityTypes">count activity of these types, pass null for don't care, pass empty array for counting null values</param>
		/// <param name="activityResults">count activity with these activityResult, pass null for don't care, pass empty array for counting null values</param>
		public static int getActivityCount(short salesRepNumber, ActivityType[] activityTypes, SalesActivityResult[] activityResults)
		{
			SqlCommand command = new SqlCommand();
			string query = @"select count(*) from SalesActivities";
			WhereClause whereClause = new WhereClause();
			if (salesRepNumber != -1)
			{
                whereClause.Add("SalesRepNumber = @SalesRepNumber");
                command.Parameters.AddWithValue("@SalesRepNumber", salesRepNumber);
			}
			if (activityTypes != null)
			{
				if (activityTypes.Length == 0)
				{
					whereClause.Add("TypeID is null");
				}
				else
				{
					WhereClauseOrStatement orStatement = new WhereClauseOrStatement();
					for (int i = 0; i < activityTypes.Length; i++)
					{
						ActivityType type = activityTypes[i];
						orStatement.addStatement("TypeID = @TypeID" + i);
						command.Parameters.AddWithValue("@TypeID" + i, (int) (type));
					}
					whereClause.Add(orStatement.ToString());
				}
			}
			if (activityResults != null)
			{
				if (activityResults.Length == 0)
				{
					whereClause.Add("ResultID is null");
				}
				else
				{
					WhereClauseOrStatement orStatement = new WhereClauseOrStatement();
					for (int i = 0; i < activityResults.Length; i++)
					{
					    SalesActivityResult result = activityResults[i];
						orStatement.addStatement("ResultID = @ResultID" + i);
						command.Parameters.AddWithValue("@ResultID" + i, (int) (result));
					}
					whereClause.Add(orStatement.ToString());
				}
			}
			if (whereClause.ToString() != "")
				query += " " + whereClause.ToString();
			command.CommandText = query;
			command.Connection = new SqlConnection(Config.GetConnectionString());
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataTable table = new DataTable();
			adapter.Fill(table);
			return (int) table.Rows[0][0];
		}
	}

}
