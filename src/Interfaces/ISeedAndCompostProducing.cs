namespace Trestlebridge.Interfaces
{
    public interface ISeedAndCompostProducing : ISeedProducing, ICompostProducing
    {
       new double Harvest ();
        new double Compost ();
        new string Type { get; }
    }
}