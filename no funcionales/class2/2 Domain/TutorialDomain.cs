using _3_Data;
using _3_Shared;

namespace _2_Domain;

public class TutorialDomain : ITutorialDomain
{
    //Esta capa también va a necesitar el modelo de datos (Capa Data)
    private ITutorialData _tutorialData;
    public TutorialDomain(ITutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }
    
    
    //Aqui se implementan todas las reglas de negocio
    public bool Save(Tutorial data)
    {
        //pARA USAR constants de la capa shared
        //Constants.IGV;
        
        //Si alguno de los datos contiene la letra a, no se permite guardar el registro
        if (data.Name.Contains("a"))
            throw new Exception("No a in the name allowed"); 
        
        return _tutorialData.Save(data);
        //return true;
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