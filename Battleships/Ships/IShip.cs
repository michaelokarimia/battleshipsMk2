using Battleships.Enums;

namespace Battleships.Ships
{
    public interface IShip
    {
        GridValues GridValue  { get; }
        int Length { get; }
    }
}