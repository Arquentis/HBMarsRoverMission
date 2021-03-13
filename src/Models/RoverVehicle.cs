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
    }
}
