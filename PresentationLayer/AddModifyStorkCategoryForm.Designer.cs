namespace Poppel_Order_Processing_System.PresentationLayer
{
    partial class AddModifyStorkCategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddModifyStorkCategoryForm));
            this.saveStorkCategoryButton = new System.Windows.Forms.Button();
            this.closeStorkCategoryFormButton = new System.Windows.Forms.Button();
            this.stockCategoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveStorkCategoryButton
            // 
            this.saveStorkCategoryButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStorkCategoryButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Save;
            this.saveStorkCategoryButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveStorkCategoryButton.Location = new System.Drawing.Point(36, 93);
            this.saveStorkCategoryButton.Name = "saveStorkCategoryButton";
            this.saveStorkCategoryButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.saveStorkCategoryButton.Size = new System.Drawing.Size(82, 67);
            this.saveStorkCategoryButton.TabIndex = 1;
            this.saveStorkCategoryButton.Text = "Save";
            this.saveStorkCategoryButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveStorkCategoryButton.UseVisualStyleBackColor = true;
            this.saveStorkCategoryButton.Click += new System.EventHandler(this.saveStorkCategoryButton_Click);
            // 
            // closeStorkCategoryFormButton
            // 
            this.closeStorkCategoryFormButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeStorkCategoryFormButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Close;
            this.closeStorkCategoryFormButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeStorkCategoryFormButton.Location = new System.Drawing.Point(130, 93);
            this.closeStorkCategoryFormButton.Name = "closeStorkCategoryFormButton";
            this.closeStorkCategoryFormButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.closeStorkCategoryFormButton.Size = new System.Drawing.Size(82, 67);
            this.closeStorkCategoryFormButton.TabIndex = 3;
            this.closeStorkCategoryFormButton.Text = "Close";
            this.closeStorkCategoryFormButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeStorkCategoryFormButton.UseVisualStyleBackColor = true;
            this.closeStorkCategoryFormButton.Click += new System.EventHandler(this.closeStorkCategoryFormButton_Click);
            // 
            // stockCategoryTextBox
            // 
            this.stockCategoryTextBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.stockCategoryTextBox.Location = new System.Drawing.Point(36, 49);
            this.stockCategoryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.stockCategoryTextBox.MinimumSize = new System.Drawing.Size(4, 26);
            this.stockCategoryTextBox.Name = "stockCategoryTextBox";
            this.stockCategoryTextBox.Size = new System.Drawing.Size(176, 22);
            this.stockCategoryTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Stock Category Name";
            // 
            // AddModifyStorkCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(247, 182);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stockCategoryTextBox);
            this.Controls.Add(this.saveStorkCategoryButton);
            this.Controls.Add(this.closeStorkCategoryFormButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddModifyStorkCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category Maintenance (Add New)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddModifyStorkCategoryForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveStorkCategoryButton;
        private System.Windows.Forms.Button closeStorkCategoryFormButton;
        private System.Windows.Forms.TextBox stockCategoryTextBox;
        private System.Windows.Forms.Label label1;
    }
}