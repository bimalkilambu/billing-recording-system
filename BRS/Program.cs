using BRS.Classes;
using BRS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    Logger.Log(string.Format("Unhandled application exception: {0}", e.ExceptionObject.GetType()));
                    var lines = e.ExceptionObject.ToString().Replace("\r", "").Split('\n');
                    foreach (var line in lines)
                    {
                        Logger.Debug(line);
                    }
                    if (e.IsTerminating)
                    {
                        Logger.Debug("Application abnormally terminated.");
                    }
                };

                new ApplicationManager().InitializeApplication();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            }
            catch (Exception ex)
            {
                Logger.Log($"Error message: {ex.Message}, Inner Exception : {ex.InnerException}, Stack Trace : {ex.StackTrace}");
            }
        }
    }
}
