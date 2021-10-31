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

namespace RestaurantManagementApp.GUI
{
    public partial class SplashScreen : Form, IRemoveFlicker
    {
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            BackgroundImage = Properties.Resources.Background;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            RemoveFlicker();
        }

        /// <summary>
        /// CẢI THIỆN TÌNH TRẠNG NHẤP NHÁY
        /// </summary>
        public void RemoveFlicker()
        {
            Utility.EnableDoubleBuff(pnlTotal);
            Utility.EnableDoubleBuff(tbPanel2);
            Utility.EnableDoubleBuff(picBox1);
            Utility.EnableDoubleBuff(tbPanel1);
            Utility.EnableDoubleBuff(pnlLoad);
        }

        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            lblCopyright.Text = "CREATED BY GIANG BÙI - NHẬT HÀO";
            lblVersion.Text = Utility.VERSION;
        }

        /// <summary>
        /// CONTROL ĐẾM GIỜ ĐỂ LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSplashScreen_Tick(object sender, EventArgs e)
        {
            pnlLoad.Width += 20;
            if (pnlLoad.Width >= 790)
            {
                timerSplashScreen.Stop();
                Hide();
                new LoginScreen().ShowDialog();
                Close();
            }
        }
    }
}
