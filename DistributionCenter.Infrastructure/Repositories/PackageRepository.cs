using DistributionCenter.Domain.Models;
using DistributionCenter.Infrastructure.Interfaces;
using Microsoft.Azure.Cosmos;

namespace DistributionCenter.Infrastructure.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly Container _container;

    public PackageRepository(
        string conn,
        string key,
        string databaseName,
        string containerName)
    {
        var cosmosClient = new CosmosClient(conn, key, new CosmosClientOptions() { });
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<IEnumerable<Package>> GetPackagesAsync()
    {
        var query = _container.GetItemQueryIterator<Package>(new QueryDefinition("SELECT * FROM package"));
        
        var results = new List<Package>();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        
        return results;
    }

    public async Task<Package> GetPackageAsync(string id, string type)
    {
        try
        {
            var response = await _container.ReadItemAsync<Package>(id, new PartitionKey(type));
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Package> CreatePackageAsync(Package package)
    {
        var response = await _container.CreateItemAsync(package, new PartitionKey(package.Type));
        return response.Resource;
    }

    public async Task<Package> UpdatePackageAsync(Package package)
    {
        var response = await _container.UpsertItemAsync(package, new PartitionKey(package.Type));
        return response.Resource;
    }

    public async Task<bool> DeletePackageAsync(string id, string type)
    {
        var response = await _container.DeleteItemAsync<Package>(id, new PartitionKey(type));
        
        if(response.Resource != null)
            return true;
        
        return false;
    }
}