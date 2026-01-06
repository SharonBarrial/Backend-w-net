using casetravelers.Infrastructure.Entities;

namespace casetravelers.Domain;

public interface IDestinationDomain
{
    /*public Destination Create(Destination destination);*/
    Task<int>SaveDestinationAsync(Destination destination);
    bool UpdateDestination(Destination destination, int id);
    
}