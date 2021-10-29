namespace RestaurantManagementApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aliment")]
    public partial class Aliment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aliment()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int AlimentID { get; set; }

        public int? TypeID { get; set; }

        [Required]
        [StringLength(255)]
        public string AlimentName { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual AlimentType AlimentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
