
namespace Poppel_Order_Processing_System.PresentationLayer.Reports
{
    partial class ExpiredProductReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpiredProductReport));
            this.ExpiredProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.poppelOrderProcessingSystemDataSet = new Poppel_Order_Processing_System.PoppelOrderProcessingSystemDataSet();
            this.expiredProductReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.poppelOrderProcessingSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expiredProductsTableAdapter = new Poppel_Order_Processing_System.PoppelOrderProcessingSystemDataSetTableAdapters.ExpiredProductsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ExpiredProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poppelOrderProcessingSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poppelOrderProcessingSystemDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ExpiredProductsBindingSource
            // 
            this.ExpiredProductsBindingSource.DataMember = "ExpiredProducts";
            this.ExpiredProductsBindingSource.DataSource = this.poppelOrderProcessingSystemDataSet;
            // 
            // poppelOrderProcessingSystemDataSet
            // 
            this.poppelOrderProcessingSystemDataSet.DataSetName = "PoppelOrderProcessingSystemDataSet";
            this.poppelOrderProcessingSystemDataSet.EnforceConstraints = false;
            this.poppelOrderProcessingSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // expiredProductReportViewer
            // 
            this.expiredProductReportViewer.BackColor = System.Drawing.Color.Gray;
            this.expiredProductReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expiredProductReportViewer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource1.Name = "PoppelOrderProcessingSystemDataSet";
            reportDataSource1.Value = this.ExpiredProductsBindingSource;
            this.expiredProductReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.expiredProductReportViewer.LocalReport.ReportEmbeddedResource = "Poppel_Order_Processing_System.PresentationLayer.Reports.ExpiredProductReport.rdl" +
    "c";
            this.expiredProductReportViewer.Location = new System.Drawing.Point(0, 0);
            this.expiredProductReportViewer.Name = "expiredProductReportViewer";
            this.expiredProductReportViewer.ShowExportButton = false;
            this.expiredProductReportViewer.Size = new System.Drawing.Size(793, 596);
            this.expiredProductReportViewer.TabIndex = 0;
            // 
            // poppelOrderProcessingSystemDataSetBindingSource
            // 
            this.poppelOrderProcessingSystemDataSetBindingSource.DataSource = this.poppelOrderProcessingSystemDataSet;
            this.poppelOrderProcessingSystemDataSetBindingSource.Position = 0;
            // 
            // expiredProductsTableAdapter
            // 
            this.expiredProductsTableAdapter.ClearBeforeFill = true;
            // 
            // ExpiredProductReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(793, 596);
            this.Controls.Add(this.expiredProductReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExpiredProductReport";
            this.Text = "Expired Product Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExpiredProductReport_FormClosed);
            this.Load += new System.EventHandler(this.ExpiredProductReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExpiredProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poppelOrderProcessingSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poppelOrderProcessingSystemDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer expiredProductReportViewer;
        private System.Windows.Forms.BindingSource ExpiredProductsBindingSource;
        private PoppelOrderProcessingSystemDataSet poppelOrderProcessingSystemDataSet;
        private System.Windows.Forms.BindingSource poppelOrderProcessingSystemDataSetBindingSource;
        private PoppelOrderProcessingSystemDataSetTableAdapters.ExpiredProductsTableAdapter expiredProductsTableAdapter;
    }
}