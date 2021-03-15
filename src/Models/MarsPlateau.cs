using Hb_mars_rover.Extensions;

namespace Hb_mars_rover
{
    public class MarsPlateau
    {
        private Coordinate _coordinate = new Coordinate();
        public Coordinate Coordinate => _coordinate;

        public MarsPlateau SetInitialCoords(Coordinate coordinate)
        {
            _coordinate = coordinate;
            return this;
        }

        public MarsPlateau SetInitialCoords(string command) => SetInitialCoords(command.ToCoordinate());

        public bool IsInside(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.Y < 0 || _coordinate.X < coordinate.X || _coordinate.Y < coordinate.Y)
                return false;
            return true;
        }
    }
}
