using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;

namespace CakesOrder.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult Login(User u)
        {
            if (u.Name!=null && u.Password != null)
            {


                Console.WriteLine("Login done");
                UserRepository userRep = new UserRepository();
                if (userRep.UserExist(u))
                {
                    IList<User> List = new List<User>();
                    List = userRep.GetUser();
                    ViewData["User"] = List;
                    return View("Home");
                }
                else
                {
                    ViewBag.validation = "Wrong UserName or Password";
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
        public IActionResult SignUp(User u)
        {
            if (ModelState.IsValid)
            {
                UserRepository userRep = new UserRepository();
                if (userRep.UserExistForLogin(u))
                {

                    ViewBag.UserExists = "UserName or Email is already exist";
                    return View();
                }
                else
                {
                    userRep.addUser(u);
                    return View("Login");
                }
            }
            else
            {
                Console.WriteLine("Invalid");
                return View();
            }

        }
        //[HttpGet]
        //public ViewResult SignUp()
        //{
        //    return View();
        //}



        [HttpGet]
        public ViewResult Home()
        {
            return View();
        }
    }
}
