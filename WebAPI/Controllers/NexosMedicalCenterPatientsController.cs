using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NexosMedicalCenterPatientsController : ControllerBase
    {
        private readonly NexosMedicalCenterContext _context;

        public NexosMedicalCenterPatientsController(NexosMedicalCenterContext context)
        {
            _context = context;
        }

        // GET: api/NexosMedicalCenterPatients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NexosMedicalCenterPatient>>> GetPatients()
        {
            return await _context.Patients.Include(i => i.PatientDoctors).ToListAsync();
        }

        // GET: api/NexosMedicalCenterPatients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NexosMedicalCenterPatient>> GetNexosMedicalCenterPatient(int id)
        {
            var nexosMedicalCenterPatient = await _context.Patients.Include(i => i.PatientDoctors).FirstOrDefaultAsync(i => i.PatientId == id);

            if (nexosMedicalCenterPatient == null)
            {
                return NotFound();
            }

            return nexosMedicalCenterPatient;
        }

        // PUT: api/NexosMedicalCenterPatients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNexosMedicalCenterPatient(int id, NexosMedicalCenterPatient nexosMedicalCenterPatient)
        {
            if (id != nexosMedicalCenterPatient.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(nexosMedicalCenterPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NexosMedicalCenterPatientExists(id))
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

        // POST: api/NexosMedicalCenterPatients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NexosMedicalCenterPatient>> PostNexosMedicalCenterPatient(NexosMedicalCenterPatient nexosMedicalCenterPatient)
        {
            nexosMedicalCenterPatient.PatientDoctors = null;
            _context.Patients.Add(nexosMedicalCenterPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNexosMedicalCenterPatient", new { id = nexosMedicalCenterPatient.PatientId }, nexosMedicalCenterPatient);
        }

        // DELETE: api/NexosMedicalCenterPatients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNexosMedicalCenterPatient(int id)
        {
            var nexosMedicalCenterPatient = await _context.Patients.FindAsync(id);
            if (nexosMedicalCenterPatient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(nexosMedicalCenterPatient);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/NexosMedicalCenterPatients/5
        [HttpDelete("DeleteRelationships/{id}")]
        public async Task<IActionResult> DeleteNexosMedicalCenterPatientRelationships(int id)
        {
            var nexosMedicalCenterPatient = await _context.Patients.Include(i => i.PatientDoctors).FirstOrDefaultAsync(i => i.PatientId == id);
            if (nexosMedicalCenterPatient == null)
            {
                return NotFound();
            }

            if (nexosMedicalCenterPatient.PatientDoctors == null)
            {
                return NotFound();
            }

            nexosMedicalCenterPatient.PatientDoctors.Clear();
            _context.SaveChanges();

            return Ok();
        }

        private bool NexosMedicalCenterPatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}
