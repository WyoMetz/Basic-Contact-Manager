using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ContactLib
{
    public class Transaction
    {
        private string DbLocation = @"ContactInfo.db";

        private SQLiteConnection DbConnection()
        {
            SQLiteConnection DbConnected = new SQLiteConnection("Data Source =" + DbLocation + ";Version=3;");
            try
            {
                DbConnected.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return new SQLiteConnection(DbConnected);
        }

        public long DbCommand(string Sql)
        {
            long RowID;
            using (SQLiteConnection connect = new SQLiteConnection(DbConnection()))
            {
                SQLiteTransaction Transaction = null;                  
                Transaction = connect.BeginTransaction();
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
                Transaction.Commit();
                RowID = connect.LastInsertRowId;
                connect.Close();                                        
            }
            return RowID;
        }
    }
}
