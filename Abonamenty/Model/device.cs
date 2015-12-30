namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class device : ViewModel.CheckboxControlViewModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public device()
        {
            devices_rents = new ObservableCollection<devices_rents>();
        }

        public int deviceId { get; set; }

        [StringLength(200)]
        public string manufacturer_name { get; set; }

        [StringLength(200)]
        public string model_name { get; set; }

        [StringLength(200)]
        public string serial_number { get; set; }

        public double? price { get; set; }

        public int? genre_id { get; set; }

        public virtual genre genre { get; set; }


        public bool is_rented { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<devices_rents> devices_rents { get; set; }
    }
}
