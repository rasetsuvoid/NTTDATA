﻿using Application.Common.Dtos.Delivery;
using Application.Common.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DeliveryController : BaseController
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateProvisionsAsync(DeliveryRequestDto request)
        {
            var result = await _deliveryService.CalculateProvisionsAsync(request);
            return Ok(result);
        }

    }
}
