namespace _3_Data;

public class TutorialOracle : ITutorialData
{
    public List<Tutorial> GetAll()
    {
        //Conecta con la BBDD MySQL y obtiene los tutoriales
        //Aqui tienes que retornar una lista de tutoriales con datos de prueba
        List<Tutorial> data = new List<Tutorial>();
        data.Add(new Tutorial { Id = 1, Name = "Tutorial 1", Description = "Oracle 1", IsActive = true });
        data.Add(new Tutorial { Id = 2, Name = "Tutorial 2", Description = "Oracle 2", IsActive = true });
        data.Add(new Tutorial { Id = 3, Name = "Tutorial 3", Description = "Oracle 3", IsActive = true });

        return data;
    }

    public Tutorial GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save(Tutorial data)
    {
        throw new NotImplementedException();
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