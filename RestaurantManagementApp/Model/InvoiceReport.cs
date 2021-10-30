using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementApp.Model
{
    public class InvoiceReport
    {
        public int InvoiceID { get; set; }
        public string TableName { get; set; }
        public string Username { get; set; }
        public DateTime CreateDate { get; set; }
        public int Total { get; set; }
    }
}
