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
using RestaurantManagementApp.Properties;
using RestaurantManagementApp.Custom;

namespace RestaurantManagementApp.GUI
{
    public partial class EmployeeScreen : Form
    {
        private string _Username;
        public delegate void SendData(string username);
        public SendData sender;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public EmployeeScreen()
        {
            InitializeComponent();
            sender = new SendData(GetData);
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeScreen_Load(object sender, EventArgs e)
        {
            GetUserInfo();
            GetTableStatus();
        }

        /// <summary>
        /// LẤY DỮ LIỆU USERNAME TỪ FORM LOGIN
        /// </summary>
        /// <param name="username"></param>
        private void GetData(string username)
        {
            _Username = username;
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
        /// NÚT THOÁT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// NÚT KÉO THẢ FORM
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
        /// CONTROL ĐẾM GIỜ ĐỂ LOAD THÔNG BÁO (NẾU CÓ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerEmployee_Tick(object sender, EventArgs e)
        {
            var notification = NotificationBusinessTier.FetchNotification(Utility.EMPLOYEE_SCREEEN);
            if (notification != null)
            {
                timerEmployee.Stop();
                DialogResult result = MessageBox.Show(notification.Content, "Thông báo từ nhà bếp", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    GetTableStatus();
                    if (!NotificationBusinessTier.ClearNotification(notification.Screen))
                    {
                        MessageBox.Show("Xảy ra lỗi khi xóa notification", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    timerEmployee.Start();
                }
            }
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
        /// LẤY TRẠNG THÁI BÀN
        /// </summary>
        private void GetTableStatus()
        {
            pnlTable.Controls.Clear();
            List<Table> tables = TableBusinessTier.GetAllTables();
            foreach (var item in tables)
            {
                _TableCard card = new _TableCard()
                {
                    TableName = TableBusinessTier.GetTableNameByTableID(Convert.ToInt32(item.TableID))
                };
                card.Tag = item.TableID;
                
                PictureBox picture = new PictureBox();
                if (item.Status.Equals("free"))
                {
                    card.TableImage = Resources.table_free;
                    card.Click += (s, e2) =>
                    {
                        PictureBox pic = s as PictureBox;
                        Order_PopupScreen popupScreen = new Order_PopupScreen(item.TableID, _Username, item.Status);
                        popupScreen.UpdateTableStatus_Employee += () => GetTableStatus();
                        popupScreen.Show();
                    };
                }
                else if (item.Status.Equals("pending"))
                {
                    card.TableImage = Resources.table_pending;
                    card.Click += (s, e2) =>
                    {
                        PictureBox pic = s as PictureBox;
                        Order_PopupScreen popupScreen = new Order_PopupScreen(item.TableID, _Username, item.Status);
                        popupScreen.UpdateTableStatus_Employee += () => GetTableStatus();
                        popupScreen.Show();
                    };
                }
                else if (item.Status.Equals("ordering"))
                {
                    card.TableImage = Resources.table_order;
                    card.Click += (s, e2) =>
                    {
                        PictureBox pic = s as PictureBox;
                        Order_PopupScreen popupScreen = new Order_PopupScreen(item.TableID, _Username, item.Status);
                        popupScreen.UpdateTableStatus_Employee += () => GetTableStatus();
                        popupScreen.Show();
                    };
                }

                pnlTable.Controls.Add(card);
            }
        }

        /// <summary>
        /// NÚT ĐĂNG XUẤT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginScreen().ShowDialog();
        }

        /// <summary>
        /// NÚT BẬT FORM ĐỔI THÔNG TIN NHÂN VIÊN
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
    }
}
