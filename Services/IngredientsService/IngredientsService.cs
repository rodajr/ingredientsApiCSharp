using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingredientsApiCSharp.Services.IngredientsService
{
    public class IngredientsService : IIngredientsService
    {
        private static List<Ingredients> ingredients = new List<Ingredients> { new Ingredients() };

        public List<Ingredients> AllIngredients()
        {
             return ingredients;
        }

        public List<Ingredients> CreateIngredient(Ingredients newIngredient)
        {

            ingredients.Add(newIngredient);
            return ingredients;
        }

        public Ingredients IngredientById(int id)
        {
            return ingredients.FirstOrDefault(ingredient => ingredient.Id == id);
        }
    }
}