using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Crm.DataAccess;
using Plasticonnect.DataAccess;

namespace Regency.Persistent
{
	/// <summary>
	/// Summary description for Conatct.
	/// </summary>
	internal class _SalesActivity	: Schema.SalesActivities
	{
		// ------------------ Private Properties -----------------------------
		private Account				iCustomer;
		private SalesActivityReference	iActivityReference;
		private SalesActivityResult		iActivityResult;
		private SchemaSalesActivities.SalesActivitiesRow	currentRow;
		// ------------------ Public Properties -----------------------------
		internal int id
		{
			get{ return currentRow.ID; }
		}
		internal int IAccountNumber
		{
			get{ return currentRow.AccountNumber; }
			set{ currentRow.AccountNumber = value; }
		}
		internal string iContact
		{
			get{ return currentRow.Contact; }
			set{ currentRow.Contact = value; }
		}
		internal string iAuthor
		{
			get { return currentRow.Author; }
			set { currentRow.Author = value; }
		}
		internal Account iOwnerCustomer
		{
			get
			{
				if (iCustomer==null && IAccountNumber!=-1) 
				{
					iCustomer = AccountTools.FindByAccountNumber(IAccountNumber);
				}
				return iCustomer;
			}
			set
			{
				IAccountNumber = value.AccountNumber;  
				iCustomer = value; 
			}
		}
		internal short iSalesrep
		{
			get { return currentRow.SalesRepNumber; }
			set { currentRow.SalesRepNumber = value; }
		}
		internal short iType
		{
			get{ return (Int16)this.SalesActivitiesTable[0].TypeID; }
			set{ this.SalesActivitiesTable[0].TypeID = value; }
		}
		internal SalesActivityReference iReference
		{
			get{return iActivityReference; }
			set{iActivityReference = value; }
		}

		internal SalesActivityResult iResult
		{
			get{ return iActivityResult; }
			set{ iActivityResult = value; }
		}

		internal DateTime iScheduled
		{
			get { return currentRow.Scheduled; }
			set{ currentRow.Scheduled = value; }
		}
		internal DateTime iCompleted
		{
			get {
			    try
			    {
			        return currentRow.Completed;
			    }
                catch (StrongTypingException)
			    {
			        return DateTime.MaxValue;
			    }
			}
			set{ currentRow.Completed = value; }
		}
		internal short iStatus
		{
			get{ return currentRow.Status; }
			set{ currentRow.Status = (short)value; }
		}
		internal int iDuration
		{
			get { return currentRow.Duration; }
			set { currentRow.Duration = value; }
		}
		internal string iSchedulingNotes
		{
			get {
			    try
			    {
			        return currentRow.SchedulingNotes;
			    }
                catch (StrongTypingException)
			    {
			        return "";
			    }
			}
			set{currentRow.SchedulingNotes = value; }
		}
		internal string iCompletionNotes
		{
			get {
			    try
			    {
			        return currentRow.CompletionNotes;
			    }
                catch (StrongTypingException)
			    {
			        return "";
			    }
			}
			set { currentRow.CompletionNotes = value; }
		}

		internal RecordState iRecordState
		{
			get { return (RecordState) currentRow.RecordState; }
			set { currentRow.RecordState = (int) value; }
		}

		// ------------------ Initializing the adpater ----------------------
		private SqlConnection connRegency;
		private SqlDataAdapter daSalesActivity;
		private SqlCommand sqlSelectCommand1;
		private SqlCommand scDurationBroken;
		private SqlCommand sqlInsertCommand1;
		private SqlCommand sqlUpdateCommand1;
		private SqlCommand sqlDeleteCommand1;

