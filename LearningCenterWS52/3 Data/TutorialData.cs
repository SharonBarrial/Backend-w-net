using _3_Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _3_Data;

public class TutorialData :iTutorialData
{
    private LearningCenterContext _learningCenterContext;
    
    public TutorialData(LearningCenterContext learningCenterContext)
    {
        _learningCenterContext = learningCenterContext;
    } 
    public async Task<List<Tutorial>> GetAllAsync()
    {
        // COnecta BBDD MySQL
        /* List<Tutorial> data = new List<Tutorial>();
         data.Add(new Tutorial(){ Name = "tutorial 1"});
         data.Add(new Tutorial(){ Name = "tutorial 2"});
         data.Add(new Tutorial(){ Name = "tutorial 3"});*/

        var result = await _learningCenterContext.Tutorials.Where(t => t.IsActive).ToListAsync();

        return result;
    }
    public Tutorial GetById(int id)
    {
        return _learningCenterContext.Tutorials.Where(t => t.Id == id && t.IsActive).FirstOrDefault();
    }

    public async Task<Tutorial> GetByNameAsync(string Name)
    {
        return await _learningCenterContext.Tutorials.Where(t => t.Name == Name && t.IsActive).FirstOrDefaultAsync();

    }

    public async Task<bool> SaveAsync(Tutorial data)
    {
        using (var transaction = await _learningCenterContext.Database.BeginTransactionAsync())
        {
            try
            {
                data.IsActive = true;
                _learningCenterContext.Tutorials.Add(data); //no se refleja
                await _learningCenterContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }

        }

        
        return true;
    }

    public bool Update(Tutorial data, int id)
    {
        var exitingTutorial = _learningCenterContext.Tutorials.Where(t => t.Id == id).FirstOrDefault();
        exitingTutorial.Name = data.Name;
        exitingTutorial.Description = data.Description;

        _learningCenterContext.Tutorials.Update(exitingTutorial);
        
        _learningCenterContext.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var exitingTutorial = _learningCenterContext.Tutorials.Where(t => t.Id == id).FirstOrDefault();
        
        // _learningCenterContext.Tutorials.Remove(exitingTutorial);
        exitingTutorial.IsActive = false;
       
        _learningCenterContext.Tutorials.Update(exitingTutorial);
        _learningCenterContext.SaveChanges();
        return true;
    }
    
    
    /*
    public List<Tutorial> getAll()
    {
        //Conecta con el BBDD MySQL 
        List<Tutorial> data = new List<Tutorial>();
        
        data.Add(new Tutorial(){Name = "tutorial 1"});
        data.Add(new Tutorial(){Name = "tutorial 2"});
        data.Add(new Tutorial(){Name = "tutorial 3"});

        return data;
    }

    public Tutorial GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save(Tutorial data)
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
    }*/
}