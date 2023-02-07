namespace Poppel_Order_Processing_System.PresentationLayer
{
    partial class AddModifyCustomerFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddModifyCustomerFile));
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.searchCustomerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customerSearchTextBox = new System.Windows.Forms.TextBox();
            this.customerListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.customerCreditComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.customerFileClosebutton = new System.Windows.Forms.Button();
            this.newCustomerButton = new System.Windows.Forms.Button();
            this.modifyCustomerButton = new System.Windows.Forms.Button();
            this.searchGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchGroupBox.Controls.Add(this.searchCustomerButton);
            this.searchGroupBox.Controls.Add(this.label1);
            this.searchGroupBox.Controls.Add(this.customerSearchTextBox);
            this.searchGroupBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchGroupBox.Location = new System.Drawing.Point(12, 12);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(265, 70);
            this.searchGroupBox.TabIndex = 0;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search Text";
            // 
            // searchCustomerButton
            // 
            this.searchCustomerButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCustomerButton.Location = new System.Drawing.Point(182, 41);
            this.searchCustomerButton.Name = "searchCustomerButton";
            this.searchCustomerButton.Size = new System.Drawing.Size(75, 23);
            this.searchCustomerButton.TabIndex = 2;
            this.searchCustomerButton.Text = "Search";
            this.searchCustomerButton.UseVisualStyleBackColor = true;
            this.searchCustomerButton.Click += new System.EventHandler(this.searchCustomerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Number";
            // 
            // customerSearchTextBox
            // 
            this.customerSearchTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerSearchTextBox.Location = new System.Drawing.Point(6, 42);
            this.customerSearchTextBox.Name = "customerSearchTextBox";
            this.customerSearchTextBox.Size = new System.Drawing.Size(170, 22);
            this.customerSearchTextBox.TabIndex = 0;
            this.customerSearchTextBox.TextChanged += new System.EventHandler(this.customerSearchTextBox_TextChanged);
            // 
            // customerListView
            // 
            this.customerListView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerListView.FullRowSelect = true;
            this.customerListView.GridLines = true;
            this.customerListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.customerListView.HideSelection = false;
            this.customerListView.Location = new System.Drawing.Point(12, 99);
            this.customerListView.MultiSelect = false;
            this.customerListView.Name = "customerListView";
            this.customerListView.Size = new System.Drawing.Size(928, 257);
            this.customerListView.TabIndex = 5;
            this.customerListView.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Credit Status";
            // 
            // customerCreditComboBox
            // 
            this.customerCreditComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerCreditComboBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.customerCreditComboBox.FormattingEnabled = true;
            this.customerCreditComboBox.Items.AddRange(new object[] {
            "",
            "Released",
            "Onhold"});
            this.customerCreditComboBox.Location = new System.Drawing.Point(9, 40);
            this.customerCreditComboBox.Name = "customerCreditComboBox";
            this.customerCreditComboBox.Size = new System.Drawing.Size(170, 24);
            this.customerCreditComboBox.TabIndex = 2;
            this.customerCreditComboBox.SelectedIndexChanged += new System.EventHandler(this.customerCreditComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.customerCreditComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(280, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter By";
            // 
            // customerFileClosebutton
            // 
            this.customerFileClosebutton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerFileClosebutton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Close;
            this.customerFileClosebutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.customerFileClosebutton.Location = new System.Drawing.Point(314, 371);
            this.customerFileClosebutton.Name = "customerFileClosebutton";
            this.customerFileClosebutton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.customerFileClosebutton.Size = new System.Drawing.Size(82, 67);
            this.customerFileClosebutton.TabIndex = 8;
            this.customerFileClosebutton.Text = "Close";
            this.customerFileClosebutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.customerFileClosebutton.UseVisualStyleBackColor = true;
            this.customerFileClosebutton.Click += new System.EventHandler(this.customerFileCloseButton_Click);
            // 
            // newCustomerButton
            // 
            this.newCustomerButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCustomerButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.New1;
            this.newCustomerButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newCustomerButton.Location = new System.Drawing.Point(147, 371);
            this.newCustomerButton.Name = "newCustomerButton";
            this.newCustomerButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.newCustomerButton.Size = new System.Drawing.Size(82, 67);
            this.newCustomerButton.TabIndex = 7;
            this.newCustomerButton.Text = "New";
            this.newCustomerButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newCustomerButton.UseVisualStyleBackColor = true;
            this.newCustomerButton.Click += new System.EventHandler(this.newCustomerButton_Click);
            // 
            // modifyCustomerButton
            // 
            this.modifyCustomerButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyCustomerButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Modify;
            this.modifyCustomerButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modifyCustomerButton.Location = new System.Drawing.Point(46, 371);
            this.modifyCustomerButton.Name = "modifyCustomerButton";
            this.modifyCustomerButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.modifyCustomerButton.Size = new System.Drawing.Size(82, 67);
            this.modifyCustomerButton.TabIndex = 6;
            this.modifyCustomerButton.Text = "Modify";
            this.modifyCustomerButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.modifyCustomerButton.UseVisualStyleBackColor = true;
            this.modifyCustomerButton.Click += new System.EventHandler(this.modifyCustomerButton_Click);
            this.modifyCustomerButton.MouseHover += new System.EventHandler(this.modifyCustomerButton_MouseHover);
            // 
            // AddModifyCustomerFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(952, 450);
            this.Controls.Add(this.customerFileClosebutton);
            this.Controls.Add(this.newCustomerButton);
            this.Controls.Add(this.modifyCustomerButton);
            this.Controls.Add(this.customerListView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.searchGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddModifyCustomerFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer File";
            this.Activated += new System.EventHandler(this.AddModifyCustomerFile_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddModifyCustomerFile_FormClosed);
            this.Load += new System.EventHandler(this.AddModifyCustomerFile_Load);
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.TextBox customerSearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchCustomerButton;
        private System.Windows.Forms.ListView customerListView;
        private System.Windows.Forms.Button modifyCustomerButton;
        private System.Windows.Forms.Button newCustomerButton;
        private System.Windows.Forms.Button customerFileClosebutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox customerCreditComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}