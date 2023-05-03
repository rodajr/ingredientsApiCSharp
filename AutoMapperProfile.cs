using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingredientsApiCSharp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ingredients, GetIngredientDto>();
            CreateMap<CreateIngredientDto, Ingredients>();
        }
    }
}