namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            gauges = new ObservableCollection<gauge>();
            offices = new ObservableCollection<office>();
        }

        public int clientId { get; set; }

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        [StringLength(150)]
        public string adress { get; set; }

        [StringLength(70)]
        public string contact_person_name { get; set; }

        [StringLength(400)]
        public string mail { get; set; }

        [StringLength(15)]
        public string tel { get; set; }

        [Required]
        [StringLength(15)]
        public string NIP { get; set; }

        [StringLength(500)]
        public string comments { get; set; }

        public int? subscription_id { get; set; }

        public virtual subscription subscription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<gauge> gauges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<office> offices { get; set; }
    }
}
