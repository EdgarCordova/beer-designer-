using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RecipeRepository
    {
        private static string _connect = "Data Source=EDGARPC;Initial Catalog=ShipCompliant;Integrated Security=True;User ID=test;pwd=test";

        public static List<Recipe> GetAllBeerRecipes()
        {
            List<Recipe> recipes = new List<Recipe>(); 
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Recipes", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Recipe recipe = new Recipe();
                                recipe.Id = Convert.ToInt32(reader["Id"]);
                                recipe.Title = reader["Title"].ToString();
                                recipe.RecipeDescription = reader["RecipeDescription"].ToString();
                                recipes.Add(recipe);
                            }
                        }
                    }
                }
            }
            return recipes;
        }

        public static List<Recipe> GetBeerRecipesByTitle(string recipeTitle)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Recipes where Title like '%" + recipeTitle + "%'", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Recipe recipe = new Recipe();
                                recipe.Id = Convert.ToInt32(reader["Id"]);
                                recipe.Title = reader["Title"].ToString();
                                recipe.RecipeDescription = reader["RecipeDescription"].ToString();
                                recipes.Add(recipe);
                            }
                        }
                    }
                }
            }
            return recipes;
        }

        public static Recipe GetBeerRecipesById(int id)
        {
            Recipe recipe = new Recipe();
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Recipes where Id = "+ id, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                               
                                recipe.Id = Convert.ToInt32(reader["Id"]);
                                recipe.Title = reader["Title"].ToString();
                                recipe.RecipeDescription = reader["RecipeDescription"].ToString();
                                
                            }
                        }
                    }
                }
            }
            return recipe;
        }


        public static Recipe InsertBeerRecipes(Recipe recipe)
        {

            Recipe createdRecipe = new Recipe();
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Recipes (Title, RecipeDescription) VALUES (@Title, @RecipeDescription) SELECT Top(1) * FROM Recipes  where Id =SCOPE_IDENTITY()", con))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Title", recipe.Title);
                    cmd.Parameters.AddWithValue("@RecipeDescription", recipe.RecipeDescription);



                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                createdRecipe.Id = Convert.ToInt32(reader["Id"]);
                                createdRecipe.Title = reader["Title"].ToString();
                                createdRecipe.RecipeDescription = reader["RecipeDescription"].ToString();
                            }
                        }
                    }
                }
            }

            return createdRecipe;
        }


        public static void DeleteBeerRecipeById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Recipes where Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);  
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
