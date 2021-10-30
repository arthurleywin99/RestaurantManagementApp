using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class AlimentDataTier
    {
        public static List<Aliment> GetAliments()
        {
            using (var context = new Context())
            {
                return context.Aliments.ToList();
            }
        }

        public static List<Aliment> GetAlimentsByTypeName(string TypeName)
        {
            using (var context = new Context())
            {
                var TypeID = context.AlimentTypes.FirstOrDefault(p => p.TypeName.Equals(TypeName)).TypeID;
                return context.Aliments.Where(p => p.TypeID == TypeID).ToList();
            }
        }

        public static Aliment GetAlimentByName(string name)
        {
            using (var context = new Context())
            {
                return context.Aliments.FirstOrDefault(p => p.AlimentName.Equals(name));
            }
        } 

        public static string GetAlimentNameByID(int AlimentID)
        {
            using (var context = new Context())
            {
                return context.Aliments.FirstOrDefault(p => p.AlimentID == AlimentID).AlimentName;
            }
        }

        public static int GetAlimentPriceByID(int AlimentID)
        {
            using (var context = new Context())
            {
                return Convert.ToInt32(context.Aliments.FirstOrDefault(p => p.AlimentID == AlimentID).Price);
            }
        }

        public static bool AddAliment(Aliment aliment, out string error)
        {
            using (var context = new Context())
            {
                error = string.Empty;
                try
                {
                    context.Aliments.Add(aliment);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool UpdateAliment(string alimentName, Aliment NewAliment, out string error)
        {
            using (var context = new Context())
            {
                error = string.Empty;
                try
                {
                    var aliment = context.Aliments.FirstOrDefault(p => p.AlimentName.Equals(alimentName));
                    aliment.AlimentName = NewAliment.AlimentName;
                    aliment.TypeID = NewAliment.TypeID;
                    aliment.Price = NewAliment.Price;
                    aliment.Image = NewAliment.Image;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool IsAlimentExist(Aliment aliment)
        {
            using (var context = new Context())
            {
                return context.Aliments.Any(p => p.TypeID == aliment.TypeID 
                                            && p.AlimentName.ToUpper() == aliment.AlimentName.ToUpper()
                                            && p.Price == aliment.Price);
            }
        }

        public static bool StopAliment(string alimentName, out string error)
        {
            using (var context = new Context())
            {
                error = string.Empty;
                try
                {
                    var aliment = context.Aliments.FirstOrDefault(p => p.AlimentName.Equals(alimentName));
                    aliment.StillForSale = false;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                    return false;
                }
            }
        }
    }
}
