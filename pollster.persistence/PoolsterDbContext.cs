using Microsoft.EntityFrameworkCore;
using pollster.domain.Entities;
using pollster.persistence.Extensions;

namespace pollster.persistence
{
    public class PoolsterDbContext : DbContext
    {
        public PoolsterDbContext(DbContextOptions<PoolsterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<PossibleAnswer> PossibleAnswers { get; set; }
        public DbSet<AnswerSet> AnswerSets { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}