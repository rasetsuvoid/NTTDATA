using Application.Common.Dtos.Coordinates;
using Application.Common.Dtos.Generic;
using Application.Common.Interfaces;
using Domain.Entities;
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
        public async Task<IActionResult> GetCoordinateById(int id)
        {
            Domain.Entities.Coordinates unit = await _unitService.GetByIdAsync(id);
            if (unit == null)
            {
                return StatusCode((int)System.Net.HttpStatusCode.NotFound, new HttpResponse<Coordinates>(System.Net.HttpStatusCode.NotFound, "No se encontraron coordenadas.", null));
            }
            return StatusCode((int)System.Net.HttpStatusCode.OK, new HttpResponse<Coordinates>(System.Net.HttpStatusCode.OK, "Coordenadas encontradas exitosamente.", unit));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoordinate(CoordinatesRequestDto request)
        {
            HttpResponse<string> unit = await _unitService.CreateCoordinates(request);

            return StatusCode((int)unit.StatusCode, unit);
        }
    }
}
