using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Responses.Meals;
using Demeter.Domain.FoodDomain;

namespace Demeter.Application.Repository
{
    public interface IMealRepository
    {
        IEnumerable<Meal?> GetMeals();

        Task<IEnumerable<Meal>> GetMealsAsync(string? userID, string? date);

        Task<IEnumerable<Meal>> GetMealsFromSpecifiedDateUntilNow(string? userID, string? date);

        Task<IEnumerable<RegisteredDaysDto>> GetRegisteredDaysAsync(string userID);

        Task<Meal?> GetMealByID(int id);

        Task<int> InsertMeal(Meal meal);

        void DeleteMeal(int id);

        Task<Meal> UpdateMealAsync(Meal record);

        void Save();
    }
}
