using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CoordinatesController : BaseController
    {
        private readonly ICoordinatesService _unitService;

        public CoordinatesController(ICoordinatesService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            var unit = await _unitService.GetByIdAsync(id);
            if (unit == null)
            {
                return BadRequest("Error");
            }
            return Ok(unit);
        }
    }
}
