using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Promocode.DomainServices.Interfaces;
using Promocode.DomainServices.Repository;

namespace Promocode.DomainServices.Implementation;

public class PromocodeDomainService : IPromocodeDomainService
{
    private readonly ILogger<PromocodeDomainService> _logger;
    private readonly ICouchbaseRepository _couchbaseRepository;
    public PromocodeDomainService(ICouchbaseRepository couchbaseRepository, ILogger<PromocodeDomainService> logger)
    {
        _couchbaseRepository = couchbaseRepository;
        _logger = logger;
    }

    public async Task<bool> CreatePromocode()
    {
        var promoCode = new Domain.Aggregates.Promocode()
        {
            Name = GenerateRandomPromocodeName(),
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(10),
            UserGroup = 1234
        };
        
        _logger.LogInformation(JsonConvert.SerializeObject(promoCode));

        await _couchbaseRepository.Insert(promoCode);
        
        return true;
    }

    private string GenerateRandomPromocodeName()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[5];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var result = new string(stringChars);
        return result.ToUpper();
    }
}