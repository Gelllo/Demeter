using FastEndpoints;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;

namespace Demeter.Web.Endpoints.Users
{
    public class AddMeal : Endpoint<AddMealRequest, AddMealResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public AddMeal(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Post("/meals/{UserID}");
            Roles("USER");
        }

        public override async Task HandleAsync(AddMealRequest req, CancellationToken ct)
        {
            req.Meal.UserId = Route<string>("UserID");
            await SendAsync(await _dispatcher.Dispatch<AddMealRequest, AddMealResponse>(req, ct));
        }
    }
}