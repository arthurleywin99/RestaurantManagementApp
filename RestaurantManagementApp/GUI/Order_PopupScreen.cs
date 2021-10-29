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
using RestaurantManagementApp.UtilityMethod;
using RestaurantManagementApp.Custom;

namespace RestaurantManagementApp.GUI
{
    public delegate void UpdateTableStatus_Employee();
    public partial class Order_PopupScreen : Form
    {
        public event UpdateTableStatus_Employee UpdateTableStatus_Employee;
        private int _TableID;
        private string _Username;
        private string _Status;
        public Order_PopupScreen()
        {
            InitializeComponent();
        }

        public Order_PopupScreen(int TableID, string Username, string Status)
        {
            InitializeComponent();
            _TableID = TableID;
            _Username = Username;
            _Status = Status;
            lblTitle.Text = TableBusinessTier.GetTableNameByTableID(_TableID).ToUpper().ToString();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            txtTotal.Texts = "0";
        }

        private void Order_PopupScreen_Load(object sender, EventArgs e)
        {
            if (_Status.Equals("free"))
            {
                btnUpdateInvoice.Enabled = false;
                btnPay.Enabled = false;
            }
            else if (_Status.Equals("ordering"))
            {
                btnUpdateInvoice.Enabled = false;
                btnSendChef.Enabled = false;
                LoadInvoice();
            }
            else
            {
                LoadInvoice();
            }
            txtEmployeeName.Texts = UserBusinessTier.GetUserByUsername(_Username).FullName;
            FillComboBoxAlimentType();
        }

        private void LoadInvoice()
        {
            List<InvoiceDetail> invoiceDetails = InvoiceDetailsBusinessTier.GetInvoiceDetailsPendingOrOrdering(_TableID);
            foreach (var item in invoiceDetails)
            {
                _AlimentBar alimentBar = new _AlimentBar();
                alimentBar.AlimentName = AlimentBusinessTier.GetAlimentNameByID(item.AlimentID);
                alimentBar.Note = InvoiceDetailsBusinessTier.GetNoteByInvoiceID(item.InvoiceID, item.AlimentID);
                alimentBar.AlimentSize = AlimentSizeBusinessTier.GetAlimentSizeByID(item.SizeID).ToString();
                alimentBar.Amount = item.Amount.ToString();
                alimentBar.Price = AlimentBusinessTier.GetAlimentPriceByID(item.AlimentID).ToString();
                alimentBar.Total = (Convert.ToInt32(alimentBar.Price) * Convert.ToInt32(alimentBar.Amount) * AlimentSizeBusinessTier.GetPercentIncrease(alimentBar.AlimentSize) / 100f).ToString();
                pnlAlimentDetails.Controls.Add(alimentBar);
            }
        }

        private void FillComboBoxAlimentType()
        {
            cboAlimentType.Items.Clear();
            cboAlimentType.Items.Add(" ");
            List<AlimentType> alimentTypes = AlimentTypeBusinessTier.GetAlimentTypes();
            foreach (var item in alimentTypes)
            {
                cboAlimentType.Items.Add(item.TypeName);
            }
            cboAlimentType.SelectedIndex = 0;
        }

        private void LoadAliment(List<Aliment> aliments)
        {
            pnlAliment.Controls.Clear();
            foreach (var item in aliments)
            {
                _AlimentCard alimentCard = new _AlimentCard();
                alimentCard.AlimentName = item.AlimentName;
                alimentCard.AlimentPrice = item.Price.ToString();
                alimentCard.AlimentPicture = item.Image == null ? null : Utility.Base64ToImage(item.Image);
                alimentCard.Click += (e, s) =>
                {
                    _AlimentBar alimentBar = new _AlimentBar();
                    alimentBar.AlimentName = item.AlimentName;
                    alimentBar.Price = item.Price.ToString();
                    alimentBar.Amount = "1";
                    alimentBar.UpdateTotal += () => SetTotal();
                    pnlAlimentDetails.Controls.Add(alimentBar);
                };
                pnlAliment.Controls.Add(alimentCard);
            }
        }

        private void cboAlimentType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            List<Aliment> aliments;
            if (cboAlimentType.Texts.Equals(" "))
            {
                aliments = AlimentBusinessTier.GetAliments();
            }
            else
            {
                aliments = AlimentBusinessTier.GetAlimentsByTypeName(cboAlimentType.Texts);
            }
            LoadAliment(aliments);
        }


        #region 3 nút Control Bar
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
        #endregion

        private void txtPay__TextChanged(object sender, EventArgs e)
        {
            SetExcessCash();
        }

        private void pnlAlimentDetails_ControlRemoved(object sender, ControlEventArgs e)
        {
            SetTotal();
        }

        private void pnlAlimentDetails_ControlAdded(object sender, ControlEventArgs e)
        {
            SetTotal();
        }

        private void SetTotal()
        {
            long Temp = 0;
            foreach (_AlimentBar item in pnlAlimentDetails.Controls)
            {
                Temp += int.Parse(item.Total);
            }
            txtTotal.Texts = Temp.ToString();
            SetExcessCash();
        }

