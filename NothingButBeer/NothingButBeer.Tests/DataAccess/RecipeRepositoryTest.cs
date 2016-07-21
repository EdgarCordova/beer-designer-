using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NothingButBeer;
using NothingButBeer.Controllers;
using DataAccess;
using BusinessEntities;

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
                RecipeDescription = "In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elitultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit."
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
