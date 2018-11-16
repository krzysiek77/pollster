using Microsoft.EntityFrameworkCore;
using pollster.persistence.Infrastructure;

namespace pollster.persistence
{
    public class PoolsterDbContextFactory : DesignTimeDbContextFactoryBase<PoolsterDbContext>
    {
        protected override PoolsterDbContext CreateNewInstance(DbContextOptions<PoolsterDbContext> options) 
        {
            return new PoolsterDbContext(options);
        }
    }
}