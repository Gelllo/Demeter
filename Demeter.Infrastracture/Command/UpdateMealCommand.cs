using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demeter.Application;
using Demeter.Application.Requests;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;
using Demeter.Domain.FoodDomain;

namespace Demeter.Infrastracture.Commands.UsersCommands
{
    public class UpdateMealCommand : ICommandHandler<UpdateMealRequest, UpdateMealResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMealCommand(IUnitOfWork uniOfWork, IMapper mapper)
        {
            _unitOfWork = uniOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateMealResponse> Handle(UpdateMealRequest request, CancellationToken cancellation)
        {
            var existingMeal = await _unitOfWork.MealRepository.GetMealByID(request.Meal.Id);
            var newMeal = _mapper.Map<Meal>(request.Meal);
            existingMeal.Foods = newMeal.Foods;
            existingMeal.DateRegistered = newMeal.DateRegistered;
            existingMeal.MealType = newMeal.MealType;

            return new UpdateMealResponse(){Meal = _mapper.Map<MealDTO>(await _unitOfWork.MealRepository.UpdateMealAsync(existingMeal))};
        }
    }
}