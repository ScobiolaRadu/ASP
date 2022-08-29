using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;

namespace ProiectOpt.Repositories.TypeRepositories
{
    public class CategorieRepository : GenericRepository<Categorie>, ICategorieRepository
    {
        public CategorieRepository(DataContext context) : base(context)
        {

        }

        IEnumerable<Categorie> ICategorieRepository.GetInstrumenteCuCorzi()
        {
            return DataContext.categories.Where(instr => instr.CategorieNume == "Chitare").ToList();
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
