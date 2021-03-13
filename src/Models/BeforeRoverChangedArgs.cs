using System;

namespace Hb_mars_rover
{
    public class BeforeRoverChangedArgs : EventArgs
    {
        public BeforeRoverChangedArgs(RoverVehicle rover)
        {
            Rover = rover;
        }
        public RoverVehicle Rover { get; }
    }
}
