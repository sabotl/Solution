using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Entity;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly Solution.Application.UseCase.PlaceUseCase _useCase;

        public PlaceController(Application.UseCase.PlaceUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Domain.Entity.Place>> Index()
        {
            return await _useCase.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Place?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _useCase.GetByIDAsync(id);
            }catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _useCase.DeleteAsync(id);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("post")]
        public async Task<IActionResult> CreateAsync(Solution.Domain.Entity.Place Place)
        {
            try
            {
                await _useCase.CreateAsync(Place);
                return Ok("Place is created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("put")]
        public async Task<IActionResult> UpdateAsync(Solution.Domain.Entity.Place Place)
        {
            try
            {
                await _useCase.UpdateAsync(Place);
                return Ok("Place is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
