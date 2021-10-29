using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;

namespace RestaurantManagementApp.BusinessTier
{
    public class InvoiceBusinessTier
    {
        public static List<Invoice> GetInvoices(int UserID, int TableID, DateTime From, DateTime To)
        {
            return InvoiceDataTier.GetInvoices(UserID, TableID, From, To);
        }

        public static int TodayInvoiceCount()
        {
            return InvoiceDataTier.TodayInvoiceCount();
        }

        public static int ThisMonthInvoiceCount()
        {
            return InvoiceDataTier.ThisMonthInvoiceCount();
        }

        public static int ThisYearInvoiceCount()
        {
            return InvoiceDataTier.ThisYearInvoiceCount();
        }

        public static int AllTimeInvoiceCount()
        {
            return InvoiceDataTier.AllTimeInvoiceCount();
        }

        public static long TodayTotalPrice()
        {
            return InvoiceDataTier.TodayTotalPrice();
        }

        public static long ThisMonthTotalPrice()
        {
            return InvoiceDataTier.ThisMonthTotalPrice();
        }

        public static long ThisYearTotalPrice()
        {
            return InvoiceDataTier.ThisYearTotalPrice();
        }

        public static long AllTimeTotalPrice()
        {
            return InvoiceDataTier.AllTimeTotalPrice();
        }

        public static int InvoiceStatistical(DateTime From, DateTime To)
        {
            return InvoiceDataTier.InvoiceStatistical(From, To);
        }

        public static List<Top5Drink> GetTop5Drinks()
        {
            return InvoiceDataTier.GetTop5Drinks();
        }

        public static List<Top5Food> GetTop5Foods()
        {
            return InvoiceDataTier.GetTop5Foods();
        }

        public static List<Invoice> GetIsNotPaidInvoices()
        {
            return InvoiceDataTier.GetIsNotPaidInvoices();
        }

        public static bool AddInvoice(Invoice invoice, out string Error)
        {
            return InvoiceDataTier.AddInvoice(invoice, out Error);
        }

        public static bool DeleteInvoice(int InvoiceID, out string Error)
        {
            return InvoiceDataTier.DeleteInvoice(InvoiceID, out Error);
        }

        public static List<Invoice> GetOrderingInvoices()
        {
            return InvoiceDataTier.GetOrderingInvoices();
        }

        public static int GetInvoiceIDByTableUserCreate(int TableID, int UserID, DateTime CreateDate, long Total)
        {
            return InvoiceDataTier.GetInvoiceIDByTableUserCreate(TableID, UserID, CreateDate, Total);
        }

        public static bool UpdatePaymentInvoiceStatus(int InvoiceID, out string Error)
        {
            return InvoiceDataTier.UpdatePaymentInvoiceStatus(InvoiceID, out Error);
        }

        public static int GetInvoiceIDByTableUserIsPaid(int TableID, int UserID)
        {
            return InvoiceDataTier.GetInvoiceIDByTableUserIsPaid(TableID, UserID);
        }

        public static bool UpdateInvoice(int InvoiceID, Invoice NewInvoice, out string Error)
        {
            return InvoiceDataTier.UpdateInvoice(InvoiceID, NewInvoice, out Error);
        }
    }
}
