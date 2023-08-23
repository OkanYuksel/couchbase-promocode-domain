namespace Promocode.DomainServices.Interfaces;

public interface IPromocodeDomainService
{
    public Task<bool> CreatePromocode();
}