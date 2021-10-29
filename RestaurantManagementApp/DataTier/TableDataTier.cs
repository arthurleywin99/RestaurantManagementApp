using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class TableDataTier
    {
        public static List<Table> GetAllTables()
        {
            using (var context = new Context())
            {
                return context.Tables.ToList();
            }
        }

        public static int GetTableByTableName(string TableName)
        {
            using (var context = new Context())
            {
                return context.Tables.FirstOrDefault(p => p.TableName.Equals(TableName)).TableID;
            }
        }

        public static string GetTableNameByTableID(int TableID)
        {
            using (var context = new Context())
            {
                return context.Tables.FirstOrDefault(p => p.TableID == TableID).TableName;
            }
        }

        public static bool SetOrderStatus(int TableID, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    var table = context.Tables.FirstOrDefault(p => p.TableID == TableID);
                    if (table.Status.Equals("pending"))
                    {
                        table.Status = "ordering";
                        context.SaveChanges();
                        return true;
                    }
                    throw new Exception("Có lỗi xảy ra. Vui lòng kiểm tra lại");
                }
                catch (Exception ex)
                {
                    Error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool SetFreeStatus(int TableID, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    var table = context.Tables.FirstOrDefault(p => p.TableID == TableID);
                    if (table.Status.Equals("pending") || table.Status.Equals("ordering"))
                    {
                        table.Status = "free";
                        context.SaveChanges();
                        return true;
                    }
                    throw new Exception("Có lỗi xảy ra. Vui lòng kiểm tra lại");
                }
                catch (Exception ex)
                {
                    Error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool SetPendingStatus(int TableID, out string Error)
        {
            using (var context = new Context())
            {
                Error = string.Empty;
                try
                {
                    var table = context.Tables.FirstOrDefault(p => p.TableID == TableID);
                    if (table.Status.Equals("free"))
                    {
                        table.Status = "pending";
                        context.SaveChanges();
                        return true;
                    }
                    throw new Exception("Có lỗi xảy ra. Vui lòng kiểm tra lại");
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
