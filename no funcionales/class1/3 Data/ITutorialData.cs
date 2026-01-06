namespace _3_Data;

//metodos de la clase TutorialData

public interface ITutorialData
{
    List<Tutorial> GetAll();
    
    Tutorial GetById(int id);
    
    bool Save(Tutorial data);
    
    bool Update(Tutorial data, int id);
    
    bool Delete(int id);
    
}