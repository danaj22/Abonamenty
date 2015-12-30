namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class calibrator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public calibrator()
        {
            calibrators_functions = new ObservableCollection<calibrators_functions>();
            calibrators_model_of_gauges = new ObservableCollection<calibrators_model_of_gauges>();
        }

        public int calibratorId { get; set; }

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        public int? model_of_gauge_id { get; set; }

        public int? function_id { get; set; }

        public bool IsChecked { get; set; }

        public int? function_functionId { get; set; }

        public virtual function function { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<calibrators_functions> calibrators_functions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }
    }
}
