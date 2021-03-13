namespace Hb_mars_rover
{
    public class RoverCommand
    {
        public RoverCommand(CommandType type, string parameter = "")
        {
            Type = type;
            Parameter = parameter;
        }
        public CommandType Type { get; }
        public string Parameter { get; }
    }
}
