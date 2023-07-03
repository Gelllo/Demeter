using FastEndpoints;
using Demeter.Application;
using Demeter.Application.Requests.Meals;
using Demeter.Application.Responses.Meals;

namespace Demeter.Web.Endpoints.Users
{
    public class UpdateMeal : Endpoint<UpdateMealRequest, UpdateMealResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public UpdateMeal(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Put("/meals/{UserID}/{MealId}");
            Roles("USER");
        }

        public override async Task HandleAsync(UpdateMealRequest req, CancellationToken ct)
        {
            req.Meal.UserId = Route<string>("UserID");
            req.Meal.Id = Route<int>("MealId");

            await SendOkAsync(await _dispatcher.Dispatch<UpdateMealRequest, UpdateMealResponse>(req, ct));
        }
    }
}