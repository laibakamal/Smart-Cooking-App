using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Smart_Cooking_App.Interfaces;
using Smart_Cooking_App.Models;



namespace Smart_Cooking_App.Repositories
{
    public class UserrRepository : Controller, IUserRepo
    {
        public IActionResult addUser(Userr u)
        {
            //*************************ADD INTO DATABASE******************************** 

            Userr temp = new Userr();
            temp.Name = u.Name;
            temp.Email = u.Email;
            temp.Username = u.Username;
            temp.Password = u.Password;
            temp.ConfirmPassword = u.ConfirmPassword;
            temp.Role = "User";

            if (u.Username != null && u.Password != null)
            {
                var db = new SmartCookingAppContext();
                db.Userrs.Add(temp);
                db.SaveChanges();
                Console.WriteLine("successssssss");
            }
            return View();
        }


        public IList<Userr> GetUser()
        {
            var db = new SmartCookingAppContext();
            IList<Userr> users = db.Userrs.ToList();
            return users;
        }


        public bool UserExist(Userr u)
        {
            var db = new SmartCookingAppContext();
            List<Userr> query = db.Userrs.Where(u => u.Email == u.Email).Where(u => u.Password == u.Password).ToList<Userr>();
            if (query.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UserExistForLogin(Userr u)
        {


            var db = new SmartCookingAppContext();
            List<Userr> query = db.Userrs.Where(u => u.Email == u.Email).Where(u => u.Username == u.Username).ToList<Userr>();
            if (query.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
