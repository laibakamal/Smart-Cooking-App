using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;
using Smart_Cooking_App.Interfaces;

namespace Smart_Cooking_App.Controllers
{
    public class UserrController : Controller
    {
        private readonly IRecipeRepo recipeRepo;
        private readonly IUserRepo userRep;
        private readonly ILogger<UserrController> _logger;

        public UserrController(ILogger<UserrController> logger, IRecipeRepo recipeRepo, IUserRepo userRep)
        {
            _logger = logger;
            this.recipeRepo = recipeRepo;
            this.userRep = userRep;
        }

        [HttpPost]
        public IActionResult Login(Userr u)
        {

            IList<Recipe> list = recipeRepo.GetRecipes();
            IList<Recipe> trimmedList = new List<Recipe>();

            for (int count = 0; count<9; count++)
            {
                trimmedList.Add(list[count]);
            }

            if (u.Email!=null && u.Password != null)
            {

                if (!HttpContext.Request.Cookies.ContainsKey("request_one"))
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Response.Cookies.Append("request_one", DateTime.Now.ToString(), options);
                    // HttpContext.Response.Cookies.Append("request_one", DateTime.Now.ToString());
                }
                else
                {
                    Object data = u;
                    HttpContext.Response.Cookies.Delete("request_one");
                }
                Console.WriteLine("Login done");
                if (userRep.UserExist(u))
                {
                    IList<Userr> List;
                    List = userRep.GetUser();
                    ViewData["Userr"] = List;
                    foreach (Userr item in List)
                    {
                        if (item.Email == u.Email && item.Role=="Admin")
                        {
                            return View("/Views/Admin/AdminHome.cshtml", trimmedList);
                        }
                    }

                    return View("Welcome", trimmedList);
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
            if (userRep.UserExistForLogin(u))
            {
                ViewBag.UserExists = "Username or Email already exists";
                return View();
            }
            else
            {
                userRep.addUser(u);
                return View("Login");

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
            IList<Recipe> list = recipeRepo.GetRecipes();
            IList<Recipe> trimmedList = new List<Recipe>();

            for (int count = 0; count<9; count++)
            {
                trimmedList.Add(list[count]);
            }
            return View("Home", trimmedList);
        }


        public IActionResult Album()
        {

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
