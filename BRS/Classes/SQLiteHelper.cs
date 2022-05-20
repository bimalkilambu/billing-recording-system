using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace BRS.Classes
{
    public class SQLiteHelper
    {
        private string sqlLitePath { get { return Library.GetAppSetting("SqlitePath").Replace("{AppDataLocal}", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)); } }

        private string DefaultConnectionString { get { return $"Data Source={sqlLitePath};Version=3;"; } }

        public int ExecuteSql(string sqlQuery)
        {
            SQLiteConnection connection = new SQLiteConnection(DefaultConnectionString);
            connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(sqlQuery, connection);

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occured inside ExecuteSql method. Exception: {ex.Message}, InnerException: {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}, Stack Trace: {ex.StackTrace}", null);
                return -1;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        public string ExecuteScalar(string sqlQuery)
        {
            SQLiteConnection connection = new SQLiteConnection(DefaultConnectionString);
            connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(sqlQuery, connection);

            try
            {
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occured inside ExecuteScalar method. Exception: {ex.Message}, InnerException: {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}, Stack Trace: {ex.StackTrace}");
                return "-1";
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        public string CreateTableScript(string entityName, Dictionary<string, string> entityColumn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CREATE TABLE IF NOT EXISTS {entityName} ( ");

            int columnCount = 1;
            string syntax = ",";

            foreach (var col in entityColumn)
            {
                if (columnCount == entityColumn.Count)
                    syntax = " );";

                //sb.Append(col.Key + " " + col.Value + syntax);
                sb.Append($" {col.Key} {col.Value} {syntax}");
                columnCount++;
            }

            return sb.ToString();
        }

        public DataSet GetDataset(string sqlQuery, string connectionString)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            connection.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlQuery, connection);
            DataSet dataset = new DataSet();
            try
            {
                da.Fill(dataset);
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occured inside ExecuteSql method. Exception: {ex.Message}, InnerException: {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}, Stack Trace: {ex.StackTrace}");
                return null;
            }
            finally
            {
                da.Dispose();
                connection.Close();
            }
            return dataset;
        }


        public DataTable GetDataTable(string sqlQuery, string connectionString = "")
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = DefaultConnectionString;
            }

            var dataset = GetDataset(sqlQuery, connectionString);

            if (dataset == null)
                return null;
            else
                return dataset.Tables[0];
        }
    }
}
