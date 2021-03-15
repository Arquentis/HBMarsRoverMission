using HBMarsMission.Models;
using System;
using System.Linq;

namespace HBMarsMission.Extensions
{
    public static class CommandStringExtensions
    {
        public static Coordinate ToCoordinate(this string command)
        {
            var _parts = command.Split(" ");
            if (_parts.Length != 2) throw new ArgumentException("Invalid command");
            if (!int.TryParse(_parts[0], System.Globalization.NumberStyles.Integer, null, out int x)) throw new ArgumentException("Invalid integer parameter for x coordinate");
            if (!int.TryParse(_parts[1], System.Globalization.NumberStyles.Integer, null, out int y)) throw new ArgumentException("Invalid integer parameter for x coordinate");
            return new Coordinate().SetCoords(x, y);
        }

        public static RoverCommand[] ParseCommands(this string command)
        {
            return command.Select(c =>
            {
                var _input = c.ToString().ToUpper();
                switch (_input)
                {
                    case "L":
                    case "R":
                        return new RoverCommand(CommandType.Rotate, c.ToString());
                    case "M": return new RoverCommand(CommandType.Move);
                    default:
                        throw new ArgumentException("Invalid command parameter");
                }
            }).ToArray();
        }
    }
}
