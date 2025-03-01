using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08Group4_7.Models;

namespace Mission08Group4_7.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Quadrants");
        }


        [HttpGet]
        public IActionResult Quadrants()
        {
            ViewBag.Categories = _repo.Categories.ToList(); // Re-populate dropdown list
            var tasks = _repo.Tasks
                .Where(x => x.Completed == false)
                .ToList(); // Load all tasks
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.ToList(); // Load all categories
            return View(new TaskClass());
        }

        [HttpPost]
        public IActionResult AddTask(TaskClass task)
        {
            ViewBag.Categories = _repo.Categories.ToList(); // Re-populate dropdown list
            if (ModelState.IsValid)
            {

                _repo.AddTask(task);
                return View("Confirmation", task); 
            }
            else
            {
                //ViewBag.Categories = _repo.Categories.ToList(); // Re-populate dropdown list
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Confirmation(string Task, string DueDate, string Quadrant, string Category, string Completed)
        {
            ViewBag.Task = Task;
            ViewBag.DueDate = DueDate;
            ViewBag.Quadrant = Quadrant;
            ViewBag.Category = Category;
            ViewBag.Completed = Completed;

            return View();
        }

        [HttpGet] public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(x => x.TaskId == id);
            ViewBag.Categories = _repo.Categories.ToList(); // Re-populate dropdown list
            return View("AddTask", task);
        }

        [HttpPost] public IActionResult Edit(TaskClass task)
        {
            _repo.UpdateTask(task);
            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(x => x.TaskId == id);
            ViewBag.Categories = _repo.Categories.ToList(); // Re-populate dropdown list
            return View("ConfirmDeletion", task);
        }

        [HttpPost]
        public IActionResult Delete(TaskClass task)
        {
            _repo.DeleteTask(task);
            return RedirectToAction("Quadrants");

        }


    }
}
