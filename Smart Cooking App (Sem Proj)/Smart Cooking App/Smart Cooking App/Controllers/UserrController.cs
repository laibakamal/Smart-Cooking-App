using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;
using Smart_Cooking_App.Repositories;
using Smart_Cooking_App.Interfaces;

namespace Smart_Cooking_App.Controllers
{
    public class UserrController : Controller
    {
        [HttpPost]
        public IActionResult Login(Userr u)
        {
            if (u.Email!=null && u.Password != null)
            {
                Console.WriteLine("Login done");
                IUserRepo userRep = new UserrRepository();
                if (userRep.UserExist(u))
                {
                    IList<Userr> List;
                    List = userRep.GetUser();
                    ViewData["Userr"] = List;
                    foreach (Userr item in List)
                    {
                        if (item.Email == u.Email && item.Role=="Admin")
                        {
                            return View("/Views/Admin/AdminHome.cshtml");
                        }
                    }
                    return View("Welcome");
                }
                else
                {
                    ViewBag.validation = "Wrong Email or Password";
                    return View();
                }
            }
            else
                return View();

        }
        [HttpGet]
        public IActionResult Login()
        {

            return View("Login");
        }


        [HttpPost]
        public IActionResult SignUp([FromBody] Userr u)
        {
            //if (ModelState.IsValid)
            //{
            IUserRepo userRepo = new UserrRepository();
            if (userRepo.UserExistForLogin(u))
            {
                ViewBag.UserExists = "Username or Email already exists";
                return View();
            }
            else
            {
                userRepo.addUser(u);
                return View();
                //return View("Login");
            }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid Inputs");
            //    return View();
            //}

        }
        [HttpGet]
        public IActionResult Signup()
        {

            return View("Signup");
        }


        [HttpGet]
        public ViewResult Home()
        {
            IRecipeRepo recipeRepo = new RecipeRepository();
            IList<Recipe> list = recipeRepo.GetRecipes();
            IList<Recipe> trimmedList = new List<Recipe>();

            for (int count = 0; count<9; count++)
            {
                trimmedList.Add(list[count]);
            }
            GlobalVariable.RecipeCount=(GlobalVariable.RecipeCount+9);
            return View(trimmedList);
        }


        [HttpGet]
        public IActionResult Album()
        {
            IRecipeRepo recipeRepo = new RecipeRepository();
            IList<Recipe> list = recipeRepo.GetRecipes();
            IList<Recipe> trimmedList = new List<Recipe>();

            for (int count = 0; count<9; count++)
            {
                trimmedList.Add(list[count]);
            }
            GlobalVariable.RecipeCount=(GlobalVariable.RecipeCount+9);
            return View(trimmedList);
        }

        [HttpGet]
        public IActionResult FAQs()
        {
            return View("FAQs");
        }


        [HttpGet]
        public IActionResult AboutUs()
        {
            return View("AboutUs");
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
            return View("ContactUs");
        }


        [HttpGet]
        public IActionResult Features()
        {
            return View("Features");
        }


        [HttpGet]
        public IActionResult RecipeDetail()
        {
            return View("RecipeDetail");
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return View("Welcome");
        }


        [HttpGet]
        public IActionResult Pricing()
        {
            return View("Pricing");
        }
    }
}
