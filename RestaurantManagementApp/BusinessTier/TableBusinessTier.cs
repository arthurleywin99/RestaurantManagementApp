using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;

namespace RestaurantManagementApp.BusinessTier
{
    public class TableBusinessTier
    {
        public static List<Table> GetAllTables()
        {
            return TableDataTier.GetAllTables();
        }

        public static int GetTableByTableName(string TableName)
        {
            return TableDataTier.GetTableByTableName(TableName);
        }

        public static string GetTableNameByTableID(int TableID)
        {
            return TableDataTier.GetTableNameByTableID(TableID);
        }

        public static bool SetOrderStatus(int TableID, out string Error)
        {
            return TableDataTier.SetOrderStatus(TableID, out Error);
        }

        public static bool SetFreeStatus(int TableID, out string Error)
        {
            return TableDataTier.SetFreeStatus(TableID, out Error);
        }

        public static bool SetPendingStatus(int TableID, out string Error)
        {
            return TableDataTier.SetPendingStatus(TableID, out Error);
        }
    }
}
