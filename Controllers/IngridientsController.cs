using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ingredientsApiCSharp.Services.IngredientsService;
using Microsoft.AspNetCore.Mvc;
// using ingredientsApiCSharp.Models;

namespace ingredientsApiCSharp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IngridientsController : ControllerBase
    {
        private readonly IIngredientsService _ingredientsService;
        public IngridientsController(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> all()
        {
            return Ok(await _ingredientsService.AllIngredients());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> single(int id)
        {
            return Ok(await _ingredientsService.IngredientById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetIngredientDto>>>> create(CreateIngredientDto newIngredient)
        {
            return Ok(await _ingredientsService.CreateIngredient(newIngredient));
        }
        
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetIngredientDto>>>> update(UpdateIngredientDto updatedIngredient)
        {
            var response = await _ingredientsService.UpdateIngredient(updatedIngredient);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> delete(int id)
        {
            var response = await _ingredientsService.DeleteIngredients(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}