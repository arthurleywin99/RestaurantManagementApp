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
        private DataTable data;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="TableID"></param>
        /// <param name="Username"></param>
        /// <param name="Status"></param>
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
            InitDataTable();
        }

        #region SỰ KIỆN LOAD VÀ CLOSE FORM
        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// SỰ KIỆN ĐÓNG FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Order_PopupScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateTableStatus_Employee();
        }
        #endregion

        #region 3 NÚT CONTROL
        /// <summary>
        /// NÚT THOÁT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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
        /// KHỞI TẠO DATATABLE
        /// </summary>
        private void InitDataTable()
        {
            data = new DataTable();
            data.Columns.Add("InvoiceID", typeof(int));
            data.Columns.Add("AlimentID", typeof(int));
            data.Columns.Add("Amount", typeof(int));
            data.Columns.Add("SizeID", typeof(int));
            data.Columns.Add("Note", typeof(string));
        }

        /// <summary>
        /// ĐỔ DỮ LIỆU HÓA ĐƠN TỪ DATABASE
        /// </summary>
        private void LoadInvoice()
        {
            List<InvoiceDetail> invoiceDetails = InvoiceDetailsBusinessTier.GetInvoiceDetailsPendingOrOrdering(_TableID);
            foreach (var item in invoiceDetails)
            {
                _AlimentBar alimentBar = new _AlimentBar
                {
                    AlimentName = AlimentBusinessTier.GetAlimentNameByID(item.AlimentID),
                    Note = InvoiceDetailsBusinessTier.GetNoteByInvoiceID(item.InvoiceID, item.AlimentID),
                    AlimentSize = AlimentSizeBusinessTier.GetAlimentSizeByID(item.SizeID).ToString(),
                    Amount = item.Amount.ToString(),
                    Price = AlimentBusinessTier.GetAlimentPriceByID(item.AlimentID).ToString()
                };
                alimentBar.Total = (Convert.ToInt32(alimentBar.Price) * Convert.ToInt32(alimentBar.Amount) * AlimentSizeBusinessTier.GetPercentIncrease(alimentBar.AlimentSize) / 100f).ToString();
                pnlAlimentDetails.Controls.Add(alimentBar);
            }
        }

        /// <summary>
        /// ĐỔ DỮ LIỆU DANH SÁCH LOẠI MÓN ĂN
        /// </summary>
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

        /// <summary>
        /// ĐỔ DỮ LIỆU DANH SÁCH MÓN ĂN
        /// </summary>
        /// <param name="aliments"></param>
        private void LoadAliment(List<Aliment> aliments)
        {
            pnlAliment.Controls.Clear();
            foreach (var item in aliments)
            {
                if (item.StillForSale == true)
                {
                    _AlimentCard alimentCard = new _AlimentCard
                    {
                        AlimentName = item.AlimentName,
                        AlimentPrice = item.Price.ToString(),
                        AlimentPicture = item.Image == null ? null : Utility.LoadBitmapUnlocked(item.Image)
                    };
                    alimentCard.Click += (e, s) =>
                    {
                        _AlimentBar alimentBar = new _AlimentBar
                        {
                            AlimentName = item.AlimentName,
                            Price = item.Price.ToString(),
                            Amount = "1"
                        };
                        alimentBar.UpdateTotal += () => SetTotal();
                        pnlAlimentDetails.Controls.Add(alimentBar);
                    };
                    pnlAliment.Controls.Add(alimentCard);
                }
            }
        }

        /// <summary>
        /// SỰ KIỆN THAY ĐỔI DỮ LIỆU TRONG COMBOBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// CẬP NHẬT THAY ĐỔI TEXTBOX TIỀN THỪA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPay__TextChanged(object sender, EventArgs e)
        {
            SetExcessCash();
        }

        /// <summary>
        /// CẬP NHẬT THAY ĐỔI TEXTBOX TỔNG TIỀN KHI XÓA MÓN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlAlimentDetails_ControlRemoved(object sender, ControlEventArgs e)
        {
            SetTotal();
        }

        /// <summary>
        /// CẬP NHẬT THAY ĐỔI TEXTBOX TỔNG TIỀN KHI THÊM MỚI MÓN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlAlimentDetails_ControlAdded(object sender, ControlEventArgs e)
        {
            SetTotal();
        }

        /// <summary>
        /// CẬP NHẬT TỔNG TIỀN
        /// </summary>
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

        /// <summary>
        /// CẬP NHẬT TIỀN THỪA
        /// </summary>
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

        /// <summary>
        /// NÚT CẬP NHẬT HÓA ĐƠN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    Notification notification = new Notification
                    {
                        Screen = Utility.CHEF_SCREEEN,
                        Content = TableBusinessTier.GetTableNameByTableID(_TableID) + " đã được cập nhật lại. Vui lòng kiểm tra!"
                    };
                    if (!NotificationBusinessTier.PushNotification(notification))
                    {
                        MessageBox.Show("Lỗi khi đẩy thông báo vào database", "Error", MessageBoxButtons.OK);
                    }
                    SendChefOrUpdate(_InvoiceID, Error);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Failure", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// SỰ KIỆN XỬ LÝ THÊM BÀN MỚI HOẶC CẬP NHẬT LẠI BÀN
        /// </summary>
        /// <param name="_InvoiceID"></param>
        /// <param name="Error"></param>
        private void SendChefOrUpdate(int _InvoiceID, string Error)
        {
            foreach (_AlimentBar item in pnlAlimentDetails.Controls)
            {
                if (int.Parse(item.Total) == 0)
                {
                    continue;
                }
                DataRow row = data.NewRow();
                row["InvoiceID"] = _InvoiceID;
                row["AlimentID"] = AlimentBusinessTier.GetAlimentByName(item.AlimentName).AlimentID;
                row["Amount"] = Convert.ToInt32(item.Amount);
                row["SizeID"] = AlimentSizeBusinessTier.GetSizeIDByName(item.AlimentSize);
                row["Note"] = item.Note;
                int index = -1;
                for (int i = 0; i < data.Rows.Count; ++i)
                {
                    if ((data.Rows[i]["AlimentID"].Equals(row["AlimentID"]) && data.Rows[i]["InvoiceID"].Equals(row["InvoiceID"])))
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    data.Rows[index]["Amount"] = (int.Parse(data.Rows[index]["Amount"].ToString()) + int.Parse(row["Amount"].ToString()));
                }
                else
                {
                    data.Rows.Add(row);
                }
            }
            foreach (DataRow row in data.Rows)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail()
                {
                    InvoiceID = _InvoiceID,
                    AlimentID = int.Parse(row["AlimentID"].ToString()),
                    Amount = int.Parse(row["Amount"].ToString()),
                    SizeID = int.Parse(row["SizeID"].ToString()),
                    Note = row["Note"].ToString()
                };

                if (!InvoiceDetailsBusinessTier.AddInvoiceDetails(invoiceDetail, out Error))
                {
                    MessageBox.Show(Error, "Invoice Details Create Failure", MessageBoxButtons.OK);
                }
            }
            data.Rows.Clear();
            Close();
        }

        /// <summary>
        /// THÊM BÀN MỚI VÀ GỬI XUỐNG BẾP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Notification notification = new Notification
                {
                    Screen = Utility.CHEF_SCREEEN,
                    Content = TableBusinessTier.GetTableNameByTableID(_TableID) + " đã được thêm vào hàng chờ. Vui lòng kiểm tra!"
                };
                if (!NotificationBusinessTier.PushNotification(notification))
                {
                    MessageBox.Show("Lỗi khi đẩy thông báo lên database", "Error", MessageBoxButtons.OK);
                }
                SendChefOrUpdate(_InvoiceID, Error);
            }
            else
            {
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// NÚT THANH TOÁN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
