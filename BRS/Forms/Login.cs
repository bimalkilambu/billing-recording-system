using BRS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRS.Forms
{
    public partial class Login : Form
    {
        private static SQLiteHelper sqliteHelper { get { return ApplicationManager.sqliteHelper; } }

        public Login()
        {
            InitializeComponent();
        }

        private void txtPassCode_TextChanged(object sender, EventArgs e)
        {
            string code = txtPassCode.Text;
            if(code.Length == 4)
            {
                string sqlQuery = $"SELECT Count(1) FROM Settings WHERE Name = 'Passcode' AND Value = '{code}'";
                string result = sqliteHelper.ExecuteScalar(sqlQuery);
                if (result == "1")
                {
                    Hide();
                    new MainWindow().Show();
                }
                else
                {
                    MessageBox.Show("Invalid passcode.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassCode.Text = "";
                }
            }
            else if(code.Length > 4)
            {
                return;
            }
            
        }

        private void txtPassCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
