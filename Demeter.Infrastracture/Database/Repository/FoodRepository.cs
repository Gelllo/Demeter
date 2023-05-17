using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Repository;
using Demeter.Domain.FoodDomain;
using Microsoft.EntityFrameworkCore;

namespace Demeter.Infrastracture.Database.Repository
{
    internal class FoodRepository: GenericRepository<Food>, IFoodRepository, IDisposable
    {
        public FoodRepository(DataContext context): base(context)
        {
                
        }

        public IEnumerable<Food> GetFoods()
        {
            return _dbContext.Foods.ToList();
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            return await GetAllAsync();
        }

        public Food GetFoodByID(int foodId)
        {
            return _dbContext.Foods.Find(foodId);
        }

        public void InsertFood(Food food)
        {
            _dbContext.Foods.Add(food);
        }

        public void DeleteFood(int foodId)
        {
            Food food = _dbContext.Foods.Find(foodId);
            _dbContext.Foods.Remove(food);
        }

        public void UpdateFood(Food food)
        {
            _dbContext.Entry(food).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
