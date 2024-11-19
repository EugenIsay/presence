using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data;

public class RemoteDatabaseContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=45.67.56.214;Port=5454;Password=hGcLvi0i;Username=user2;Database=user2");
    }

    public DbSet<GroupDAO> groups { get; set; }
    public DbSet<UserDAO> users { get; set; }
    public DbSet<SubjectDAO> subjects { get; set; }
    public DbSet<GroupSubjectDAO> groupsSubjects { get; set; }
    public DbSet<SubjectDayDAO> subjectdays { get; set; }
    public DbSet<StatusDAO> statuses { get; set; }
    public DbSet<PresenceDAO> presences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDAO>().HasKey(it => it.Guid);
        modelBuilder.Entity<GroupDAO>().HasKey(it => it.GroupId); 
        modelBuilder.Entity<SubjectDAO>().HasKey(it => it.SubjectId);
        modelBuilder.Entity<SubjectDayDAO>().HasKey(it => it.Id);
        modelBuilder.Entity<StatusDAO>().HasKey(it => it.Id); 
        modelBuilder.Entity<PresenceDAO>().HasKey(it => new { it.UserGuid, it.SubjectDayId });
        modelBuilder.Entity<GroupSubjectDAO>().HasKey(it => new { it.GroupId, it.SubjectId });

        modelBuilder.Entity<UserDAO>().Property(it => it.Guid).ValueGeneratedOnAdd();
        modelBuilder.Entity<GroupDAO>().Property(it => it.GroupId).ValueGeneratedOnAdd();
        modelBuilder.Entity<SubjectDAO>().Property(it => it.SubjectId).ValueGeneratedOnAdd();
        modelBuilder.Entity<SubjectDayDAO>().Property(it => it.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<StatusDAO>().Property(it => it.Id).ValueGeneratedOnAdd();
    }
}