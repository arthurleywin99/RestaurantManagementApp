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
        public ChefScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void ChefScreen_Load(object sender, EventArgs e)
        {
            GetTableStatus();
        }

        private void chefTime_Tick(object sender, EventArgs e)
        {
            GetTableStatus();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
