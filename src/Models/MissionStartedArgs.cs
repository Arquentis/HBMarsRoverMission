using System;

namespace Hb_mars_rover
{
    public class MissionStartedArgs : EventArgs
    {
        public MissionStartedArgs(int numberOfRovers)
        {
            NumberOfRovers = numberOfRovers;
        }
        public int NumberOfRovers { get; }
    }
}
