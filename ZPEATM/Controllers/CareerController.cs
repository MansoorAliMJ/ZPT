using Microsoft.AspNetCore.Mvc;
using ZPEATM.Data;
using ZPEATM.Models;

namespace ZPEATM.Controllers
{
    public class CareerController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CareerController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(Career model, IFormFile resume)
        {
            if (ModelState.IsValid && resume != null)
            {
                var uploads = Path.Combine(_env.WebRootPath, "resumes");
                Directory.CreateDirectory(uploads);
                var filePath = Path.Combine(uploads, resume.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await resume.CopyToAsync(stream);
                }

                model.ResumePath = "/resumes/" + resume.FileName;
                _context.Careers.Add(model);
                await _context.SaveChangesAsync();

                ViewBag.Message = "Application submitted!";
                TempData["SuccessMessage"] = "Application submitted successfully!";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
