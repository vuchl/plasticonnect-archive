using System;
using System.Data;
using Mapping;
using Plasticonnect.DataAccess;

namespace Plasticonnect.DataAccess.Crm
{
    partial class SchemaAccounts
    {
        partial class AccountsDataTable
        {
        }
    }
}

namespace Plasticonnect.DataAccess.Crm.SchemaAccountsTableAdapters
{
    public partial class AccountsTableAdapter
    {
        public SchemaAccounts.AccountsDataTable getBy(string salesRepUsername, AccountStatus[] includedStatus, string anythingLike, string startingWith, int pageSize, int pageNumber, SortAccounts? sort, bool? descending)
        {   
            if (anythingLike != null && startingWith != null)
                throw new ArgumentException("Can't search for anythingLike and startWith at the same time.");

            SchemaAccounts accountsDataSet = new SchemaAccounts();
            Adapter.SelectCommand = CommandCollection[0].Clone();

            string selectClause = " select acc.* ";
            string fromClause = " from Accounts acc ";
            string whereClause = "";
            string orderClause = " Order By ";
            if (salesRepUsername != null)
            {
                fromClause += " inner join regencyRef..tblSalesRep sr on acc.SalesrepNumber=sr.salesRepNumber ";
                whereClause += whereClause == "" ? " Where " : " And ";
                whereClause += " sr.username" + "=@username ";
                Adapter.SelectCommand.Parameters.AddWithValue("@username", salesRepUsername);
            }
            if(includedStatus != null)
            {
                whereClause += whereClause == "" ? " Where " : " And ";
                string commaSepratedStatusValues = "";
                for (int i = 0; i < includedStatus.Length; i++)
                {
                    AccountStatus status = includedStatus[i];
                    commaSepratedStatusValues += commaSepratedStatusValues == "" ? "" : ", ";
                    string param = "@status" + i;
                    commaSepratedStatusValues += param;
                    Adapter.SelectCommand.Parameters.AddWithValue(param, (int)status);
                }
                whereClause += "acc." + accountsDataSet.Accounts.StatusColumn.ColumnName + " In (" + commaSepratedStatusValues + ")";
            }
            if(anythingLike != null)
            {
                fromClause += " left outer join Addresses ad on acc.accountNumber = ad.AccountNumber and ad.type=" 
                    + (int)AddressType.BillingTo + " and ad.recordState=" + (int)RecordState.Regular + " ";
                whereClause += whereClause == "" ? " Where " : " And ";
                whereClause += "(";
                whereClause += "acc.AccountName like @anythingLike";
                int accountNumber;
                if (Int32.TryParse(anythingLike, out accountNumber))
                {
                    whereClause += " or acc.AccountNumber = @accountNumber";
                    Adapter.SelectCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
                    
                    // to make found accountNumber first
                    selectClause += " ,Case When acc.accountNumber = @accountNumber Then 0 Else 1 End as accNumSort ";
                    orderClause += " accNumSort, ";
                }
                whereClause += " or acc.DefaultEmail like @anythingLike";
                whereClause += " or acc.DefaultPhone like @anythingLike";
                whereClause += " or acc.DefaultFax like @anythingLike";
                whereClause += " or ad.City like @anythingLike";
                whereClause += " or ad.PostalCode like @anythingLike";
                whereClause += ")";
                Adapter.SelectCommand.Parameters.AddWithValue("@anythingLike", "%" + removeSpecialCharacters(anythingLike) + "%");
            }       
            if(startingWith != null)
            {
                whereClause += whereClause == "" ? " Where " : " And ";
                whereClause += "(";
                whereClause += "acc." + accountsDataSet.Accounts.AccountNameColumn.ColumnName + " like @startingWith";
                int accountNumber;
                if (Int32.TryParse(startingWith, out accountNumber))
                {
                    whereClause += " or acc.AccountNumber = @accountNumber";
                    Adapter.SelectCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

                    // to make found accountNumber first
                    selectClause += " ,Case When acc.accountNumber = @accountNumber Then 0 Else 1 End as accNumSort ";
                    orderClause += " accNumSort, ";
                } 
                whereClause += ")";
                Adapter.SelectCommand.Parameters.AddWithValue("@startingWith", removeSpecialCharacters(startingWith) + "%");
            }
            
            if (sort == null)
                sort = SortAccounts.AccountName;
            switch ((SortAccounts)sort)
            {
                case SortAccounts.AccountName:
                    orderClause += accountsDataSet.Accounts.AccountNameColumn.ColumnName;
                    break;
                case SortAccounts.AccountNumber:
                    orderClause += accountsDataSet.Accounts.AccountNumberColumn.ColumnName;
                    break;
            }
            orderClause += (descending ?? false) ? " desc" : " asc";
        
            Adapter.SelectCommand.CommandText = selectClause + fromClause + whereClause + orderClause;
            Adapter.Fill(accountsDataSet, (pageNumber - 1) * pageSize, pageSize, accountsDataSet.Accounts.TableName);
            return accountsDataSet.Accounts;
        }

