using System;

namespace Hb_mars_rover
{
    public class RoverVehicle
    {
        private int _rotation;
        public int Rotation
        {
            get { return _rotation; }
            private set { _rotation = value % 360; }
        }

        private int _x;
        public int X
        {
            get { return _x; }
            private set { _x = value; }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            private set { _y = value; }
        }

        public void Move()
        {
            var direction = GetDirectionHeading();
            switch (direction)
            {
                case "N":
                    Y += 1;
                    break;
                case "S":
                    Y -= 1;
                    break;
                case "E":
                    X += 1;
                    break;
                case "W":
                    X -= 1;
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
                    Rotation -= 90;
                    break;
                case RotationDirection.R:
                    Rotation += 90;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Rotation");
            }
        }
        public string GetDirectionHeading()
        {
            // total 
            switch (Rotation)
            {
                case 0: return "N";
                case 90:
                case -270:
                    return "E";
                case 180:
                case -180:
                    return "S";
                case 270:
                case -90:
                    return "W";
                default:
                    return "<invalid-heading>";
            }
        }


        public override string ToString()
        {
            return $"{X} {Y} {GetDirectionHeading()}";
        }


    }
}
