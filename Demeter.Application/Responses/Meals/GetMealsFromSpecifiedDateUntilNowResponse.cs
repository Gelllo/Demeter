using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Requests;

namespace Demeter.Application.Responses.Meals
{
    public record GetMealsFromSpecifiedDateUntilNowResponse
    {
        public IEnumerable<MealDTO> Meals { get; set; }
    }
}