        public int countBy(string salesRepUsername, AccountStatus[] includedStatus, string anythingLike, string startingWith)
        {
            if (anythingLike != null && startingWith != null)
                throw new ArgumentException("Can't search for anythingLike and startWith at the same time.");

            SchemaAccounts accountsDataSet = new SchemaAccounts();
            Adapter.SelectCommand = CommandCollection[0].Clone();

            string selectClause = " select acc.* ";
            string fromClause = " from Accounts acc ";
            string whereClause = "";
            if (salesRepUsername != null)
            {
                fromClause += " inner join regencyRef..tblSalesRep sr on acc.SalesrepNumber=sr.salesRepNumber ";
                whereClause += whereClause == "" ? " Where " : " And ";
                whereClause += " sr.username" + "=@username ";
                Adapter.SelectCommand.Parameters.AddWithValue("@username", salesRepUsername);
            }
            if (includedStatus != null)
            {
                whereClause += whereClause == "" ? " Where " : " And ";
                string commaSepratedStatusValues = "";
                for (int i = 0; i < includedStatus.Length; i++)
                {
                    AccountStatus status = includedStatus[i];
                    commaSepratedStatusValues += commaSepratedStatusValues == "" ? "" : ", ";
                    string param = "@status" + i;
                    commaSepratedStatusValues += param;
                    Adapter.SelectCommand.Parameters.AddWithValue(param, (int)status);
                }
                whereClause += "acc." + accountsDataSet.Accounts.StatusColumn.ColumnName + " In (" + commaSepratedStatusValues + ")";
            }
            if (anythingLike != null)
            {
                fromClause += " left outer join Addresses ad on acc.accountNumber = ad.AccountNumber and ad.type="
                    + (int)AddressType.BillingTo + " and ad.recordState=" + (int)RecordState.Regular + " ";
                whereClause += whereClause == "" ? " Where " : " And ";
                whereClause += "(";
                whereClause += "acc.AccountName like @anythingLike";
                int accountNumber;
                if (Int32.TryParse(anythingLike, out accountNumber))
                {
                    whereClause += " or acc.AccountNumber = @accountNumber";
                    Adapter.SelectCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

                    // to make found accountNumber first
                    selectClause += " ,Case When acc.accountNumber = @accountNumber Then 0 Else 1 End as accNumSort ";
                }
                whereClause += " or acc.DefaultEmail like @anythingLike";
                whereClause += " or acc.DefaultPhone like @anythingLike";
                whereClause += " or acc.DefaultFax like @anythingLike";
                whereClause += " or ad.City like @anythingLike";
                whereClause += " or ad.PostalCode like @anythingLike";
                whereClause += ")";
                Adapter.SelectCommand.Parameters.AddWithValue("@anythingLike", "%" + removeSpecialCharacters(anythingLike) + "%");
            }
            if (startingWith != null)
            {
                whereClause += whereClause == "" ? " Where " : " And ";
                whereClause += "(";
                whereClause += "acc." + accountsDataSet.Accounts.AccountNameColumn.ColumnName + " like @startingWith";
                int accountNumber;
                if (Int32.TryParse(startingWith, out accountNumber))
                {
                    whereClause += " or acc.AccountNumber = @accountNumber";
                    Adapter.SelectCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

                    // to make found accountNumber first
                    selectClause += " ,Case When acc.accountNumber = @accountNumber Then 0 Else 1 End as accNumSort ";
                }
                whereClause += ")";
                Adapter.SelectCommand.Parameters.AddWithValue("@startingWith", removeSpecialCharacters(startingWith) + "%");
            }

            Adapter.SelectCommand.CommandText = "SELECT COUNT(*) FROM (" + selectClause + fromClause + whereClause + ") AS tbl";
            DataTable dataTable = new DataTable();
            Adapter.Fill(dataTable);
            return (int)dataTable.Rows[0][0];
        }

        private string removeSpecialCharacters(string str)
        {
            return str.Replace(@"\", "").Replace(@"%", @"\%");
        }
    }
}