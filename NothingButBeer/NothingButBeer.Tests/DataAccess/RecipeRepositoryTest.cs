using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NothingButBeer;
using NothingButBeer.Controllers;
using NothingButBeer.Models;
using DataAccess;

namespace NothingButBeer.Tests.Controllers
{
    [TestClass]
    public class RecipeRepositoryTest
    {
        [TestMethod]
        public void GetAllBeerRecipes()
        {
            List<Recipe> recipes = RecipeRepository.GetAllBeerRecipes();

            Assert.IsTrue(recipes.Count() > 0);
        }

        [TestMethod]
        public void GetBeerRecipesByTitle()
        {
            string recipeTitle = "test";
            List<Recipe> recipes = RecipeRepository.GetBeerRecipesByTitle(recipeTitle);

            Assert.IsTrue(recipes.Count() > 0);
        }

        [TestMethod]
        public void GetBeerRecipesById()
        {
            int recipeId = 1;
            Recipe recipe = RecipeRepository.GetBeerRecipesById(recipeId);

            Assert.IsTrue(recipe != null);
        }

        [TestMethod]
        public void InsertBeerRecipe()
        {
            Recipe recipe = new Recipe()
            {
                Title = "test",
                RecipeDescription = "test description"
            };


            Recipe newRecipe = RecipeRepository.InsertBeerRecipes(recipe);

            Assert.IsTrue(newRecipe.Id > 0);
        }

        [TestMethod]
        public void DeleteBeerRecipeById()
        {
            Recipe recipe = new Recipe()
            {
                Title = "test",
                RecipeDescription = "test description"
            };

            Recipe newRecipe = RecipeRepository.InsertBeerRecipes(recipe);

            RecipeRepository.DeleteBeerRecipeById(newRecipe.Id);

            recipe = RecipeRepository.GetBeerRecipesById(newRecipe.Id);

            Assert.IsTrue(recipe.Id == 0);
        }


    }
}
