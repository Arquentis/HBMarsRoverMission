namespace Hb_mars_rover
{
    public struct Coordinate
    {
        private int _x;
        public int X => _x;


        private int _y;
        public int Y => _y;

        public Coordinate SetCoords(int x, int y)
        {
            return this.SetX(x).SetY(y);
        }
        public Coordinate SetCoords(Coordinate coordinate)
        {
            return this.SetX(coordinate.X).SetY(coordinate.Y);
        }
        public Coordinate SetX(int x)
        {
            _x = x;
            return this;
        }
        public Coordinate SetY(int y)
        {
            _y = y;
            return this;
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}
