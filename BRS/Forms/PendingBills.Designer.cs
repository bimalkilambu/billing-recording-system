
namespace BRS.Forms
{
    partial class PendingBills
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvPendingBills = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPaymentDetail = new System.Windows.Forms.GroupBox();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.txtPaidDate = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.lblCheque = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblManualBillNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.grpPaymentDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pending Bills";
            // 
            // lvPendingBills
            // 
            this.lvPendingBills.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvPendingBills.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvPendingBills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPendingBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvPendingBills.FullRowSelect = true;
            this.lvPendingBills.GridLines = true;
            this.lvPendingBills.HideSelection = false;
            this.lvPendingBills.Location = new System.Drawing.Point(12, 45);
            this.lvPendingBills.Name = "lvPendingBills";
            this.lvPendingBills.Size = new System.Drawing.Size(780, 270);
            this.lvPendingBills.TabIndex = 1;
            this.lvPendingBills.UseCompatibleStateImageBehavior = false;
            this.lvPendingBills.View = System.Windows.Forms.View.Details;
            this.lvPendingBills.ItemActivate += new System.EventHandler(this.lvPendingBills_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Vendor";
            this.columnHeader1.Width = 191;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Manual bill no.";
            this.columnHeader2.Width = 84;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bill date";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Bill amount";
            this.columnHeader4.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Paid amount";
            this.columnHeader5.Width = 101;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Credit amount";
            this.columnHeader6.Width = 112;
            // 
            // grpPaymentDetail
            // 
            this.grpPaymentDetail.Controls.Add(this.cmbPaymentType);
            this.grpPaymentDetail.Controls.Add(this.txtBank);
            this.grpPaymentDetail.Controls.Add(this.txtPaidAmount);
            this.grpPaymentDetail.Controls.Add(this.txtPaidDate);
            this.grpPaymentDetail.Controls.Add(this.txtChequeNo);
            this.grpPaymentDetail.Controls.Add(this.btnPay);
            this.grpPaymentDetail.Controls.Add(this.lblCheque);
            this.grpPaymentDetail.Controls.Add(this.lblBank);
            this.grpPaymentDetail.Controls.Add(this.label8);
            this.grpPaymentDetail.Controls.Add(this.label7);
            this.grpPaymentDetail.Controls.Add(this.label6);
            this.grpPaymentDetail.Controls.Add(this.lblManualBillNo);
            this.grpPaymentDetail.Controls.Add(this.label4);
            this.grpPaymentDetail.Controls.Add(this.lblVendor);
            this.grpPaymentDetail.Controls.Add(this.label2);
            this.grpPaymentDetail.Location = new System.Drawing.Point(12, 320);
            this.grpPaymentDetail.Name = "grpPaymentDetail";
            this.grpPaymentDetail.Size = new System.Drawing.Size(780, 100);
            this.grpPaymentDetail.TabIndex = 2;
            this.grpPaymentDetail.TabStop = false;
            this.grpPaymentDetail.Text = "Payment detail";
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.cmbPaymentType.Location = new System.Drawing.Point(353, 17);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(154, 21);
            this.cmbPaymentType.TabIndex = 14;
            this.cmbPaymentType.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType_SelectedIndexChanged);
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(353, 77);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(154, 20);
            this.txtBank.TabIndex = 13;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Location = new System.Drawing.Point(353, 47);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(153, 20);
            this.txtPaidAmount.TabIndex = 12;
            this.txtPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaidAmount_KeyPress);
            // 
            // txtPaidDate
            // 
            this.txtPaidDate.Location = new System.Drawing.Point(76, 77);
            this.txtPaidDate.MaxLength = 10;
            this.txtPaidDate.Name = "txtPaidDate";
            this.txtPaidDate.Size = new System.Drawing.Size(129, 20);
            this.txtPaidDate.TabIndex = 11;
            this.txtPaidDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDate_KeyPress);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(644, 17);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(128, 20);
            this.txtChequeNo.TabIndex = 10;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(644, 73);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(128, 26);
            this.btnPay.TabIndex = 9;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblCheque
            // 
            this.lblCheque.AutoSize = true;
            this.lblCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheque.Location = new System.Drawing.Point(561, 20);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(79, 13);
            this.lblCheque.TabIndex = 8;
            this.lblCheque.Text = "Cheque No*:";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.Location = new System.Drawing.Point(262, 80);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(81, 13);
            this.lblBank.TabIndex = 7;
            this.lblBank.Text = "Bank Name*:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(262, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Paid amout*:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(262, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Payment type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Paid date*:";
            // 
            // lblManualBillNo
            // 
            this.lblManualBillNo.AutoSize = true;
            this.lblManualBillNo.Location = new System.Drawing.Point(76, 50);
            this.lblManualBillNo.Name = "lblManualBillNo";
            this.lblManualBillNo.Size = new System.Drawing.Size(28, 13);
            this.lblManualBillNo.TabIndex = 3;
            this.lblManualBillNo.Text = "XXX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bill no:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(76, 20);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(69, 13);
            this.lblVendor.TabIndex = 1;
            this.lblVendor.Text = "vendor name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vendor:";
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.Location = new System.Drawing.Point(643, 3);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(113, 13);
            this.lblTotalCredit.TabIndex = 3;
            this.lblTotalCredit.Text = "Total credit amount : 0";
            // 
            // PendingBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(226)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(804, 441);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.grpPaymentDetail);
            this.Controls.Add(this.lvPendingBills);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PendingBills";
            this.Text = "Pending Bills";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PendingBills_FormClosed);
            this.Load += new System.EventHandler(this.PendingBills_Load);
            this.grpPaymentDetail.ResumeLayout(false);
            this.grpPaymentDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvPendingBills;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox grpPaymentDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblManualBillNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtPaidDate;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lblCheque;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label lblTotalCredit;
    }
}