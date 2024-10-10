using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Common
{
    public class AppDbContext : DbContext
    {
        // tables
        public virtual DbSet<SuperAdmin> SuperAdmins { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Participante> Participantes { get; set; } = null!;
        public virtual DbSet<Entity> Entities { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventType> EventTypes { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Participante_Event> Participante_Events { get; set; } = null!;
        public virtual DbSet<EventType_Event> EventType_Events { get; set; } = null!;
        public virtual DbSet<WhitelistDomain> WhitelistDomains { get; set; } = null!;
        public virtual DbSet<WhitelistEmail> WhitelistEmails { get; set; } = null!;
        public virtual DbSet<Poap> Poaps { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Participante_Event
            modelBuilder.Entity<Participante_Event>().HasKey(c => new { c.EventId, c.ParticipanteId });
            modelBuilder.Entity<Participante_Event>().HasOne(b => b.Participante).WithMany(bc => bc.Participante_Events)
                .HasForeignKey(bi => bi.ParticipanteId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Participante_Event>().HasOne(b => b.Event).WithMany(bc => bc.Participante_Events)
                .HasForeignKey(bi => bi.EventId).OnDelete(DeleteBehavior.NoAction);

            // EventType_Event
            modelBuilder.Entity<EventType_Event>().HasKey(c => new { c.EventTypeId, c.EventId });
            modelBuilder.Entity<EventType_Event>().HasOne(b => b.EventType).WithMany(bc => bc.EventType_Events)
                .HasForeignKey(bi => bi.EventTypeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EventType_Event>().HasOne(b => b.Event).WithMany(bc => bc.EventType_Events)
                .HasForeignKey(bi => bi.EventId).OnDelete(DeleteBehavior.NoAction);

            //Event
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            /*
            // Event
            modelBuilder.Entity<Event>().HasKey(c => c.Id);
            modelBuilder.Entity<Event>().HasOne(c => c.Entity).WithMany(bc => bc.Events)
                .HasForeignKey(bi => bi.EntityId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>().HasOne(c => c.Admin).WithMany(bc => bc.Events)
                .HasForeignKey(bi => bi.AdminId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>().HasOne(c => c.Manager).WithMany(bc => bc.Events)
                .HasForeignKey(bi => bi.ManagerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>().HasIndex(c => new { c.EntityId, c.AdminId, c.ManagerId});
            // Image
            modelBuilder.Entity<Image>().HasKey(c => c.Id);
            modelBuilder.Entity<Image>().HasOne(c => c.Event).WithMany(bc => bc.Images)
                .HasForeignKey(bi => bi.EventId).OnDelete(DeleteBehavior.NoAction);

            // Admin
            modelBuilder.Entity<Admin>().HasKey(a => a.Id);
            modelBuilder.Entity<Admin>().HasOne(c => c.Entity).WithMany(bc => bc.Admins)
                .HasForeignKey(bi => bi.EntityId).OnDelete(DeleteBehavior.NoAction);

            // Manager
            modelBuilder.Entity<Manager>().HasKey(a => a.Id);
            modelBuilder.Entity<Manager>().HasOne(c => c.Group).WithMany(bc => bc.Managers)
                .HasForeignKey(bi => bi.GroupId).OnDelete(DeleteBehavior.NoAction);

            // Group
            modelBuilder.Entity<Group>().HasKey(a => a.Id);
            modelBuilder.Entity<Group>().HasOne(c => c.Entity).WithMany(bc => bc.Groups)
                .HasForeignKey(bi => bi.EntityId).OnDelete(DeleteBehavior.NoAction);

            // Participante
            modelBuilder.Entity<Participante>().HasKey(a => a.Id);
            modelBuilder.Entity<Participante>().HasOne(c => c.Entity).WithMany(bc => bc.Participantes)
                .HasForeignKey(bi => bi.EntityId).OnDelete(DeleteBehavior.NoAction);

            // Entity
            modelBuilder.Entity<Entity>().HasKey(a => a.Id);

            // EventType
            modelBuilder.Entity<EventType>().HasKey(a => a.Id);*/
        }
    }
}
