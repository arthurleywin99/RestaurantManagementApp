using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class InvoiceDetailsDataTier
    {
        public static List<InvoiceDetail> GetInvoiceDetails(int InvoiceID)
        {
            using (var context = new Context())
            {
                return context.InvoiceDetails.Where(p => p.InvoiceID == InvoiceID).ToList();
            }
        }

        public static int TodayAlimentServeCount()
        {
            using (var context = new Context())
            {
                DateTime end = DateTime.Now.AddDays(1).Date;
                DateTime start = DateTime.Now.Date;
                return (from a in context.Invoices
                        join b in context.InvoiceDetails
                        on a.InvoiceID equals b.InvoiceID
                        where a.CreateDate >= start && a.CreateDate <= end
                        select new { b.AlimentID }).ToList().Count();
            }
        }

        public static int ThisMonthAlimentServeCount()
        {
            using (var context = new Context())
            {
                return (from a in context.Invoices
                        join b in context.InvoiceDetails
                        on a.InvoiceID equals b.InvoiceID
                        where a.CreateDate.Month == DateTime.Now.Month
                        select new { b.AlimentID }).ToList().Count();
            }
        }

        public static int ThisYearAlimentServeCount()
        {
            using (var context = new Context())
            {
                return (from a in context.Invoices
                        join b in context.InvoiceDetails
                        on a.InvoiceID equals b.InvoiceID
                        where a.CreateDate.Year == DateTime.Now.Year
                        select new { b.AlimentID }).ToList().Count();
            }
        }

        public static int AllTimeAlimentServeCount()
        {
            using (var context = new Context())
            {
                return context.InvoiceDetails.ToList().Count;
            }
        }

        public static bool AddInvoiceDetails(InvoiceDetail invoiceDetail, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    context.InvoiceDetails.Add(invoiceDetail);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool DeleteInvoiceDetails(int InvoiceID, out string Error) 
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                List<InvoiceDetail> invoices = context.InvoiceDetails.Where(p => p.InvoiceID == InvoiceID).ToList();
                foreach (var item in invoices)
                {
                    try
                    {
                        context.InvoiceDetails.Remove(item);
                    }
                    catch (Exception ex)
                    {
                        Error = ex.ToString();
                        return false;
                    }
                }
                context.SaveChanges();
                return true;
            }
        }

        public static List<InvoiceDetail> GetInvoiceDetailsPendingOrOrdering(int TableID)
        {
            using (var context = new Context())
            {
                var PendingInvoiceID = context.Invoices.FirstOrDefault(p => p.TableID == TableID && !p.IsPaid).InvoiceID;
                return context.InvoiceDetails.Where(p => p.InvoiceID == PendingInvoiceID).ToList();
            }
        }

        public static string GetNoteByInvoiceID(int InvoiceID, int AlimentID)
        {
            using (var context = new Context())
            {
                return context.InvoiceDetails.FirstOrDefault(p => p.InvoiceID == InvoiceID && p.AlimentID == AlimentID).Note;
            }
        }
    }
}
