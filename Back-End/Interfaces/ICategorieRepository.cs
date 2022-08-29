using ProiectOpt.Models;

namespace ProiectOpt.Interfaces
{
    public interface ICategorieRepository : IGenericRepository<Categorie>
    {
        IEnumerable<Categorie> GetInstrumenteCuCorzi();
    }
}
