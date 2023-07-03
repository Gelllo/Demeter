using FastEndpoints;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;

namespace Demeter.Web.Endpoints.Users
{
    public class DeleteMeal : EndpointWithoutRequest
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public DeleteMeal(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Delete("/meals/{MealID}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var req = new DeleteMealRequest() { Id = Route<int>("MealID") };
            await _dispatcher.Dispatch<DeleteMealRequest, DeleteMealResponse>(req, ct);
        }
    }
}