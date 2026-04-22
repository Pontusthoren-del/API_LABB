using API_LABB.Data;
using API_LABB.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LABB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public PersonsController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet(Name = "GetAllPeople")]

        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll()
        {
            return Ok(await _ctx.Persons
                .AsNoTracking()
                .Select(p => new PersonDto
                (
                  p.Id,
                  p.Name,
                  p.Phone
                )
                ).ToListAsync());
        }

        [HttpGet("{id}/interest")]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetInterestByPerson(int id)
        {
            var person = await _ctx.Persons.AnyAsync(p => p.Id == id);

            if (!person)
            {
                return NotFound();
            }

            return Ok(await _ctx.PersonInterests
                .AsNoTracking()
                .Where(pi => pi.PersonId == id)
                .Select(pi => new InterestDto
                (
                    pi.Interest.Id,
                    pi.Interest.Title,
                    pi.Interest.Description
                )
                )
                .ToListAsync());
        }

        [HttpGet("{id}/links")]

        public async Task<ActionResult<IEnumerable<LinkDto>>> GetLinkByPerson(int id)
        {
            var person = await _ctx.Persons.AnyAsync(p => p.Id == id);

            if (!person)
            {
                return NotFound();
            }

            return Ok(await _ctx.Links
                .AsNoTracking()
                .Where(l => l.PersonId == id)
                .Select(l => new LinkDto
                (
                    l.Id,
                    l.Url,
                    l.Label,
                    l.InterestId,
                    l.PersonName.Title,
                    l.Person.Name
                ))
                .ToListAsync()
                );
        }

        [HttpPost("{id}/interests")]

        public async Task<ActionResult> AddInterestToPerson(int id, AddInterestToPersonDto dto)
        {
            var person = await _ctx.Persons.AnyAsync(p => p.Id == id);
            if (!person)
            {
                return NotFound("Person not found.");
            }
            var interest = await _ctx.Interests.AnyAsync(i => i.Id == dto.InterestId);
            if (!interest)
            {
                return NotFound("Interest not found.");
            }
            var alreadyExist = await _ctx.PersonInterests
                .AnyAsync(pi => pi.PersonId == id && pi.InterestId == dto.InterestId);
            if (alreadyExist)
            {
                return Conflict("Person already has this interest");
            }
            _ctx.PersonInterests.Add(new Models.PersonInterest
            {
                PersonId = id,
                InterestId = dto.InterestId,
            });
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("{id}/interests/{interestId}/links")]

        public async Task<ActionResult> AddLinkToPerson(int id, int interestId, AddLinkDto dto)
        {
            var person = await _ctx.Persons.AnyAsync(p => p.Id == id);
            if (!person)
            {
                return NotFound("Person not found");
            }
            var hasInterest = await _ctx.PersonInterests
                .AnyAsync(pi => pi.PersonId == id && pi.InterestId == interestId);
            if (!hasInterest)
            {
                return BadRequest("Person does not have this interest");
            }
            _ctx.Links.Add(new Models.Link
            {
                PersonId = id,
                InterestId = interestId,
                Url = dto.Url,
                Label = dto.Label
            });
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
