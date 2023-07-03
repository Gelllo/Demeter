using FastEndpoints;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;

namespace Demeter.Web.Endpoints.Users
{
    public class GetMealsFromSpecifiedDateUntilNow : EndpointWithoutRequest
    {
        private IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetMealsFromSpecifiedDateUntilNow(IQueryDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Get("/meals/fromDateUntilNow/{UserID}/{Date}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var req = new GetMealsFromSpecifiedDateUntilNowRequest() { Date = Route<string>("Date"), UserID = Route<string>("UserID") };
            await SendAsync(await _dispatcher.Dispatch<GetMealsFromSpecifiedDateUntilNowRequest, GetMealsFromSpecifiedDateUntilNowResponse>(req, ct));
        }
    }
}