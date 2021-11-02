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
using RestaurantManagementApp.Model;
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.Custom;
using RestaurantManagementApp.Properties;
using System.Threading;

namespace RestaurantManagementApp.GUI
{
    public partial class ChefScreen : Form
    {
        private string _Username;
        public delegate void SendData(string username);
        public SendData sender;
        
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public ChefScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            sender = new SendData(GetData);
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        /// <summary>
        /// LẤY DỮ LIỆU USERNAME TỪ FORM LOGIN
        /// </summary>
        /// <param name="username"></param>
        private void GetData(string username)
        {
            _Username = username;
        }

        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChefScreen_Load(object sender, EventArgs e)
        {
            GetUserInfo();
            GetTableStatus();
        }

        #region 3 NÚT CONTROL
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
        /// NÚT ĐÓNG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
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
        /// DELEGATE EVENT CẬP NHẬT LẠI TRẠNG THÁI BÀN
        /// </summary>
        private void PopupScreen_updateTableStatus()
        {
            GetTableStatus();
        }

        /// <summary>
        /// CONTROL ĐẾM GIỜ ĐỂ LOAD THÔNG BÁO TỪ EMPLOYEE (NẾU CÓ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerChef_Tick(object sender, EventArgs e)
        {
            var notification = NotificationBusinessTier.FetchNotification(Utility.CHEF_SCREEEN);
            if (notification != null)
            {
                timerChef.Stop();
                DialogResult result = MessageBox.Show(notification.Content, "Thông báo từ nhân viên phục vụ", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    GetTableStatus();
                    if (!NotificationBusinessTier.ClearNotification(notification.Screen))
                    {
                        MessageBox.Show("Xảy ra lỗi khi xóa notification", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    timerChef.Start();
                }
            }
        }

        /// <summary>
        /// LẤY TRẠNG THÁI BÀN TỪ DATABASE
        /// </summary>
        private void GetTableStatus()
        {
            pnlTable.Controls.Clear();
            List<Invoice> invoices = InvoiceBusinessTier.GetIsNotPaidInvoices();
            foreach (var item in invoices)
            {
                _TableCard card = new _TableCard
                {
                    TableName = TableBusinessTier.GetTableNameByTableID(Convert.ToInt32(item.TableID)),
                    TableImage = Resources.table_pending
                };

                card.Click += (s, e2) =>
                {
                    PictureBox pic = s as PictureBox;
                    ChefInfomation_PopupScreen popupScreen = new ChefInfomation_PopupScreen();
                    popupScreen.sender(item);
                    popupScreen.updateTableStatus += PopupScreen_updateTableStatus;
                    popupScreen.Show();
                };

                pnlTable.Controls.Add(card);
            }

            icoLogout.Click += (s, e) =>
            {
                if (pnlTable.Controls.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Vẫn còn bàn chưa được làm, bạn có muốn thoát không?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Hide();
                        new LoginScreen().ShowDialog();
                    }
                    else
                    {
                        return;
                    }
                }
            };
        }

        /// <summary>
        /// CẬP NHẬT LẠI THÔNG TIN NHÂN VIÊN
        /// </summary>
        private void GetUserInfo()
        {
            User user = UserBusinessTier.GetUserByUsername(_Username);
            txtFullName.Texts = user.FullName;
            txtDate.Texts = user.DateOfBirth.ToShortDateString();
            txtGender.Texts = user.Gender ? "Nam" : "Nữ";
            txtCardID.Texts = user.IDCard;
            picAvatar.Image = user.Images == null ? null : Utility.LoadBitmapUnlocked(user.Images);
        }

        /// <summary>
        /// NÚT MỞ FORM THAY ĐỔI THÔNG TIN NHÂN VIÊN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            ChangeInfo_PopupScreen changeInfo_PopupScreen = new ChangeInfo_PopupScreen(UserBusinessTier.GetUserByUsername(_Username));
            changeInfo_PopupScreen.UpdateUserInfo += () =>
            {
                GetUserInfo();
            };
            changeInfo_PopupScreen.ShowDialog();
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
        }
    }
}
