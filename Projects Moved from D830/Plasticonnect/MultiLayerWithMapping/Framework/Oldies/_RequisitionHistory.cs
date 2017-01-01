using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Common;
using Common.Exceptions;
using Mapping;

namespace Regency
{
	/// <summary>
	/// Summary description for _Requistion.
	/// </summary>
	internal class _RequisitionHistory : DataSet 
	{
		// -------------------- private properties ------------------------
		private		DataRow		currentRow;
		// -------------------- public properties -------------------------
		internal int id
		{
			get
			{
				if (currentRow["ID"]==DBNull.Value)
					return -1;
				return (int)currentRow["ID"];
			}
		}
		internal int iOwnerID
		{
			get	{return (int)currentRow["Owner"];}
			set {currentRow["Owner"]=value;}
		}
		internal RequisitionActionType iAction
		{
			get
			{
				return (RequisitionActionType)int.Parse(currentRow["ActionID"].ToString());
			}
			set
			{
				currentRow["ActionID"] = (short)value;
			}
		}
		internal string iComment
		{
			get
			{
				return (currentRow["Comment"]==DBNull.Value?"":currentRow["Comment"].ToString());
			}
			set
			{
				currentRow["Comment"] = value;
			}
		}
		public DateTime iDateTimeStamp 
		{
			get{ return (DateTime)currentRow["DateTimeStamp"]; }
			set{currentRow["DateTimeStamp"]= value;} 
		}
		private SqlCommand sqlSelectCommand1;
		private SqlCommand scGetLastAction;
		private SqlCommand scGetLastActionBasedOnAction;
		private SqlCommand sqlInsertCommand1;
		private SqlCommand sqlUpdateCommand1;
		protected SqlConnection connRegency;
		private SqlDataAdapter daRequisitionHistory;
		private SqlCommand sqlDeleteCommand1;

		private void InitializeComponent()
		{
			this.sqlDeleteCommand1 = new SqlCommand();
			this.connRegency = new SqlConnection();
			this.sqlInsertCommand1 = new SqlCommand();
			this.sqlSelectCommand1 = new SqlCommand();
			this.sqlUpdateCommand1 = new SqlCommand();
			this.scGetLastAction = new SqlCommand();
			this.scGetLastActionBasedOnAction = new SqlCommand();
			this.daRequisitionHistory = new SqlDataAdapter();
			((ISupportInitialize)(this)).BeginInit();
			// 
			// scGetLastAction
			// 
			this.scGetLastAction.CommandText = "select * from requisitionHistory where owner=@Owner and datetimestamp in (select " +
				"max(datetimestamp) from requisitionHistory where owner=@Owner)";
			this.scGetLastAction.Connection = this.connRegency;
			this.scGetLastAction.Parameters.Add(new SqlParameter("@Owner", SqlDbType.Int, 4, "Owner"));
			// 
			// scGetLastActionBasedOnAction
			// 
			this.scGetLastActionBasedOnAction.CommandText = "select * from requisitionHistory where owner=@Owner and ActionID=@ActionID and da" +
				"tetimestamp in (select max(datetimestamp) from requisitionHistory where owner=@O" +
				"wner and ActionID=@ActionID)";
			this.scGetLastActionBasedOnAction.Connection = this.connRegency;
			this.scGetLastActionBasedOnAction.Parameters.Add(new SqlParameter("@Owner", SqlDbType.Int, 4, "Owner"));
			this.scGetLastActionBasedOnAction.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.SmallInt, 2, "ActionID"));
			// 
			// daRequisitionHistory
			// 
			this.daRequisitionHistory.DeleteCommand = this.sqlDeleteCommand1;
			this.daRequisitionHistory.InsertCommand = this.sqlInsertCommand1;
			this.daRequisitionHistory.SelectCommand = this.sqlSelectCommand1;
			this.daRequisitionHistory.TableMappings.AddRange(new DataTableMapping[] {
				new DataTableMapping("Table", "RequisitionHistory", new DataColumnMapping[] {
					new DataColumnMapping("ID", "ID"),
					new DataColumnMapping("Owner", "Owner"),
					new DataColumnMapping("ActionID", "ActionID"),
					new DataColumnMapping("DateTimeStamp", "DateTimeStamp"),
					new DataColumnMapping("Comment", "Comment"),
																																																							 })});
			this.daRequisitionHistory.UpdateCommand = this.sqlUpdateCommand1;
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
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT ID, Owner, ActionID, DateTimeStamp, Comment FROM dbo.Requ" +
				"isitionHistory WHERE (ID = @id)";
			this.sqlSelectCommand1.Connection = this.connRegency;
			this.sqlSelectCommand1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "ID"));
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
			((ISupportInitialize)(this)).EndInit();

		}
	
		// ------------ Constructors Section -------------------
		public _RequisitionHistory()
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			sqlSelectCommand1.Parameters["@ID"].Value = -1;
			daRequisitionHistory.Fill(this);
			
			this.Tables["RequisitionHistory"].Rows.Add(this.Tables["RequisitionHistory"].NewRow());

			currentRow = this.Tables[0].Rows[0];
		}

		public _RequisitionHistory(int pID)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			sqlSelectCommand1.Parameters["@ID"].Value = pID;
			daRequisitionHistory.SelectCommand = sqlSelectCommand1;  
			daRequisitionHistory.Fill(this);
		
			if (this.Tables[0].Rows.Count<1)
			{
				throw new NoRequisitionHistoryFoundException();
			}
			else
			{
				currentRow = this.Tables["RequisitionHistory"].Rows[0];
			}
		}

		public _RequisitionHistory(int requisitionID, RequisitionActionType pRAT)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			if (pRAT == RequisitionActionType.All)
			{
				scGetLastAction.Parameters["@Owner"].Value = requisitionID;
				daRequisitionHistory.SelectCommand = scGetLastAction;  
				daRequisitionHistory.Fill(this);
			}
			else
			{
				scGetLastActionBasedOnAction.Parameters["@Owner"].Value = requisitionID;
				scGetLastActionBasedOnAction.Parameters["@ActionID"].Value = (int)pRAT;
				daRequisitionHistory.SelectCommand = scGetLastActionBasedOnAction;  
				daRequisitionHistory.Fill(this);
			}
			if (this.Tables[0].Rows.Count<1)
			{
				throw new NoRequisitionHistoryFoundException();
			}
			else
			{
				currentRow = this.Tables["RequisitionHistory"].Rows[0];
			}

		}

		public _RequisitionHistory(_RequisitionHistories pCollection, int pIndex)
		{
			InitializeComponent();
			this.connRegency.ConnectionString = Config.GetConnectionString();  

			currentRow = pCollection.Tables[0].Rows[pIndex]; 
		}
		// ------------ Actions Section ------------------------
		internal void Save()
		{
			updateCurrentRecord();
		}
		private void updateCurrentRecord()
		{
			try
			{
				currentRow["ActionID"] = (short)iAction;
				currentRow["Comment"] = currentRow["Comment"] is DBNull?"":currentRow["Comment"];

				daRequisitionHistory.Update(this); 
			}
			catch (SqlException se)
			{
				string m=se.Message;
			}
			catch (Exception ee)
			{
				string m=ee.Message;
			}
		}
	}
}
