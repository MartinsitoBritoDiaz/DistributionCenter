using DistributionCenter.Application.Interfaces.Services;
using DistributionCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributionCenter.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly Container _container;
        
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseId = "DistributeCenterDB";
        private readonly string _containerId = "Packages";

        public PackageService(CosmosClient dbClient, string databaseName, string containerName)
        {
            _cosmosClient = dbClient;
            _container = dbClient.GetContainer(databaseName, containerName);
        }
        public async Task<string> Create(Package package)
        {

            package.Id = Guid.NewGuid().ToString();
            await _container.CreateItemAsync(package, new PartitionKey(package.Id));
            return package.Id;
        }

        public async Task<Package> GetByIdAsync(int id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Package>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Package>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<Package>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<Package>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _container.DeleteItemAsync<Package>(id.ToString(), new PartitionKey(id.ToString()));
                return true;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }
    }

    
}
