namespace Poppel_Order_Processing_System.PresentationLayer
{
    partial class StockQuantityAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockQuantityAdjustment));
            this.saveStockQuantityAdjustmentButton = new System.Windows.Forms.Button();
            this.closeStockQuantityAdjustmentFormButton = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.stockQtyAdjustmentIgrid = new TenTec.Windows.iGridLib.iGrid();
            this.iGrid1DefaultCellStyle = new TenTec.Windows.iGridLib.iGCellStyle(true);
            this.iGrid1DefaultColHdrStyle = new TenTec.Windows.iGridLib.iGColHdrStyle(true);
            this.iGrid1RowTextColCellStyle = new TenTec.Windows.iGridLib.iGCellStyle(true);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockQtyAdjustmentIgrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveStockQuantityAdjustmentButton
            // 
            this.saveStockQuantityAdjustmentButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStockQuantityAdjustmentButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Save;
            this.saveStockQuantityAdjustmentButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveStockQuantityAdjustmentButton.Location = new System.Drawing.Point(32, 433);
            this.saveStockQuantityAdjustmentButton.Name = "saveStockQuantityAdjustmentButton";
            this.saveStockQuantityAdjustmentButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.saveStockQuantityAdjustmentButton.Size = new System.Drawing.Size(82, 67);
            this.saveStockQuantityAdjustmentButton.TabIndex = 1;
            this.saveStockQuantityAdjustmentButton.Text = "Save";
            this.saveStockQuantityAdjustmentButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveStockQuantityAdjustmentButton.UseVisualStyleBackColor = true;
            this.saveStockQuantityAdjustmentButton.Click += new System.EventHandler(this.saveStockQuantityAdjustmentButton_Click);
            // 
            // closeStockQuantityAdjustmentFormButton
            // 
            this.closeStockQuantityAdjustmentFormButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeStockQuantityAdjustmentFormButton.Image = global::Poppel_Order_Processing_System.Properties.Resources.Close;
            this.closeStockQuantityAdjustmentFormButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeStockQuantityAdjustmentFormButton.Location = new System.Drawing.Point(128, 433);
            this.closeStockQuantityAdjustmentFormButton.Name = "closeStockQuantityAdjustmentFormButton";
            this.closeStockQuantityAdjustmentFormButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.closeStockQuantityAdjustmentFormButton.Size = new System.Drawing.Size(82, 67);
            this.closeStockQuantityAdjustmentFormButton.TabIndex = 2;
            this.closeStockQuantityAdjustmentFormButton.Text = "Close";
            this.closeStockQuantityAdjustmentFormButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeStockQuantityAdjustmentFormButton.UseVisualStyleBackColor = true;
            this.closeStockQuantityAdjustmentFormButton.Click += new System.EventHandler(this.closeStockQuantityAdjustmentFormButton_Click);
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.stockQtyAdjustmentIgrid);
            this.gridPanel.Location = new System.Drawing.Point(12, 13);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(736, 377);
            this.gridPanel.TabIndex = 5;
            // 
            // stockQtyAdjustmentIgrid
            // 
            this.stockQtyAdjustmentIgrid.DefaultCol.CellStyle = this.iGrid1DefaultCellStyle;
            this.stockQtyAdjustmentIgrid.DefaultCol.ColHdrStyle = this.iGrid1DefaultColHdrStyle;
            this.stockQtyAdjustmentIgrid.DefaultCol.SortOrder = TenTec.Windows.iGridLib.iGSortOrder.None;
            this.stockQtyAdjustmentIgrid.DefaultCol.SortType = TenTec.Windows.iGridLib.iGSortType.None;
            this.stockQtyAdjustmentIgrid.DefaultRow.CellStyle = this.iGrid1RowTextColCellStyle;
            this.stockQtyAdjustmentIgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockQtyAdjustmentIgrid.Header.AllowPress = false;
            this.stockQtyAdjustmentIgrid.Header.Height = 17;
            this.stockQtyAdjustmentIgrid.Location = new System.Drawing.Point(0, 0);
            this.stockQtyAdjustmentIgrid.Name = "stockQtyAdjustmentIgrid";
            this.stockQtyAdjustmentIgrid.ProcessEnter = false;
            this.stockQtyAdjustmentIgrid.RowSelectionInCellMode = TenTec.Windows.iGridLib.iGRowSelectionInCellModeTypes.SingleRow;
            this.stockQtyAdjustmentIgrid.RowTextCol.CellStyle = this.iGrid1DefaultCellStyle;
            this.stockQtyAdjustmentIgrid.SingleClickEdit = true;
            this.stockQtyAdjustmentIgrid.Size = new System.Drawing.Size(736, 377);
            this.stockQtyAdjustmentIgrid.TabIndex = 0;
            this.stockQtyAdjustmentIgrid.VScrollBar.HeightOverride = null;
            this.stockQtyAdjustmentIgrid.VScrollBar.Visibility = TenTec.Windows.iGridLib.iGScrollBarVisibility.Always;
            this.stockQtyAdjustmentIgrid.VScrollBar.WidthOverride = null;
            this.stockQtyAdjustmentIgrid.BeforeCommitEdit += new TenTec.Windows.iGridLib.iGBeforeCommitEditEventHandler(this.stockQtyAdjustmentIgrid_BeforeCommitEdit);
            this.stockQtyAdjustmentIgrid.AfterCommitEdit += new TenTec.Windows.iGridLib.iGAfterCommitEditEventHandler(this.AfterEdit);
            this.stockQtyAdjustmentIgrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stockQtyAdjustmentIgrid_KeyDown);
            // 
            // iGrid1DefaultCellStyle
            // 
            this.iGrid1DefaultCellStyle.SingleClickEdit = TenTec.Windows.iGridLib.iGBool.True;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.totalTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 27);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(566, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total:";
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.totalTextBox.Location = new System.Drawing.Point(614, 3);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(103, 21);
            this.totalTextBox.TabIndex = 4;
            this.totalTextBox.TabStop = false;
            // 
            // StockQuantityAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(760, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.saveStockQuantityAdjustmentButton);
            this.Controls.Add(this.closeStockQuantityAdjustmentFormButton);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockQuantityAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Quantity Adjustment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockQuantityAdjustment_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StockQuantityAdjustment_FormClosed);
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockQtyAdjustmentIgrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveStockQuantityAdjustmentButton;
        private System.Windows.Forms.Button closeStockQuantityAdjustmentFormButton;
        private System.Windows.Forms.Panel gridPanel;
        private TenTec.Windows.iGridLib.iGrid stockQtyAdjustmentIgrid;
        private TenTec.Windows.iGridLib.iGCellStyle iGrid1DefaultCellStyle;
        private TenTec.Windows.iGridLib.iGColHdrStyle iGrid1DefaultColHdrStyle;
        private System.Windows.Forms.ToolTip toolTip1;
        private TenTec.Windows.iGridLib.iGCellStyle iGrid1RowTextColCellStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Label label1;
    }
}