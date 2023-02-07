namespace Poppel_Order_Processing_System.PresentationLayer
{
    partial class AddModifyStockFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddModifyStockFile));
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.stockSearchTextBox = new System.Windows.Forms.TextBox();
            this.stockSearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.expiryDateComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stockCatergoryComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stockFileClosebutton = new System.Windows.Forms.Button();
            this.newStockButton = new System.Windows.Forms.Button();
            this.modifyStockButton = new System.Windows.Forms.Button();
            this.stockFileListView = new System.Windows.Forms.ListView();
            this.searchGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.stockSearchTextBox);
            this.searchGroupBox.Controls.Add(this.stockSearchButton);
            this.searchGroupBox.Controls.Add(this.label1);
            this.searchGroupBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchGroupBox.Location = new System.Drawing.Point(12, 12);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(266, 70);
            this.searchGroupBox.TabIndex = 9;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search Text";
            // 
            // stockSearchTextBox
            // 
            this.stockSearchTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockSearchTextBox.Location = new System.Drawing.Point(8, 41);
            this.stockSearchTextBox.Name = "stockSearchTextBox";
            this.stockSearchTextBox.Size = new System.Drawing.Size(170, 22);
            this.stockSearchTextBox.TabIndex = 0;
            this.stockSearchTextBox.TextChanged += new System.EventHandler(this.stockSearchTextBox_TextChanged);
            // 
            // stockSearchButton
            // 
            this.stockSearchButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockSearchButton.Location = new System.Drawing.Point(182, 41);
            this.stockSearchButton.Name = "stockSearchButton";
            this.stockSearchButton.Size = new System.Drawing.Size(75, 23);
            this.stockSearchButton.TabIndex = 1;
            this.stockSearchButton.Text = "Search";
            this.stockSearchButton.UseVisualStyleBackColor = true;
            this.stockSearchButton.Click += new System.EventHandler(this.stockSearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Id";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.expiryDateComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.stockCatergoryComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(281, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 70);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter By";
            // 
            // expiryDateComboBox
            // 
            this.expiryDateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expiryDateComboBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiryDateComboBox.FormattingEnabled = true;
            this.expiryDateComboBox.Items.AddRange(new object[] {
            "",
            "Yes",
            "No"});
            this.expiryDateComboBox.Location = new System.Drawing.Point(181, 42);
            this.expiryDateComboBox.Name = "expiryDateComboBox";
            this.expiryDateComboBox.Size = new System.Drawing.Size(80, 24);
            this.expiryDateComboBox.TabIndex = 3;
            this.expiryDateComboBox.SelectedIndexChanged += new System.EventHandler(this.expiryDateComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(179, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Expiry Date";
            // 
            // stockCatergoryComboBox
            // 
            this.stockCatergoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockCatergoryComboBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCatergoryComboBox.FormattingEnabled = true;
            this.stockCatergoryComboBox.Location = new System.Drawing.Point(9, 42);
            this.stockCatergoryComboBox.Name = "stockCatergoryComboBox";
            this.stockCatergoryComboBox.Size = new System.Drawing.Size(170, 24);
            this.stockCatergoryComboBox.TabIndex = 2;
            this.stockCatergoryComboBox.SelectedIndexChanged += new System.EventHandler(this.stockCatergoryComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stock Category";
            // 
            // stockFileClosebutton
            // 
            this.stockFileClosebutton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockFileClosebutton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Close;
            this.stockFileClosebutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.stockFileClosebutton.Location = new System.Drawing.Point(314, 371);
            this.stockFileClosebutton.Name = "stockFileClosebutton";
            this.stockFileClosebutton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.stockFileClosebutton.Size = new System.Drawing.Size(82, 67);
            this.stockFileClosebutton.TabIndex = 7;
            this.stockFileClosebutton.Text = "Close";
            this.stockFileClosebutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.stockFileClosebutton.UseVisualStyleBackColor = true;
            this.stockFileClosebutton.Click += new System.EventHandler(this.stockFileCloseButton_Click);
            // 
            // newStockButton
            // 
            this.newStockButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newStockButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.New1;
            this.newStockButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newStockButton.Location = new System.Drawing.Point(147, 371);
            this.newStockButton.Name = "newStockButton";
            this.newStockButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.newStockButton.Size = new System.Drawing.Size(82, 67);
            this.newStockButton.TabIndex = 6;
            this.newStockButton.Text = "New";
            this.newStockButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newStockButton.UseVisualStyleBackColor = true;
            this.newStockButton.Click += new System.EventHandler(this.newStockButton_Click);
            // 
            // modifyStockButton
            // 
            this.modifyStockButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyStockButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Modify;
            this.modifyStockButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modifyStockButton.Location = new System.Drawing.Point(46, 371);
            this.modifyStockButton.Name = "modifyStockButton";
            this.modifyStockButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.modifyStockButton.Size = new System.Drawing.Size(82, 67);
            this.modifyStockButton.TabIndex = 5;
            this.modifyStockButton.Text = "Modify";
            this.modifyStockButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.modifyStockButton.UseVisualStyleBackColor = true;
            this.modifyStockButton.Click += new System.EventHandler(this.modifyStockButton_Click);
            this.modifyStockButton.MouseHover += new System.EventHandler(this.modifyStockButton_MouseHover);
            // 
            // stockFileListView
            // 
            this.stockFileListView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockFileListView.FullRowSelect = true;
            this.stockFileListView.GridLines = true;
            this.stockFileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.stockFileListView.HideSelection = false;
            this.stockFileListView.LabelWrap = false;
            this.stockFileListView.Location = new System.Drawing.Point(12, 99);
            this.stockFileListView.MultiSelect = false;
            this.stockFileListView.Name = "stockFileListView";
            this.stockFileListView.Size = new System.Drawing.Size(915, 257);
            this.stockFileListView.TabIndex = 4;
            this.stockFileListView.UseCompatibleStateImageBehavior = false;
            // 
            // AddModifyStockFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.stockFileListView);
            this.Controls.Add(this.searchGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.stockFileClosebutton);
            this.Controls.Add(this.newStockButton);
            this.Controls.Add(this.modifyStockButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddModifyStockFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock File";
            this.Activated += new System.EventHandler(this.AddModifyStockFile_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddModifyStockFile_FormClosed);
            this.Load += new System.EventHandler(this.AddModifyStockFile_Load);
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.Button stockSearchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox stockCatergoryComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stockFileClosebutton;
        private System.Windows.Forms.Button newStockButton;
        private System.Windows.Forms.Button modifyStockButton;
        private System.Windows.Forms.ComboBox expiryDateComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView stockFileListView;
        private System.Windows.Forms.TextBox stockSearchTextBox;
    }
}