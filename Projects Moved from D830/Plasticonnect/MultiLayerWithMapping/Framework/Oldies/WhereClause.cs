using System.Data;
using System.Data.SqlClient;
using Common.Exceptions;

namespace Common
{
    /// <summary>
    /// Represents the whereclasue that should be used to filter a select statement
    /// </summary>
    public class WhereClause
    {
        // ----- private properties -----
        private string whereClause="";

        public void Add(string pCondition)
        {
            whereClause += (whereClause=="" ? 
                                                " Where (" + pCondition + ")" : 
                                                                                  " And (" + pCondition + ")"); 
        }
        internal void Add(int pFilterID)
        {
            SqlConnection connRegency = new SqlConnection();
            connRegency.ConnectionString = Config.GetConnectionString();  

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dsFilter = new DataSet();

            SqlCommand scFilter = new SqlCommand();
            scFilter.Connection = connRegency;
            scFilter.CommandType = CommandType.Text;
            scFilter.CommandText = "select * from filters where id = @ID ";
            scFilter.Parameters.Add(new SqlParameter("@ID",SqlDbType.Int,4,"ID"));
            scFilter.Parameters["@ID"].Value = pFilterID;
            da.SelectCommand = scFilter;
            da.Fill(dsFilter);
			
            if (dsFilter.Tables[0].Rows.Count!=0)
            {
                string Criteria = dsFilter.Tables[0].Rows[0]["Criteria"].ToString();
                if (Criteria.Trim()!="") 
                    whereClause += (whereClause=="" ? " Where (" + Criteria + ")" : " And (" + Criteria + ")"); 
            }
            else
            {
                throw new FilterNotFoundException(); 
            }
        }
        public override string ToString()
        {
            return whereClause; 
        }
    }
}