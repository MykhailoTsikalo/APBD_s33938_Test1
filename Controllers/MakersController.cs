using Microsoft.AspNetCore.Mvc;
using Test.DTOs;
using Test.Repositories;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MakersController : ControllerBase
    {
        private readonly IMakerRepository _repo;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMakerInfo(int id)
        {
            var maker = await _repo.GetMakerAsync(id);
            if (maker is null)
            {
                return NotFound($"Maker with id {id} was not found.");
            }

            return Ok(maker);
        }


        [HttpPost]
        public async Task<IActionResult> PostManufacturer([FromBody] CreateMakerRequest request)
        { 
            await _repo.CreateMakerAsync(request);
            return Ok();
        }
    }
}
