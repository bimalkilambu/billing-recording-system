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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //var mdiControl = Controls.OfType<MdiClient>().First();

            //if (mdiControl != null)
            //{
            //    mdiControl.BackColor = System.Drawing.Color.FromArgb(207, 221, 238);
            //}
            
            ApplicationManager.mainWindow = this;
            PendingBills bills = new PendingBills();
            bills.MdiParent = this;
            bills.WindowState = FormWindowState.Maximized;
            bills.Show();
        }

        private void menuPendingBills_Click(object sender, EventArgs e)
        {
            PendingBills bills = new PendingBills();
            bills.MdiParent = this;
            bills.WindowState = FormWindowState.Maximized;
            bills.Show();
        }

        private void menuNormalBills_Click(object sender, EventArgs e)
        {
            Bills bills = new Bills();
            bills.MdiParent = this;
            bills.WindowState = FormWindowState.Maximized;
            bills.Show();
        }

        private void menuVendor_Click(object sender, EventArgs e)
        {
            ListPage page = new ListPage();
            page.MdiParent = this;
            page.WindowState = FormWindowState.Maximized;
            page.Show();
        }
    }
}
