using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.SQLite;

using System.Collections;

namespace MOrders
{
    public class SQLite
    {
        SQLiteConnection connection = new SQLiteConnection();
        SQLiteCommand command = new SQLiteCommand();
        SQLiteDataAdapter adapter = new SQLiteDataAdapter();

        DataSet dataset = new DataSet();
        DataTable dataTable = new DataTable();
        public DataTableReader reader;


        public void CreateBase(string baseName)
        {
            SQLiteConnection.CreateFile(baseName);
        }

        public bool Connect(string baseName)
        {
            if (connection.State == ConnectionState.Closed)
            {
                string connectionString = "Data Source="+baseName+";Version=3;New=false;Compress=True;";
                connection = new SQLiteConnection(connectionString);
                    connection.Open();
                    if (connection.State==ConnectionState.Open) return true;
            }
            return false;
        }

        public void Disconnect()
        {
            connection.Close();
        }

        public void ExecuteCommand(string commandText)
        {
            adapter = new SQLiteDataAdapter(commandText, connection);
        }

        void FillDataSet()
        {
            dataset.Reset();
            adapter.Fill(dataset);
        }

        bool CheckTablesExist()
        {
            if (dataset.Tables.Count>0) return true;
            else return false;
        }

        void CreateTables() { 
              //dataset.Tables[0],
        }

        public DataTable GetTable(string name)
        {
           
            reader = new DataTableReader(dataset.Tables[name]);
            return dataset.Tables[name];
        }


        void DropTable(string table)
        {
            ExecuteCommand(@"DROP TABLE"+" `"+table+"`");
        }
        void CreateCostumerTable()
        {
            ExecuteCommand(@"CREATE TABLE [Costumer] (
                    [id_c] INT NOT NULL PRIMARY KEY, 
                    [photo] CHAR(200) NOT NULL,
                    [fio] CHAR(100) NOT NULL,
                    [adress] CHAR(100) NOT NULL);");
        }

        void CreateProjectTable()
        {
            ExecuteCommand(@"CREATE TABLE [Costumer] (
                    [id_pr] INT NOT NULL PRIMARY KEY,
                    [id_worker] INT,
                    [cost] FLOAT,
                    [costApprox]  FLOAT,
                    [startD] DATE,
                    [endD] DATE,
                    [status] TINYINT UNSIGNED;");
        }

    }
}
