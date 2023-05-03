global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingredientsApiCSharp.Services.IngredientsService
{
    public class IngredientsService : IIngredientsService
    {
        private static List<Ingredients> ingredients = new List<Ingredients> { new Ingredients() };
        private readonly IMapper _mapper;

        public IngredientsService(IMapper mapper)
        {
            _mapper = mapper;
                    
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> AllIngredients()
        {
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();
            serviceResponse.Data = ingredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> CreateIngredient(CreateIngredientDto newIngredient)
        {
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();
            ingredients.Add(_mapper.Map<Ingredients>(newIngredient));
            serviceResponse.Data = ingredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetIngredientDto>> IngredientById(int id)
        {
            var serviceResponse = new ServiceResponse<GetIngredientDto>();
            var ingredient = ingredients.FirstOrDefault(ingredient => ingredient.Id == id);
            serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);
            return serviceResponse;            
        }       
    }
}