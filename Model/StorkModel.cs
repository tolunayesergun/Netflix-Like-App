namespace StorkFlix
{
    using System.Data.Entity;

    public partial class StorkModel : DbContext
    {
        public StorkModel()
            : base("name=StorkModel")
        {
        }

        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KullaniciProgram> KullaniciProgram { get; set; }
        public virtual DbSet<Programlar> Programlar { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Turler> Turler { get; set; }
        public virtual DbSet<ProgramTurleri> ProgramTurleri { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .Property(e => e.isim)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Programlar>()
                .Property(e => e.isim)
                .IsUnicode(false);

            modelBuilder.Entity<Programlar>()
                .HasMany(e => e.KullaniciProgram)
                .WithRequired(e => e.Programlar)
                .HasForeignKey(e => e.programId);

            modelBuilder.Entity<Programlar>()
                .HasMany(e => e.ProgramTurleri)
                .WithRequired(e => e.Programlar)
                .HasForeignKey(e => e.programId);

            modelBuilder.Entity<Turler>()
                .Property(e => e.isim)
                .IsUnicode(false);

            modelBuilder.Entity<Turler>()
                .HasMany(e => e.ProgramTurleri)
                .WithOptional(e => e.Turler)
                .HasForeignKey(e => e.turId)
                .WillCascadeOnDelete();
        }
    }
}