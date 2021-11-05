using BV3N92_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

            Parliament ger = new Parliament() { ParliamentName = "Reichstag", Ruling_Party = "fp" };
            Parliament eng = new Parliament() { ParliamentName = "House of Commons", Ruling_Party = "dp" };
            Parliament hun = new Parliament() { ParliamentName = "Országház", Ruling_Party = "cp" };

            Party left = new Party() { ParliamentName = eng.ParliamentName, PartyName = "Socialist Party", Ideology = Ideologies.Socialist };
            Party center = new Party() { ParliamentName = ger.ParliamentName, PartyName = "Conservative Party", Ideology = Ideologies.Conservative };
            Party right = new Party() { ParliamentName = hun.ParliamentName, PartyName = "Nationalist Party", Ideology = Ideologies.Nationalist };

            Random r = new Random();
            var members = new List<Party_Member>()
            {
                //left
                new Party_Member() { MemberID = 1, Last_Name = "Stewart", Age = r.Next(18,70), Party = left, PartyName = left.PartyName },
                new Party_Member() { MemberID = 2, Last_Name = "Myers", Age = r.Next(18,70), Party = left, PartyName = left.PartyName },
                new Party_Member() { MemberID = 3, Last_Name = "Norman", Age = r.Next(18,70), Party = left, PartyName = left.PartyName },
                new Party_Member() { MemberID = 4, Last_Name = "Stephenson", Age = r.Next(18,70), Party = left, PartyName = left.PartyName },
                new Party_Member() { MemberID = 5, Last_Name = "Horton", Age = r.Next(18,70), Party = left, PartyName = left.PartyName },
                //center
                new Party_Member() { MemberID = 6, Last_Name = "Weber", Age = r.Next(18,70), Party = center, PartyName = center.PartyName },
                new Party_Member() { MemberID = 7, Last_Name = "von Hohenzoller", Age = r.Next(18,70), Party = center, PartyName = center.PartyName },
                new Party_Member() { MemberID = 8, Last_Name = "von Tirpitz", Age = r.Next(18,70), Party = center, PartyName = center.PartyName },
                new Party_Member() { MemberID = 9, Last_Name = "Schacht", Age = r.Next(18,70), Party = center, PartyName = center.PartyName },
                new Party_Member() { MemberID = 10, Last_Name = "von Reuter", Age = r.Next(18,70), Party = center, PartyName = center.PartyName },
                //right
                new Party_Member() { MemberID = 11, Last_Name = "Vörös", Age = r.Next(18,70), Party = right, PartyName = right.PartyName },
                new Party_Member() { MemberID = 12, Last_Name = "Tóth", Age = r.Next(18,70), Party = right, PartyName = right.PartyName },
                new Party_Member() { MemberID = 13, Last_Name = "Hajdú", Age = r.Next(18,70), Party = right, PartyName = right.PartyName },
                new Party_Member() { MemberID = 14, Last_Name = "Kocsis", Age = r.Next(18,70), Party = right, PartyName = right.PartyName },
                new Party_Member() { MemberID = 15, Last_Name = "Biró", Age = r.Next(18,70), Party = right, PartyName = right.PartyName }
            };

            modelBuilder.Entity<Parliament>().HasData(ger, eng, hun);
            modelBuilder.Entity<Party>().HasData(left, center, right);
            modelBuilder.Entity<Party_Member>().HasData(members);
        }
    }
}
