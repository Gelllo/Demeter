﻿using Demeter.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Repository;
using Demeter.Infrastracture.Repository;

namespace Demeter.Infrastracture
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMealRepository _mealRepository;

        private IFoodRepository _foodRepository;

        private readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMealRepository MealRepository
        {
            get
            {
                return _mealRepository = _mealRepository ?? new MealRepository(_dbContext);
            }
        }

        public IFoodRepository FoodRepository
        {
            get
            {
                return _foodRepository = _foodRepository ?? new FoodRepository(_dbContext);
            }
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _dbContext.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
