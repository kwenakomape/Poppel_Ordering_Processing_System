using System.Windows.Forms;
// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class SelectDateForm : Form
    {
        private FormState myState;

        public enum FormState
        {
            Daily = 0,
            Monthly = 1
        }

        public SelectDateForm()
        {
            InitializeComponent();

        }

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Daily:
                    myState = stateValue;
                    this.Text = "Select Date";
                    break;
                default:
                    myState = stateValue;
                    this.Text = "Select Monthly";
                    break;
            }
        }
    }
}
