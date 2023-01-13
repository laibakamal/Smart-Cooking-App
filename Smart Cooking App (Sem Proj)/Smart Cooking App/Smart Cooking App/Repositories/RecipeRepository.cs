using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Smart_Cooking_App.Interfaces;
using Smart_Cooking_App.Models;

namespace Smart_Cooking_App.Repositories
{
    public class RecipeRepository : Controller, IRecipeRepo
    {
        public IList<Recipe> GetRecipes()
        {
            var db = new SmartCookingAppContext();
            IList<Recipe> recipes = db.Recipe.ToList();
            return recipes;
        }



        public Recipe GetRecipeDetail(int id)
        {

            var db = new SmartCookingAppContext();
            List<Recipe> query = db.Recipe.Where(r => r.Id == id).ToList<Recipe>();

            foreach (var recipee in query)
            {
                return recipee;
            }
            return new Recipe();

        }



        public IActionResult addRecipe(Recipe u)
        {
            //*************************ADD INTO DATABASE******************************** 

            Recipe temp = new Recipe();
            temp.Name = u.Name;
            temp.Detail = u.Detail;
            temp.Ingredients = u.Ingredients;
            temp.ThumbnailText = u.ThumbnailText;
            temp.ImagePath= u.ImagePath;
            var db = new SmartCookingAppContext();
            db.Recipe.Add(temp);
            db.SaveChanges();
            Console.WriteLine("successssssss");
            return View();
        }



        public IActionResult updateRecipe(Recipe u)
        {
            //*************************ADD INTO DATABASE******************************** 

            SmartCookingAppContext db = new SmartCookingAppContext();
            Recipe temp = db.Recipe.Where(r => r.Id==u.Id).FirstOrDefault();
            temp.Name = u.Name;
            temp.Detail = u.Detail;
            temp.Ingredients = u.Ingredients;
            temp.ThumbnailText = u.ThumbnailText;
            db.Recipe.Update(temp);
            db.SaveChanges();
            Console.WriteLine("successssssss");
            return View();
        }



        public Recipe GetRecipeById(int id)
        {
            var db = new SmartCookingAppContext();
            Recipe r = db.Recipe.Find(id);

            return r;

        }
    }

}

