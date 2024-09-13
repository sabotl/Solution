using Microsoft.AspNetCore.Mvc;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly Solution.Application.UseCase.TagUseCase _useCase;

        public TagController(Application.UseCase.TagUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpGet]
        public async Task<IReadOnlyList<Domain.Entity.Tag>> Index()
        {
            return await _useCase.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Domain.Entity.Tag> GetByIDAsync(int id)
        {
            return await _useCase.GetByIDAsync(id);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _useCase.DeleteAsync(id);
                return Ok("Success");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("post")]
        public async Task<IActionResult> CreateAsync(Solution.Domain.Entity.Tag tag)
        {
            try
            {
                await _useCase.CreateAsync(tag);
                return Ok("Tag is created");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("put")]
        public async Task<IActionResult> UpdateAsync(Solution.Domain.Entity.Tag tag)
        {
            try
            {
                await _useCase.UpdateAsync(tag);
                return Ok("Tag is updated");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
