namespace _3_Data;

public interface iTutorialData
{
    List<Tutorial> GetAllAsync();

    Tutorial GetById(int id);
    
    Task<Tutorial> GetByNameAsync(string Name);
    
    Task<bool> SaveAsync(Tutorial data);
    
    bool Update(Tutorial data, int id);
    bool Delete(int id);
}

