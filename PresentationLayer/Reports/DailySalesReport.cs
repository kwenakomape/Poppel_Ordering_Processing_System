using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poppel_Order_Processing_System.PresentationLayer.Reports
{
    public partial class DailySalesReport : Form
    {
        public DailySalesReport()
        {
            InitializeComponent();
        }

        private void DailySalesReport_Load(object sender, EventArgs e)
        {

            this.dailySalesReportViewer.RefreshReport();
        }
    }
}
