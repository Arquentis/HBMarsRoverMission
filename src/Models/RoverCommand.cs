namespace HBMarsMission.Models
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
