using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;

namespace Smart_Cooking_App.Interfaces
{
    public interface IRecipeRepo
    {
        public IList<Recipe> GetRecipes();
        public Recipe GetRecipeDetail(int id);
        public IActionResult addRecipe(Recipe u);

        public Recipe GetRecipeById(int id);
        public IActionResult updateRecipe(Recipe r);
    }
}
