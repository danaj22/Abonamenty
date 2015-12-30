namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class calibrators_functions
    {
        [Key]
        public int calibrator_functionId { get; set; }

        public int? calibrator_id { get; set; }

        public int? function_id { get; set; }

        public virtual calibrator calibrator { get; set; }

        public virtual function function { get; set; }
    }
}
