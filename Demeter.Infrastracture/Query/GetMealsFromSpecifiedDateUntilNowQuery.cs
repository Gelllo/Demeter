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


namespace Demter.Infrastracture.Database.Query.GlucoseRecordsQueries
{
    public class GetMealsFromSpecifiedDateUntilNowQuery : IQueryHandler<GetMealsFromSpecifiedDateUntilNowRequest, GetMealsFromSpecifiedDateUntilNowResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMealsFromSpecifiedDateUntilNowQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<GetMealsFromSpecifiedDateUntilNowResponse> Handle(GetMealsFromSpecifiedDateUntilNowRequest query, CancellationToken cancellation)
        {
            return new GetMealsFromSpecifiedDateUntilNowResponse(){Meals = _mapper.Map<IEnumerable<MealDTO>>(await _unitOfWork.MealRepository.GetMealsFromSpecifiedDateUntilNow(query.UserID, query.Date))};
        }
    }
}