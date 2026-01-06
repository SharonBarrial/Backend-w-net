using _3_Data;
using Microsoft.VisualBasic;
using _3_Shared;
namespace _2_Domain;

public class TutorialDomain : iTutorialDomain
{
    private iTutorialData _tutorialData;
    public TutorialDomain(iTutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }
    public async Task<bool> SaveAsync(Tutorial data)
    {
        //Validaciones de formato aqui np van, sino en Tutorial Request.cs
        /*if(data.Name=== "" && data.Name.Length > 50)
            throw new Exception("Name is required and should be less than 50 characters"*/
        
        //Aqui solo van validaciones de negocio

        //Constans.IGV;
        ///if(data.Name=== "" && data.Name.Length >3 )

        //Constans.IGV;
        // if (data.Name.Contains('a'))
        //    throw new Exception("No a in the name allowed");
        
        /*if (data.Name.Contains('a'))
            throw new Exception("No a in the name allowed");
        
        return _tutorialData.Save(data);*/
        
        if (data.Name == "")
            throw new Exception("NAME CAN'T BE NULL");
        
        if (data.Name.Length > 5)
            throw new Exception("NAME can be more than 5 chars");
        
        var tutorial = await _tutorialData.GetByNameAsync(data.Name);
        if (tutorial != null )
            throw new Exception("Name already exits");
        
        var total = (await _tutorialData.GetAllAsync()).Count();
        if( total >= Constans.MAX_TUTORIALS)
            throw new Exception("limited exceeded");
        
        if(data.Sections.Count() < Constans.MIN_SECCTIONS )
            throw new Exception("Al leaset 2 sections");
        
        return await _tutorialData.SaveAsync(data);
        
    }

    public bool Update(Tutorial data, int id)
    {
        
        //Business Rules
        var existingTutorial = _tutorialData.GetById(id);
        
        if (existingTutorial.Description != data.Description)
            throw new Exception("No allowed to update description");
        /*throw new NotImplementedException();*/
        
        return _tutorialData.Update(data, id);
    }

    public bool Delete(int id)
    {
        //Business Rules
        /*throw new NotImplementedException();*/
        return _tutorialData.Delete(id);
    }
}