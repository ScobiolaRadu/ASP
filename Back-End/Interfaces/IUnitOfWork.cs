namespace ProiectOpt.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategorieRepository Categorie { get; }
        IClientRepository Client { get; }
        IComandaClientRepository ComandaClient { get; }
        IFabricantRepository Fabricant { get; } 
        IInstrumentRepository Instrument { get; }
        IItemRepository Item { get; }
        IItemComandaRepository ItemComanda { get; }

        int Complete();


    }
}
