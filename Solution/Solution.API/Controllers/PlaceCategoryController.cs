using Microsoft.AspNetCore.Mvc;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceCategoryController : ControllerBase
    {
        private readonly Solution.Application.UseCase.PlaceCategoryUseCase _useCase;

        public PlaceCategoryController(Application.UseCase.PlaceCategoryUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpGet]
        public async Task<IReadOnlyList<Domain.Entity.PlaceCategory>> Index()
        {
            return await _useCase.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Domain.Entity.PlaceCategory> GetByIDAsync(Guid id)
        {
            return await _useCase.GetByIDAsync(id);
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
        public async Task<IActionResult> CreateAsync(Solution.Domain.Entity.PlaceCategory tag)
        {
            try
            {
                await _useCase.CreateAsync(tag);
                return Ok("Tag is created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("put")]
        public async Task<IActionResult> UpdateAsync(Solution.Domain.Entity.PlaceCategory tag)
        {
            try
            {
                await _useCase.UpdateAsync(tag);
                return Ok("Tag is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
