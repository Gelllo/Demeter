using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Requests;
using Demeter.Domain.FoodDomain;

namespace Demeter.Application.Responses.Meals
{
    public record UpdateMealResponse
    {
        public MealDTO Meal { get; set; }
    }
}
