using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Enum;
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

    public DbSet<FixedExpense> FixedExpenses {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Instead UserSecrets, it's gonna be using env var.
        // var mySqlSettings = _configuration.GetSection(MySqlSettings.SESSION_NAME).Get<MySqlSettings>();
        
        // TODO: There is a better way to load the env vars?
        var dbName = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
        var dbUser = Environment.GetEnvironmentVariable("MYSQL_USER");
        var dbPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        var dbPort = Environment.GetEnvironmentVariable("MYSQL_TCP_PORT");
        var dbServer = Environment.GetEnvironmentVariable("MYSQL_SERVER_NAME");
        Console.WriteLine(Environment.GetEnvironmentVariable("ASPNETCORE_URLS"));
        var connectionString = $"Server={dbServer};Port={dbPort};Database={dbName};User={dbUser};Password={dbPassword};";       

        optionsBuilder
        .UseLazyLoadingProxies()
        .UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
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
                v => new PaymentCategories { Value = v })
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

        modelBuilder.Entity<FixedExpense>()
        .Property(fixedExpense => fixedExpense.PaymentCategory)
        .HasConversion(
            category => category.Value,
            value => new PaymentCategories {Value = value}
        )
        .HasColumnName("PaymentCategory");


        base.OnModelCreating(modelBuilder);
    }
}
