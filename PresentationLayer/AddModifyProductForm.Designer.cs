namespace Poppel_Order_Processing_System.PresentationLayer
{
    partial class AddModifyProductForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddModifyProductForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveProductButton = new System.Windows.Forms.Button();
            this.quantityOnHandTextBox = new System.Windows.Forms.TextBox();
            this.productDetailsTextBox = new System.Windows.Forms.TextBox();
            this.productIdTextBox = new System.Windows.Forms.TextBox();
            this.retailPriceTextBox = new System.Windows.Forms.TextBox();
            this.costPriceTextBox = new System.Windows.Forms.TextBox();
            this.profitTextBox = new System.Windows.Forms.TextBox();
            this.closeProductFormButton = new System.Windows.Forms.Button();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.nextProductButton = new System.Windows.Forms.Button();
            this.previousProductButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.productCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.expiryDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackExpiryDateCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveProductButton
            // 
            this.saveProductButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveProductButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Save;
            this.saveProductButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveProductButton.Location = new System.Drawing.Point(151, 216);
            this.saveProductButton.Name = "saveProductButton";
            this.saveProductButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.saveProductButton.Size = new System.Drawing.Size(82, 67);
            this.saveProductButton.TabIndex = 9;
            this.saveProductButton.Text = "Save";
            this.saveProductButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.saveProductButton, "Save Customer");
            this.saveProductButton.UseVisualStyleBackColor = true;
            this.saveProductButton.Click += new System.EventHandler(this.saveProductButton_Click);
            // 
            // quantityOnHandTextBox
            // 
            this.quantityOnHandTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityOnHandTextBox.Location = new System.Drawing.Point(572, 55);
            this.quantityOnHandTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.quantityOnHandTextBox.MinimumSize = new System.Drawing.Size(4, 24);
            this.quantityOnHandTextBox.Name = "quantityOnHandTextBox";
            this.quantityOnHandTextBox.ReadOnly = true;
            this.quantityOnHandTextBox.Size = new System.Drawing.Size(80, 22);
            this.quantityOnHandTextBox.TabIndex = 7;
            this.quantityOnHandTextBox.Text = "0";
            this.toolTip1.SetToolTip(this.quantityOnHandTextBox, "Enter Customer Details");
            this.quantityOnHandTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quantityOnHandTextBox_KeyDown);
            // 
            // productDetailsTextBox
            // 
            this.productDetailsTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productDetailsTextBox.Location = new System.Drawing.Point(119, 50);
            this.productDetailsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.productDetailsTextBox.MinimumSize = new System.Drawing.Size(4, 24);
            this.productDetailsTextBox.Name = "productDetailsTextBox";
            this.productDetailsTextBox.Size = new System.Drawing.Size(299, 22);
            this.productDetailsTextBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.productDetailsTextBox, "Enter Customer Details");
            this.productDetailsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productDetailsTextBox_KeyDown);
            // 
            // productIdTextBox
            // 
            this.productIdTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productIdTextBox.Location = new System.Drawing.Point(119, 25);
            this.productIdTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.productIdTextBox.MinimumSize = new System.Drawing.Size(4, 24);
            this.productIdTextBox.Name = "productIdTextBox";
            this.productIdTextBox.Size = new System.Drawing.Size(156, 22);
            this.productIdTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.productIdTextBox, "Enter Customer Details");
            this.productIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productIdTextBox_KeyDown);
            this.productIdTextBox.Leave += new System.EventHandler(this.productIdTextBox_Leave);
            // 
            // retailPriceTextBox
            // 
            this.retailPriceTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retailPriceTextBox.Location = new System.Drawing.Point(119, 102);
            this.retailPriceTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.retailPriceTextBox.MinimumSize = new System.Drawing.Size(4, 24);
            this.retailPriceTextBox.Name = "retailPriceTextBox";
            this.retailPriceTextBox.Size = new System.Drawing.Size(80, 22);
            this.retailPriceTextBox.TabIndex = 3;
            this.retailPriceTextBox.Text = "0.00";
            this.toolTip1.SetToolTip(this.retailPriceTextBox, "Enter Customer Details");
            this.retailPriceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.retailPriceTextBox_KeyDown);
            this.retailPriceTextBox.Leave += new System.EventHandler(this.retailPriceTextBox_Leave);
            // 
            // costPriceTextBox
            // 
            this.costPriceTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costPriceTextBox.Location = new System.Drawing.Point(119, 127);
            this.costPriceTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.costPriceTextBox.MinimumSize = new System.Drawing.Size(4, 24);
            this.costPriceTextBox.Name = "costPriceTextBox";
            this.costPriceTextBox.Size = new System.Drawing.Size(80, 22);
            this.costPriceTextBox.TabIndex = 4;
            this.costPriceTextBox.Text = "0.00";
            this.toolTip1.SetToolTip(this.costPriceTextBox, "Enter Customer Details");
            this.costPriceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.costPriceTextBox_KeyDown);
            this.costPriceTextBox.Leave += new System.EventHandler(this.costPriceTextBox_Leave);
            // 
            // profitTextBox
            // 
            this.profitTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profitTextBox.Location = new System.Drawing.Point(119, 152);
            this.profitTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.profitTextBox.MinimumSize = new System.Drawing.Size(4, 24);
            this.profitTextBox.Name = "profitTextBox";
            this.profitTextBox.ReadOnly = true;
            this.profitTextBox.Size = new System.Drawing.Size(80, 22);
            this.profitTextBox.TabIndex = 5;
            this.profitTextBox.Text = "0.00";
            this.toolTip1.SetToolTip(this.profitTextBox, "Enter Customer Details");
            this.profitTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.profitTextBox_KeyDown);
            // 
            // closeProductFormButton
            // 
            this.closeProductFormButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeProductFormButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Close;
            this.closeProductFormButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeProductFormButton.Location = new System.Drawing.Point(487, 216);
            this.closeProductFormButton.Name = "closeProductFormButton";
            this.closeProductFormButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.closeProductFormButton.Size = new System.Drawing.Size(82, 67);
            this.closeProductFormButton.TabIndex = 13;
            this.closeProductFormButton.Text = "Close";
            this.closeProductFormButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeProductFormButton.UseVisualStyleBackColor = true;
            this.closeProductFormButton.Click += new System.EventHandler(this.closeProductFormButton_Click);
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteProductButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Delete;
            this.deleteProductButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteProductButton.Location = new System.Drawing.Point(403, 216);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.deleteProductButton.Size = new System.Drawing.Size(82, 67);
            this.deleteProductButton.TabIndex = 12;
            this.deleteProductButton.Text = "Delete";
            this.deleteProductButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteProductButton.UseVisualStyleBackColor = true;
            this.deleteProductButton.Click += new System.EventHandler(this.deleteProductButton_Click);
            // 
            // nextProductButton
            // 
            this.nextProductButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextProductButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Next;
            this.nextProductButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.nextProductButton.Location = new System.Drawing.Point(319, 216);
            this.nextProductButton.Name = "nextProductButton";
            this.nextProductButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.nextProductButton.Size = new System.Drawing.Size(82, 67);
            this.nextProductButton.TabIndex = 11;
            this.nextProductButton.Text = "Next";
            this.nextProductButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.nextProductButton.UseVisualStyleBackColor = true;
            this.nextProductButton.Click += new System.EventHandler(this.nextProductButton_Click);
            // 
            // previousProductButton
            // 
            this.previousProductButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousProductButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Last1;
            this.previousProductButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.previousProductButton.Location = new System.Drawing.Point(235, 216);
            this.previousProductButton.Name = "previousProductButton";
            this.previousProductButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.previousProductButton.Size = new System.Drawing.Size(82, 67);
            this.previousProductButton.TabIndex = 10;
            this.previousProductButton.Text = "Previous";
            this.previousProductButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.previousProductButton.UseVisualStyleBackColor = true;
            this.previousProductButton.Click += new System.EventHandler(this.previousProductButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(448, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Track Expiry Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(448, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Product Category";
            // 
            // productCategoryComboBox
            // 
            this.productCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productCategoryComboBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productCategoryComboBox.FormattingEnabled = true;
            this.productCategoryComboBox.Location = new System.Drawing.Point(572, 27);
            this.productCategoryComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.productCategoryComboBox.Name = "productCategoryComboBox";
            this.productCategoryComboBox.Size = new System.Drawing.Size(125, 24);
            this.productCategoryComboBox.TabIndex = 6;
            this.productCategoryComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productCategoryComboBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(448, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Quantity On Hand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(18, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Expiry Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(18, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Product Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Product  Id";
            // 
            // expiryDateTimePicker
            // 
            this.expiryDateTimePicker.CustomFormat = "";
            this.expiryDateTimePicker.Font = new System.Drawing.Font("Arial", 9.75F);
            this.expiryDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expiryDateTimePicker.Location = new System.Drawing.Point(119, 75);
            this.expiryDateTimePicker.MinimumSize = new System.Drawing.Size(4, 24);
            this.expiryDateTimePicker.Name = "expiryDateTimePicker";
            this.expiryDateTimePicker.Size = new System.Drawing.Size(156, 24);
            this.expiryDateTimePicker.TabIndex = 2;
            this.expiryDateTimePicker.Tag = "";
            this.expiryDateTimePicker.Value = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.expiryDateTimePicker.ValueChanged += new System.EventHandler(this.expiryDateTimePicker_ValueChanged);
            this.expiryDateTimePicker.Enter += new System.EventHandler(this.expiryDateTimePicker_Enter);
            this.expiryDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.expiryDateTimePicker_KeyDown);
            this.expiryDateTimePicker.MouseEnter += new System.EventHandler(this.expiryDateTimePicker_MouseEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(18, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "Retail Price (R)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(17, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 43;
            this.label6.Text = "Cost Price (R)";
            // 
            // trackExpiryDateCheckBox
            // 
            this.trackExpiryDateCheckBox.AutoSize = true;
            this.trackExpiryDateCheckBox.Checked = true;
            this.trackExpiryDateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trackExpiryDateCheckBox.Location = new System.Drawing.Point(572, 84);
            this.trackExpiryDateCheckBox.Name = "trackExpiryDateCheckBox";
            this.trackExpiryDateCheckBox.Size = new System.Drawing.Size(15, 14);
            this.trackExpiryDateCheckBox.TabIndex = 8;
            this.trackExpiryDateCheckBox.UseVisualStyleBackColor = true;
            this.trackExpiryDateCheckBox.CheckedChanged += new System.EventHandler(this.trackExpiryDateCheckBox_CheckedChanged);
            this.trackExpiryDateCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackExpiryDateCheckBox_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(17, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 46;
            this.label9.Text = "Profit (R)";
            // 
            // AddModifyProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(716, 302);
            this.Controls.Add(this.profitTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackExpiryDateCheckBox);
            this.Controls.Add(this.costPriceTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.retailPriceTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.expiryDateTimePicker);
            this.Controls.Add(this.closeProductFormButton);
            this.Controls.Add(this.deleteProductButton);
            this.Controls.Add(this.nextProductButton);
            this.Controls.Add(this.previousProductButton);
            this.Controls.Add(this.saveProductButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.productCategoryComboBox);
            this.Controls.Add(this.quantityOnHandTextBox);
            this.Controls.Add(this.productDetailsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.productIdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddModifyProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Maintenance (Add New)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button saveProductButton;
        private System.Windows.Forms.TextBox quantityOnHandTextBox;
        private System.Windows.Forms.Button closeProductFormButton;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Button nextProductButton;
        private System.Windows.Forms.Button previousProductButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox productCategoryComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox trackExpiryDateCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox productDetailsTextBox;
        private System.Windows.Forms.TextBox productIdTextBox;
        private System.Windows.Forms.TextBox retailPriceTextBox;
        private System.Windows.Forms.TextBox costPriceTextBox;
        private System.Windows.Forms.TextBox profitTextBox;
        private System.Windows.Forms.DateTimePicker expiryDateTimePicker;
    }
}