using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Domain.FoodDomain;

namespace Demeter.Application.Repository
{
    public interface IFoodRepository
    {
        IEnumerable<Food> GetFoods();

        Task<IEnumerable<Food>> GetFoodsAsync();
        Food GetFoodByID(int foodId);
        void InsertFood(Food food);
        void DeleteFood(int foodId);
        void UpdateFood(Food food);
        void Save();
    }
}
