using crud_assignment.DBContext;
using crud_assignment.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly TrainerTraineeDBSet _context;
        public TraineeController(TrainerTraineeDBSet context)
        {
            _context = context;
        }
        [HttpGet("GetAllTranees")]
        public async Task<ActionResult<IEnumerable<Trainee>>> Get()
        {
            var trainee = await _context.Trainee.ToListAsync();
            if (trainee == null)
            {
                return NotFound("There is no trainee registered before");
            }
            return trainee;
        }
        [HttpGet("GetTraineeByID/{id}")]
        public async Task<ActionResult<Trainee>> GetTrainee(int id)
        {
            var result = await _context.Trainee.FindAsync(id);
            if (result == null)
            {
                return NotFound("No result found");
            }
           
            return result;
        }
        [HttpPost("AddTrainee")]
        public async Task<ActionResult<Trainee>> Post([FromBody] Trainee trainees)
        {
           var  trainee = new Trainee()
             {
                Name = trainees.Name,
                PhoneNumber = trainees.PhoneNumber,
                Department = trainees.Department
            };
            _context.Trainee.Add(trainee);
            await _context.SaveChangesAsync();
            return trainee;
        }
        [HttpDelete("DeleteTraineeWithID/{id}")]
        public async Task <ActionResult> DeleteTrainee(int id)
        {
            var result = await _context.Trainee.FindAsync(id);
            if (result == null)
            {
                return NotFound($"There is no trainee with id {id}");
            }
            _context.Trainee.Remove(result);
            await _context.SaveChangesAsync();
            return NoContent();


        }
        [HttpPut("UpdateTraineeWithId/{id}")]
        public async Task<ActionResult<Trainee>> Put(int id, [FromBody] Trainee trainees)
        {
            var trainee = await _context.Trainee.FindAsync(id);
            if (trainee == null)
            {
                return NotFound($"There is no trainee with id {id}");
            }
            trainee.Name = trainees.Name;
            trainee.PhoneNumber = trainees.PhoneNumber;
            trainee.Department = trainees.Department;
            _context.Trainee.Update(trainee);
            await _context.SaveChangesAsync();
            return trainees;



        }
    }
}
