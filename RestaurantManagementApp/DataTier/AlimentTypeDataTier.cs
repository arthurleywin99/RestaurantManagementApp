using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class AlimentTypeDataTier
    {
        public static List<AlimentType> GetAlimentTypes()
        {
            using (var context = new Context())
            {
                return context.AlimentTypes.ToList();
            }
        }

        public static int GetAlimentTypeIDByName(string name)
        {
            using (var context = new Context())
            {
                return context.AlimentTypes.SingleOrDefault(p => p.TypeName.Equals(name)).TypeID;
            }
        }

        public static string GetAlimentTypeNameByID(int TypeID)
        {
            using (var context = new Context())
            {
                return context.AlimentTypes.SingleOrDefault(p => p.TypeID == TypeID).TypeName;
            }
        }
    }
}
