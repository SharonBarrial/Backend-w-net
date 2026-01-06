using casetravelers.Infrastructure.Entities;

namespace casetravelers.Infrastructure.Repositories;

public interface IDestinationData
{
   /* public Destination Create(Destination destination);
    public bool ExistsByName(string name);*/
    
   
    Task<Destination> GetByNameAsync(string name);
    Task<int> SaveDestinationAsync(Destination data);
    Task<List<Destination>> GetAllAsync();
    Destination GetById(int id);
    Task<List<Destination>> GetSearchAsync(string name);
    bool UpdateData(Destination data, int id);
    bool DeleteData(int id);
}