namespace HaveYouSeenMe.Models.Business
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetPhoto> PetPhotoes { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.From)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Message1)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.PetName)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.LastSeenWhere)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .HasMany(e => e.PetPhotoes)
                .WithRequired(e => e.Pet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PetPhoto>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<PetPhoto>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<PetType>()
                .Property(e => e.PetTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.Key)
                .IsUnicode(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Pets)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserProfile>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserProfile>()
                .HasMany(e => e.Pets)
                .WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(false);
        }
    }
}
