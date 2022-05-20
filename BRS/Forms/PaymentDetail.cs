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
    public partial class PaymentDetail : Form
    {
        private static SQLiteHelper sqliteHelper { get { return ApplicationManager.sqliteHelper; } }

        public PaymentDetail()
        {
            InitializeComponent();
        }

        private void PaymentDetail_Load(object sender, EventArgs e)
        {

        }

        public void ShowPaymentDetail(string billId)
        {
            string sqlQuery = $"SELECT * FROM Payments WHERE BillId = {billId};";
            DataTable dataTable = sqliteHelper.GetDataTable(sqlQuery);
            lvPaymentDetail.Items.Clear();


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                ListViewItem item = new ListViewItem(row["PaidDate"].ToString());
                item.SubItems.Add(row["PaidAmount"].ToString());
                item.SubItems.Add(row["BankName"].ToString());
                item.SubItems.Add(row["ChequeNo"].ToString());

                lvPaymentDetail.Items.Add(item);
            }


            ShowDialog();
        }
    }
}
