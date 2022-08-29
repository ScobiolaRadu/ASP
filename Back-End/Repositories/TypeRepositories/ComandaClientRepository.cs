using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;

namespace ProiectOpt.Repositories.TypeRepositories
{
    public class ComandaClientRepository : GenericRepository<ComandaClient>, IComandaClientRepository
    {
        public ComandaClientRepository(DataContext context) : base(context)
        {

        }
    }
}
