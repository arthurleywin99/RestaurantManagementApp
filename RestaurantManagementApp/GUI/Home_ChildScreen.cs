using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.UtilityMethod;
using RestaurantManagementApp.Properties;
using System.Drawing.Drawing2D;

namespace RestaurantManagementApp.GUI
{
    public partial class Home_ChildScreen : Form
    {
        public Home_ChildScreen()
        {
            BackColor = Utility.RGBColors.Color4;
            InitializeComponent();
        }

        private void Home_ChildForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
