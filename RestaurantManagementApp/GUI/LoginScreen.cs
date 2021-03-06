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
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.Properties;
using RestaurantManagementApp.Model;
using System.Diagnostics;

namespace RestaurantManagementApp.GUI
{
    public partial class LoginScreen : Form, IRemoveFlicker
    {
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public LoginScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            BackgroundImage = Resources.Background;
            RemoveFlicker();
        }

        /// <summary>
        /// CẢI THIỆN TÌNH TRẠNG NHẤP NHÁY
        /// </summary>
        public void RemoveFlicker()
        {
            DoubleBuffered = true;
            Utility.EnableDoubleBuff(tbPanel1);
            Utility.EnableDoubleBuff(tbPanel2);
            Utility.EnableDoubleBuff(tbPanel3);
            Utility.EnableDoubleBuff(tbPanel4);
            Utility.EnableDoubleBuff(tbPanel5);
            Utility.EnableDoubleBuff(tbPanel6);
            Utility.EnableDoubleBuff(btnMinimized);
            Utility.EnableDoubleBuff(btnExit);
            Utility.EnableDoubleBuff(picBox1);
            Utility.EnableDoubleBuff(picBox2);
            Utility.EnableDoubleBuff(picBox3);
            Utility.EnableDoubleBuff(Panel1);
            Utility.EnableDoubleBuff(Panel2);
        }

        #region 3 NÚT CONTROL
        /// <summary>
        /// NÚT THU NHỎ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// NÚT THOÁT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// KÉO THẢ FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }
        #endregion

        /// <summary>
        /// NÚT ĐĂNG NHẬP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Texts) || string.IsNullOrWhiteSpace(txtUsername.Texts))
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Texts) || string.IsNullOrWhiteSpace(txtPassword.Texts))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            string Role = RoleBusinessTier.GetUserRoleName(txtUsername.Texts, txtPassword.Texts);
            switch (Role)
            {
                case "admin":
                    {
                        if (UserBusinessTier.IsActivated(txtUsername.Texts))
                        {
                            Hide();
                            AdminScreen admin = new AdminScreen();
                            admin.sender(txtUsername.Texts);
                            admin.ShowDialog();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản này hiện tại đang bị khóa. Vui lòng liên hệ admin để được hỗ trợ", "Account Banned", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "employee":
                    {
                        if (UserBusinessTier.IsActivated(txtUsername.Texts))
                        {
                            Hide();
                            EmployeeScreen employee = new EmployeeScreen();
                            employee.sender(txtUsername.Texts);
                            employee.ShowDialog();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản này hiện tại đang bị khóa. Vui lòng liên hệ admin để được hỗ trợ", "Account Banned", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "chef":
                    {
                        if (UserBusinessTier.IsActivated(txtUsername.Texts))
                        {
                            Hide();
                            ChefScreen chef = new ChefScreen();
                            chef.sender(txtUsername.Texts);
                            chef.ShowDialog();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản này hiện tại đang bị khóa. Vui lòng liên hệ admin để được hỗ trợ", "Account Banned", MessageBoxButtons.OK);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Login Failure", MessageBoxButtons.OK);
                        break;
                    }
            }
        }
    }
}
