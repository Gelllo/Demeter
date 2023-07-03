using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demeter.Application;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;


namespace Demeter.Infrastracture.Database.Query.MealsRecordsQueries
{
    public class GetMealsRegisteredDaysQuery : IQueryHandler<GetMealsRegisteredDaysRequest, GetMealsRegisteredDaysResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMealsRegisteredDaysQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<GetMealsRegisteredDaysResponse> Handle(GetMealsRegisteredDaysRequest query, CancellationToken cancellation)
        {
            return new GetMealsRegisteredDaysResponse() { RegisteredDays = await _unitOfWork.MealRepository.GetRegisteredDaysAsync() };
        }
    }
}