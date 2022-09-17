using Smart_Cooking_App.Models;

namespace Smart_Cooking_App.Interfaces
{
    public interface IRecipeRepo
    {
        public IList<Recipe> GetRecipes();
    }
}
