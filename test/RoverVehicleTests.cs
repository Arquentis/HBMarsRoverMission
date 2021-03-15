using HBMarsMission.Models;
using Xunit;

namespace HBMarsMissionTest
{
    public class RoverVehicleTests
    {
        [Fact]
        public void Rover_Should_Look_N_Initially()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act

            // Assert
            Assert.Equal("N", myRover.Rotation.GetDirection());
        }

        [Fact]
        public void Rover_Should_Look_E_After_Rotate_Right()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Rotate(RotationDirection.R);

            // Assert
            Assert.Equal("E", myRover.Rotation.GetDirection());
            Assert.Equal(90, myRover.Rotation.Degree);
        }

        [Fact]
        public void Rover_Should_Look_W_After_Rotate_Left()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Rotate(RotationDirection.L);

            // Assert
            Assert.Equal("W", myRover.Rotation.GetDirection());
            Assert.Equal(-90, myRover.Rotation.Degree);
        }

        [Fact]
        public void Rover_Should_Look_S_After_2xRotate_Left()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Rotate(RotationDirection.L);
            myRover.Rotate(RotationDirection.L);

            // Assert
            Assert.Equal("S", myRover.Rotation.GetDirection());
            Assert.Equal(-180, myRover.Rotation.Degree);
        }

        [Fact]
        public void Rover_Should_Look_S_After_2xRotate_Right()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Rotate(RotationDirection.R);
            myRover.Rotate(RotationDirection.R);

            // Assert
            Assert.Equal("S", myRover.Rotation.GetDirection());
            Assert.Equal(180, myRover.Rotation.Degree);
        }

        [Fact]
        public void Rover_Should_Move_North_Once()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Move();

            // Assert
            Assert.Equal("N", myRover.Rotation.GetDirection());
            Assert.Equal(0, myRover.Rotation.Degree);
            Assert.Equal(1, myRover.Coordinate.Y);
            Assert.Equal($"{myRover.Name} - 0 1 N", myRover.ToString());
        }

        [Fact]
        public void Rover_Should_Move_East_Once()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Rotate(RotationDirection.R);
            myRover.Move();

            // Assert
            Assert.Equal("E", myRover.Rotation.GetDirection());
            Assert.Equal(90, myRover.Rotation.Degree);
            Assert.Equal(1, myRover.Coordinate.X);
            Assert.Equal($"{myRover.Name} - 1 0 E", myRover.ToString());
        }

        [Fact]
        public void Rover_Should_Crash()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Crash();

            // Assert
            Assert.Equal(true, myRover.IsCrashed);
        }
    }
}
