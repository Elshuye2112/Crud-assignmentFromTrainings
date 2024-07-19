

using crud_assignment.model;
using Microsoft.EntityFrameworkCore;
namespace crud_assignment.DBContext
{
    public class TrainerTraineeDBSet :DbContext
    {
        public TrainerTraineeDBSet(DbContextOptions<TrainerTraineeDBSet> options) : base(options) { }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
    }

}
