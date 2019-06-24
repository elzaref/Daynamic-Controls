using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.DataStores
{
    public class MCQContext : DbContext,IMCQContext
    {
        public MCQContext() :
            base(new DbContextOptionsBuilder().UseSqlServer(
                "Data Source=.;initial catalog=MCQDataBase;Integrated Security=True;"
                ).Options)
        {

        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public async Task<int> CommitAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
