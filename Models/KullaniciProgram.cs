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

        public int? bolum { get; set; }
        
        [DecimalPrecision(2, 2)]
        public decimal? puan { get; set; }

        public int tamamlandi { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Programlar Programlar { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalPrecisionAttribute : Attribute
    {
        public DecimalPrecisionAttribute(byte precision, byte scale)
        {
            Precision = precision;
            Scale = scale;

        }

        public byte Precision { get; set; }
        public byte Scale { get; set; }

    }
}