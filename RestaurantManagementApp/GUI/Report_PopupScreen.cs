using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.UtilityMethod;
using RestaurantManagementApp.Model;
using Microsoft.Reporting.WinForms;

namespace RestaurantManagementApp.GUI
{
    public partial class Report_PopupScreen : Form
    {
        private readonly Context context;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public Report_PopupScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            context = new Context();
        }

        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_PopupScreen_Load(object sender, EventArgs e)
        {
            this.invoiceReportViewer.RefreshReport();
            List<Invoice> invoices = context.Invoices.ToList();
            List<InvoiceReport> reports = new List<InvoiceReport>();

            foreach (var item in invoices)
            {
                InvoiceReport report = new InvoiceReport
                {
                    InvoiceID = item.InvoiceID,
                    TableName = TableBusinessTier.GetTableNameByTableID(Convert.ToInt32(item.TableID)),
                    Username = UserBusinessTier.GetUsernameByUserID(Convert.ToInt32(item.UserID)),
                    CreateDate = item.CreateDate,
                    Total = Convert.ToInt32(item.Total)
                };
                reports.Add(report);
            }

            invoiceReportViewer.LocalReport.ReportPath = "../../Report/InvoiceReport.rdlc";
            var reportDataSource = new ReportDataSource("InvoiceDataSet", reports);
            invoiceReportViewer.LocalReport.DataSources.Clear();
            invoiceReportViewer.LocalReport.DataSources.Add(reportDataSource);
            invoiceReportViewer.RefreshReport();
        }

        #region 2 NÚT CONTROL
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
        /// NÚT ĐÓNG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
