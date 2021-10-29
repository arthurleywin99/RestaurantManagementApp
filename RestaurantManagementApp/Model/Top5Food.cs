namespace RestaurantManagementApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Top5Food
    {
        [Key]
        [StringLength(255)]
        public string AlimentName { get; set; }

        public int? Count { get; set; }
    }
}
