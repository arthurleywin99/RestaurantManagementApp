using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementApp.GUI
{
    public partial class Report_PopupScreen : Form
    {
        public Report_PopupScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Report_PopupScreen_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
