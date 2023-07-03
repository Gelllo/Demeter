using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Repository;
using Demeter.Domain.FoodDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Demeter.Infrastracture.Repository
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository, IDisposable
    {
        public FoodRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Food?> GetFoods()
        {
            return _dbContext.Foods.ToList();
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            return await _dbContext.Foods.ToListAsync();
        }

        public async Task<Food?> GetFoodByID(int id)
        {
            return await _dbContext.Foods.FindAsync(id);
        }

        public async Task<int> InsertFood(Food Food)
        {
            await _dbContext.Foods.AddAsync(Food);
            Save();
            return Food.Id;
        }

        public void AddFoodsIfNotExists(IEnumerable<Food> Foods)
        {
            foreach (var food in Foods)
            {
                if (!_dbContext.Foods.Any(x => x.Title == food.Title))
                    _dbContext.Foods.AddAsync(food);
            }

            Save();
        }

        public void DeleteFood(int id)
        {
            Food food = _dbContext.Foods.FirstOrDefault(x => x.Id == id);
            _dbContext.Foods.Remove(food);
            Save();
        }

        public async Task<Food> UpdateFoodAsync(Food food)
        {
            _dbContext.Entry(food).State = EntityState.Modified;
            Save();
            return food;
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
