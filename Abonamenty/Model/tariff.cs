namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tariff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tariff()
        {
            subscriptions = new ObservableCollection<subscription>();
        }

        public int tariffId { get; set; }

        public double? discount { get; set; }

        public int? number_of_calling { get; set; }

        public string name_tarriff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<subscription> subscriptions { get; set; }
    }
}
