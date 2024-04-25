using S.EN;

namespace S.DAL.Repositories;

public interface IPersonaRepository
{
    Task<PersonaS> Crear(PersonaS persona);

    Task<int> Update(PersonaS persona);

    Task<int> Delete(int id);

    Task<PersonaS> GetById(int id);

    Task<IEnumerable<PersonaS>> GetAll();

    IEnumerable<PersonaS> Search(string nombre);
}
