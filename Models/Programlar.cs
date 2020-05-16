namespace StorkFlix
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Programlar")]
    public partial class Programlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Programlar()
        {
            KullaniciProgram = new HashSet<KullaniciProgram>();
            ProgramTurleri = new HashSet<ProgramTurleri>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string isim { get; set; }

        [StringLength(50)]
        public string tip { get; set; }

        public int? bolum { get; set; }

        public int? uzunluk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciProgram> KullaniciProgram { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgramTurleri> ProgramTurleri { get; set; }
    }
}