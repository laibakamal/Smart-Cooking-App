using Microsoft.AspNetCore.Mvc;

namespace Smart_Cooking_App.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AdminHome()
        {
            return View("~/Views/Admin/AdminHome");
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View("~/Views/Admin/AddRecipe.cshtml");
        }


        public IActionResult AdminAlbum()
        {
            return View("PartialViews/AdminAlbums");
        }
    }
}
