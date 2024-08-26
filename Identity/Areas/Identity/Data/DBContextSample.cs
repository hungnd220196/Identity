
using Identity.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Areas.Identity.Data;

public class DBContextSample : IdentityDbContext<SampleUser>,DbContext<Student>
{
    public DBContextSample(DbContextOptions<DBContextSample> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<SampleUser>
{
    public void Configure(EntityTypeBuilder<SampleUser> builder)
    {
        builder.Property(x => x.firtName).HasMaxLength(100);
        builder.Property(x => x.lastName).HasMaxLength(100);
    }
}