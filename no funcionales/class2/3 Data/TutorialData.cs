using _3_Data.Contexts;

namespace _3_Data;

//Aquí tienes que implementar los metodos de la interfaz ITutorialData
public class TutorialData : ITutorialData
{
    private LearningCenterContext _learningCenterContext;
    
    public TutorialData(LearningCenterContext learningCenterContext)
    {
        _learningCenterContext = learningCenterContext;
    }
    
    public List<Tutorial> GetAll()
    {
        //Conecta con la BBDD MySQL y obtiene los tutoriales
        //Aqui tienes que retornar una lista de tutoriales con datos de prueba
        /*List<Tutorial> data = new List<Tutorial>();
        data.Add(new Tutorial { Id = 1, Name = "Tutorial 1", Description = "Description 1", IsActive = true });
        data.Add(new Tutorial { Id = 2, Name = "Tutorial 2", Description = "Description 2", IsActive = true });
        data.Add(new Tutorial { Id = 3, Name = "Tutorial 3", Description = "Description 3", IsActive = true });
*/
        //return _learningCenterContext.Tutorials.ToList();
        return _learningCenterContext.Tutorials.Where(t=>t.IsActive).ToList();
    }

    public Tutorial GetById(int id)
    {
        return _learningCenterContext.Tutorials.Where(t=>t.Id == id && t.IsActive).FirstOrDefault();
    }

    public bool Save(Tutorial data)
    //Aqui debe devolver la base de datos
    {
        return true;
    }

    public bool Update(Tutorial data, int id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}