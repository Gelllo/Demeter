using FastEndpoints;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;

namespace Demeter.Web.Endpoints.Users
{
    public class GetMeals : EndpointWithoutRequest
    {
        private IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetMeals(IQueryDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Get("/meals/{UserID}/{Date}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var req = new GetMealsRequest() { Date = Route<string>("Date"), UserID = Route<string>("UserID") };
            await SendAsync(await _dispatcher.Dispatch<GetMealsRequest, GetMealsResponse>(req, ct));
        }
    }
}