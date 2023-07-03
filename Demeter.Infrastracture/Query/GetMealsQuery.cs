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
    public class GetMealsQuery : IQueryHandler<GetMealsRequest, GetMealsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMealsQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<GetMealsResponse> Handle(GetMealsRequest query, CancellationToken cancellation)
        {
            return new GetMealsResponse() { MealsRecords = _mapper.Map<IEnumerable<MealDTO>>(await _unitOfWork.MealRepository.GetMealsAsync(query.UserID, query.Date))};
        }
    }
}