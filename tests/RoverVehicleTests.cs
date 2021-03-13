using Hb_mars_rover;
using Xunit;

namespace HbMarsRoverTests
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
            Assert.Equal("N", myRover.GetDirectionHeading());
        }

        [Fact]
        public void Rover_Should_Look_E_After_Rotate_Right()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Rotate(RotationDirection.R);

            // Assert
            Assert.Equal("E", myRover.GetDirectionHeading());
            Assert.Equal(90, myRover.Rotation);
        }

        [Fact]
        public void Rover_Should_Look_W_After_Rotate_Left()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Rotate(RotationDirection.L);

            // Assert
            Assert.Equal("W", myRover.GetDirectionHeading());
            Assert.Equal(-90, myRover.Rotation);
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
            Assert.Equal("S", myRover.GetDirectionHeading());
            Assert.Equal(-180, myRover.Rotation);
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
            Assert.Equal("S", myRover.GetDirectionHeading());
            Assert.Equal(180, myRover.Rotation);
        }

        [Fact]
        public void Rover_Should_Move_North_Once()
        {
            // Arrange
            var myRover = new RoverVehicle();

            // Act
            myRover.Move();

            // Assert
            Assert.Equal("N", myRover.GetDirectionHeading());
            Assert.Equal(0, myRover.Rotation);
            Assert.Equal(1, myRover.Y);
            Assert.Equal("0 1 N", myRover.ToString());
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
            Assert.Equal("E", myRover.GetDirectionHeading());
            Assert.Equal(90, myRover.Rotation);
            Assert.Equal(1, myRover.X);
            Assert.Equal("1 0 E", myRover.ToString());
        }
    }
}
