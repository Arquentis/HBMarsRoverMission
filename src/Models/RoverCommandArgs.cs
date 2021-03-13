using System;

namespace Hb_mars_rover
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
