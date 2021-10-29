using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;

namespace RestaurantManagementApp.BusinessTier
{
    public class AlimentSizeBusinessTier
    {
        public static string GetAlimentSizeByID(int SizeID)
        {
            return AlimentSizeDataTier.GetAlimentSizeByID(SizeID);
        }

        public static List<AlimentSize> GetAlimentSizes()
        {
            return AlimentSizeDataTier.GetAlimentSizes();
        }

        public static int GetPercentIncrease(string SizeName)
        {
            return AlimentSizeDataTier.GetPercentIncrease(SizeName);
        }

        public static string GetSizeNameByPercent(int Percent)
        {
            return AlimentSizeDataTier.GetSizeNameByPercent(Percent);
        }

        public static int GetSizeIDByName(string SizeName)
        {
            return AlimentSizeDataTier.GetSizeIDByName(SizeName);
        }
    }
}
