namespace Trestlebridge.Interfaces
{
    public interface IEggFeatherMeatProducing : IEggProducing, IFeatherProducing, IMeatProducing
    {
        string Type { get; }
    }
}