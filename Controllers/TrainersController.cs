using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud_assignment.DBContext;
using crud_assignment.model;

namespace crud_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly TrainerTraineeDBSet _context;

        public TrainersController(TrainerTraineeDBSet context)
        {
            _context = context;
        }

        // GET: api/Trainers
        [HttpGet("GetAllTrainers")]
        public async Task<ActionResult<IEnumerable<Trainer>>> Get()
        {
            var result = await _context.Trainer.ToListAsync();

            return result;
        }

        // GET: api/Trainers/5
        [HttpGet("GetTrainerWithID/{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var result = await _context.Trainer.FindAsync(id);
            /**/
            if (result == null)
            {
                return NotFound($"Trainer with id {id} not found!");
            }
            return result;
        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateTrainersWithId/{id}")]
       public async Task<ActionResult<Trainer>> Put(int id, [FromBody] Trainer trainers)
        {
            var trainer = await _context.Trainer.FindAsync(id);
            if(trainer == null){
                return NotFound($"There is no trainer with id {id}");
            }
            trainer.Name = trainers.Name;
            trainer.PhoneNumber = trainers.PhoneNumber;
            trainer.Role = trainers.Role;
            _context.Trainer.Update(trainer);
            await _context.SaveChangesAsync();

            return trainer;

        }

        // POST: api/Trainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddTrainer")]
        public async Task<ActionResult<Trainer>> Post([FromBody] Trainer trainers)
        {
            var trainer = new Trainer()
            {
                Name=trainers.Name,
                PhoneNumber = trainers.PhoneNumber,
                Role = trainers.Role
            };
            _context.Trainer.Add(trainer);
            await _context.SaveChangesAsync();
            return trainer;
        }

        // DELETE: api/Trainers/5
        [HttpDelete("DeleteTrainerWithId/{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainer.FindAsync(id);
            if (trainer == null)
            {
                return NotFound($"There is no trainer with id {id}  ");
            }

            _context.Trainer.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainerExists(int id)
        {
            return _context.Trainer.Any(e => e.Id == id);
        }
    }
}
