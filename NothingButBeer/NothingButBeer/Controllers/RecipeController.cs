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

            recipe.ListOfIngredients = IngredientsRepository.GetAllRecipeIngredientsById(id);

            return View(recipe);
        }

        public ActionResult Ingredients(int id)
        {
            Recipe recipe = RecipeRepository.GetBeerRecipesById(id);

            ViewBag.ingredients = IngredientsRepository.GetAllIngredients();
            ViewBag.id = id;

            return View();
        }


        public ActionResult InsertIngredients(List<string> listOfIngredient)
        {
            int id = (Request.QueryString["Id"] != null && int.TryParse(Request.QueryString["Id"].ToString(), out id)) ? id : 1;

            foreach (string ingredient in listOfIngredient)
            {
                IngredientsRepository.InsertIngredient(ingredient, id);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
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
                    returnView = Redirect("/recipe/ingredients/" + recipe.Id);
                }

            return returnView;
        }
    }
}