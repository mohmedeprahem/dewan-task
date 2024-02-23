using main.DTOs;
using main.Interfaces.Services;
using main.Models;
using Microsoft.AspNetCore.Mvc;

namespace main.Controllers
{
    [Route("items")]
    public class ItemController : Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(CreateItemRequestDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Item item = await itemService.CreateItemAsync(itemDto);

            return Created();
        }
    }
}
