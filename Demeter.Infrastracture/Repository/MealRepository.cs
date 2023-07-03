using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Repository;
using Demeter.Application.Responses.Meals;
using Demeter.Domain.FoodDomain;
using Microsoft.EntityFrameworkCore;

namespace Demeter.Infrastracture.Repository
{
    public class MealRepository:GenericRepository<Meal>, IMealRepository, IDisposable
    {
        public MealRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Meal?> GetMeals()
        {
            return _dbContext.Meals.ToList();
        }

        public async Task<IEnumerable<Meal>> GetMealsAsync(string? userID, string? date)
        {
            DateTime.TryParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime dateObj);

            return await _dbContext.Meals.AsQueryable()
                .Where(x => x.UserId == userID && x.DateRegistered == dateObj)
                .ToListAsync();
        }

        public async Task<IEnumerable<Meal>> GetMealsFromSpecifiedDateUntilNow(string? userID, string? date)
        {
            DateTime.TryParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime dateObj);

            return _dbContext.Meals.AsQueryable().Where(x => x.UserId == userID)
                .OrderByDescending(x => x.DateRegistered)
                .AsEnumerable()
                .Where(x => x.DateRegistered > dateObj)
                .ToList();
        }

        public async Task<IEnumerable<RegisteredDaysDto>> GetRegisteredDaysAsync()
        {
            var groupedDates = await _dbContext.Meals.GroupBy(x => x.DateRegistered).OrderByDescending(x => x.Key).Select(g =>
                    new RegisteredDaysDto() { Date = g.Key.ToShortDateString(), RecordsCountPerDay = g.Count() })
                .ToListAsync();

            return groupedDates;
        }

        public async Task<Meal?> GetMealByID(int id)
        {
            return await _dbContext.Meals.FindAsync(id);
        }

        public async Task<int> InsertMeal(Meal meal)
        {
            await _dbContext.Meals.AddAsync(meal);
            Save();

            return meal.Id;
        }

        public void DeleteMeal(int id)
        {
            Meal meal = _dbContext.Meals.FirstOrDefault(x => x.Id == id);
            _dbContext.Meals.Remove(meal);
            _dbContext.SaveChangesAsync();
        }

        public async Task<Meal> UpdateMealAsync(Meal meal)
        {
            _dbContext.Meals.Entry(meal).State = EntityState.Modified;
            Save();
            return meal;
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
