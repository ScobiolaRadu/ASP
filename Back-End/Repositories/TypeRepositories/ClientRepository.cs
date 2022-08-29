using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;

namespace ProiectOpt.Repositories.TypeRepositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        {

        }
    }
}
