using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NexosMedicalCenterDoctorsController : ControllerBase
    {
        private readonly NexosMedicalCenterContext _context;

        public NexosMedicalCenterDoctorsController(NexosMedicalCenterContext context)
        {
            _context = context;
        }

        // GET: api/NexosMedicalCenterDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NexosMedicalCenterDoctor>>> GetDoctors()
        {
            return await _context.Doctors.Include(i => i.DoctorPatients).ToListAsync();
        }

        // GET: api/NexosMedicalCenterDoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NexosMedicalCenterDoctor>> GetNexosMedicalCenterDoctor(int id)
        {
            var nexosMedicalCenterDoctor = await _context.Doctors.Include(i => i.DoctorPatients).FirstOrDefaultAsync(i => i.DoctorId == id);

            if (nexosMedicalCenterDoctor == null)
            {
                return NotFound();
            }

            return nexosMedicalCenterDoctor;
        }

        // PUT: api/NexosMedicalCenterDoctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNexosMedicalCenterDoctor(int id, NexosMedicalCenterDoctor nexosMedicalCenterDoctor)
        {
            if (id != nexosMedicalCenterDoctor.DoctorId)
            {
                return BadRequest();
            }

            _context.Entry(nexosMedicalCenterDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NexosMedicalCenterDoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/NexosMedicalCenterDoctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NexosMedicalCenterDoctor>> PostNexosMedicalCenterDoctor(NexosMedicalCenterDoctor nexosMedicalCenterDoctor)
        {
            nexosMedicalCenterDoctor.DoctorPatients = null;
            _context.Doctors.Add(nexosMedicalCenterDoctor);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNexosMedicalCenterDoctor", new { id = nexosMedicalCenterDoctor.DoctorId }, nexosMedicalCenterDoctor);
        }

        // DELETE: api/NexosMedicalCenterDoctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNexosMedicalCenterDoctor(int id)
        {
            var nexosMedicalCenterDoctor = await _context.Doctors.FindAsync(id);
            if (nexosMedicalCenterDoctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(nexosMedicalCenterDoctor);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/NexosMedicalCenterDoctors/DeleteRelationships/5
        [HttpDelete("DeleteRelationships/{id}")]
        public async Task<IActionResult> DeleteNexosMedicalCenterDoctorRelationships(int id)
        {
            var nexosMedicalCenterDoctor = await _context.Doctors.Include(i => i.DoctorPatients).FirstOrDefaultAsync(i => i.DoctorId == id);
            if (nexosMedicalCenterDoctor == null)
            {
                return NotFound();
            }
            
            if (nexosMedicalCenterDoctor.DoctorPatients == null)
            {
                return NotFound();
            }

            nexosMedicalCenterDoctor.DoctorPatients.Clear();
            _context.SaveChanges();

            return Ok();
        }

        private bool NexosMedicalCenterDoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
