using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;

namespace Smart_Cooking_App.View_Components
{
    public class RecipeCard : ViewComponent
    {
        Recipe recipe;
        public object Invoke(Recipe recipe)
        {
            this.recipe=recipe;
            return this.recipe;
        }
    }
}
