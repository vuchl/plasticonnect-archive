using System.Data;
using System.Data.SqlClient;

namespace ROS.Schema {


    partial class SchemaCost
    {
    }
}
namespace ROS.Schema.SchemaCostTableAdapters {

    public partial class tblCostTableAdapter 
    {
        public virtual int update(SchemaCost.tblCostRow dataRow)
        {
            Adapter.InsertCommand = CommandCollection[4];
            Adapter.UpdateCommand = CommandCollection[5];
            return Adapter.Update(new DataRow[] { dataRow });              
        }
    }
}