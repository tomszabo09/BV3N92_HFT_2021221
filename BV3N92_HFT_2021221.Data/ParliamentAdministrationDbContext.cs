using BV3N92_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace BV3N92_HFT_2021221.Data
{
    public class ParliamentAdministrationDbContext : DbContext
    {
        public virtual DbSet<Parliament> Parliament { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<Party_Member> PartyMembers { get; set; }
        public ParliamentAdministrationDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>(entity =>
            {
                entity.HasOne(party => party.Parliament)
                    .WithMany(parliament => parliament.Parties)
                    .HasForeignKey(party => party.ParliamentName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(party => party.PartyMembers)
                .WithOne(partymember => partymember.Party)
                .HasForeignKey(partymembers => partymembers.PartyName);
            });

            Parliament p1 = new Parliament() { ParliamentName = "p1", Ruling_Party = "fp" };
            Parliament p2 = new Parliament() { ParliamentName = "p2", Ruling_Party = "dp" };
            Parliament p3 = new Parliament() { ParliamentName = "p3", Ruling_Party = "cp" };

            Party pt1 = new Party() { ParliamentName = "p2", PartyName = "dp", Ideology = "d" };
            Party pt2 = new Party() { ParliamentName = "p3", PartyName = "cp", Ideology = "c" };
            Party pt3 = new Party() { ParliamentName = "p1", PartyName = "fp", Ideology = "f" };
            Party pt4 = new Party() { ParliamentName = "p2", PartyName = "dpd", Ideology = "d" };

            Party_Member pm1 = new Party_Member() { MemberID = 1, Age = 46, Last_Name = "Gyurcsány", PartyName="fp" };
            Party_Member pm2 = new Party_Member() { MemberID = 2, Age = 26, Last_Name = "Orbán", PartyName = "dp" };
            Party_Member pm3 = new Party_Member() { MemberID = 3, Age = 66, Last_Name = "Dobrev", PartyName = "cp" };
            Party_Member pm4 = new Party_Member() { MemberID = 4, Age = 56, Last_Name = "MZP", PartyName = "dpd" };
            Party_Member pm5 = new Party_Member() { MemberID = 5, Age = 39, Last_Name = "Toroczkai", PartyName = "fp" };

            modelBuilder.Entity<Parliament>().HasData(p1, p2, p3);
            modelBuilder.Entity<Party>().HasData(pt1, pt2, pt3, pt4);
            modelBuilder.Entity<Party_Member>().HasData(pm1, pm2, pm3, pm4, pm5);
            
        }
    }
}
