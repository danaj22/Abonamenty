namespace Abonamenty.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class office
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public office()
        {
            gauges = new ObservableCollection<gauge>();
        }

        public int officeId { get; set; }

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        [StringLength(250)]
        public string adress { get; set; }

        [StringLength(300)]
        public string contact_person_name { get; set; }

        [StringLength(300)]
        public string mail { get; set; }

        [StringLength(15)]
        public string tel { get; set; }

        [StringLength(10)]
        public string is_default { get; set; }

        public int client_id { get; set; }

        public virtual client client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<gauge> gauges { get; set; }
    }
}
