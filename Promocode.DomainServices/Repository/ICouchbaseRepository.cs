namespace Promocode.DomainServices.Repository;

public interface ICouchbaseRepository
{
    Task Insert(Domain.Aggregates.Promocode promocode);
}