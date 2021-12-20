using ADSGuestbook.Data;
using ADSGuestbook.Models;
using ADSGuestbook.Models.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ADSGuestbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeViewModel
            {
                Comments = await _context.Comment.
                                            OrderByDescending(x => x.CreatedDate).
                                            ToListAsync()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> AddComment(HomeViewModel model)
        {
            Comment comment = new Comment
            {
                Title = model.Comment.Title ?? "",
                Body = model.Comment.Body ?? "",
                Name = model.Comment.Name ?? "",
                Email = model.Comment.Email ?? "",
                CreatedDate = DateTime.Now
            };

            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}