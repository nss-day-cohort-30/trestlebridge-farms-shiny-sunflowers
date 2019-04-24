namespace Trestlebridge.Interfaces
{
    public interface ISeedAndCompostProducing : ISeedProducing, ICompostProducing
    {
        double Harvest ();
        double Compost ();
        string Type { get; }
    }
}