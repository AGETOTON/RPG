namespace AgetotonRPG.Interfaces
{
    public interface IMoveable
    {
        float X { get; set; }

        float Y { get; set; }

        int CurrentFrame { get; set; }
    }
}