using Microsoft.EntityFrameworkCore;

namespace Momentum.Models
{
    public class MomentumContext : DbContext
    {
        public MomentumContext(DbContextOptions<MomentumContext> options)
            : base(options)
        {
        }

        public DbSet<Goal> Goals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>().HasData(
                new Goal
                {
                    GoalId = 1,
                    Title = "Save $1,000",
                    Description = "Build a starter emergency fund.",
                    Category = "Money",
                    TargetDate = new DateTime(2027, 1, 1)
                },
                new Goal
                {
                    GoalId = 2,
                    Title = "Exercise Consistently",
                    Description = "Build a regular weekly exercise routine.",
                    Category = "Health",
                    TargetDate = new DateTime(2027, 3, 1)
                },
                new Goal
                {
                    GoalId = 3,
                    Title = "Learn a New Skill",
                    Description = "Practice a new skill through small, manageable steps.",
                    Category = "Learning",
                    TargetDate = new DateTime(2027, 6, 1)
                }
            );
        }
    }
}