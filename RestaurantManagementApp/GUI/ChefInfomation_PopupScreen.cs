using RestaurantManagementApp.UtilityMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.BusinessTier;

namespace RestaurantManagementApp.GUI
{
    public delegate void UpdateTableStatus();

    public partial class ChefInfomation_PopupScreen : Form
    {
        public event UpdateTableStatus updateTableStatus;

        public delegate void SendData(Invoice invoice);
        public SendData sender;
        private Invoice _Invoice;
        private DataTable data;
        public ChefInfomation_PopupScreen()
        {
            InitializeComponent();
            sender = new SendData(GetData);
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void GetData(Invoice invoice)
        {
            _Invoice = invoice;
        }

        private void ChefInfomation_PopupScreen_Load(object sender, EventArgs e)
        {
            lblTitle.Text = TableBusinessTier.GetTableNameByTableID(Convert.ToInt32(_Invoice.TableID));
            InitDataTable();
            List<InvoiceDetail> invoiceDetails = InvoiceDetailsBusinessTier.GetInvoiceDetails(_Invoice.InvoiceID);
            for (int i = 0; i < invoiceDetails.Count; ++i)
            {
                DataRow row = data.NewRow();
                row["STT"] = i + 1;
                row["Mã Hóa Đơn"] = invoiceDetails[i].InvoiceID;
                row["Tên món"] = AlimentBusinessTier.GetAlimentNameByID(invoiceDetails[i].AlimentID);
                row["Số lượng"] = invoiceDetails[i].Amount;
                row["Kích cỡ"] = AlimentSizeBusinessTier.GetAlimentSizeByID(invoiceDetails[i].SizeID);
                data.Rows.Add(row);
            }
            dgvInvoice.DataSource = data;
        }

        private void InitDataTable()
        {
            data = new DataTable();
            data.Columns.Add("STT", typeof(int));
            data.Columns.Add("Mã Hóa Đơn", typeof(int));
            data.Columns.Add("Tên món", typeof(string));
            data.Columns.Add("Số lượng", typeof(int));
            data.Columns.Add("Kích cỡ", typeof(string));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận đã hoàn thành?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string Error = string.Empty;
                if (TableBusinessTier.SetOrderStatus(Convert.ToInt32(_Invoice.TableID), out Error)) 
                {
                    MessageBox.Show("Đã hoàn tất " + lblTitle.Text, "Success", MessageBoxButtons.OK);
                    Close();
                }
                else
                {
                    MessageBox.Show(Error, "Failure", MessageBoxButtons.OK);
                }
            }
            else
            {
                return;
            }
        }

        private void ChefInfomation_PopupScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateTableStatus();
        }

        private void btnOutOfStock_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận hết món?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string Error = string.Empty;
                if (InvoiceDetailsBusinessTier.DeleteInvoiceDetails(_Invoice.InvoiceID, out Error)
                    && InvoiceBusinessTier.DeleteInvoice(_Invoice.InvoiceID, out Error)
                    && TableBusinessTier.SetFreeStatus(_Invoice.InvoiceID, out Error))
                {
                    MessageBox.Show("Xác nhận hết món hoàn tất", "Success", MessageBoxButtons.OK);
                    Close();
                }
                else
                {
                    MessageBox.Show(Error, "Failure", MessageBoxButtons.OK);
                }
            }
            else
            {
                return;
            }
        }
    }
}
