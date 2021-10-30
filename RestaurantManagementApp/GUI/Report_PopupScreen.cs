using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.UtilityMethod;

namespace RestaurantManagementApp.GUI
{
    public partial class Report_PopupScreen : Form
    {
        public Report_PopupScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Report_PopupScreen_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
            }
            else
            {
                WindowState = FormWindowState.Normal;
                Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }
    }
}
