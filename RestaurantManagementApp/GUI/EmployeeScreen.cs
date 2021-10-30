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
        private SqlDependencyEx listener = new SqlDependencyEx(Utility.CONNECTION_STRING, "RestaurantManagement", "Invoice");
        private string _Username;
        public delegate void SendData(string username);
        public SendData sender;
        public EmployeeScreen()
        {
            InitializeComponent();
            sender = new SendData(GetData);
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void EmployeeScreen_Load(object sender, EventArgs e)
        {
            GetUserInfo();
            GetTableStatus();
            listener.TableChanged += (o, e1) =>
            {
                MessageBox.Show("Có bàn đã hoàn thành. Xuống bếp lấy đi");
                GetTableStatus();
            };
            listener.Start();
        }

        private void EmployeeScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            listener.Stop();
        }

        private void GetUserInfo()
        {
            User user = UserBusinessTier.GetUserByUsername(_Username);
            txtFullName.Texts = user.FullName;
            txtDate.Texts = user.DateOfBirth.ToShortDateString();
            txtGender.Texts = user.Gender ? "Nam" : "Nữ";
            txtCardID.Texts = user.IDCard;
            picAvatar.Image = user.Images == null ? null : Utility.LoadBitmapUnlocked(user.Images);
        }

        private void GetData(string username)
        {
            _Username = username;
        }

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

        #region 3 nút Control
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
            Application.Exit();
        }

        private void ControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }
        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginScreen().ShowDialog();
        }

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
