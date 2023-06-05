using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Models;
using MinhasFinancas.Settings.DbSettings;

namespace MinhasFinancas;

public class AppDbContext : IdentityDbContext<User>
{
    private IConfiguration _configuration { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<MoneyInflow> MoneyInflows { get; set; }
    public DbSet<MoneyOutflow> MoneyOutflows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var mySqlSettings = _configuration.GetSection(MySqlSettings.SESSION_NAME).Get<MySqlSettings>();

        optionsBuilder
        .UseLazyLoadingProxies()
        .UseMySql(
            mySqlSettings.ConnectionString,
            ServerVersion.AutoDetect(mySqlSettings.ConnectionString)
        );

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        

        // We used the HasConversion method to store the "enum" string in database.
        modelBuilder.Entity<MoneyOutflow>()
            .Property(mo => mo.PaymentMethod)
            .HasConversion(
                pm => pm.Value,
                v => new MoneyOutflow.PaymentMethods { Value = v })
            .HasColumnName("PaymentMethod");

        modelBuilder.Entity<MoneyOutflow>()
            .Property(mo => mo.PaymentCategory)
            .HasConversion(
                pc => pc.Value,
                v => new MoneyOutflow.PaymentCategories { Value = v })
            .HasColumnName("PaymentCategory");

        modelBuilder.Entity<User>()
        .HasMany(u => u.MoneyOutflows)
        .WithOne(mo => mo.User)
        .HasForeignKey(mo => mo.UserId)
        .IsRequired();

        modelBuilder.Entity<User>()
        .HasMany(u => u.MoneyInflows)
        .WithOne(mi => mi.User)
        .HasForeignKey(mi => mi.UserId)
        .IsRequired();


        base.OnModelCreating(modelBuilder);
    }
}
