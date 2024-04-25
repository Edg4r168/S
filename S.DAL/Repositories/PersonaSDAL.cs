using Microsoft.EntityFrameworkCore;
using S.DAL.DataContext;
using S.EN;

namespace S.DAL.Repositories;

public class PersonaSDAL : IPersonaRepository
{
    private readonly SDBContext _context;

    public PersonaSDAL(SDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(); ;
    }

    public async Task<PersonaS> Crear(PersonaS persona)
    {
        try
        {
            await _context.PersonasS.AddAsync(persona);
            await _context.SaveChangesAsync();

        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("DbUpdateException: " + ex.Message);

            if (ex.InnerException != null)
            {
                Console.WriteLine("InnerException: " + ex.InnerException.Message);
            }
            throw;
            throw;
        }
        
        return persona;
    }

    public async Task<int> Delete(int id)
    {
        var personaAliminar = await GetById(id);

        if (personaAliminar is not null) _context.PersonasS.Remove(personaAliminar);
            
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PersonaS>> GetAll()
    {
        return await _context.PersonasS.ToListAsync();
    }

    public async Task<PersonaS> GetById(int id)
    {
        var persona = await _context.PersonasS.FirstOrDefaultAsync(persona => persona.Id == id);

        return persona ?? new PersonaS();
    }

    public IEnumerable<PersonaS> Search(string nombre)
    {

        var personas = _context.PersonasS.Where(p => p.NombreS == nombre).ToList();

        return personas;
    }

    public async Task<int> Update(PersonaS persona)
    {
        _context.PersonasS.Update(persona);

        return await _context.SaveChangesAsync();
    }
}
