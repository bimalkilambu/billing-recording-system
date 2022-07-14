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
using static System.Windows.Forms.ListViewItem;

namespace BRS.Forms
{
    public partial class PendingBills : Form
    {
        private static SQLiteHelper sqliteHelper { get { return ApplicationManager.sqliteHelper; } }
        private int activeBillNo = 0;
        int maxPayAmount = 0;

        public PendingBills()
        {
            InitializeComponent();
        }

        #region helper function
        private void ShowPaymentDetail(bool display)
        {
            lvPendingBills.Height = display ? 270 : 370;
            grpPaymentDetail.Visible = display;
            ShowChequeDetail(false);
            cmbPaymentType.SelectedIndex = 0;
        }

        private void ShowChequeDetail(bool display)
        {
            lblBank.Visible = txtBank.Visible = lblCheque.Visible = txtChequeNo.Visible = display;
        }

        private void LoadPendingBills()
        {
            lvPendingBills.Items.Clear();
            string sqlQuery = "SELECT * FROM Bills WHERE TotalAmount != PaidAmount AND DateDeleted IS NULL;";
            DataTable dataTable = sqliteHelper.GetDataTable(sqlQuery);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                ListViewItem item = new ListViewItem(row["Vendor"].ToString());
                item.SubItems.Add(row["ManualBillNo"].ToString());
                item.SubItems.Add(row["BillDate"].ToString());
                item.SubItems.Add(row["TotalAmount"].ToString());
                item.SubItems.Add(row["PaidAmount"].ToString());
                item.SubItems.Add((Convert.ToInt32(row["TotalAmount"]) - Convert.ToInt32(row["PaidAmount"])).ToString());
                item.SubItems.Add(row["BillId"].ToString());

                lvPendingBills.Items.Add(item);
            }

            CalculateTotalCreditAmount();
        }

        private void CalculateTotalCreditAmount()
        {
            int totalAmount = 0;

            for (int i = 0; i < lvPendingBills.Items.Count; i++)
            {
                string amountString = lvPendingBills.Items[i].SubItems[5].Text;
                int amount = string.IsNullOrEmpty(amountString) ? 0 : Convert.ToInt32(amountString);
                totalAmount += amount;
            }

            lblTotalCredit.Text = "Total credit amount: " + totalAmount.ToString();
        }

        private bool PaymentValidation()
        {
            bool isValid = !string.IsNullOrEmpty(txtPaidDate.Text.Trim()) && !string.IsNullOrEmpty(txtPaidAmount.Text.Trim());

            if (isValid && cmbPaymentType.SelectedIndex == 1)
            {
                isValid = !string.IsNullOrEmpty(txtBank.Text.Trim()) && !string.IsNullOrEmpty(txtChequeNo.Text.Trim());
            }

            return isValid;
        }
        #endregion

        #region event handlers
        private void PendingBills_Load(object sender, EventArgs e)
        {
            ShowPaymentDetail(false);
            LoadPendingBills();
        }

        private void PendingBills_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChequeDetail(cmbPaymentType.SelectedIndex == 1);
        }
  
        private void lvPendingBills_ItemActivate(object sender, EventArgs e)
        {
            ListViewSubItemCollection bill = lvPendingBills.SelectedItems[0].SubItems;
            lblVendor.Text = bill[0].Text;
            lblManualBillNo.Text = bill[1].Text;
            activeBillNo = Convert.ToInt32(bill[6].Text);
            maxPayAmount = Convert.ToInt32(bill[5].Text);
            ShowPaymentDetail(true);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (PaymentValidation())
            {
                int paidamount = Convert.ToInt32(txtPaidAmount.Text);

                if (paidamount <= maxPayAmount)
                {
                    string paidDate = txtPaidDate.Text;
                    string bankName = txtBank.Text;
                    string chequeNo = txtChequeNo.Text;

                    string sqlQuery = $"INSERT INTO Payments(BillId, PaidAmount, BankName, ChequeNo, PaidDate) VALUES({activeBillNo},{paidamount},'{bankName}','{chequeNo}','{paidDate}');UPDATE Bills SET PaidAmount = PaidAmount + {paidamount} WHERE BillId = {activeBillNo}; ";
                    sqliteHelper.ExecuteSql(sqlQuery);
                    ShowPaymentDetail(false);
                    LoadPendingBills();
                    txtBank.Text = txtChequeNo.Text = txtPaidAmount.Text = txtPaidDate.Text = "";
                }
                else
                {
                    MessageBox.Show("Paid amount should not be greater than pending bill amount.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please all the mandatory fields.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)0x2D)
            {
                e.Handled = true;
            }
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
