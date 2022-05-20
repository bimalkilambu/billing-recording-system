using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRS.Classes
{
    internal static class Library
    {
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings.Get(key) ?? string.Empty;
        }

        public static List<string> GetList(this DataTable dataTable, string columnName)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return dataTable.AsEnumerable().Select(r => r.Field<string>(columnName)).ToList();
            }

            return null;
        }
    }
}
