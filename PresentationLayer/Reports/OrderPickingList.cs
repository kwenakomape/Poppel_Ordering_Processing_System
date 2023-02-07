using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;
// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer.Reports
{
    public partial class OrderPickingList : Form
    {
        private Order order;
        public bool orderPickingListClosed;

        public OrderPickingList(Order order)
        {
            InitializeComponent();
            this.order = order;
            PageSettings pageSettings = this.orderPickingListReportViewer.GetPageSettings();
            pageSettings.Margins = new Margins(7, 7, 10, 10);
            this.orderPickingListReportViewer.SetPageSettings(pageSettings);
            this.orderPickingListReportViewer.ShowExportButton = false;
        }

        private void OrderPickingList_Load(object sender, EventArgs e)
        {
            this.expiredProductsTableAdapter.Fill(poppelOrderProcessingSystemDataSet.ExpiredProducts);
            this.orderDetailsTableAdapter.Fill(poppelOrderProcessingSystemDataSet.OrderDetails,order.OrderId);
            this.orderItemsTableAdapter.Fill(poppelOrderProcessingSystemDataSet.OrderItems, order.OrderId);
            this.orderPickingListReportViewer.RefreshReport();
        }

        private void OrderPickingList_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderPickingListClosed = true;
            ((PoppelOrderProcessingSystem)MdiParent).EnableGeneratePickingListButton(true);
        }
    }
}
