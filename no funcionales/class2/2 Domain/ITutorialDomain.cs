using _3_Data;

namespace _2_Domain;

public interface ITutorialDomain
{
    bool Save(Tutorial data);
    
    bool Update(Tutorial data, int id);
    
    bool Delete(int id);
}