namespace RestaurantManagementApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlimentSize")]
    public partial class AlimentSize
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AlimentSize()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Key]
        public int SizeID { get; set; }

        [Required]
        [StringLength(3)]
        public string SizeName { get; set; }

        public int PercentIncrease { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
