using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class InvoiceDataTier
    {
        public static List<Invoice> GetInvoices(int UserID, int TableID, DateTime from, DateTime to)
        {
            using (var context = new Context())
            {
                DateTime From = from.AddDays(-1).Date;
                DateTime To = to.AddDays(1).Date;
                if (UserID == -1 && TableID == -1)
                {
                    return context.Invoices.Where(p => p.CreateDate >= From
                                             && p.CreateDate <= To).ToList();
                }
                else if (UserID == -1)
                {
                    return context.Invoices.Where(p => p.TableID == TableID
                                             && p.CreateDate >= From
                                             && p.CreateDate <= To).ToList();
                }
                else if (TableID == -1)
                {
                    return context.Invoices.Where(p => p.UserID == UserID
                                             && p.CreateDate >= From
                                             && p.CreateDate <= To).ToList();
                }
                return context.Invoices.Where(p => p.UserID == UserID
                                             && p.TableID == TableID
                                             && p.CreateDate >= From
                                             && p.CreateDate <= To).ToList();
            }
        }

        public static int TodayInvoiceCount()
        {
            using (var context = new Context())
            {
                DateTime end = DateTime.Now.AddDays(1).Date;
                DateTime start = DateTime.Now.Date;
                return context.Invoices.Where(p => p.CreateDate >= start
                                              && p.CreateDate <= end).ToList().Count;
            }
        }

        public static int ThisMonthInvoiceCount()
        {
            using (var context = new Context())
            {
                int month = DateTime.Now.Month;
                return context.Invoices.Where(p => p.CreateDate.Month == month).ToList().Count;
            }
        }

        public static int ThisYearInvoiceCount()
        {
            using (var context = new Context())
            {
                int year = DateTime.Now.Year;
                return context.Invoices.Where(p => p.CreateDate.Year == year).ToList().Count;
            }
        }

        public static int AllTimeInvoiceCount()
        {
            using (var context = new Context())
            {
                return context.Invoices.ToList().Count;
            }
        }

        public static long TodayTotalPrice()
        {
            using (var context = new Context())
            {
                DateTime end = DateTime.Now.AddDays(1).Date;
                DateTime start = DateTime.Now.Date;
                return context.Invoices.Where(p => p.CreateDate >= start
                                              && p.CreateDate <= end).ToList()
                                              .Select(t => Convert.ToInt32(t.Total)).Sum();
            }
        }

        public static long ThisMonthTotalPrice()
        {
            using (var context = new Context())
            {
                return context.Invoices.Where(p => p.CreateDate.Month == DateTime.Now.Month).ToList()
                                              .Select(t => Convert.ToInt32(t.Total)).Sum();
            }
        }

        public static long ThisYearTotalPrice()
        {
            using (var context = new Context())
            {
                return context.Invoices.Where(p => p.CreateDate.Year == DateTime.Now.Year).ToList()
                                              .Select(t => Convert.ToInt32(t.Total)).Sum();
            }
        }

        public static long AllTimeTotalPrice()
        {
            using (var context = new Context())
            {
                return long.Parse(context.Invoices.Select(p => p.Total).Sum().ToString());
            }
        }

        public static int InvoiceStatistical(DateTime From, DateTime To)
        {
            using (var context = new Context())
            {
                return context.Invoices.Where(p => p.CreateDate >= From
                                             && p.CreateDate <= To).ToList().Count;
            }
        }

        public static List<Top5Drink> GetTop5Drinks()
        {
            using (var context = new Context())
            {
                return context.Top5Drink.ToList();
            }
        }

        public static List<Top5Food> GetTop5Foods()
        {
            using (var context = new Context())
            {
                return context.Top5Food.ToList();
            }
        }

        public static List<Invoice> GetIsNotPaidInvoices()
        {
            using (var context = new Context())
            {
                return (from a in context.Invoices
                              join b in context.Tables
                              on a.TableID equals b.TableID
                              where a.IsPaid == false && b.Status.Equals("pending")
                              select a).ToList();
            }
        }

        public static List<Invoice> GetOrderingInvoices()
        {
            using (var context = new Context())
            {
                return (from a in context.Invoices
                        join b in context.Tables
                        on a.TableID equals b.TableID
                        where a.IsPaid == false && b.Status.Equals("ordering")
                        select a).ToList();
            }
        }

        public static bool AddInvoice(Invoice invoice, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    context.Invoices.Add(invoice);
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

        public static bool DeleteInvoice(int InvoiceID, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    var Invoice = context.Invoices.FirstOrDefault(p => p.InvoiceID == InvoiceID);
                    context.Invoices.Remove(Invoice);
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

        public static int GetInvoiceIDByTableUserCreate(int TableID, int UserID, DateTime CreateDate, long Total)
        {
            using (var context = new Context())
            {
                DateTime from = CreateDate.Date;
                DateTime to = CreateDate.AddDays(1).Date;
                return context.Invoices.FirstOrDefault(p => p.TableID == TableID
                                                         && p.UserID == UserID
                                                         && p.CreateDate >= from
                                                         && p.CreateDate <= to
                                                         && p.Total == Total
                                                         && p.IsPaid == false).InvoiceID;
            }
        }

        public static int GetInvoiceIDByTableUserIsPaid(int TableID, int UserID)
        {
            using (var context = new Context())
            {
                return context.Invoices.FirstOrDefault(p => p.TableID == TableID
                                                         && p.UserID == UserID
                                                         && p.IsPaid == false).InvoiceID;
            }
        }

        public static bool UpdateInvoice(int InvoiceID, Invoice NewInvoice, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    var OldInvoice = context.Invoices.FirstOrDefault(p => p.InvoiceID == InvoiceID);
                    OldInvoice.UserID = NewInvoice.UserID;
                    OldInvoice.CreateDate = NewInvoice.CreateDate;
                    OldInvoice.Total = NewInvoice.Total;
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

        public static bool UpdatePaymentInvoiceStatus(int InvoiceID, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    var Invoice = context.Invoices.FirstOrDefault(p => p.InvoiceID == InvoiceID);
                    Invoice.IsPaid = true;
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
    }
}
