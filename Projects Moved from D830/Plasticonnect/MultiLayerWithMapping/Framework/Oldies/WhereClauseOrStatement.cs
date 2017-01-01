using System.Collections;

namespace Common
{
    /// <summary>
    /// this class is for creating sql statement concatinated with or
    /// </summary>
    public class WhereClauseOrStatement
    {
        readonly ArrayList statements = new ArrayList();		
		
        public void addStatement(string statement)
        {
            statements.Add(statement);
        }

        public override string ToString()
        { 
            if (statements.Count == 0)
                return "";
            string sql = "";
            for (int i = 0; i < statements.Count; i++)
            {
                string statement = (string) statements[i];
                sql += (sql == "" ? "" : " or ") + statement;
            }
            if (statements.Count > 1)
                sql = "(" + sql + ")";
            return sql;
        }
    }
}