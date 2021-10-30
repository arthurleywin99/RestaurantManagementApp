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
using System.Data.SqlClient;

namespace RestaurantManagementApp.GUI
{
    public partial class ChefScreen : Form
    {
        private SqlDependencyEx listenerInvoice = new SqlDependencyEx(Utility.CONNECTION_STRING, "RestaurantManagement", "Invoice");
        private SqlDependencyEx listenerInvoiceDetails = new SqlDependencyEx(Utility.CONNECTION_STRING, "RestaurantManagement", "InvoiceDetail");

        private string _Username;
        public delegate void SendData(string username);
        public SendData sender;
        
        public ChefScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            sender = new SendData(GetData);
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void GetData(string username)
        {
            _Username = username;
        }

        private void ChefScreen_Load(object sender, EventArgs e)
        {
            GetUserInfo();
            GetTableStatus();
            listenerInvoice.TableChanged += (o, e1) =>
            {
                MessageBox.Show("Đã có đơn mới. Vui lòng kiểm tra");
                GetTableStatus();
            };
            listenerInvoice.Start();

            listenerInvoiceDetails.TableChanged += (o, e1) =>
            {
                MessageBox.Show("Đã có bàn bị thay đổi. Vui lòng kiểm tra lại");
                GetTableStatus();
            };
        }

        private void ChefScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            listenerInvoice.Stop();
            listenerInvoiceDetails.Stop();
        }

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

        private void GetUserInfo()
        {
            User user = UserBusinessTier.GetUserByUsername(_Username);
            txtFullName.Texts = user.FullName;
            txtDate.Texts = user.DateOfBirth.ToShortDateString();
            txtGender.Texts = user.Gender ? "Nam" : "Nữ";
            txtCardID.Texts = user.IDCard;
            picAvatar.Image = user.Images == null ? null : Utility.LoadBitmapUnlocked(user.Images);
        }

        #region 3 nút Control Bar
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

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PopupScreen_updateTableStatus()
        {
            GetTableStatus();
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

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            ChangeInfo_PopupScreen changeInfo_PopupScreen = new ChangeInfo_PopupScreen(UserBusinessTier.GetUserByUsername(_Username));
            changeInfo_PopupScreen.UpdateUserInfo += () =>
            {
                GetUserInfo();
            };
            changeInfo_PopupScreen.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginScreen().ShowDialog();
        }
    }
}
