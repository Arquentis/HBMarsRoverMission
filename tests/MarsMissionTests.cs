using Hb_mars_rover;
using Xunit;

namespace HbMarsRoverTests
{
    public class MarsMissionTests
    {
        [Fact]
        public void MarsMission_Should_Start()
        {
            // Arrange
            var marsMission = new MarsMission();

            // Act
            marsMission.Start(new RoverVehicle());

            // Assert
            Assert.NotEqual(marsMission.State, CommandState.NotInit);
        }

        [Fact]
        public void MarsMission_Should_Get_CurrentRover()
        {
            // Arrange
            var marsMission = new MarsMission();
            var myRover = new RoverVehicle();
            marsMission.Start(myRover);

            // Act
            var currentRover = marsMission.GetCurrentRover();

            // Assert
            Assert.Equal(currentRover, myRover);
        }

        [Fact]
        public void MarsMission_Should_Execute_PlateuCoordsCommand()
        {
            // Arrange
            var marsMission = new MarsMission();
            var myRover = new RoverVehicle();
            marsMission.Start(myRover);

            // Act
            marsMission.ExecuteCommand("5 8");

            // Assert
            Assert.Equal(marsMission.State, CommandState.SetRoverPosition);
            Assert.Equal(5, marsMission.Plateau.Coordinate.X);
            Assert.Equal(8, marsMission.Plateau.Coordinate.Y);
        }

        [Fact]
        public void MarsMission_Should_Execute_SetRoverPositionCommand()
        {
            // Arrange
            var marsMission = new MarsMission();
            var myRover = new RoverVehicle();
            marsMission.Start(myRover);
            marsMission.ExecuteCommand("5 8");

            // Act
            marsMission.ExecuteCommand("2 3 S");

            // Assert
            Assert.Equal(marsMission.State, CommandState.MoveRover);
            Assert.Equal(2, myRover.Coordinate.X);
            Assert.Equal(3, myRover.Coordinate.Y);
            Assert.Equal(180, myRover.Rotation.Degree);
        }

        [Fact]
        public void MarsMission_Should_Execute_MoveRoverCommand()
        {
            // Arrange
            var marsMission = new MarsMission();
            var myRover = new RoverVehicle("Test");
            marsMission.Start(myRover);
            marsMission.ExecuteCommand("5 8");
            marsMission.ExecuteCommand("2 3 S");

            // Act
            try
            {
                marsMission.ExecuteCommand("LMMLMM");
            }
            catch (MissionOverException)
            {
            }

            // Assert
            Assert.Equal(4, myRover.Coordinate.X);
            Assert.Equal(5, myRover.Coordinate.Y);
            Assert.Equal(0, myRover.Rotation.Degree);
            Assert.Equal("Test - 4 5 N", myRover.ToString());
        }
        
        [Fact]
        public void MarsMission_Should_Complete()
        {
            // Arrange
            var marsMission = new MarsMission();
            var myRover = new RoverVehicle();
            marsMission.Start(myRover);
            marsMission.ExecuteCommand("5 8");
            marsMission.ExecuteCommand("2 3 S");
            var isMissionCompleted = false;

            // Act
            try
            {
                marsMission.ExecuteCommand("M");
            }
            catch (MissionOverException)
            {
                isMissionCompleted = true;
            }

            // Assert

            Assert.True(isMissionCompleted);
        }
    }
}
