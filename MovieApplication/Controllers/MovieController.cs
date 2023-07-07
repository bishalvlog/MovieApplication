using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Index()
        {
            var movielist = _unitOfWork.movie.GetAll().ToList();
            return View(movielist);
        }

        // GET: MovieController/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var details = _unitOfWork.movie.GetFirstordefault(u => u.Id == id);
            return View(details);
        }

        // GET: M
        // ovieController/Create
        [HttpGet]
        public IActionResult Create(int? Id)
        {
           
            MovieVM movieVM = new()
            {
                
            MovieList = _unitOfWork.movie.GetAll().Select(c=> new SelectListItem
                {
                    Text =c.Title,
                    Value=c.Id.ToString()
                }),
                Movies = new movie()

            };

            if (Id == null || Id == 0)
            {
                return View(movieVM);
            }
            else
            {
                movieVM.Movies = _unitOfWork.movie.GetFirstordefault(u => u.Id == Id);
                return View(movieVM);
            }
        }
        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieVM movieVM, IFormFile? formFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if(formFile != null)
                {
                    string filename =Guid.NewGuid().ToString();
                    var upload =Path.Combine(wwwRootPath, @"\Images\");
                    var extension =Path.GetExtension(formFile.FileName);
                    if(movieVM.Movies.Imageurl != null)
                    {
                        var oldpath =Path.Combine(wwwRootPath,movieVM.Movies.Imageurl.TrimEnd('/'));
                        if (System.IO.File.Exists(oldpath))
                        {
                            System.IO.File.Delete(oldpath);
                        }
                    }

                    using (var filestreams = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                    {
                        formFile.CopyTo(filestreams);

                    }
                    movieVM.Movies.Imageurl = filename + extension;
                }
                if(movieVM.Movies.Id == 0)
                {
                    _unitOfWork.movie.Add(movieVM.Movies);
                    TempData["create"] = "movie add successfully";
                   

                }
                else
                {
                    _unitOfWork.movie.update(movieVM.Movies);
                    TempData["edit"] = "update movie successfully";
                }
                _unitOfWork.save();

                return RedirectToAction("Index");
            }
            return View(movieVM);
           
        }

        // GET: MovieController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            var deletes = _unitOfWork.movie.GetFirstordefault(u => u.Id == id);
            return View(deletes);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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
