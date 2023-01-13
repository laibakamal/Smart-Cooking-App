using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;
using Smart_Cooking_App.Interfaces;
using AutoMapper;
using Smart_Cooking_App.ViewModels;

namespace Smart_Cooking_App.Controllers
{
    public class RecipeController : Controller
    {

        private readonly IRecipeRepo recipeRepo;
        private readonly IUserRepo userRep;
        private readonly ILogger<RecipeController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment Environment;

        public RecipeController(ILogger<RecipeController> logger, IMapper mapper, IRecipeRepo recipeRepo, IUserRepo userRep, IWebHostEnvironment environment)
        {
            _logger = logger;
            this.recipeRepo = recipeRepo;
            this.userRep = userRep;
            _mapper = mapper;
            Environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }



        [Route("recipe-details/{id:int:min(1)}", Name = "recipeDetailsRoute")]
        public async Task<ViewResult> GetRecipeDetails(int id)
        {
            Recipe recipe = recipeRepo.GetRecipeDetail(id);
            RecipeViewModel recipeViewModel = _mapper.Map<RecipeViewModel>(recipe);
            return View("RecipeDetail", recipeViewModel);
        }


        [Route("edit-recipe/{id:int:min(1)}", Name = "editRecipeRoute")]
        public async Task<ViewResult> EditRecipe(int id)
        {
            Recipe r = recipeRepo.GetRecipeById(id);
            return View("EditRecipe", r);
        }




        [Route("edit-recipepost/{id:int:min(1)}", Name = "editRecipeRoutePost")]
        public IActionResult EditRecipe(int id, Recipe u, List<IFormFile> files)
        {
            Recipe r = recipeRepo.GetRecipeById(id);
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in files)
            {
                string imagePath = "/Uploads/"+file.FileName;
                u.ImagePath=imagePath;
            }
            //if (ModelState.IsValid)
            //{

            recipeRepo.updateRecipe(r);
            return this.RedirectToAction("EditRecipe", "Admin");

            //return View("Login");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid Inputs");
            //    return View();
            //}

        }


        [HttpGet]
        public PartialViewResult Album()
        {

            IList<Recipe> list = recipeRepo.GetRecipes();
            return PartialView("PartialViews/HomeAlbum", list);
        }



        [HttpPost]
        public JsonResult SearchRecipe(string name)
        {
            var db = new SmartCookingAppContext();
            var recipes = from c in db.Recipe
                          where c.Name.Contains(name)
                          select c;
            return Json(recipes.ToList().Take(10));
        }



        [HttpPost]
        public IActionResult AjaxUpload(List<IFormFile> files)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                    ViewBag.FileName = fileName;
                }
            }
            return Json(true);
        }




        [HttpPost]
        public IActionResult AddRecipe(Recipe u, List<IFormFile> files)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in files)
            {
                string imagePath = "/Uploads/"+file.FileName;
                u.ImagePath=imagePath;
            }
            //if (ModelState.IsValid)
            //{

            recipeRepo.addRecipe(u);
            return this.RedirectToAction("AddRecipe", "Admin");

            //return View("Login");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid Inputs");
            //    return View();
            //}

        }


    }
}
