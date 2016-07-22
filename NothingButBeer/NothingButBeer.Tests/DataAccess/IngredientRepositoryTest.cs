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
    public class IngredientRepositoryTest
    {
        [TestMethod]
        public void GetAllBeerRecipes()
        {
            List<Ingredient> ingredients = IngredientsRepository.GetAllIngredients();

            Assert.IsTrue(ingredients.Count() > 0);
        }



        [TestMethod]
        public void InsertIngredient()
        {
            Recipe recipe = new Recipe()
            {
                Title = "Unit Test IPA",
                RecipeDescription = "In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elitultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            string ingredient = "Test Ingredient";

            Recipe newRecipe = RecipeRepository.InsertBeerRecipes(recipe);

            Ingredient item = IngredientsRepository.InsertIngredient(ingredient, newRecipe.Id);

            Assert.IsTrue(item.Id > 0);
        }



        [TestMethod]
        public void GetAllRecipeIngredientsById()
        {
            Recipe recipe = new Recipe()
            {
                Title = "Unit Test IPA",
                RecipeDescription = "In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elitultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit.ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia est placerat dui venenatis lobortis. Proin non nisl a lorem varius facilisis sodales dignissim felis. Nullam tortor nisl, sodales et gravida non, vehicula sed massa. Vestibulum ligula lacus, rhoncus id lacinia ac, tristique sed massa. Morbi tortor metus, varius sit amet cursus ac, sagittis sodales ex. Praesent ultricies, arcu a aliquet pulvinar, purus metus tincidunt tellus, eu pulvinar nisi augue non augue. Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            string ingredient = "Test Ingredient";

            Recipe newRecipe = RecipeRepository.InsertBeerRecipes(recipe);

            Ingredient item = IngredientsRepository.InsertIngredient(ingredient, newRecipe.Id);

            List<string> ingredients = IngredientsRepository.GetAllRecipeIngredientsById(newRecipe.Id);


            Assert.IsTrue(ingredients.Count() > 0);
        }

    }
}
