using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;

namespace RestaurantManagementApp.BusinessTier
{
    public class AlimentTypeBusinessTier
    {
        public static List<AlimentType> GetAlimentTypes()
        {
            return AlimentTypeDataTier.GetAlimentTypes();
        }

        public static int GetAlimentTypeIDByName(string name)
        {
            return AlimentTypeDataTier.GetAlimentTypeIDByName(name);
        }

        public static string GetAlimentTypeNameByID(int TypeID)
        {
            return AlimentTypeDataTier.GetAlimentTypeNameByID(TypeID);
        }
    }
}
