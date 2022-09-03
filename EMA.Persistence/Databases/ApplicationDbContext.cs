namespace EMA.Persistence.Databases;

public class ApplicationDbContext : DbContext
{
    public DbSet<PresentationEntity> Presentations => Set<PresentationEntity>();

    public DbSet<PresentationStateEntity> PresentationStates => Set<PresentationStateEntity>();

    public DbSet<VisitorEntity> Visitors => Set<VisitorEntity>();

    public DbSet<VisitorContactEntity> VisitorContacts => Set<VisitorContactEntity>();

    public DbSet<VisitorCredentialEntity> VisitorCredentials => Set<VisitorCredentialEntity>();

    public DbSet<VisitorGenderEntity> VisitorGenders => Set<VisitorGenderEntity>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PresentationEntity>()
            .HasIndex(indexExpression: presentation => presentation.Id)
            .IsUnique();

        modelBuilder.Entity<PresentationStateEntity>()
            .HasIndex(indexExpression: presentationState => presentationState.Id)
            .IsUnique();

        modelBuilder.Entity<VisitorEntity>()
            .HasIndex(indexExpression: visitor => visitor.Id)
            .IsUnique();

        modelBuilder.Entity<VisitorContactEntity>()
            .HasIndex(indexExpression: visitorContact => visitorContact.Id)
            .IsUnique();

        modelBuilder.Entity<VisitorCredentialEntity>()
           .HasIndex(indexExpression: visitorCredential => visitorCredential.Id)
           .IsUnique();

        modelBuilder.Entity<VisitorGenderEntity>()
           .HasIndex(indexExpression: visitorGender => visitorGender.Id)
           .IsUnique();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);
}