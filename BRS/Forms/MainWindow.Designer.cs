
namespace BRS.Forms
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.billsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPendingBills = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNormalBills = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVendor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.billsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // billsToolStripMenuItem
            // 
            this.billsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPendingBills,
            this.menuNormalBills,
            this.menuVendor});
            this.billsToolStripMenuItem.Name = "billsToolStripMenuItem";
            this.billsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.billsToolStripMenuItem.Text = "Page";
            // 
            // menuPendingBills
            // 
            this.menuPendingBills.Name = "menuPendingBills";
            this.menuPendingBills.Size = new System.Drawing.Size(180, 22);
            this.menuPendingBills.Text = "Pending bills";
            this.menuPendingBills.Click += new System.EventHandler(this.menuPendingBills_Click);
            // 
            // menuNormalBills
            // 
            this.menuNormalBills.Name = "menuNormalBills";
            this.menuNormalBills.Size = new System.Drawing.Size(180, 22);
            this.menuNormalBills.Text = "Normal bills";
            this.menuNormalBills.Click += new System.EventHandler(this.menuNormalBills_Click);
            // 
            // menuVendor
            // 
            this.menuVendor.Name = "menuVendor";
            this.menuVendor.Size = new System.Drawing.Size(180, 22);
            this.menuVendor.Text = "List page";
            this.menuVendor.Click += new System.EventHandler(this.menuVendor_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing system";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem billsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuPendingBills;
        private System.Windows.Forms.ToolStripMenuItem menuNormalBills;
        private System.Windows.Forms.ToolStripMenuItem menuVendor;
    }
}