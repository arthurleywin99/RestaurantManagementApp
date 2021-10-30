namespace RestaurantManagementApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Screen { get; set; }

        public string Content { get; set; }
    }
}
