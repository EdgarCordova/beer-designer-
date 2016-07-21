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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> RecipeSearchGrid()
        {
            string keyword = string.IsNullOrEmpty(Request.QueryString["keyword"]) ? string.Empty : Request.QueryString["keyword"];

            List<Recipe> recipes = RecipeRepository.GetBeerRecipesByTitle(keyword);

            return PartialView("/Views/Home/_RecipeSearchGrid.cshtml", recipes);
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