using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingredientsApiCSharp.Services.IngredientsService
{
    public interface IIngredientsService
    {
        List<Ingredients> AllIngredients();
        Ingredients IngredientById(int id);
        List<Ingredients> CreateIngredient(Ingredients newIngredient);
    }
}