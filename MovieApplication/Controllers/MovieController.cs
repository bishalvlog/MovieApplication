using Microsoft.AspNetCore.Mvc;
using MovieApplication.Models;
using Movies.DataAccess.Repository.IRepository;
using Movies.Model.VM;

namespace MovieApplication.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        public MovieController (IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: MovieController
        public ActionResult Index()
        {
            var movielist = _unitOfWork.movie.GetAll().ToList();
            return View(movielist);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieVM movieVM,IFormFile? formFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if(formFile != null)
                {
                    string filename =Guid.NewGuid().ToString();
                    var upload =Path.Combine(wwwRootPath, @"\Images\");
                    var extension =Path.GetExtension(formFile.FileName);

                    using (var filestreams = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                    {
                        formFile.CopyTo(filestreams);

                    }
                }
                _unitOfWork.movie.Add(movieVM.movie);
                TempData["create"] = "movie add successfully";
                _unitOfWork.save();
                return RedirectToAction("Index");
            }
            return View(movieVM);
           
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
