using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;
using ProiectOpt.Repositories.TypeRepositories;

namespace ProiectOpt.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Categorie = new CategorieRepository(_context);
            Client = new ClientRepository(_context);
            ComandaClient = new ComandaClientRepository(_context);
            Fabricant = new FabricantRepository(_context);
            Instrument = new InstrumentRepository(_context);
            Item = new ItemRepository(_context);
            ItemComanda = new ItemComandaRepository(_context);
        }

        public ICategorieRepository Categorie { get; set; }
        public IClientRepository Client { get; set; }
        public IComandaClientRepository ComandaClient { get; set; }
        public IFabricantRepository Fabricant { get; set; }
        public IInstrumentRepository Instrument { get; set; }
        public IItemRepository Item { get; set; }
        public IItemComandaRepository ItemComanda { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
