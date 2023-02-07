
namespace Poppel_Order_Processing_System.PresentationLayer.Reports
{
    partial class DailySalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailySalesReport));
            this.dailySalesReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // dailySalesReportViewer
            // 
            this.dailySalesReportViewer.BackColor = System.Drawing.Color.Gray;
            this.dailySalesReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailySalesReportViewer.Location = new System.Drawing.Point(0, 0);
            this.dailySalesReportViewer.Name = "dailySalesReportViewer";
            this.dailySalesReportViewer.Size = new System.Drawing.Size(793, 596);
            this.dailySalesReportViewer.TabIndex = 0;
            // 
            // DailySalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(793, 596);
            this.Controls.Add(this.dailySalesReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DailySalesReport";
            this.Text = "Daily Sales Report";
            this.Load += new System.EventHandler(this.DailySalesReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer dailySalesReportViewer;
    }
}