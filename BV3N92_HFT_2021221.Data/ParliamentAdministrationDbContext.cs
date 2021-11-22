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
        public virtual DbSet<PartyMember> PartyMembers { get; set; }
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
                    .HasForeignKey(party => party.ParliamentID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(party => party.PartyMembers)
                .WithOne(partymember => partymember.Party)
                .HasForeignKey(partymembers => partymembers.PartyID);
            });

            Parliament ger = new Parliament() { ParliamentID = 1, ParliamentName = "Reichstag", RulingParty = "Conservative Party" };
            Parliament eng = new Parliament() { ParliamentID = 2, ParliamentName = "House of Commons", RulingParty = "Socialist Party" };
            Parliament hun = new Parliament() { ParliamentID = 3, ParliamentName = "Országház", RulingParty = "Nationalist Party" };

            Party left = new Party() { PartyID = 1, ParliamentID = eng.ParliamentID, PartyName = "Socialist Party", Ideology = Ideologies.Socialist };
            Party center = new Party() { PartyID = 2, ParliamentID = ger.ParliamentID, PartyName = "Conservative Party", Ideology = Ideologies.Conservative };
            Party right = new Party() { PartyID = 3, ParliamentID = hun.ParliamentID, PartyName = "Nationalist Party", Ideology = Ideologies.Nationalist };

            Random r = new Random();
            var members = new List<PartyMember>()
            {
                //left
                new PartyMember() { MemberID = 1, LastName = "Stewart", Age = 51, PartyID = left.PartyID },
                new PartyMember() { MemberID = 2, LastName = "Myers", Age = 39, PartyID = left.PartyID },
                new PartyMember() { MemberID = 3, LastName = "Norman", Age = 67, PartyID = left.PartyID },
                new PartyMember() { MemberID = 4, LastName = "Stephenson", Age = 23, PartyID = left.PartyID },
                new PartyMember() { MemberID = 5, LastName = "Horton", Age = 45, PartyID = left.PartyID },
                //center
                new PartyMember() { MemberID = 6, LastName = "Weber", Age = r.Next(18,70), PartyID = center.PartyID },
                new PartyMember() { MemberID = 7, LastName = "von Hohenzoller", Age = r.Next(18,70), PartyID = center.PartyID },
                new PartyMember() { MemberID = 8, LastName = "von Tirpitz", Age = r.Next(18,70), PartyID = center.PartyID },
                new PartyMember() { MemberID = 9, LastName = "Schacht", Age = r.Next(18,70), PartyID = center.PartyID },
                new PartyMember() { MemberID = 10, LastName = "von Reuter", Age = r.Next(18,70), PartyID = center.PartyID },
                //right
                new PartyMember() { MemberID = 11, LastName = "Vörös", Age = r.Next(18,70), PartyID = right.PartyID },
                new PartyMember() { MemberID = 12, LastName = "Tóth", Age = r.Next(18,70), PartyID = right.PartyID },
                new PartyMember() { MemberID = 13, LastName = "Hajdú", Age = r.Next(18,70), PartyID = right.PartyID },
                new PartyMember() { MemberID = 14, LastName = "Kocsis", Age = r.Next(18,70), PartyID = right.PartyID },
                new PartyMember() { MemberID = 15, LastName = "Biró", Age = r.Next(18,70), PartyID = right.PartyID }
            };

            modelBuilder.Entity<Parliament>().HasData(ger, eng, hun);
            modelBuilder.Entity<Party>().HasData(left, center, right);
            modelBuilder.Entity<PartyMember>().HasData(members);
        }
    }
}
