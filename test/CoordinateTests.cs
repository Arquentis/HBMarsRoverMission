using HBMarsMission.Models;
using Xunit;

namespace HBMarsMissionTest
{
    public class CoordinateTests
    {
        [Fact]
        public void Coordinate_Shoud_Change()
        {
            // Arrange
            var coordinate = new Coordinate();

            // Act
            coordinate = coordinate.SetCoords(3, 5);

            // Assert
            Assert.Equal(3, coordinate.X);
            Assert.Equal(5, coordinate.Y);
        }

        [Fact]
        public void Coordinate_Shoud_Update_With_New_Coordinate()
        {
            // Arrange
            var coordinate = new Coordinate();
            var newCoordinate = new Coordinate().SetCoords(4, 6);

            // Act
            coordinate = coordinate.SetCoords(newCoordinate);

            // Assert
            Assert.Equal(4, coordinate.X);
            Assert.Equal(6, coordinate.Y);
        }

        [Fact]
        public void Coordinate_Shoud_Set_X()
        {
            // Arrange
            var coordinate = new Coordinate();

            // Act
            coordinate = coordinate.SetX(3);

            // Assert
            Assert.Equal(3, coordinate.X);
        }

        [Fact]
        public void Coordinate_Shoud_Set_Y()
        {
            // Arrange
            var coordinate = new Coordinate();

            // Act
            coordinate = coordinate.SetY(5);

            // Assert
            Assert.Equal(5, coordinate.Y);
        }
    }
}
