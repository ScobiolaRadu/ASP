using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;

namespace ProiectOpt.Repositories.TypeRepositories
{
    public class ItemComandaRepository : GenericRepository<ItemComanda>, IItemComandaRepository
    {
        public ItemComandaRepository(DataContext context) : base(context)
        {

        }
    }
}
