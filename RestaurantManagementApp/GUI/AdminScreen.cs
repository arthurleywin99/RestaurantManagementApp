using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.Properties;
using RestaurantManagementApp.UtilityMethod;
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.Custom;
using FontAwesome.Sharp;

namespace RestaurantManagementApp.GUI
{
    public partial class AdminScreen : Form, IRemoveFlicker
    {
        public delegate void SendData(string username);
        public SendData sender;
        private IconButton currentBtn;
        private Panel leftBorder;
        private Form childForm;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public AdminScreen()
        {
            InitializeComponent();
            sender = new SendData(GetData);
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            BackgroundImage = Resources.Background;
            CollapseMenu();
            leftBorder = new Panel();
            leftBorder.Size = new Size(7, 60);
            pnlMenu.Controls.Add(leftBorder);
        }

        /// <summary>
        /// LẤY DỮ LIỆU USERNAME TỪ FORM LOGIN BẰNG DELEGATE
        /// </summary>
        /// <param name="username"></param>
        private void GetData(string username)
        {
            lbUsername.Tag = username;
            lbName.Tag = UserBusinessTier.GetFullName(username);
            picUser.Image = UserBusinessTier.LoadImage(username) != null 
                            ? Utility.LoadBitmapUnlocked(UserBusinessTier.GetUserByUsername(username).Images)
                            : Resources.User;
        }

        /// <summary>
        /// CẢI THIỆN TÌNH TRẠNG NHẤP NHÁY
        /// </summary>
        public void RemoveFlicker()
        {
            DoubleBuffered = true;
            Utility.EnableDoubleBuff(ControlBar);
            Utility.EnableDoubleBuff(pnlMenu);
            Utility.EnableDoubleBuff(picLogoHome);
            Utility.EnableDoubleBuff(btnMaximized);
            Utility.EnableDoubleBuff(btnMinimized);
            Utility.EnableDoubleBuff(btnExit);
            Utility.EnableDoubleBuff(panel1);
            Utility.EnableDoubleBuff(pnlWindow);
            Utility.EnableDoubleBuff(panel4);
        }

        #region 3 NÚT CONTROL
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
        /// NÚT PHÓNG TO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// NÚT THU NHỎ CỬA SỔ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// SỰ KIỆN KÉO THẢ FORM
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
        /// NÚT MỞ RỘNG/THU NHỎ THANH BÊN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNavigation_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        /// <summary>
        /// MỞ RỘNG/THU NHỎ THANH BÊN
        /// </summary>
        private void CollapseMenu()
        {
            if (pnlMenu.Width > 200)
            {
                btnNavigation.IconChar = FontAwesome.Sharp.IconChar.Bars;
                pnlMenu.Width = 100;
                picLogoHome.Visible = false;
                picUser.Visible = false;
                lbUsername.Text = string.Empty;
                lbName.Text = string.Empty;
                btnNavigation.Dock = DockStyle.Top;
                foreach (Button button in pnlMenu.Controls.OfType<Button>())
                {
                    button.Text = "";
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.Padding = new Padding(0);
                }
            }
            else
            {
                btnNavigation.IconChar = IconChar.ArrowLeft;
                pnlMenu.Width = 265;
                picLogoHome.Visible = true;
                picUser.Visible = true;
                lbUsername.Text = lbUsername.Tag.ToString();
                lbName.Text = lbName.Tag.ToString();
                btnNavigation.Dock = DockStyle.None;
                foreach (Button button in pnlMenu.Controls.OfType<Button>())
                {
                    button.Text = "     " + button.Tag.ToString();
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        /// <summary>
        /// NÚT ĐĂNG XUẤT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icoLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginScreen().ShowDialog();
            Close();
        }

        /// <summary>
        /// KÍCH HOẠT MÀU CỦA NÚT TRÊN NAVIGATION KHI NGƯỜI DÙNG CLICK MỞ FORM CON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        private void ActivateButton(object sender, Color color)
        {
            if (sender != null)
            {
                DisableButton();
                currentBtn = sender as IconButton;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorder.BackColor = color;
                leftBorder.Location = new Point(0, currentBtn.Location.Y);
                leftBorder.Visible = true;
                leftBorder.BringToFront();
            }
        }

        /// <summary>
        /// VÔ HIỆU HÓA MÀU NÚT TRÊN NAVIGATION
        /// </summary>
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        /// <summary>
        /// MỞ FORM CON TRÊN PANEL
        /// </summary>
        /// <param name="form"></param>
        private void OpenChildForm(Form form)
        {
            if (childForm != null)
            {
                childForm.Close();
            }
            childForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlWindow.Controls.Add(form);
            pnlWindow.Tag = form;
            form.BringToFront();
            form.Show();
        }

        /// <summary>
        /// NÚT MỞ FORM QUẢN LÝ NHÂN VIÊN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icoEmployee_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Utility.RGBColors.Color1);
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            OpenChildForm(new User_ChildScreen());
        }

        /// <summary>
        /// NÚT MỞ FORM QUẢN LÝ THỰC ĐƠN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icoMenu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Utility.RGBColors.Color2);
            lblTitle.Text = "QUẢN LÝ THỰC ĐƠN";
            OpenChildForm(new Aliment_ChildScreen());
        }

        /// <summary>
        /// NÚT MỞ FORM THỐNG KÊ DOANH SỐ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icoDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Utility.RGBColors.Color3);
            lblTitle.Text = "DOANH SỐ";
            OpenChildForm(new Dashboard_ChildScreen());
        }

        /// <summary>
        /// NÚT MỞ FORM XEM DANH SÁCH HÓA ĐƠN VÀ CHI TIẾT CỦA NÓ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icoStatistical_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Utility.RGBColors.Color4);
            lblTitle.Text = "THỐNG KÊ HÓA ĐƠN";
            OpenChildForm(new InvoiceStatistical_ChildScreen());
        }

        /// <summary>
        /// MỞ TRANG CHỦ ĐỂ XEM NGÀY GIỜ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picLogoHome_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "SECRET COFFEE STORE";
            OpenChildForm(new Home_ChildScreen());
        }

        /// <summary>
        /// OVERRIDE CÁC PHÍM TẮT
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                ActivateButton(icoEmployee, Utility.RGBColors.Color1);
                OpenChildForm(new User_ChildScreen());
                return true;
            }
            if (keyData == Keys.F2)
            {
                ActivateButton(icoMenu, Utility.RGBColors.Color2);
                OpenChildForm(new Aliment_ChildScreen());
            }
            if (keyData == Keys.F3)
            {
                ActivateButton(icoDashboard, Utility.RGBColors.Color3);
                OpenChildForm(new Dashboard_ChildScreen());
            }
            if (keyData == Keys.F4)
            {
                ActivateButton(icoStatistical, Utility.RGBColors.Color4);
                OpenChildForm(new InvoiceStatistical_ChildScreen());
            }
            if (keyData == (Keys.Control | Keys.Tab))
            {
                CollapseMenu();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