        private void SetExcessCash()
        {
            int Excess;
            if (string.IsNullOrEmpty(txtPay.Texts) || string.IsNullOrWhiteSpace(txtPay.Texts))
            {
                Excess = 0;
            }
            else
            {
                Excess = Convert.ToInt32(txtPay.Texts) - Convert.ToInt32(txtTotal.Texts);
                txtExcessCash.Texts = Excess > 0 ? Excess.ToString() : (Math.Abs(Excess).ToString() + "-");
            }
        }

        private void btnUpdateInvoice_Click(object sender, EventArgs e)
        {
            int UserID = UserBusinessTier.GetUserByUsername(_Username).UserID;
            int _InvoiceID = InvoiceBusinessTier.GetInvoiceIDByTableUserIsPaid(_TableID, UserID);
            string Error = string.Empty;
            if (!InvoiceDetailsBusinessTier.DeleteInvoiceDetails(_InvoiceID, out Error))
            {
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK);
            }
            else
            {
                Invoice invoice = new Invoice()
                {
                    TableID = _TableID,
                    UserID = UserBusinessTier.GetUserByUsername(_Username).UserID,
                    CreateDate = DateTime.Now,
                    Total = int.Parse(txtTotal.Texts),
                    IsPaid = false
                };
                if (InvoiceBusinessTier.UpdateInvoice(_InvoiceID, invoice, out Error))
                {
                    MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButtons.OK);
                    foreach (_AlimentBar item in pnlAlimentDetails.Controls)
                    {
                        if (int.Parse(item.Total) == 0)
                        {
                            continue;
                        }
                        InvoiceDetail invoiceDetail = new InvoiceDetail()
                        {
                            InvoiceID = _InvoiceID,
                            AlimentID = AlimentBusinessTier.GetAlimentByName(item.AlimentName).AlimentID,
                            Amount = Convert.ToInt32(item.Amount),
                            SizeID = AlimentSizeBusinessTier.GetSizeIDByName(item.AlimentSize),
                            Note = item.Note
                        };
                        if (!InvoiceDetailsBusinessTier.AddInvoiceDetails(invoiceDetail, out Error))
                        {
                            MessageBox.Show(Error, "Invoice Details Create Failure", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Failure", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSendChef_Click(object sender, EventArgs e)
        {
            if (txtTotal.Texts.Equals("0"))
            {
                MessageBox.Show("Chưa chọn món hoặc số lượng = 0. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK);
                return;
            }
            Invoice invoice = new Invoice()
            {
                TableID = _TableID,
                UserID = UserBusinessTier.GetUserByUsername(_Username).UserID,
                CreateDate = DateTime.Now,
                Total = int.Parse(txtTotal.Texts),
                IsPaid = false
            };

            string Error = string.Empty;
            if (InvoiceBusinessTier.AddInvoice(invoice, out Error))
            {
                MessageBox.Show("Gửi xuống bếp thành công", "Success", MessageBoxButtons.OK);
                if (!TableBusinessTier.SetPendingStatus(_TableID, out Error))
                {
                    MessageBox.Show(Error, "Table Status Update Failure", MessageBoxButtons.OK);
                }
                int _InvoiceID = InvoiceBusinessTier.GetInvoiceIDByTableUserCreate(_TableID, Convert.ToInt32(invoice.UserID), invoice.CreateDate, Convert.ToInt64(invoice.Total));
                foreach (_AlimentBar item in pnlAlimentDetails.Controls)
                {
                    if (int.Parse(item.Total) == 0)
                    {
                        continue;
                    }
                    InvoiceDetail invoiceDetail = new InvoiceDetail()
                    {
                        InvoiceID = _InvoiceID,
                        AlimentID = AlimentBusinessTier.GetAlimentByName(item.AlimentName).AlimentID,
                        Amount = Convert.ToInt32(item.Amount),
                        SizeID = AlimentSizeBusinessTier.GetSizeIDByName(item.AlimentSize),
                        Note = item.Note
                    };
                    if (!InvoiceDetailsBusinessTier.AddInvoiceDetails(invoiceDetail, out Error))
                    {
                        MessageBox.Show(Error, "Invoice Details Create Failure", MessageBoxButtons.OK);
                    }
                }
                Close();
            }
            else
            {
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thanh toán?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txtExcessCash.Texts.Substring(txtExcessCash.Texts.Length - 1).Equals("-"))
                {
                    MessageBox.Show("Khách chưa thanh toán đủ tiền", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    int UserID = UserBusinessTier.GetUserByUsername(_Username).UserID;
                    int InvoiceID = InvoiceBusinessTier.GetInvoiceIDByTableUserIsPaid(_TableID, UserID);
                    string Error = string.Empty;
                    if (InvoiceBusinessTier.UpdatePaymentInvoiceStatus(InvoiceID, out Error))
                    {
                        MessageBox.Show("Thanh toán hoàn tất", "Success", MessageBoxButtons.OK);
                        if (!TableBusinessTier.SetFreeStatus(_TableID, out Error))
                        {
                            MessageBox.Show(Error, "Đặt trạng thái bàn thất bại", MessageBoxButtons.OK);
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(Error, "Failure", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void Order_PopupScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateTableStatus_Employee();
        }
    }
}
