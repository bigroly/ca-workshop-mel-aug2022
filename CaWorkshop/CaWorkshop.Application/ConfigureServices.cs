using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

using Microsoft.Extensions.DependencyInjection;

namespace CaWorkshop.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddTransient<IGetTodoListsQuery, GetTodoListsQuery>();

        return services;
    }
}
