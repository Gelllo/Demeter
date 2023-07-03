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
    public class DeleteMealCommand : ICommandHandler<DeleteMealRequest, DeleteMealResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMealCommand(IUnitOfWork uniOfWork, IMapper mapper)
        {
            _unitOfWork = uniOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteMealResponse> Handle(DeleteMealRequest request, CancellationToken cancellation)
        {
            _unitOfWork.MealRepository.DeleteMeal(request.Id);
            return new DeleteMealResponse() { };
        }
    }
}