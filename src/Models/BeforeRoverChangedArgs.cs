using System;
using System.Collections.Generic;
using System.Text;

namespace HBMarsMission.Models
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
