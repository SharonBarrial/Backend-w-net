using casetravelers.Infrastructure.Contexts;
using casetravelers.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace casetravelers.Infrastructure.Repositories;

public class DestinationData : IDestinationData
{
    private TravelerContext _context;

    public DestinationData(TravelerContext context)
    {
        _context = context;
    }
    public async Task<int> SaveDestinationAsync(Destination destination)
    {
        _context.Destinations.Add(destination);
        await _context.SaveChangesAsync();
        return destination.Id;
    }

    public async Task<Destination> GetByNameAsync(string name)
    {
        var destination = await _context.Destinations
            .Where(d => d.Name == name)
            .FirstOrDefaultAsync();
        return destination;

    }
    
    public async Task<List<Destination>> GetAllAsync()
    {
        var destinations = await _context.Destinations.ToListAsync();
        return destinations;
    }
    
    public Destination GetById(int id)
    {
        var destination = _context.Destinations
            .Where(d => d.Id == id)
            .FirstOrDefault();
        return destination;
    }
    
    public async Task<List<Destination>> GetSearchAsync(string name)
    {
        var destinations = await _context.Destinations
            .Where(d => d.Name.Contains(name))
            .ToListAsync();
        return destinations;
    }
    
    public bool UpdateData(Destination destination, int id)
    {
        var existingDestination = _context.Destinations
            .Where(d => d.Id == id)
            .FirstOrDefault();
        if (existingDestination == null)
        {
            throw new Exception("Destination not found");
        }
        existingDestination.Name = destination.Name;
        existingDestination.MaxUsers = destination.MaxUsers;
        existingDestination.IsRisky = destination.IsRisky;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteData(int id)
    {
        var exitingTutorial = _context.Destinations
            .Where(t => t.Id == id)
            .FirstOrDefault();

        // _learningCenterContext.Tutorials.Remove(exitingTutorial);
        //exitingTutorial.IsActive = false;

        _context.Destinations.Update(exitingTutorial);
        _context.SaveChanges();
        return true;
    }
}