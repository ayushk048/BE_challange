using Microsoft.Azure.Cosmos;
using _Diabetes_BE_challenge.Entities;
using User = _Diabetes_BE_challenge.Entities.User;

namespace _Diabetes_BE_challenge.CosmosConfig.Service
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<User>> GetUsersAsync(string query);

        Task<User> GetUserAsync(string emailAddress);

        Task<User> AddUserAsync(User item);

        Task<ContainerResponse> Health();

    }
}
