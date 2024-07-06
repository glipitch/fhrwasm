using FhrWasm.Distribution.Configuration;
using FhrWasm.RatingsApi;
namespace FhrWasm.Distribution;
public static class DistributionExtensions
{
    public static IServiceCollection AddRatingsDistribution(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Templates>(configuration.GetSection("DistributionTemplates"));
        services.AddHttpClient(
            "ratings-api",
            config =>
            {
                config.BaseAddress = new Uri(configuration.GetValue<string>("BaseUrl"));
                config.DefaultRequestHeaders.Add("x-api-version", "2");
            }
        );
        services.AddSingleton<DistributionService>();
        services.AddSingleton<RatingsApiService>();
        return services;
    }
    public static decimal AsPercent(this decimal input) => input * 100;
    public static decimal AsFractionOf(this decimal input, decimal denominator) => input / denominator;
}