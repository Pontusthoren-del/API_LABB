using API_LABB.Data;
using API_LABB.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LABB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public UserController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet(Name = "GetAllPeople")]

        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            return Ok(await _ctx.User
                .AsNoTracking()
                .Select(p => new UserDto
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
            var user = await _ctx.User.AnyAsync(p => p.Id == id);

            if (!user)
            {
                return NotFound();
            }

            return Ok(await _ctx.UserInterests
                .AsNoTracking()
                .Where(pi => pi.UserId == id)
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

        public async Task<ActionResult<IEnumerable<LinkDto>>> GetLinkByUser(int id)
        {
            var user = await _ctx.User.AnyAsync(p => p.Id == id);

            if (!user)
            {
                return NotFound();
            }

            return Ok(await _ctx.Links
                .AsNoTracking()
                .Where(l => l.UserId == id)
                .Select(l => new LinkDto
                (
                    l.Id,
                    l.Url,
                    l.Label,
                    l.InterestId,
                    l.UserName.Title,
                    l.User.Name
                ))
                .ToListAsync()
                );
        }

        [HttpPost("{id}/interests")]

        public async Task<ActionResult> AddInterestToUser(int id, AddInterestToUserDto dto)
        {
            var user = await _ctx.User.AnyAsync(p => p.Id == id);
            if (!user)
            {
                return NotFound("Person not found.");
            }
            var interest = await _ctx.Interests.AnyAsync(i => i.Id == dto.InterestId);
            if (!interest)
            {
                return NotFound("Interest not found.");
            }
            var alreadyExist = await _ctx.UserInterests
                .AnyAsync(pi => pi.UserId == id && pi.InterestId == dto.InterestId);
            if (alreadyExist)
            {
                return Conflict("Person already has this interest");
            }
            _ctx.UserInterests.Add(new Models.UserInterest
            {
                UserId = id,
                InterestId = dto.InterestId,
            });
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("{id}/interests/{interestId}/links")]

        public async Task<ActionResult> AddLinkToUser(int id, int interestId, AddLinkDto dto)
        {
            var user = await _ctx.User.AnyAsync(p => p.Id == id);
            if (!user)
            {
                return NotFound("Person not found");
            }
            var hasInterest = await _ctx.UserInterests
                .AnyAsync(pi => pi.UserId == id && pi.InterestId == interestId);
            if (!hasInterest)
            {
                return BadRequest("Person does not have this interest");
            }
            _ctx.Links.Add(new Models.Link
            {
                UserId = id,
                InterestId = interestId,
                Url = dto.Url,
                Label = dto.Label
            });
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
