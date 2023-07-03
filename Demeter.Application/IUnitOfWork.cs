using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Repository;

namespace Demeter.Application
{
    public interface IUnitOfWork
    {
        IMealRepository MealRepository { get; }
        IFoodRepository FoodRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
