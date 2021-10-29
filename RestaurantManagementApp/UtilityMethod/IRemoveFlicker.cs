using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementApp.UtilityMethod
{
    public interface IRemoveFlicker
    {
        /// <summary>
        /// Cải thiện hiện tượng nhấp nháy khi có quá nhiều Control 
        /// </summary>
        void RemoveFlicker();
    }
}
