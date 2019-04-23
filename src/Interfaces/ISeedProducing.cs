namespace Trestlebridge.Interfaces
{
    public interface ISeedProducing
    {
        double Harvest ();

        string Type { get; }
    }
}