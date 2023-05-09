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
        private readonly DataContext _context;

        public IngredientsService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
                    
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> AllIngredients()
        {
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();
            var dbIngredients = await _context.Ingredients.ToListAsync();
            serviceResponse.Data = dbIngredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToList();
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
            var dbIngredient = await _context.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.Id == id);
            serviceResponse.Data = _mapper.Map<GetIngredientDto>(dbIngredient);
            return serviceResponse;            
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> UpdateIngredient(UpdateIngredientDto updateIngredient)
        {
            var serviceResponse = new ServiceResponse<GetIngredientDto>();
            var ingredient = ingredients.FirstOrDefault(ingredient => ingredient.Id == updateIngredient.Id);

            ingredient.Name = updateIngredient.Name;
            ingredient.Amount = updateIngredient.Amount;
            ingredient.Cost = updateIngredient.Cost;
            ingredient.Unit = updateIngredient.Unit;
            ingredient.Updated_at = updateIngredient.Updated_at;

            serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);

            return serviceResponse;
        }
    }
}