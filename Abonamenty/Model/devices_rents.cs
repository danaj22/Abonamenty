namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class devices_rents
    {
        [Key]
        public int device_rentId { get; set; }

        public int? device_id { get; set; }

        public int? rent_id { get; set; }

        public virtual device device { get; set; }

        public virtual rent rent { get; set; }
    }
}
