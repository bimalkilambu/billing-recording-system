using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRS.Classes
{
    public class Logger
    {
        public static string LogFileName;
        private static bool SeparatorWritten = false;
        private static readonly object LockObject = new object();

        public static void Initialize()
        {
            string logFolder = Library.GetAppSetting("LogPath")
                .Replace("{AppDataLocal}", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            LogFileName = Path.Combine(logFolder, DateTime.Now.ToString("yyyyMMdd") + ".log");

            if (!SeparatorWritten)
            {
                WriteLog(string.Empty);
                WriteLog("---------------------------------------------------------------------------------------");
                WriteLog(string.Empty);

                SeparatorWritten = true;
            }

        }

        public static void Log(string title, string[] messages = null)
        {

            if (string.IsNullOrEmpty(LogFileName))
            {
                Initialize();
            }

            var contents = string.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), title);
            WriteLog(contents);

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        contents = string.Format("                    : {0}", message);
                        WriteLog(contents);
                    }
                }
            }

        }

        private static void WriteLog(string message)
        {
            lock (LockObject)
            {
                using (var writer = new StreamWriter(LogFileName, true))
                {
                    writer.WriteLine(message);
                }
            }
        }

        public static void Debug(string message)
        {
            if (Library.GetAppSetting("LogDebug").ToLower() == "y")
            {
                message = $"DEBUG: {message}";
                Log(message);
            }

        }
    }
}