		private void InitializeComponent()
		{
			this.connRegency = new SqlConnection();
			this.daSalesActivity = new SqlDataAdapter();
			this.sqlDeleteCommand1 = new SqlCommand();
			this.sqlInsertCommand1 = new SqlCommand();
			this.sqlSelectCommand1 = new SqlCommand();
			this.sqlUpdateCommand1 = new SqlCommand();
			this.scDurationBroken = new SqlCommand();
			((ISupportInitialize)(this)).BeginInit();
			// 
			// daSalesActivity
			// 
			this.daSalesActivity.DeleteCommand = this.sqlDeleteCommand1;
			this.daSalesActivity.InsertCommand = this.sqlInsertCommand1;
			this.daSalesActivity.SelectCommand = this.sqlSelectCommand1;
			this.daSalesActivity.TableMappings.AddRange(new DataTableMapping[] {
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
			this.daSalesActivity.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.SalesActivities WHERE (ID = @Original_ID) AND (Completed = @Original_Completed OR @Original_Completed IS NULL AND Completed IS NULL) AND (CompletionNotes = @Original_CompletionNotes OR @Original_CompletionNotes IS NULL AND CompletionNotes IS NULL) AND (contact = @Original_contact) AND (AccountNumber = @Original_AccountNumber) AND (Duration = @Original_Duration) AND (RecordState = @Original_RecordState) AND (ReferenceID = @Original_ReferenceID) AND (ResultID = @Original_ResultID) AND (Author = @Original_Author) AND (Scheduled = @Original_Scheduled OR @Original_Scheduled IS NULL AND Scheduled IS NULL) AND (SchedulingNotes = @Original_SchedulingNotes OR @Original_SchedulingNotes IS NULL AND SchedulingNotes IS NULL) AND (Status = @Original_Status) AND (TypeID = @Original_TypeID) AND (SalesRepNumber = @Original_SalesRepNumber)";
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
			this.sqlSelectCommand1.CommandText = "SELECT ID, AccountNumber, Author, contact, TypeID, ReferenceID, Scheduled, Duration, ResultID, SchedulingNotes, CompletionNotes, RecordState, Status, Completed, SalesRepNumber FROM dbo.SalesActivities WHERE (ID = @id)";
			this.sqlSelectCommand1.Connection = this.connRegency;
			this.sqlSelectCommand1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "ID"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.SalesActivities SET AccountNumber = @AccountNumber, Author = @Author, contact = @contact, TypeID = @TypeID, ReferenceID = @ReferenceID, Scheduled = @Scheduled, Duration = @Duration, ResultID = @ResultID, SchedulingNotes = @SchedulingNotes, CompletionNotes = @CompletionNotes, RecordState = @RecordState, Status = @Status, Completed = @Completed,SalesRepNumber = @SalesRepNumber WHERE (ID = @ID); SELECT ID, AccountNumber, Author, contact, TypeID, ReferenceID, Scheduled, Duration, ResultID, SchedulingNotes, CompletionNotes, RecordState, Status, Completed, SalesRepNumber FROM dbo.SalesActivities WHERE (ID = @ID)";
			this.sqlUpdateCommand1.Connection = this.connRegency;
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int, 4, "AccountNumber"));
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
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 70, "Author"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Author", SqlDbType.VarChar, 70, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Author", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Scheduled", SqlDbType.DateTime, 8, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Scheduled", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_SchedulingNotes", SqlDbType.VarChar, 2000, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "SchedulingNotes", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Status", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_TypeID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "TypeID", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_SalesRepNumber", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "SalesRepNumber", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, "ID"));
			// 
			// scDurationBroken
			// 
			this.scDurationBroken.CommandText = @"SELECT ID, AccountNumber, Author, TypeID, ReferenceID, Scheduled, Completed, Duration, ResultID, SchedulingNotes, CompletionNotes, RecordState, contact, Status, SalesRepNumber FROM SalesActivities WHERE (ID = @id)";
			this.scDurationBroken.Connection = this.connRegency;
			this.scDurationBroken.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "ID"));
			((ISupportInitialize)(this)).EndInit();
		}
	
		
		// -------------------- Constructors Section -------------------------
		internal _SalesActivity(bool createnew)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			if (createnew)
			{
				currentRow = this.SalesActivitiesTable.NewSalesActivitiesRow();
				this.SalesActivitiesTable.Rows.Add(currentRow);
				currentRow[this.SalesActivitiesTable.DurationColumn.ColumnName] = 0;
			}
		}

		internal _SalesActivity(int pID)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			scDurationBroken.Parameters["@ID"].Value = pID;
			daSalesActivity.SelectCommand = scDurationBroken;
			daSalesActivity.Fill(this);
			if (this.Tables[0].Rows.Count<1)
			{
				throw new NoSalesActivityFoundException();
			}
			else
			{
				currentRow = this.SalesActivitiesTable[0];

				iActivityReference = (SalesActivityReference) ((short)this.Tables["SalesActivities"].Rows[0]["ReferenceID"]);
				iActivityResult = (SalesActivityResult) ((short)this.Tables["SalesActivities"].Rows[0]["ResultID"]);
			}
		}
/*
		internal static _SalesActivity findBySalesActivitiesAndIndex(_SalesActivities _salesActivities, int index)
		{
			_SalesActivity iSalesActivity = new _SalesActivity(true);
			copy(iSalesActivity.currentRow, _salesActivities.SalesActivitiesTable[index]);
			iSalesActivity.AcceptChanges();
			return iSalesActivity;
		}
*/
		private static void copy(SalesActivitiesRow toRow, SalesActivitiesRow fromRow)
		{
			toRow.ID = fromRow.ID;
			toRow.AccountNumber = fromRow.AccountNumber;
			toRow.Contact = fromRow.Contact;
			toRow.Author = fromRow.Author;
			toRow.TypeID = fromRow.TypeID;
			toRow.ResultID = fromRow.ResultID;
			toRow.Scheduled = fromRow.Scheduled;
		    try
		    {
		        toRow.Completed = fromRow.Completed;
		    }
		    catch (StrongTypingException)
		    {
		        toRow.Completed = DateTime.MaxValue;
		    }
			toRow.Duration = fromRow.Duration;
			toRow.Status = fromRow.Status;
		    try
		    {
		        toRow.SchedulingNotes = fromRow.SchedulingNotes;
		    }
		    catch (StrongTypingException)
		    {
		        toRow.SchedulingNotes = "";
		    }
		    try
		    {
		        toRow.CompletionNotes = fromRow.CompletionNotes;
		    }
            catch (StrongTypingException)
		    {
		        toRow.CompletionNotes = "";
		    }
			toRow.RecordState = fromRow.RecordState;
			toRow.SalesRepNumber = fromRow.SalesRepNumber;
		}
		// -------------------- Actions Section ------------------------------
		public void Save()
		{
			currentRow.TypeID = iType;
			currentRow.ReferenceID = (short)iReference;
			currentRow.ResultID = (short)iResult;
			currentRow.Author = iAuthor ?? "";
			currentRow.AccountNumber = iCustomer!=null?iCustomer.AccountNumber:-1;

			currentRow.Status = currentRow.Status;

			daSalesActivity.Update(this);
		}

		public void Delete()
		{
		}
	}

	// ------------------------- Exceptions Section ---------------------------
}
