using main.DTOs;
using main.Interfaces.Services;
using main.Models;
using main.Services;
using Microsoft.AspNetCore.Mvc;

namespace main.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public async Task<ActionResult> Index()
        {
            var items = await itemService.GetAllItemsAsync();
            return View(items);
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
