using System;
using System.Linq;
using Hb_mars_rover.Extensions;

namespace Hb_mars_rover
{
    public class MarsMission
    {
        private MarsPlateau _plateau = null;
        private CommandState state = CommandState.NotInit;
        public CommandState State => state;
        public MarsPlateau Plateau => _plateau;
        private int _roverIndex = 0;
        private RoverVehicle[] _rovers = null;

        public event EventHandler RoverCommandExecuted;
        public event EventHandler BeforeRoverChanged;
        public event EventHandler MissionStarted;

        public void Start(params RoverVehicle[] rovers)
        {
            if (rovers == null || rovers.Length == 0) throw new ArgumentException("Min 1 rover required for the mission!");
            _plateau = new MarsPlateau();
            _rovers = rovers;
            state = CommandState.SetPlateauCoordinates;
            OnMissionStarted(new MissionStartedArgs(_rovers.Length));
        }

        private void NextState()
        {
            switch (state)
            {
                case CommandState.SetPlateauCoordinates:
                    state = CommandState.SetRoverPosition;
                    break;
                case CommandState.MoveRover:
                    state = CommandState.SetRoverPosition;
                    SwitchToNextRover();
                    break;
                case CommandState.SetRoverPosition:
                    state = CommandState.MoveRover;
                    break;
                default:
                    break;
            }
        }

        private void SwitchToNextRover()
        {
            OnBeforeRoverChanged(new BeforeRoverChangedArgs(GetCurrentRover()));
            _roverIndex++;
            if (_roverIndex == _rovers.Length) throw new MissionOverException();
            if (_roverIndex >= 0 && _rovers[_roverIndex].IsCrashed) SwitchToNextRover();
        }

        public RoverVehicle GetCurrentRover()
        {
            if (_roverIndex < 0) throw new MissionOverException();
            return _rovers[_roverIndex];
        }

        private void CheckRoverInPlateau(RoverVehicle rover)
        {
            if (!_plateau.IsInside(rover.Coordinate)) rover.Crash();
        }

        private void SetRoverPosition(string command)
        {
            var rover = GetCurrentRover();
            var parts = command.Split(" ");
            if (parts.Length != 3) throw new ArgumentException($"Invalid command: {command}");
            rover.SetInitialCoords($"{parts[0]} {parts[1]}".ToCoordinate());
            CheckRoverInPlateau(rover);
            if (rover.IsCrashed)
            {
                SwitchToNextRover();
                throw new Exception($"{rover.Name} is crashed.");
            }
            rover.SetInitialRotation(Rotation.GetRotation(parts[2].ToUpper()));
            OnRoverCommandExecuted(new RoverCommandArgs(CommandType.SetPosition, rover));
        }

        private void MoveRover(string command)
        {
            if (string.IsNullOrEmpty(command)) throw new ArgumentException($"Invalid Command: {command}");
            var listOfCommands = command.Trim().ParseCommands();
            var rover = GetCurrentRover();
            foreach (var item in listOfCommands)
            {
                switch (item.Type)
                {
                    case CommandType.Rotate:
                        rover.Rotate(Enum.Parse<RotationDirection>(item.Parameter));
                        OnRoverCommandExecuted(new RoverCommandArgs(CommandType.Rotate, rover));
                        break;
                    case CommandType.Move:
                        rover.Move();
                        OnRoverCommandExecuted(new RoverCommandArgs(CommandType.Move, rover));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid Command Type");
                }
                CheckRoverInPlateau(rover);
            }
        }

        public RoverVehicle[] GetRovers()
        {
            return _rovers;
        }

        public MarsMission ExecuteCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) throw new ArgumentException("No command entered");
            switch (state)
            {
                case CommandState.NotInit:
                    throw new ArgumentException("Mission not started yet. Please Start mission first");
                case CommandState.SetPlateauCoordinates:
                    // parse coordinates
                    _plateau.SetInitialCoords(command.ToCoordinate());
                    break;
                case CommandState.SetRoverPosition:
                    SetRoverPosition(command);
                    break;
                case CommandState.MoveRover:
                    MoveRover(command);
                    break;
                default:
                    throw new ArgumentException("Invalid State");
            }
            NextState();
            return this;
        }

        protected virtual void OnRoverCommandExecuted(RoverCommandArgs e) => RoverCommandExecuted?.Invoke(this, e);
        protected virtual void OnBeforeRoverChanged(BeforeRoverChangedArgs e) => BeforeRoverChanged?.Invoke(this, e);
        protected virtual void OnMissionStarted(MissionStartedArgs e) => MissionStarted?.Invoke(this, e);
    }
}
