using System;

namespace HBMarsMission.Models
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
