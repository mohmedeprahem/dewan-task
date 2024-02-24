﻿using main.DTOs;
using main.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace main.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReceiptRequestDto receiptDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (receiptDto.Items.Count == 0)
            {
                ModelState.AddModelError("Items", "Receipt must have at least one item.");
                return BadRequest(ModelState);
            }

            Dictionary<string, List<string>> errors = await receiptService.CreateReceiptAsync(
                receiptDto
            );

            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }

            return Created();
        }
    }
}
