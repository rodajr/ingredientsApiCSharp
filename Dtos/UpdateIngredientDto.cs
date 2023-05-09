using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingredientsApiCSharp.Dtos
{
    public class UpdateIngredientDto
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Amount  { get; set; } = 0.00F;
        public float Cost  { get; set; } =  0.00F;
        public string? Unit  { get; set; }
        public DateTime Created_at  { get; set; } = DateTime.Now;
        public DateTime Updated_at  { get; set; } = DateTime.Now;
    }
}