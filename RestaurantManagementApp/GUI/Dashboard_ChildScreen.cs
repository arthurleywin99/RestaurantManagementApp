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
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.GUI
{
    public partial class Dashboard_ChildScreen : Form
    {
        public Dashboard_ChildScreen()
        {
            InitializeComponent();
        }

        private void Dashboard_ChildScreen_Load(object sender, EventArgs e)
        {
            FillComboBoxOption();
            InvoiceMonthChart();
            Top5Foods();
            Top5Drinks();
        }

        private void FillComboBoxOption()
        {
            cboOption.Items.Add("Hôm nay");
            cboOption.Items.Add("Tháng này");
            cboOption.Items.Add("Năm này");
            cboOption.Items.Add("Từ trước đến nay");
        }

        private void cboOption_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboOption.SelectedIndex)
            {
                case 0:
                    {
                        Today();
                        break;
                    }
                case 1:
                    {
                        ThisMonth();
                        break;
                    }
                case 2:
                    {
                        ThisYear();
                        break;
                    }
                case 3:
                    {
                        AllTimes();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        private void Today()
        {
            lblInvoiceCount.Text = InvoiceBusinessTier.TodayInvoiceCount().ToString();
            lblInvoiceServe.Text = InvoiceDetailsBusinessTier.TodayAlimentServeCount().ToString();
            lblTotal.Text = InvoiceBusinessTier.TodayTotalPrice().ToString();
        }

        private void ThisMonth()
        {
            lblInvoiceCount.Text = InvoiceBusinessTier.ThisMonthInvoiceCount().ToString();
            lblInvoiceServe.Text = InvoiceDetailsBusinessTier.ThisMonthAlimentServeCount().ToString();
            lblTotal.Text = InvoiceBusinessTier.ThisMonthTotalPrice().ToString();
        }

        private void ThisYear()
        {
            lblInvoiceCount.Text = InvoiceBusinessTier.ThisYearInvoiceCount().ToString();
            lblInvoiceServe.Text = InvoiceDetailsBusinessTier.ThisYearAlimentServeCount().ToString();
            lblTotal.Text = InvoiceBusinessTier.ThisYearTotalPrice().ToString();
        }

        private void AllTimes()
        {
            lblInvoiceCount.Text = InvoiceBusinessTier.AllTimeInvoiceCount().ToString();
            lblInvoiceServe.Text = InvoiceDetailsBusinessTier.AllTimeAlimentServeCount().ToString();
            lblTotal.Text = InvoiceBusinessTier.AllTimeTotalPrice().ToString();
        }

        private void InvoiceMonthChart()
        {
            int _year = DateTime.Now.Year;
            int _month = DateTime.Now.Month;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            invoiceChart.Titles.Add($"Thống kê số hóa đơn trong tháng {_month}/{_year}");
            invoiceChart.Series["Hóa Đơn"].Points.AddXY("Ngày 1 - 4", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 1), new DateTime(_year, _month, 4)));
            invoiceChart.Series["Hóa Đơn"].Points.AddXY("Ngày 5 - 8", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 5), new DateTime(_year, _month, 8)));
            invoiceChart.Series["Hóa Đơn"].Points.AddXY("Ngày 9 - 12", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 9), new DateTime(_year, _month, 12)));
            invoiceChart.Series["Hóa Đơn"].Points.AddXY("Ngày 13 - 16", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 13), new DateTime(_year, _month, 16)));
            invoiceChart.Series["Hóa Đơn"].Points.AddXY("Ngày 17 - 20", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 17), new DateTime(_year, _month, 20)));
            invoiceChart.Series["Hóa Đơn"].Points.AddXY("Ngày 21 - 24", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 21), new DateTime(_year, _month, 24)));
            invoiceChart.Series["Hóa Đơn"].Points.AddXY("Ngày 25 - 28", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 25), new DateTime(_year, _month, 28)));
            if (lastDay > 29)
            {
                invoiceChart.Series["Hóa Đơn"].Points.AddXY($"Ngày 29 - {lastDay}", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 29), new DateTime(_year, _month, lastDay)));
            }
            if (lastDay == 29)
            {
                invoiceChart.Series["Hóa Đơn"].Points.AddXY($"Ngày 29", InvoiceBusinessTier.InvoiceStatistical(new DateTime(_year, _month, 29), new DateTime(_year, _month, 29)));
            }
        }

        private void Top5Drinks()
        {
            topDrinkChart.Titles.Add("Top 5 đồ uống bán chạy nhất");
            List<Top5Drink> top5Drinks = InvoiceBusinessTier.GetTop5Drinks();
            int Sum = top5Drinks.Select(p => Convert.ToInt32(p.Count)).Sum();
            foreach (var item in top5Drinks)
            {
                topDrinkChart.Series["Top Đồ Uống Bán Chạy"].Points.AddXY(item.AlimentName, Math.Round(Convert.ToDouble(item.Count * 1.0f / Sum * 100), 2));
            }
        }

        private void Top5Foods()
        {
            topFoodChart.Titles.Add("Top 5 đồ ăn bán chạy nhất");
            List<Top5Food> top5Foods = InvoiceBusinessTier.GetTop5Foods();
            int Sum = top5Foods.Select(p => Convert.ToInt32(p.Count)).Sum();
            foreach (var item in top5Foods)
            {
                topFoodChart.Series["Top Đồ Ăn Bán Chạy"].Points.AddXY(item.AlimentName, Math.Round(Convert.ToDouble(item.Count * 1.0f / Sum * 100), 2));
            }
        }
    }
}
