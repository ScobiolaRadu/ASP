using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;

namespace ProiectOpt.Repositories.TypeRepositories
{
    public class InstrumentRepository : GenericRepository<Instrument>, IInstrumentRepository
    {
        public InstrumentRepository(DataContext context) : base(context)
        {

        }
    }
}
