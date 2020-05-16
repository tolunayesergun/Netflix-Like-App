namespace StorkFlix
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Turler")]
    public partial class Turler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turler()
        {
            ProgramTurleri = new HashSet<ProgramTurleri>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string isim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgramTurleri> ProgramTurleri { get; set; }
    }
}