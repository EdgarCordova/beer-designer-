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
    public class IngredientsRepository
    {
        private static string _connect = "Data Source=EDGARPC;Initial Catalog=ShipCompliant;Integrated Security=True;User ID=test;pwd=test";

        public static List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>(); 
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Ingredients", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Ingredient ingredient = new Ingredient();
                                ingredient.Id = Convert.ToInt32(reader["Id"]);
                                ingredient.IngredientName = reader["IngredientName"].ToString();
                                ingredients.Add(ingredient);
                            }
                        }
                    }
                }
            }
            return ingredients;
        }

        public static List<string> GetAllRecipeIngredientsById(int id)
        {
            List<string> ingredients = new List<string>();
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM RecipeIngredient WHERE RecipeId = " + id, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                string ingredient = "";

                                ingredient = reader["IngredientName"].ToString();
                                ingredients.Add(ingredient);
                            }
                        }
                    }
                }
            }
            return ingredients;
        }


        public static Ingredient InsertIngredient(string ingredient, int id)
        {
            Ingredient ingredientItem = new Ingredient();
            using (SqlConnection con = new SqlConnection(_connect))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO RecipeIngredient (RecipeId, IngredientName) VALUES (@RecipeId, @IngredientName) SELECT Top(1) * FROM RecipeIngredient  where Id =SCOPE_IDENTITY()", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@RecipeId", id);
                    cmd.Parameters.AddWithValue("@IngredientName", ingredient);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                ingredientItem.Id = Convert.ToInt32(reader["Id"]);
                                ingredientItem.RecipeId = Convert.ToInt32(reader["RecipeId"]);
                                ingredientItem.IngredientName = reader["IngredientName"].ToString();
                            }
                        }
                    }
                }
            }

            return ingredientItem;
        }
    }
}
