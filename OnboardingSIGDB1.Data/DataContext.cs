using Microsoft.EntityFrameworkCore;

namespace OnboardingSIGDB1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }
}
