using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;

namespace ProiectOpt.Repositories.TypeRepositories
{
    public class FabricantRepository : GenericRepository<Fabricant>, IFabricantRepository
    {
        public FabricantRepository(DataContext context) : base(context)
        {

        }
    }
}
