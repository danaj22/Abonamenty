namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class certificate
    {
        [Key]
        public int certifacateId { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public DateTime? date { get; set; }

        public float? cost { get; set; }

        [StringLength(50)]
        public string authorized_by { get; set; }

        public int gauge_id { get; set; }

        public virtual gauge gauge { get; set; }
    }
}
