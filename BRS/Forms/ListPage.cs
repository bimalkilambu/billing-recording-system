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
    public partial class ListPage : Form
    {
        private static SQLiteHelper sqliteHelper { get { return ApplicationManager.sqliteHelper; } }
        private DataTable ProductList { get; set; }
        private DataTable VendorList { get; set; }

        public ListPage()
        {
            InitializeComponent();
            LoadVendorList();
            LoadProductList();
        }

        private void LoadVendorList()
        {
            string sqlQuery = "SELECT * FROM Vendors";
            VendorList = sqliteHelper.GetDataTable(sqlQuery);
        }

        private void LoadVendors()
        {
            lvVendors.Items.Clear();

            for (int i = 0; i < VendorList.Rows.Count; i++)
            {
                AddVendorToListView(VendorList.Rows[i]);
            }
        }

        private void AddVendorToListView(DataRow vendor)
        {
            ListViewItem item = new ListViewItem(vendor["Name"].ToString());
            item.SubItems.Add(vendor["VendorId"].ToString());
            lvVendors.Items.Add(item);

        }

        private void LoadProductList()
        {
            string sqlQuery = "SELECT * FROM Products";
            ProductList = sqliteHelper.GetDataTable(sqlQuery);
        }

        private void AddProductToListView(DataRow product)
        {
            ListViewItem item = new ListViewItem(product["Name"].ToString());
            item.SubItems.Add(product["ProductId"].ToString());
            lvProduct.Items.Add(item);

        }

        private void LoadProducts()
        {
            lvProduct.Items.Clear();

            for (int i = 0; i < ProductList.Rows.Count; i++)
            {
                AddProductToListView(ProductList.Rows[i]);
            }
        }

        private void FilterVendor(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                LoadVendors();
            }
            else
            {
                lvVendors.Items.Clear();
                searchText = searchText.ToLower();

                for (int i = 0; i < VendorList.Rows.Count; i++)
                {
                    if (VendorList.Rows[i]["Name"].ToString().ToLower().Contains(searchText))
                    {
                        AddVendorToListView(VendorList.Rows[i]);
                    }
                }
            }
        }

        private void FilterProduct(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                LoadProducts();
            }
            else
            {
                lvProduct.Items.Clear();
                searchText = searchText.ToLower();

                for (int i = 0; i < ProductList.Rows.Count; i++)
                {
                    if (ProductList.Rows[i]["Name"].ToString().ToLower().Contains(searchText))
                    {
                        AddProductToListView(ProductList.Rows[i]);
                    }
                }
            }
        }

        private int DeleteVendors(string[] ids)
        {
            string sqlQuery = $"DELETE FROM Vendors WHERE VendorId IN ({string.Join(",", ids)});";
            return sqliteHelper.ExecuteSql(sqlQuery);
        }

        private int DeleteProduct(string[] ids)
        {
            string sqlQuery = $"DELETE FROM Products WHERE ProductId IN ({string.Join(",", ids)});";
            return sqliteHelper.ExecuteSql(sqlQuery);
        }


        private void ListPage_Load(object sender, EventArgs e)
        {
            LoadVendors();
            LoadProducts();
        }

        private void txtSearchVendor_TextChanged(object sender, EventArgs e)
        {
            FilterVendor(txtSearchVendor.Text.Trim());
        }

        private void btnDeleteVendor_Click(object sender, EventArgs e)
        {
            var checkedItems = lvVendors.CheckedItems;
            if (checkedItems.Count > 0)
            {
                var confirmDialog = MessageBox.Show("Are you sure you want to delete selected vendors?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (confirmDialog == DialogResult.Yes)
                {
                    string[] id = new string[checkedItems.Count];
                    for (int i = 0; i < checkedItems.Count; i++)
                    {
                        id[i] = checkedItems[i].SubItems[1].Text;
                    }

                    int isDeleted = DeleteVendors(id);
                    if (isDeleted == -1)
                    {
                        MessageBox.Show("Error while deleting vendors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LoadVendorList();
                        LoadVendors();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select at least one vendor to delete", "Delete items", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            var checkedItems = lvProduct.CheckedItems;
            if (checkedItems.Count > 0)
            {
                var confirmDialog = MessageBox.Show("Are you sure you want to delete selected products?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (confirmDialog == DialogResult.Yes)
                {
                    string[] id = new string[checkedItems.Count];
                    for (int i = 0; i < checkedItems.Count; i++)
                    {
                        id[i] = checkedItems[i].SubItems[1].Text;
                    }

                    int isDeleted = DeleteProduct(id);
                    if (isDeleted == -1)
                    {
                        MessageBox.Show("Error while deleting products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LoadProductList();
                        LoadProducts();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select at least one product to delete", "Delete items", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            FilterProduct(txtSearchProduct.Text.Trim());
        }
    }
}
