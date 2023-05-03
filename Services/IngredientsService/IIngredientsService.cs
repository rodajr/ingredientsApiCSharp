using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingredientsApiCSharp.Services.IngredientsService
{
    public interface IIngredientsService
    {
        Task<ServiceResponse<List<GetIngredientDto>>> AllIngredients();
        Task<ServiceResponse<GetIngredientDto>> IngredientById(int id);
        Task<ServiceResponse<List<GetIngredientDto>>> CreateIngredient(CreateIngredientDto newIngredient);
    }
}