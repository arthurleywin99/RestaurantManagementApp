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

        public Report_PopupScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            context = new Context();
        }

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

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        private void ControlBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }
    }
}
