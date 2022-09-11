using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;


namespace Smart_Cooking_App.Interfaces
{
    public interface IUserRepo
    {
        public IActionResult addUser(Userr u);
        public IList<Userr> GetUser();
        public bool UserExist(Userr u);
        public bool UserExistForLogin(Userr u);
    }
}
