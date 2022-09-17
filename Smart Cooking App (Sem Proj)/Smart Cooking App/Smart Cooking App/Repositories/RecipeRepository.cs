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

            IList<Recipe> List = new List<Recipe>();
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "select* from [Recipe]";
            SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Recipe recipe = new Recipe();

                recipe.Id= Convert.ToInt32(dr[0]);
                recipe.Name = dr[1].ToString();
                recipe.Detail = dr[2].ToString();
                recipe.Ingredients= dr[3].ToString();
                recipe.ImagePath=dr[4].ToString();
                recipe.ThumbnailText=dr[5].ToString();

                List.Add(recipe);
            }
            con.Close();

            return List;
        }
    }
}
