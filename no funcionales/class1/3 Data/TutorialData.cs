namespace _3_Data;

//Aquí tienes que implementar los metodos de la interfaz ITutorialData
public class TutorialData : ITutorialData
{
    public List<Tutorial> GetAll()
    {
        //Conecta con la BBDD MySQL y obtiene los tutoriales
        //Aqui tienes que retornar una lista de tutoriales con datos de prueba
        List<Tutorial> data = new List<Tutorial>();
        data.Add(new Tutorial { Id = 1, Name = "Tutorial 1", Description = "Description 1", IsActive = true });
        data.Add(new Tutorial { Id = 2, Name = "Tutorial 2", Description = "Description 2", IsActive = true });
        data.Add(new Tutorial { Id = 3, Name = "Tutorial 3", Description = "Description 3", IsActive = true });

        return data;
    }

    public Tutorial GetById(int id)
    {
        throw new NotImplementedException();
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