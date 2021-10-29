namespace RestaurantManagementApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceDetail")]
    public partial class InvoiceDetail
    {
        public int ID { get; set; }

        public int InvoiceID { get; set; }

        public int AlimentID { get; set; }

        public int Amount { get; set; }

        public int SizeID { get; set; }

        public string Note { get; set; }

        public virtual Aliment Aliment { get; set; }

        public virtual AlimentSize AlimentSize { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
