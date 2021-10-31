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
    public partial class InvoiceStatistical_ChildScreen : Form
    {
        private DataTable DataInvoice, DataInvoiceDetails;
        private int index;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public InvoiceStatistical_ChildScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceStatistical_ChildScreen_Load(object sender, EventArgs e)
        {
            FillEmployeeToComboBox();
            FillTableToComboBox();
            InitDataTableInvoice();
            InitDataTableInvoiceDetails();
        }

        /// <summary>
        /// KHỞI TẠO DATATABLE HÓA ĐƠN
        /// </summary>
        private void InitDataTableInvoice()
        {
            DataInvoice = new DataTable();
            DataInvoice.Columns.Add("STT", typeof(int));
            DataInvoice.Columns.Add("Mã Hóa Đơn", typeof(int));
            DataInvoice.Columns.Add("Tên Bàn", typeof(string));
            DataInvoice.Columns.Add("Tên Nhân Viên", typeof(string));
            DataInvoice.Columns.Add("Ngày Lập Hóa Đơn", typeof(DateTime));
            DataInvoice.Columns.Add("Tổng Tiền", typeof(int));
            DataInvoice.Columns.Add("Đã Thanh Toán", typeof(bool));
            dgvInvoice.DataSource = DataInvoice;
        }

        /// <summary>
        /// KHỞI TẠO DATATABLE CHI TIẾT HÓA ĐƠN
        /// </summary>
        private void InitDataTableInvoiceDetails()
        {
            DataInvoiceDetails = new DataTable();
            DataInvoiceDetails.Columns.Add("STT", typeof(int));
            DataInvoiceDetails.Columns.Add("Mã Hóa Đơn", typeof(int));
            DataInvoiceDetails.Columns.Add("Tên Món Ăn", typeof(string));
            DataInvoiceDetails.Columns.Add("Số Lượng", typeof(int));
            DataInvoiceDetails.Columns.Add("Kích Cỡ", typeof(string));
            DataInvoiceDetails.Columns.Add("Ghi Chú", typeof(string));
        }

        /// <summary>
        /// ĐỔ DỮ LIỆU DANH SÁCH CÁC NHÂN VIÊN VÀO COMBOBOX
        /// </summary>
        private void FillEmployeeToComboBox()
        {
            cboEmployee.Items.Add("");
            List<User> employeeUsers = UserBusinessTier.GetEmployeeList();
            foreach (var item in employeeUsers)
            {
                cboEmployee.Items.Add(item.Username);
            }
        }

        /// <summary>
        /// ĐỔ DỮ LIỆU DANH SÁCH CÁC BÀN VÀO COMBOBOX
        /// </summary>
        private void FillTableToComboBox()
        {
            cboTable.Items.Add("");
            List<Table> tables = TableBusinessTier.GetAllTables();
            foreach (var item in tables)
            {
                cboTable.Items.Add(item.TableName);
            }
        }

        /// <summary>
        /// NÚT TÌM HÓA ĐƠN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region Ràng Buộc Khoảng Thời Gian Tìm Kiếm
            if (DateTime.Compare(dtpFrom.Value, dtpTo.Value) > 0)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK);
                dtpFrom.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now;
                return;
            }
            #endregion
            int UserID = cboEmployee.Texts.Equals("") ? -1 : UserBusinessTier.GetUserByUsername(cboEmployee.Texts).UserID;
            int TableID = cboTable.Texts.Equals("") ? -1 : TableBusinessTier.GetTableByTableName(cboTable.Texts);
            List<Invoice> invoices = InvoiceBusinessTier.GetInvoices(UserID, TableID, dtpFrom.Value.Date, dtpTo.Value.Date);
            txtResult.Texts = invoices.Count.ToString();
            FillDataInvoiceToDataTable(DataInvoice, invoices);
        }

        /// <summary>
        /// ĐỔ DỮ LIỆU HÓA ĐƠN VÀO DATATABLE HÓA ĐƠN
        /// </summary>
        /// <param name="data"></param>
        /// <param name="invoices"></param>
        private void FillDataInvoiceToDataTable(DataTable data, List<Invoice> invoices)
        {
            data.Rows.Clear();
            index = 0;
            foreach (var item in invoices)
            {
                DataRow row = data.NewRow();
                row["STT"] = index + 1;
                row["Mã Hóa Đơn"] = item.InvoiceID;
                row["Tên Bàn"] = TableBusinessTier.GetTableNameByTableID(Convert.ToInt32(item.TableID));
                row["Tên Nhân Viên"] = UserBusinessTier.GetFullNameByUserID(Convert.ToInt32(item.UserID));
                row["Ngày Lập Hóa Đơn"] = item.CreateDate;
                row["Tổng Tiền"] = item.Total;
                row["Đã Thanh Toán"] = item.IsPaid;
                data.Rows.Add(row);
                index++;
            }
        }

        /// <summary>
        /// ĐẶT TRẠNG THÁI CÁC CONTROL VỀ BAN ĐẦU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboEmployee.SelectedIndex = 0;
            cboTable.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Now.Date;
            dtpTo.Value = DateTime.Now.Date;
        }

        /// <summary>
        /// HIỆN FORM REPORT ĐỂ IN HÓA ĐƠN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            new Report_PopupScreen().ShowDialog();
        }

        /// <summary>
        /// SỰ KIỆN NHẤN VÀO Ô TRONG DATAGRIDVIEW HÓA ĐƠN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInvoiceDetails.DataSource = null;
            int currentRow = dgvInvoice.CurrentRow.Index;
            int InvoiceID = Convert.ToInt32(dgvInvoice.Rows[currentRow].Cells[1].Value.ToString());
            List<InvoiceDetail> invoiceDetails = InvoiceDetailsBusinessTier.GetInvoiceDetails(InvoiceID);
            DataInvoiceDetails.Rows.Clear();
            index = 0;
            foreach (var item in invoiceDetails)
            {
                DataRow row = DataInvoiceDetails.NewRow();
                row["STT"] = index + 1;
                row["Mã Hóa Đơn"] = item.InvoiceID;
                row["Tên Món Ăn"] = AlimentBusinessTier.GetAlimentNameByID(item.AlimentID);
                row["Số Lượng"] = item.Amount;
                row["Kích Cỡ"] = AlimentSizeBusinessTier.GetAlimentSizeByID(Convert.ToInt32(item.SizeID));
                row["Ghi Chú"] = InvoiceDetailsBusinessTier.GetNoteByInvoiceID(item.InvoiceID, item.AlimentID);
                DataInvoiceDetails.Rows.Add(row);
                index++;
            }
            dgvInvoiceDetails.DataSource = DataInvoiceDetails;
        }
    }
}