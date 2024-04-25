
using Microsoft.EntityFrameworkCore;
using S.DAL.Repositories;
using S.EN;

namespace S.BL.Services;

public class PersonaSBL : IPersonService
{
    private readonly IPersonaRepository _repository;

    public PersonaSBL(IPersonaRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException();
    }

    public async Task<PersonaS> Crear(PersonaS persona)
    {
       return await _repository.Crear(persona);
    }

    public Task<int> Delete(int id)
    {
        return _repository.Delete(id);
    }

    public async Task<IEnumerable<PersonaS>> GetAll()
    {
        return await _repository.GetAll();
    }

    public Task<PersonaS> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public IEnumerable<PersonaS> Search(string nombre)
    {
        return _repository.Search(nombre);
    }

    public async Task<int> Update(PersonaS persona)
    {
        return await _repository.Update(persona);
    }
}
