using NothingButBeer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NothingButBeer.Controllers
{
    public class HomeController : Controller
    {

        private static string _connect = "Data Source=EDGARPC;Initial Catalog=ShipCompliant;Integrated Security=True";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRecipes()
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
                                recipe.Description = reader["Description"].ToString();
                                recipes.Add(recipe);           
                            }
                        }
                    } // reader closed and disposed up here

                } // command disposed here

            } 
            return View();

        }

        public ActionResult Recipes()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}