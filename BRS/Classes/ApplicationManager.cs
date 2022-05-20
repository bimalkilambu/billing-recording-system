

using BRS.Forms;

namespace BRS.Classes
{
    public class ApplicationManager
    {
        public static ApplicationDatabase AppDatabase { get; set; }
        public static SQLiteHelper sqliteHelper { get; set; }
        public static MainWindow mainWindow { get; set; }

        public ApplicationManager()
        {
            sqliteHelper = new SQLiteHelper();
            AppDatabase = new ApplicationDatabase();
        }

        public void InitializeApplication()
        {
            AppDatabase.Initialize();
        }
    }
}
