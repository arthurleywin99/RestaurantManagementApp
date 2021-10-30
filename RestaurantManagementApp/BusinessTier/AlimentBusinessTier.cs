using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;

namespace RestaurantManagementApp.BusinessTier
{
    public class AlimentBusinessTier
    {
        public static List<Aliment> GetAliments()
        {
            return AlimentDataTier.GetAliments();
        }

        public static List<Aliment> GetAlimentsByTypeName(string TypeName)
        {
            return AlimentDataTier.GetAlimentsByTypeName(TypeName);
        }

        public static Aliment GetAlimentByName(string name)
        {
            return AlimentDataTier.GetAlimentByName(name);
        }

        public static int GetAlimentPriceByID(int AlimentID)
        {
            return AlimentDataTier.GetAlimentPriceByID(AlimentID);
        }

        public static bool AddAliment(Aliment aliment, out string error)
        {
            return AlimentDataTier.AddAliment(aliment, out error);
        }

        public static bool UpdateAliment(string alimentName, Aliment NewAliment, out string error)
        {
            return AlimentDataTier.UpdateAliment(alimentName, NewAliment, out error);
        }

        public static bool IsAlimentExist(Aliment aliment)
        {
            return AlimentDataTier.IsAlimentExist(aliment);
        }

        public static bool StopAliment(string alimentName, out string error)
        {
            return AlimentDataTier.StopAliment(alimentName, out error);
        }

        public static string GetAlimentNameByID(int AlimentID)
        {
            return AlimentDataTier.GetAlimentNameByID(AlimentID);
        }
    }
}
