using Common.Interface;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class EventRepository(OmegaGamesDbContext _context) : IEventService<Event>
{
    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        return await _context.Events.Include(e => e.Ticket).ToListAsync();
    }

    public async Task AddEventAsync(Event e)
    {
        await _context.Events.AddAsync(e);
        await _context.SaveChangesAsync();
    }
}