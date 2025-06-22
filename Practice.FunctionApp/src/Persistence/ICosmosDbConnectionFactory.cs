using FunctionApp.IsolatedDemo.Api.Persistence.DbFactory;
using Microsoft.Azure.Cosmos;

namespace FunctionApp.IsolatedDemo.Api.Persistence;

internal interface ICosmosDbConnectionFactory : IDbConnectionFactory<Container>
{
}
