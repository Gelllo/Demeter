using Demeter.Domain.FoodDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter.Application.Repository
{
    public interface IFoodRepository
    {
        IEnumerable<Food?> GetFoods();

        Task<IEnumerable<Food>> GetFoodsAsync();

        Task<Food?> GetFoodByID(int id);

        Task<int> InsertFood(Food Food);
        public void AddFoodsIfNotExists(IEnumerable<Food> Foods);

        void DeleteFood(int id);

        Task<Food> UpdateFoodAsync(Food record);

        void Save();
    }
}
