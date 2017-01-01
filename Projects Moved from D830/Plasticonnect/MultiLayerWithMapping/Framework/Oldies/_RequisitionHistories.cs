using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Common;
using Mapping;

namespace Regency
{
	/// <summary>
	/// Summary description for _RequisitionHistories.
	/// </summary>
	internal class _RequisitionHistories :DataSet
	{
		// -------------------- private properties ------------------------
		// -------------------- public properties -------------------------
		internal int iCount 
		{
			get {return this.Tables[0].Rows.Count;}
		}
		private SqlCommand scFindAction;
		private SqlConnection sqlConnection1;
		private SqlDataAdapter daRequisitionHistories;
		private SqlCommand sqlSelectCommand1;
		private SqlCommand sqlInsertCommand1;
		private SqlCommand sqlUpdateCommand1;
		private SqlCommand sqlDeleteCommand1;
		protected SqlConnection connRegency;

		private void InitializeComponent()
		{
			this.connRegency = new SqlConnection();
			this.scFindAction = new SqlCommand();
			this.sqlConnection1 = new SqlConnection();
			this.daRequisitionHistories = new SqlDataAdapter();
			this.sqlSelectCommand1 = new SqlCommand();
			this.sqlInsertCommand1 = new SqlCommand();
			this.sqlUpdateCommand1 = new SqlCommand();
			this.sqlDeleteCommand1 = new SqlCommand();
			((ISupportInitialize)(this)).BeginInit();
			// 
			// scFindAction
			// 
			this.scFindAction.CommandText = "SELECT ID, Owner, ActionID, DateTimeStamp, Comment FROM Requisit" +
				"ionHistory WHERE (Owner = @Owner) and (ActionID=@ActionID)";
			this.scFindAction.Connection = this.connRegency;
			this.scFindAction.Parameters.Add(new SqlParameter("@Owner", SqlDbType.Int, 4, "Owner"));
			this.scFindAction.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.SmallInt, 2, "ActionID"));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=DEV009;packet size=4096;integrated security=SSPI;data source=TESTS" +
				"ERVER;persist security info=False;initial catalog=Regency";
			// 
			// daRequisitionHistories
			// 
			this.daRequisitionHistories.DeleteCommand = this.sqlDeleteCommand1;
			this.daRequisitionHistories.InsertCommand = this.sqlInsertCommand1;
			this.daRequisitionHistories.SelectCommand = this.sqlSelectCommand1;
			this.daRequisitionHistories.TableMappings.AddRange(new DataTableMapping[] {
				new DataTableMapping("Table", "RequisitionHistory", new DataColumnMapping[] {
					new DataColumnMapping("ID", "ID"),
					new DataColumnMapping("Owner", "Owner"),
					new DataColumnMapping("ActionID", "ActionID"),
					new DataColumnMapping("DateTimeStamp", "DateTimeStamp"),
					new DataColumnMapping("Comment", "Comment"),
				 })});
			this.daRequisitionHistories.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT ID, Owner, ActionID, DateTimeStamp, Comment FROM dbo.Requ" +
				"isitionHistory WHERE (Owner = @Owner)";
			this.sqlSelectCommand1.Connection = this.connRegency;
			this.sqlSelectCommand1.Parameters.Add(new SqlParameter("@Owner", SqlDbType.Int, 4, "Owner"));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.RequisitionHistory(Owner, ActionID, DateTimeStamp, Comment) VALUES (@Owner, @ActionID, @DateTimeStamp, @Comment); SELECT ID, Owner, ActionID, DateTimeStamp, Comment FROM dbo.RequisitionHistory WHERE (ID = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.connRegency;
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@Owner", SqlDbType.Int, 4, "Owner"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.SmallInt, 2, "ActionID"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@DateTimeStamp", SqlDbType.DateTime, 8, "DateTimeStamp"));
			this.sqlInsertCommand1.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 150, "Comment"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.RequisitionHistory SET Owner = @Owner, ActionID = @ActionID, DateTimeStamp = @DateTimeStamp, Comment = @Comment WHERE (ID = @Original_ID) AND (ActionID = @Original_ActionID) AND (Comment = @Original_Comment OR @Original_Comment IS NULL AND Comment IS NULL) AND (DateTimeStamp = @Original_DateTimeStamp OR @Original_DateTimeStamp IS NULL AND DateTimeStamp IS NULL) AND (Owner = @Original_Owner); SELECT ID, Owner, ActionID, DateTimeStamp, Comment FROM dbo.RequisitionHistory WHERE (ID = @ID)";
			this.sqlUpdateCommand1.Connection = this.connRegency;
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Owner", SqlDbType.Int, 4, "Owner"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.SmallInt, 2, "ActionID"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@DateTimeStamp", SqlDbType.DateTime, 8, "DateTimeStamp"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 150, "Comment"));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ID", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_ActionID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ActionID", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 150, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Comment", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_DateTimeStamp", SqlDbType.DateTime, 8, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "DateTimeStamp", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@Original_Owner", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Owner", DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, "ID"));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.RequisitionHistory WHERE (ID = @Original_ID) AND (ActionID = @Original_ActionID) AND (Comment = @Original_Comment OR @Original_Comment IS NULL AND Comment IS NULL) AND (DateTimeStamp = @Original_DateTimeStamp OR @Original_DateTimeStamp IS NULL AND DateTimeStamp IS NULL) AND (Owner = @Original_Owner)";
			this.sqlDeleteCommand1.Connection = this.connRegency;
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ID", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_ActionID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "ActionID", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 150, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Comment", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_DateTimeStamp", SqlDbType.DateTime, 8, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "DateTimeStamp", DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new SqlParameter("@Original_Owner", SqlDbType.Int, 4, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "Owner", DataRowVersion.Original, null));
			((ISupportInitialize)(this)).EndInit();

		}
		// -------------------- Constructors Section ----------------------	
		public _RequisitionHistories()
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			sqlSelectCommand1.Parameters["@Owner"].Value = -99;
			daRequisitionHistories.SelectCommand = sqlSelectCommand1;  
			daRequisitionHistories.Fill(this);
		}
		public _RequisitionHistories(int pOwnerID)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			sqlSelectCommand1.Parameters["@Owner"].Value = pOwnerID;
			daRequisitionHistories.SelectCommand = sqlSelectCommand1;  
			daRequisitionHistories.Fill(this);
		}
		public _RequisitionHistories(int pOwnerID, RequisitionActionType pRAT)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			scFindAction.Parameters["@Owner"].Value = pOwnerID;
			scFindAction.Parameters["@ActionID"].Value = (short)pRAT;
			daRequisitionHistories.SelectCommand = scFindAction;  
			daRequisitionHistories.Fill(this);
		}
		// -------------------- Actions Section ----------------------	
		internal void Save(int pOwnerID)
		{
			try
			{
				foreach (DataRow dr in this.Tables[0].Rows)
				{
					if (dr["Owner"] is DBNull)
						dr["Owner"]=pOwnerID;
				}
				daRequisitionHistories.Update(this);
			}
			catch(IndexOutOfRangeException)
			{
				// TODO: add system log here
			}
			catch(NullReferenceException)
			{
				// TODO: add system log here
			}
		}
		internal void Add(_RequisitionHistory rh)
		{
			DataRow dr= this.Tables[0].NewRow();
			
			dr["ActionID"]=(short)rh.iAction;
			dr["Comment"]=rh.iComment;
			dr["DateTimeStamp"]=rh.iDateTimeStamp;
			
			this.Tables[0].Rows.Add(dr);
		}
	}
}
