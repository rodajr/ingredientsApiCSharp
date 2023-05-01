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
        public ActionResult<Ingredients> all()
        {
            return Ok(_ingredientsService.AllIngredients());
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredients> single(int id)
        {
            return Ok(_ingredientsService.IngredientById(id));
        }

        [HttpPost]
        public ActionResult<Ingredients> create(Ingredients newIngredient)
        {
            return Ok(_ingredientsService.CreateIngredient(newIngredient));
        }
        
        // [HttpPost]
        // public ActionResult<Ingredients> update(Ingredients newIngredient)
        // {

        //     ingredients.Add(newIngredient);
        //     return Ok(ingredients);
        // }
        
        // [HttpDelete]
        // public ActionResult<Ingredients> delete(Ingredients newIngredient)
        // {

        //     ingredients.Add(newIngredient);
        //     return Ok(ingredients);
        // }
    }
}