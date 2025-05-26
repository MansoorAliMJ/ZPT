using Microsoft.AspNetCore.Mvc;
using ZPEATM.Data;
using ZPEATM.Models;

namespace ZPEATM.Controllers
{
    public class ContactController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(model);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Message submitted successfully!";
            }

            ModelState.Clear();
            return View(new Contact());
        }
    }
}
