﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string IngredientName { get; set; }
    }
}
