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
    public partial class Bills : Form
    {
        private static SQLiteHelper sqliteHelper { get { return ApplicationManager.sqliteHelper; } }
        private ListViewSubItemCollection activeBill;
        private ListViewSubItemCollection activeBillItem;
        private string activeBillId = "";
        private string activeBillItemId = "";

        public Bills()
        {
            InitializeComponent();
            GetProductSuggestion();
            GetVendorSuggestion();
        }

        private void GetProductSuggestion()
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();

            string sqlQuery = "SELECT Name FROM Products;";
            sqliteHelper.GetDataTable(sqlQuery).GetList("Name");
            autoCompleteStringCollection.AddRange((sqliteHelper.GetDataTable(sqlQuery).GetList("Name") ?? new List<string>()).ToArray());
            txtProduct.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void GetVendorSuggestion()
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();

            string sqlQuery = "SELECT Name FROM Vendors;";
            sqliteHelper.GetDataTable(sqlQuery).GetList("Name");
            autoCompleteStringCollection.AddRange((sqliteHelper.GetDataTable(sqlQuery).GetList("Name") ?? new List<string>()).ToArray());
            txtVendor.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void LoadBills()
        {
            lvBillList.Items.Clear();
            string sqlQuery = "SELECT * FROM Bills WHERE DateDeleted IS NULL ORDER BY 1 DESC";
            DataTable dataTable = sqliteHelper.GetDataTable(sqlQuery);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                ListViewItem item = new ListViewItem(row["Vendor"].ToString());
                item.SubItems.Add(row["ManualBillNo"].ToString());
                item.SubItems.Add(row["BillDate"].ToString());
                item.SubItems.Add(row["TotalAmount"].ToString());
                item.SubItems.Add(row["BillId"].ToString());

                lvBillList.Items.Add(item);
            }
        }

        private void LoadBillDetails(string billId)
        {
            ClearBillDetail();
            lvBillItemList.Items.Clear();
            activeBillId = billId;

            string sqlQuery = $"SELECT * FROM Bills WHERE BillId = {billId} AND DateDeleted IS NULL";
            DataTable dataTable = sqliteHelper.GetDataTable(sqlQuery);

            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                txtVendor.Text = dataRow["Vendor"].ToString();
                txtBillNo.Text = dataRow["ManualBillNo"].ToString();
                txtBillDate.Text = dataRow["BillDate"].ToString();
                txtTotalAmount.Text = dataRow["TotalAmount"].ToString();

                LoadBillItems(billId);
            }
        }

        private void LoadBillItems(string billId)
        {
            lvBillItemList.Items.Clear();
            string sqlQuery = $"SELECT * FROM BillItems WHERE BillId = {billId} AND DateDeleted IS NULL";
            DataTable dataTable = sqliteHelper.GetDataTable(sqlQuery);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                ListViewItem item = new ListViewItem(row["Product"].ToString());
                item.SubItems.Add(row["Quantity"].ToString());
                item.SubItems.Add(row["UnitPrice"].ToString());
                item.SubItems.Add(row["Amount"].ToString());
                item.SubItems.Add(row["BillItemId"].ToString());

                lvBillItemList.Items.Add(item);
            }
        }

        private int DeleteBills(string[] ids)
        {
            string sqlQuery = $"UPDATE Bills SET DateDeleted = Datetime('now','localtime') WHERE BillId IN ({string.Join(",", ids)});UPDATE BillItems SET DateDeleted = Datetime('now','localtime') WHERE BillId IN ({string.Join(",", ids)}) AND DateDeleted IS NULL;";
            return sqliteHelper.ExecuteSql(sqlQuery);
        }

        private int DeleteBillItems(string[] ids)
        {
            string sqlQuery = $"UPDATE BillItems SET DateDeleted = Datetime('now','localtime') WHERE BillItemId IN ({string.Join(",", ids)});";
            return sqliteHelper.ExecuteSql(sqlQuery);
        }

        private void ClearBillDetail()
        {
            txtVendor.Text = txtBillNo.Text = txtBillDate.Text = txtTotalAmount.Text = string.Empty;
            ClearProductDetail();
        }

        private void ClearProductDetail()
        {
            txtProduct.Text = txtQuantity.Text = txtUnitPrice.Text = txtAmount.Text = string.Empty;
        }

        private int UpdateBill(string field, string value)
        {
            string sqlQuery = $"UPDATE Bills SET {field} = '{value}' WHERE BillId = {activeBillId}";
            return sqliteHelper.ExecuteSql(sqlQuery);
        }

        private int UpdateBillItem(string field, string value)
        {
            string sqlQuery = $"UPDATE BillItems SET {field} = '{value}' WHERE BillItemId = {activeBillItemId}";
            return sqliteHelper.ExecuteSql(sqlQuery);
        }

        private void CalculateProductAmount()
        {
            int quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToInt32(txtQuantity.Text);
            int unitPrice = string.IsNullOrEmpty(txtUnitPrice.Text) ? 0 : Convert.ToInt32(txtUnitPrice.Text);
            int amount = quantity * unitPrice;
            txtAmount.Text = amount.ToString();
            txtAmount_Leave(null, null);
        }

        private void ShowBillDetail(bool display)
        {
            if (display)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
                ShowItemDetail(false);
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Hide();
            }
        }

        private void ShowItemDetail(bool display)
        {
            groupItemDetail.Visible = display;
            lvBillItemList.Height = display ? 220 : 285;
        }

        private void InsertProduct(string productName)
        {
            if (!txtProduct.AutoCompleteCustomSource.Contains(productName) && !string.IsNullOrEmpty(productName))
            {
                txtProduct.AutoCompleteCustomSource.Add(productName);
                string sqlQuery = $"INSERT INTO Products(Name) VALUES('{productName}')";
                sqliteHelper.ExecuteSql(sqlQuery);
            }
        }

        private void InsertVendor(string vendorName)
        {
            if (!txtVendor.AutoCompleteCustomSource.Contains(vendorName) && !string.IsNullOrEmpty(vendorName))
            {
                txtVendor.AutoCompleteCustomSource.Add(vendorName);
                string sqlQuery = $"INSERT INTO Vendors(Name) VALUES('{vendorName}')";
                sqliteHelper.ExecuteSql(sqlQuery);
            }
        }

        private void CalculateTotalAmount()
        {
            int totalAmount = 0;

            for(int i = 0; i < lvBillItemList.Items.Count; i++)
            {
                string amountString = lvBillItemList.Items[i].SubItems[3].Text;
                int amount = string.IsNullOrEmpty(amountString) ? 0 : Convert.ToInt32(amountString);
                totalAmount += amount;
            }

            lblCalculateTotalAmount.Text = "Total: " + totalAmount.ToString();
            lblCalculateTotalAmount.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string sqlQuery = "INSERT INTO Bills(BillId) VALUES(NULL); SELECT last_insert_rowid();";
            string billId = sqliteHelper.ExecuteScalar(sqlQuery);

            ListViewItem item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add(billId);

            lvBillList.Items.Add(item);

            activeBill = item.SubItems;

            if (lvBillList.SelectedItems.Count > 0)
                lvBillList.SelectedItems[0].Selected = false;

            item.Selected = true;
            LoadBillDetails(billId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var checkedItems = lvBillList.CheckedItems;
            if (checkedItems.Count > 0)
            {
                var confirmDialog = MessageBox.Show("Are you sure you want to delete selected bills?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (confirmDialog == DialogResult.Yes)
                {
                    string[] id = new string[checkedItems.Count];
                    for (int i = 0; i < checkedItems.Count; i++)
                    {
                        id[i] = checkedItems[i].SubItems[4].Text;
                    }

                    int isDeleted = DeleteBills(id);
                    if (isDeleted == -1)
                    {
                        MessageBox.Show("Error while deleting bills", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LoadBills();
                        lvBillItemList.Items.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select at least one bill to delete", "Delete bills", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Bills_Load(object sender, EventArgs e)
        {
            LoadBills();
            ShowBillDetail(false);
        }

        private void lvBillList_ItemActivate(object sender, EventArgs e)
        {
            ListViewSubItemCollection bill = lvBillList.SelectedItems[0].SubItems;
            string billId = bill[4].Text;
            LoadBillDetails(billId);
            activeBill = bill;
            ShowBillDetail(true);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string sqlQuery = $"INSERT INTO BillItems(BillId) VALUES({activeBillId}); SELECT last_insert_rowid();";
            string billItemId = sqliteHelper.ExecuteScalar(sqlQuery);

            ListViewItem item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add(billItemId);

            lvBillItemList.Items.Add(item);

            if (lvBillItemList.SelectedItems.Count > 0)
                lvBillItemList.SelectedItems[0].Selected = false;

            item.Selected = true;
            activeBillItem = item.SubItems;
            activeBillItemId = billItemId;

            ClearProductDetail();
            ShowItemDetail(true);
        }

        private void lvItemList_ItemActivate(object sender, EventArgs e)
        {
            ListViewSubItemCollection item = lvBillItemList.SelectedItems[0].SubItems;
            txtProduct.Text = item[0].Text;
            txtQuantity.Text = item[1].Text;
            txtUnitPrice.Text = item[2].Text;
            txtAmount.Text = item[3].Text;
            activeBillItemId = item[4].Text;

            activeBillItem = item;
            ShowItemDetail(true);
        }

        private void txtVendor_Leave(object sender, EventArgs e)
        {

            if (activeBill != null && !string.IsNullOrEmpty(activeBillId))
            {
                string vendor = txtVendor.Text;
                activeBill[0].Text = vendor;
                UpdateBill("Vendor", vendor);
                InsertVendor(vendor);
            }
        }

        private void txtBillNo_Leave(object sender, EventArgs e)
        {
            if (activeBill != null && !string.IsNullOrEmpty(activeBillId))
            {
                string billNo = txtBillNo.Text;
                activeBill[1].Text = billNo;
                UpdateBill("ManualBillNo", billNo);
            }
        }

        private void txtBillDate_Leave(object sender, EventArgs e)
        {
            if (activeBill != null && !string.IsNullOrEmpty(activeBillId))
            {
                string billDate = txtBillDate.Text;
                activeBill[2].Text = billDate;
                UpdateBill("BillDate", billDate);
            }
        }

        private void txtTotalAmount_Leave(object sender, EventArgs e)
        {
            if (activeBill != null && !string.IsNullOrEmpty(activeBillId))
            {
                string totalAmount = txtTotalAmount.Text;
                activeBill[3].Text = totalAmount;
                UpdateBill("TotalAmount", totalAmount);
            }
        }

        private void txtProduct_Leave(object sender, EventArgs e)
        {
            if (activeBillItem != null && !string.IsNullOrEmpty(activeBillItemId))
            {
                string product = txtProduct.Text;
                activeBillItem[0].Text = product;
                UpdateBillItem("Product", product);
                InsertProduct(product);
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (activeBillItem != null && !string.IsNullOrEmpty(activeBillItemId))
            {
                string quantity = txtQuantity.Text;
                activeBillItem[1].Text = quantity;
                UpdateBillItem("Quantity", quantity);
                CalculateProductAmount();
            }
        }

        private void txtUnitPrice_Leave(object sender, EventArgs e)
        {
            if (activeBillItem != null && !string.IsNullOrEmpty(activeBillItemId))
            {
                string unitPrice = txtUnitPrice.Text;
                activeBillItem[2].Text = unitPrice;
                UpdateBillItem("UnitPrice", unitPrice);
                CalculateProductAmount();
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (activeBillItem != null && !string.IsNullOrEmpty(activeBillItemId))
            {
                string amount = txtAmount.Text;
                activeBillItem[3].Text = amount;
                UpdateBillItem("Amount", amount);
                CalculateTotalAmount();
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            var checkedItems = lvBillItemList.CheckedItems;
            if (checkedItems.Count > 0)
            {
                var confirmDialog = MessageBox.Show("Are you sure you want to delete selected items?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (confirmDialog == DialogResult.Yes)
                {
                    string[] id = new string[checkedItems.Count];
                    for (int i = 0; i < checkedItems.Count; i++)
                    {
                        id[i] = checkedItems[i].SubItems[4].Text;
                    }

                    int isDeleted = DeleteBillItems(id);
                    if (isDeleted == -1)
                    {
                        MessageBox.Show("Error while deleting bill items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LoadBillItems(activeBillId);
                        ClearProductDetail();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select at least one item to delete", "Delete items", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaymentDetails_Click(object sender, EventArgs e)
        {
            PaymentDetail paymentDetail = new PaymentDetail();
            paymentDetail.ShowPaymentDetail(activeBillId);
        }

        private void txtBillDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtBillDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)0x2D)
            {
                e.Handled = true;
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
