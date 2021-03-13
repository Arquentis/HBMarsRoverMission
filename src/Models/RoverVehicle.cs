using System;

namespace Hb_mars_rover
{
    public class RoverVehicle
    {
        private Rotation _rotation = new Rotation();
        public Rotation Rotation => _rotation;

        private Coordinate _coordinate = new Coordinate();
        public Coordinate Coordinate => _coordinate;
        public string Name { get; }
        private bool _isCrashed = false;
        public bool IsCrashed => _isCrashed;

        public RoverVehicle()
        {
            Name = "Rover";
        }
        public RoverVehicle(string name)
        {
            Name = name;
        }

        public void SetInitialCoords(Coordinate coordinate) => _coordinate = coordinate;
        public void SetInitialRotation(Rotation rotation) => _rotation = rotation;
        public void Move()
        {
            var direction = Rotation.GetDirection();
            switch (direction)
            {
                case "N":
                    _coordinate = Coordinate.SetY(Coordinate.Y + 1);
                    break;
                case "S":
                    _coordinate = Coordinate.SetY(Coordinate.Y - 1);
                    break;
                case "E":
                    _coordinate = Coordinate.SetX(Coordinate.X + 1);
                    break;
                case "W":
                    _coordinate = Coordinate.SetX(Coordinate.X - 1);
                    break;
                default:
                    throw new ArgumentException("Invalid Direction");
            }
        }

        public void Rotate(RotationDirection direction)
        {
            switch (direction)
            {
                case RotationDirection.L:
                    _rotation = Rotation.AddDegree(-90);
                    break;
                case RotationDirection.R:
                    _rotation = Rotation.AddDegree(+90);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Rotation");
            }
        }

        public void Crash() => this._isCrashed = true;

        public override string ToString()
        {
            if (_isCrashed)
            {
                return $"{Name} is crashed. Last coords: {Coordinate.ToString()} {Rotation.GetDirection()}";
            }
            return $"{Name} - {Coordinate.ToString()} {Rotation.GetDirection()}";
        }
    }
}
