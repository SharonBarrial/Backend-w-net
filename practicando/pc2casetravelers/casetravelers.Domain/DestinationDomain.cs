using casetravelers.Infrastructure.Entities;
using casetravelers.Infrastructure.Repositories;

namespace casetravelers.Domain;

public class DestinationDomain : IDestinationDomain
{
    private readonly IDestinationData _destinationData;

    public DestinationDomain(IDestinationData destinationData)
    {
        _destinationData = destinationData;
    }
    public async Task<int> SaveDestinationAsync(Destination destination)
    {
        var existingDestination = await _destinationData.GetByNameAsync(destination.Name);
        if (existingDestination != null)
        {
            throw new Exception("Destination already exists");
        }
        if (destination.MaxUsers <= 0)
        {
            throw new Exception("Max users must be greater than 0");
        }

        if (destination.IsRisky != 0 && destination.IsRisky != 1)
        {
            throw new Exception("IsRisky must be 0 or 1");
        }

        return await _destinationData.SaveDestinationAsync(destination);
    }
    
    public bool UpdateDestination(Destination destination, int id)
    {
        var existingDestination = _destinationData.GetById(id);
        if (existingDestination == null)
        {
            throw new Exception("Destination not found");
        }
        if (destination.MaxUsers <= 0)
        {
            throw new Exception("Max users must be greater than 0");
        }

        if (destination.IsRisky != 0 && destination.IsRisky != 1)
        {
            throw new Exception("IsRisky must be 0 or 1");
        }
        
       return _destinationData.UpdateData(destination, id);
    }
}