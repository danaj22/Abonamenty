namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rent()
        {
            devices_rents = new ObservableCollection<devices_rents>();
        }

        public int rentId { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_rent { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_return { get; set; }

        public double total_price { get; set; }

        public int subscription_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<devices_rents> devices_rents { get; set; }

        public virtual subscription subscription { get; set; }
    }
}
