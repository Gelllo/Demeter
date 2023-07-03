using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Domain.FoodDomain;

namespace Demeter.Application.Requests.Meals
{
    public record UpdateMealRequest
    {
        public MealDTO? Meal { get; set; }
    }
}
