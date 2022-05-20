using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace BRS.Classes
{
    public class ApplicationDatabase
    {
        private SQLiteHelper sqliteHelper = new SQLiteHelper();
        private string sqlLitePath { get { return Library.GetAppSetting("SqlitePath").Replace("{AppDataLocal}", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)); } }

        public void Initialize()
        {
            if (!File.Exists(sqlLitePath))
            {
                CreateDatabase();
                CreateBaseTables();
            }

            //CheckDbVersion();
        }

        private void CreateDatabase()
        {
            string sqliteFolder = Path.GetDirectoryName(sqlLitePath);
            if (!Directory.Exists(sqliteFolder))
            {
                Directory.CreateDirectory(sqliteFolder);
            }

            SQLiteConnection.CreateFile(sqlLitePath);
        }

        private void CreateBaseTables()
        {
            string sqlQuery = string.Empty;
            sqlQuery += BillsTable();
            sqlQuery += BillItemsTable();
            sqlQuery += VendorsTable();
            sqlQuery += ProductsTable();
            sqlQuery += PaymentsTable();
            sqlQuery += SettingTable();
            sqlQuery += InsertDefaultSettingValue();
            sqliteHelper.ExecuteSql(sqlQuery);
        }

        private string BillsTable()
        {
            Dictionary<string, string> column = new Dictionary<string, string>();
            column.Add("BillId", "INTEGER NOT NULL PRIMARY KEY");
            column.Add("Vendor", "VARCHAR(100)");
            column.Add("ManualBillNo", "VARCHAR(10)");
            column.Add("BillDate", "VARCHAR(10)");
            column.Add("TotalAmount", "INTEGER DEFAULT 0");
            column.Add("PaidAmount", "INTEGER DEFAULT 0");
            column.Add("DateDeleted", "VARCHAR(20)");
            return sqliteHelper.CreateTableScript("Bills", column);
        }

        private string BillItemsTable()
        {
            Dictionary<string, string> column = new Dictionary<string, string>();
            column.Add("BillItemId", "INTEGER NOT NULL PRIMARY KEY");
            column.Add("BillId", "INTEGER NOT NULL");
            column.Add("Product", "VARCHAR(100)");
            column.Add("Quantity", "INTEGER");
            column.Add("UnitPrice", "INTEGER");
            column.Add("Amount", "INTEGER");
            column.Add("DateDeleted", "VARCHAR(20)");
            return sqliteHelper.CreateTableScript("BillItems", column);
        }

        private string VendorsTable()
        {
            Dictionary<string, string> column = new Dictionary<string, string>();
            column.Add("VendorId", "INTEGER NOT NULL PRIMARY KEY");
            column.Add("Name", "VARCHAR(100) NOT NULL");
            return sqliteHelper.CreateTableScript("Vendors", column);
        }

        private string ProductsTable()
        {
            Dictionary<string, string> column = new Dictionary<string, string>();
            column.Add("ProductId", "INTEGER NOT NULL PRIMARY KEY");
            column.Add("Name", "VARCHAR(100) NOT NULL");
            return sqliteHelper.CreateTableScript("Products", column);
        }

        private string PaymentsTable()
        {
            Dictionary<string, string> column = new Dictionary<string, string>();
            column.Add("PaymentId", "INTEGER NOT NULL PRIMARY KEY");
            column.Add("BillId", "INTEGER NOT NULL");
            column.Add("PaidAmount", "INTEGER NOT NULL");
            column.Add("BankName", "VARCHAR(100) NOT NULL");
            column.Add("ChequeNo", "VARCHAR(100) NOT NULL");
            column.Add("PaidDate", "VARCHAR(10) NOT NULL");
            return sqliteHelper.CreateTableScript("Payments", column);
        }

        private string SettingTable()
        {
            Dictionary<string, string> column = new Dictionary<string, string>();
            column.Add("SettingId", "INTEGER");
            column.Add("Name", "VARCHAR(100) NOT NULL UNIQUE");
            column.Add("Value", "VARCHAR(1000)");
            column.Add("PRIMARY KEY", "(SettingId AUTOINCREMENT)");
            return sqliteHelper.CreateTableScript("Settings", column);
        }

        private string InsertDefaultSettingValue()
        {
            return "INSERT INTO Settings(Name, Value) VALUES('Passcode','8878')";
        }
    }
}
