using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Model;

namespace TestApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InsuranceMembersController : ControllerBase
	{
		private readonly InsuranceDbContext _context;

		public InsuranceMembersController(InsuranceDbContext context)
		{
			_context = context;
		}

		// GET: api/InsuranceMembers
		[HttpGet]
		public async Task<ActionResult<IEnumerable<InsuranceMember>>> GetInsuranceMembers()
		{
			return await _context.InsuranceMembers.Take(100).ToListAsync();
		}

		// GET: api/InsuranceMembers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<InsuranceMember>> GetInsuranceMember(int id)
		{
			var insuranceMember = await _context.InsuranceMembers.FindAsync(id);

			if (insuranceMember == null)
			{
				return NotFound();
			}

			return insuranceMember;
		}

		// PUT: api/InsuranceMembers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutInsuranceMember(int id, InsuranceMember insuranceMember)
		{
			if (id != insuranceMember.Id)
			{
				return BadRequest();
			}

			_context.Entry(insuranceMember).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!InsuranceMemberExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/InsuranceMembers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<InsuranceMember>> PostInsuranceMember(InsuranceMember insuranceMember)
		{
			_context.InsuranceMembers.Add(insuranceMember);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetInsuranceMember", new { id = insuranceMember.Id }, insuranceMember);
		}

		// DELETE: api/InsuranceMembers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteInsuranceMember(int id)
		{
			var insuranceMember = await _context.InsuranceMembers.FindAsync(id);
			if (insuranceMember == null)
			{
				return NotFound();
			}

			_context.InsuranceMembers.Remove(insuranceMember);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool InsuranceMemberExists(int id)
		{
			return _context.InsuranceMembers.Any(e => e.Id == id);
		}
	}
}