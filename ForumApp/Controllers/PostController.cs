using ForumApp.Core.Models;
using ForumApp.Core.Services.Contracts;
using ForumApp.DataBase.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IService service;

        public PostController(IService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await service.GetAllPostsAsync();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
           => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Post post = new()
            {
                Title = model.Title,
                Content = model.Content
            };

            await service.AddAsync(post);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit()
           => View();

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await service.EditAsync(model, id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete()
            => View();

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
