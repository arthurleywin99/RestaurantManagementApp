using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class AlimentSizeDataTier
    {
        public static string GetAlimentSizeByID(int SizeID)
        {
            using (var context = new Context())
            {
                return context.AlimentSizes.FirstOrDefault(p => p.SizeID == SizeID).SizeName;
            }
        }

        public static List<AlimentSize> GetAlimentSizes()
        {
            using (var context = new Context())
            {
                return context.AlimentSizes.ToList();
            }
        }

        public static int GetPercentIncrease(string SizeName)
        {
            using (var context = new Context())
            {
                return context.AlimentSizes.FirstOrDefault(p => p.SizeName.Equals(SizeName)).PercentIncrease;
            }
        }

        public static string GetSizeNameByPercent(int Percent)
        {
            using (var context = new Context())
            {
                return context.AlimentSizes.FirstOrDefault(p => p.PercentIncrease == Percent).SizeName;
            }
        }

        public static int GetSizeIDByName(string SizeName)
        {
            using (var context = new Context())
            {
                return context.AlimentSizes.FirstOrDefault(p => p.SizeName.Equals(SizeName)).SizeID;
            }
        }
    }
}
