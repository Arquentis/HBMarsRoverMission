using Hb_mars_rover;
using Xunit;

namespace HbMarsRoverTests
{
    public class RotationTests
    {
        [Fact]
        public void Rotation_Shoud_Add_Degree()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            rotation = rotation.AddDegree(90);

            // Assert
            Assert.Equal(90, rotation.Degree);
        }

        [Fact]
        public void Rotation_Shoud_Get_North()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            // rotation = rotation.AddDegree(0);

            // Assert
            Assert.Equal("N", rotation.GetDirection());
        }

        [Fact]
        public void Rotation_Shoud_Get_East_CW()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            rotation = rotation.AddDegree(90);

            // Assert
            Assert.Equal("E", rotation.GetDirection());
        }

        [Fact]
        public void Rotation_Shoud_Get_South_CW()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            rotation = rotation.AddDegree(90);
            rotation = rotation.AddDegree(90);

            // Assert
            Assert.Equal("S", rotation.GetDirection());
        }

        [Fact]
        public void Rotation_Shoud_Get_West_CW()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            rotation = rotation.AddDegree(90);
            rotation = rotation.AddDegree(90);
            rotation = rotation.AddDegree(90);

            // Assert
            Assert.Equal("W", rotation.GetDirection());
        }

        [Fact]
        public void Rotation_Shoud_Get_West_CCW()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            rotation = rotation.AddDegree(-90);

            // Assert
            Assert.Equal("W", rotation.GetDirection());
        }

        [Fact]
        public void Rotation_Shoud_Get_South_CCW()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            rotation = rotation.AddDegree(-90);
            rotation = rotation.AddDegree(-90);

            // Assert
            Assert.Equal("S", rotation.GetDirection());
        }

        [Fact]
        public void Rotation_Shoud_Get_East_CCW()
        {
            // Arrange
            var rotation = new Rotation();

            // Act
            rotation = rotation.AddDegree(-90);
            rotation = rotation.AddDegree(-90);
            rotation = rotation.AddDegree(-90);

            // Assert
            Assert.Equal("E", rotation.GetDirection());
        }

        [Fact]
        public void Rotation_Shoud_Get_90_Degree_Rotation_By_GetDirection_E()
        {
            // Arrange

            // Act
            var rotation = Rotation.GetRotation("E");

            // Assert
            Assert.Equal(90, rotation.Degree);
        }

        [Fact]
        public void Rotation_Shoud_Get_90_Degree_Rotation_By_GetDirection_S()
        {
            // Arrange

            // Act
            var rotation = Rotation.GetRotation("S");

            // Assert
            Assert.Equal(180, rotation.Degree);
        }

        [Fact]
        public void Rotation_Shoud_Get_90_Degree_Rotation_By_GetDirection_W()
        {
            // Arrange

            // Act
            var rotation = Rotation.GetRotation("S");

            // Assert
            Assert.Equal(270, rotation.Degree);
        }

        [Fact]
        public void Rotation_Shoud_Get_90_Degree_Rotation_By_GetDirection_N()
        {
            // Arrange

            // Act
            var rotation = Rotation.GetRotation("N");

            // Assert
            Assert.Equal(0, rotation.Degree);
        }
    }
}
