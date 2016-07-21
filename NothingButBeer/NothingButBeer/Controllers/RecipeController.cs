using BusinessEntities;
using DataAccess;
using NothingButBeer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NothingButBeer.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult Details(int id)
        {
            Recipe recipe = RecipeRepository.GetBeerRecipesById(id);

            return View(recipe);
        }

        [ValidateInput(false)]
        public ActionResult Create(Recipe recipe)
        {
             ActionResult returnView = Redirect("/home/index");
          
                if (string.IsNullOrEmpty(recipe.Title))
                {
                    returnView = View();
                }
                else
                {
                    recipe = RecipeRepository.InsertBeerRecipes(recipe);

                    returnView = Redirect("/recipe/Details/" + recipe.Id);
                }

            return returnView;
        }
    }
}