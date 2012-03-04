namespace Battleships
{
    public interface IShip
    {
        GridValues GridValue  { get; }
        int Length { get; }
    }
}