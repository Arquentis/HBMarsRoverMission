using System;

namespace HBMarsMission.Models
{
    public struct Rotation
    {
        private int _degree;
        public int Degree
        {
            get { return _degree; }
            private set { _degree = value % 360; }
        }

        public Rotation AddDegree(int degree)
        {
            Degree += degree;
            return this;
        }

        public string GetDirection()
        {
            // total 
            switch (Degree)
            {
                case 0:
                    return "N";
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

        public static Rotation GetRotation(string direction)
        {
            var _instance = new Rotation();
            switch (direction)
            {
                case "N":
                    return _instance;
                case "E":
                    return _instance.AddDegree(90);
                case "S":
                    return _instance.AddDegree(180);
                case "W":
                    return _instance.AddDegree(270);
                default:
                    throw new ArgumentException($"Invalid direction. {direction}");
            }
        }
    }
}
