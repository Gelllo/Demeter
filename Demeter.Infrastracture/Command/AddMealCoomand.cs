using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;
using Demeter.Domain.FoodDomain;

namespace Demeter.Infrastracture.Commands.UsersCommands
{
    public class AddMealCommand : ICommandHandler<AddMealRequest, AddMealResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddMealCommand(IUnitOfWork uniOfWork, IMapper mapper)
        {
            _unitOfWork = uniOfWork;
            _mapper = mapper;
        }

        public async Task<AddMealResponse> Handle(AddMealRequest request, CancellationToken cancellation)
        {
            await _unitOfWork.MealRepository.InsertMeal(_mapper.Map<Meal>(request.Meal));
            return new AddMealResponse(){};
        }
    }
}