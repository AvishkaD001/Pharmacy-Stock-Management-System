namespace StaffStockManagement
{
    partial class Form1
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
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.cmbStockType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDrugName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.dtpSupplierDate = new System.Windows.Forms.DateTimePicker();
            this.btnLoadStock = new System.Windows.Forms.Button();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.btnDeleteStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(477, 12);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.RowTemplate.Height = 24;
            this.dgvStock.Size = new System.Drawing.Size(872, 717);
            this.dgvStock.TabIndex = 0;
            // 
            // cmbStockType
            // 
            this.cmbStockType.FormattingEnabled = true;
            this.cmbStockType.Items.AddRange(new object[] {
            "Internal",
            "External"});
            this.cmbStockType.Location = new System.Drawing.Point(209, 46);
            this.cmbStockType.Name = "cmbStockType";
            this.cmbStockType.Size = new System.Drawing.Size(121, 24);
            this.cmbStockType.TabIndex = 1;
            this.cmbStockType.Text = "StockType";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Drug Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Expiry Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Manufacture Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(63, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Stock Location";
            // 
            // txtDrugName
            // 
            this.txtDrugName.Location = new System.Drawing.Point(209, 91);
            this.txtDrugName.Name = "txtDrugName";
            this.txtDrugName.Size = new System.Drawing.Size(121, 22);
            this.txtDrugName.TabIndex = 9;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(209, 137);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(121, 22);
            this.txtQuantity.TabIndex = 10;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(209, 279);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(121, 22);
            this.txtLocation.TabIndex = 11;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(209, 327);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(121, 22);
            this.txtPrice.TabIndex = 12;
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Location = new System.Drawing.Point(226, 179);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 22);
            this.dtpExpiryDate.TabIndex = 13;
            // 
            // dtpManufactureDate
            // 
            this.dtpManufactureDate.Location = new System.Drawing.Point(228, 227);
            this.dtpManufactureDate.Name = "dtpManufactureDate";
            this.dtpManufactureDate.Size = new System.Drawing.Size(200, 22);
            this.dtpManufactureDate.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(102, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "If Drug is External fill that";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(63, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(63, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Supplier Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(63, 503);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Supplier Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 551);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Company Name";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(228, 449);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(121, 22);
            this.txtSupplierName.TabIndex = 19;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(237, 549);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(121, 22);
            this.txtCompanyName.TabIndex = 20;
            // 
            // dtpSupplierDate
            // 
            this.dtpSupplierDate.Location = new System.Drawing.Point(226, 501);
            this.dtpSupplierDate.Name = "dtpSupplierDate";
            this.dtpSupplierDate.Size = new System.Drawing.Size(200, 22);
            this.dtpSupplierDate.TabIndex = 21;
            // 
            // btnLoadStock
            // 
            this.btnLoadStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadStock.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnLoadStock.Location = new System.Drawing.Point(62, 594);
            this.btnLoadStock.Name = "btnLoadStock";
            this.btnLoadStock.Size = new System.Drawing.Size(103, 55);
            this.btnLoadStock.TabIndex = 22;
            this.btnLoadStock.Text = "Load Stock";
            this.btnLoadStock.UseVisualStyleBackColor = true;
            this.btnLoadStock.Click += new System.EventHandler(this.btnLoadStock_Click);
            // 
            // btnAddStock
            // 
            this.btnAddStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddStock.Location = new System.Drawing.Point(226, 594);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(103, 55);
            this.btnAddStock.TabIndex = 23;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click_1);
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStock.ForeColor = System.Drawing.Color.Coral;
            this.btnUpdateStock.Location = new System.Drawing.Point(62, 655);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(103, 55);
            this.btnUpdateStock.TabIndex = 24;
            this.btnUpdateStock.Text = "Update Stock";
            this.btnUpdateStock.UseVisualStyleBackColor = true;
            this.btnUpdateStock.Click += new System.EventHandler(this.btnUpdateStock_Click_1);
            // 
            // btnDeleteStock
            // 
            this.btnDeleteStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStock.ForeColor = System.Drawing.Color.Crimson;
            this.btnDeleteStock.Location = new System.Drawing.Point(226, 655);
            this.btnDeleteStock.Name = "btnDeleteStock";
            this.btnDeleteStock.Size = new System.Drawing.Size(103, 55);
            this.btnDeleteStock.TabIndex = 25;
            this.btnDeleteStock.Text = "Delete Stock";
            this.btnDeleteStock.UseVisualStyleBackColor = true;
            this.btnDeleteStock.Click += new System.EventHandler(this.btnDeleteStock_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 741);
            this.Controls.Add(this.btnDeleteStock);
            this.Controls.Add(this.btnUpdateStock);
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(this.btnLoadStock);
            this.Controls.Add(this.dtpSupplierDate);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpManufactureDate);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtDrugName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStockType);
            this.Controls.Add(this.dgvStock);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.ComboBox cmbStockType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDrugName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpManufactureDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.DateTimePicker dtpSupplierDate;
        private System.Windows.Forms.Button btnLoadStock;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnUpdateStock;
        private System.Windows.Forms.Button btnDeleteStock;
    }
}

