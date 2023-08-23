using Couchbase.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Promocode.DomainServices.Interfaces;
using Promocode.DomainServices.Repository;

namespace Promocode.Infrastructure.Repositories.CouchbaseRepository.Implementation;

public class CouchbaseRepository : ICouchbaseRepository
{
    private readonly ILogger<CouchbaseRepository> _logger;
    private IBucketProvider _bucketProvider;

    public CouchbaseRepository(ILogger<CouchbaseRepository> logger, IBucketProvider bucketProvider)
    {
        _logger = logger;
        _bucketProvider = bucketProvider;
    }

    public async Task Insert(Domain.Aggregates.Promocode promocode)
    {
        var bucket = await _bucketProvider.GetBucketAsync("bucket");
        var collection = await bucket.CollectionAsync("Promocodes");
        await collection.InsertAsync(promocode.Id.ToString(), promocode);
    }
}