
namespace Poppel_Order_Processing_System.PresentationLayer.Reports
{
    partial class OrderPickingList
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPickingList));
            this.ExpiredProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.poppelOrderProcessingSystemDataSet = new Poppel_Order_Processing_System.PoppelOrderProcessingSystemDataSet();
            this.OrderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrderItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderPickingListReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.orderItemsTableAdapter = new Poppel_Order_Processing_System.PoppelOrderProcessingSystemDataSetTableAdapters.OrderItemsTableAdapter();
            this.orderDetailsTableAdapter = new Poppel_Order_Processing_System.PoppelOrderProcessingSystemDataSetTableAdapters.OrderDetailsTableAdapter();
            this.poppelOrderProcessingSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expiredProductsTableAdapter = new Poppel_Order_Processing_System.PoppelOrderProcessingSystemDataSetTableAdapters.ExpiredProductsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ExpiredProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poppelOrderProcessingSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemsBindingSource)).BeginInit();
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
            // OrderDetailsBindingSource
            // 
            this.OrderDetailsBindingSource.DataMember = "OrderDetails";
            this.OrderDetailsBindingSource.DataSource = this.poppelOrderProcessingSystemDataSet;
            // 
            // OrderItemsBindingSource
            // 
            this.OrderItemsBindingSource.DataMember = "OrderItems";
            this.OrderItemsBindingSource.DataSource = this.poppelOrderProcessingSystemDataSet;
            // 
            // orderPickingListReportViewer
            // 
            this.orderPickingListReportViewer.BackColor = System.Drawing.Color.Gray;
            this.orderPickingListReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PoppelOrderProcessingSystemDataSet";
            reportDataSource1.Value = this.ExpiredProductsBindingSource;
            reportDataSource2.Name = "OrderDetails";
            reportDataSource2.Value = this.OrderDetailsBindingSource;
            reportDataSource3.Name = "OrderItems";
            reportDataSource3.Value = this.OrderItemsBindingSource;
            this.orderPickingListReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.orderPickingListReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.orderPickingListReportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.orderPickingListReportViewer.LocalReport.ReportEmbeddedResource = "Poppel_Order_Processing_System.PresentationLayer.Reports.OrderPickingList.rdlc";
            this.orderPickingListReportViewer.Location = new System.Drawing.Point(0, 0);
            this.orderPickingListReportViewer.Name = "orderPickingListReportViewer";
            this.orderPickingListReportViewer.Size = new System.Drawing.Size(793, 596);
            this.orderPickingListReportViewer.TabIndex = 0;
            // 
            // orderItemsTableAdapter
            // 
            this.orderItemsTableAdapter.ClearBeforeFill = true;
            // 
            // orderDetailsTableAdapter
            // 
            this.orderDetailsTableAdapter.ClearBeforeFill = true;
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
            // OrderPickingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(793, 596);
            this.Controls.Add(this.orderPickingListReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderPickingList";
            this.Text = "Order Picking List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderPickingList_FormClosed);
            this.Load += new System.EventHandler(this.OrderPickingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExpiredProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poppelOrderProcessingSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poppelOrderProcessingSystemDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer orderPickingListReportViewer;
        private PoppelOrderProcessingSystemDataSetTableAdapters.OrderItemsTableAdapter orderItemsTableAdapter;
        private PoppelOrderProcessingSystemDataSetTableAdapters.OrderDetailsTableAdapter orderDetailsTableAdapter;
        private System.Windows.Forms.BindingSource ExpiredProductsBindingSource;
        private PoppelOrderProcessingSystemDataSet poppelOrderProcessingSystemDataSet;
        private System.Windows.Forms.BindingSource OrderDetailsBindingSource;
        private System.Windows.Forms.BindingSource OrderItemsBindingSource;
        private System.Windows.Forms.BindingSource poppelOrderProcessingSystemDataSetBindingSource;
        private PoppelOrderProcessingSystemDataSetTableAdapters.ExpiredProductsTableAdapter expiredProductsTableAdapter;
    }
}