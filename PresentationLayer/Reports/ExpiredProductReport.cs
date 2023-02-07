using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer.Reports
{
    public partial class ExpiredProductReport : Form
    {
        public bool expiredProductReportClosed;
        public ExpiredProductReport()
        {
            InitializeComponent();
            PageSettings pageSettings = this.expiredProductReportViewer.GetPageSettings();
            pageSettings.Margins = new Margins(7, 7, 10, 10);
            this.expiredProductReportViewer.SetPageSettings(pageSettings);
            this.expiredProductReportViewer.ShowExportButton = false;
        }

        #region Events

        private void ExpiredProductReport_Load(object sender, EventArgs e)
        {
            this.expiredProductsTableAdapter.Fill(poppelOrderProcessingSystemDataSet.ExpiredProducts);
            this.expiredProductReportViewer.RefreshReport();
        }

        private void ExpiredProductReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            expiredProductReportClosed = true;
            ((PoppelOrderProcessingSystem) MdiParent).EnableButtons(true);
        }

        #endregion

    }
}