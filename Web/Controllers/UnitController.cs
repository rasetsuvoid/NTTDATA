using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UnitController : BaseController
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
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
