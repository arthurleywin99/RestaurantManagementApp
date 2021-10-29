using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;

namespace RestaurantManagementApp.BusinessTier
{
    public class InvoiceDetailsBusinessTier
    {
        public static List<InvoiceDetail> GetInvoiceDetails(int InvoiceID)
        {
            return InvoiceDetailsDataTier.GetInvoiceDetails(InvoiceID);
        }

        public static int TodayAlimentServeCount()
        {
            return InvoiceDetailsDataTier.TodayAlimentServeCount();
        }

        public static int ThisMonthAlimentServeCount()
        {
            return InvoiceDetailsDataTier.ThisMonthAlimentServeCount();
        }

        public static int ThisYearAlimentServeCount()
        {
            return InvoiceDetailsDataTier.ThisYearAlimentServeCount();
        }

        public static int AllTimeAlimentServeCount()
        {
            return InvoiceDetailsDataTier.AllTimeAlimentServeCount();
        }

        public static bool AddInvoiceDetails(InvoiceDetail invoiceDetail, out string Error)
        {
            return InvoiceDetailsDataTier.AddInvoiceDetails(invoiceDetail, out Error);
        }

        public static bool DeleteInvoiceDetails(int InvoiceID, out string Error)
        {
            return InvoiceDetailsDataTier.DeleteInvoiceDetails(InvoiceID, out Error);
        }

        public static List<InvoiceDetail> GetInvoiceDetailsPendingOrOrdering(int TableID)
        {
            return InvoiceDetailsDataTier.GetInvoiceDetailsPendingOrOrdering(TableID);
        }

        public static string GetNoteByInvoiceID(int InvoiceID, int AlimentID)
        {
            return InvoiceDetailsDataTier.GetNoteByInvoiceID(InvoiceID, AlimentID);
        }
    }
}
