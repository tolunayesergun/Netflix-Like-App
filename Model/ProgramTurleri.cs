namespace StorkFlix
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProgramTurleri")]
    public partial class ProgramTurleri
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int programId { get; set; }

        public int? turId { get; set; }

        public virtual Programlar Programlar { get; set; }

        public virtual Turler Turler { get; set; }
    }
}