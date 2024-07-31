using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infraestructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options) 
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

}
