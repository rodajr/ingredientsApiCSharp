global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingredientsApiCSharp.Services.IngredientsService
{
    public class IngredientsService : IIngredientsService
    {
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
            var ingredients = _mapper.Map<Ingredients>(newIngredient);
            _context.Ingredients.Add(ingredients);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Ingredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> DeleteIngredients(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();

            try
            {
                var ingredient = await _context.Ingredients.FirstAsync(ingredient => ingredient.Id == id);
                if (ingredient is null)
                {
                    throw new Exception($"Ingredient ID '{id}' not found");
                }

                _context.Ingredients.Remove(ingredient);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Ingredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToListAsync();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;                
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetIngredientDto>> IngredientById(int id)
        {
            var serviceResponse = new ServiceResponse<GetIngredientDto>();
            var dbIngredient = await _context.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.Id == id);
            serviceResponse.Data = _mapper.Map<GetIngredientDto>(dbIngredient);
            return serviceResponse;            
        }

        public async Task<ServiceResponse<GetIngredientDto>> UpdateIngredient(UpdateIngredientDto updateIngredient)
        {
            var serviceResponse = new ServiceResponse<GetIngredientDto>();

            try
            {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.Id == updateIngredient.Id);
                if (ingredient is null)
                {
                    throw new Exception($"Ingredient ID '{updateIngredient.Id}' not found");
                }

                ingredient.Name = updateIngredient.Name;
                ingredient.Amount = updateIngredient.Amount;
                ingredient.Cost = updateIngredient.Cost;
                ingredient.Unit = updateIngredient.Unit;
                ingredient.Updated_at = updateIngredient.Updated_at;

                serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);                
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;                
            }

            return serviceResponse;
        }
    }
}