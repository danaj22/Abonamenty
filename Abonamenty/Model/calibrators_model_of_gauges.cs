namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class calibrators_model_of_gauges
    {
        [Key]
        public int calibrator_modelId { get; set; }

        public int? calibrator_id { get; set; }

        public int? model_of_gaug_id { get; set; }

        public virtual calibrator calibrator { get; set; }

        public virtual model_of_gauges model_of_gauges { get; set; }
    }
}
