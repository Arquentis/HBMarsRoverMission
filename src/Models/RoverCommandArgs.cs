using System;

namespace HBMarsMission.Models
{
    public class RoverCommandArgs : EventArgs
    {
        public RoverCommandArgs(CommandType type, RoverVehicle rover)
        {
            Type = type;
            Rover = rover;
        }
        public CommandType Type { get; }
        public RoverVehicle Rover { get; }
    }
}
