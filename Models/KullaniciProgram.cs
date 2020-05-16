namespace StorkFlix
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KullaniciProgram")]
    public partial class KullaniciProgram
    {
        public int id { get; set; }

        public int kullaniciId { get; set; }

        public int programId { get; set; }

        public DateTime? izlemeTarihi { get; set; }

        public int? izlemeSuresi { get; set; }

        public int? kaldigiBolum { get; set; }

        public int? puan { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Programlar Programlar { get; set; }
    }
}