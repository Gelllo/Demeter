using FastEndpoints;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;

namespace Demeter.Web.Endpoints.Users
{
    public class GetMealsRegisteredDays : EndpointWithoutRequest
    {
        private IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetMealsRegisteredDays(IQueryDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Get("/meals/days/{UserID}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var req = new GetMealsRegisteredDaysRequest(){ UserID = Route<string>("UserID") };
            await SendAsync(await _dispatcher.Dispatch<GetMealsRegisteredDaysRequest, GetMealsRegisteredDaysResponse>(req, ct));
        }
    }
}