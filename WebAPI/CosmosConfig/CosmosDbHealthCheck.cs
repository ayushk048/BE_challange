using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;
using _Diabetes_BE_challenge.CosmosConfig.Service;

namespace _Diabetes_BE_challenge.CosmosConfig
{
    public class CosmosDbHealthCheck : IHealthCheck
    {
        private readonly ICosmosDbService _cosmosDbService;

        public CosmosDbHealthCheck(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {

                ContainerResponse health = await _cosmosDbService.Health();
                if (health.StatusCode == HttpStatusCode.OK)
                {
                    return HealthCheckResult.Healthy();
                }
                return HealthCheckResult.Unhealthy();
            }
            catch
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
