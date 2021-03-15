using HBMarsMission.Models;
using Xunit;

namespace HBMarsMissionTest
{
    public class MarsPlateauTests
    {
        [Fact]
        public void MarsPlateau_Shoud_Set_Initial_Coords()
        {
            // Arrange
            var marsPlateau = new MarsPlateau();

            // Act
            marsPlateau.SetInitialCoords(new Coordinate().SetCoords(5, 10));

            // Assert
            Assert.Equal(5, marsPlateau.Coordinate.X);
            Assert.Equal(10, marsPlateau.Coordinate.Y);
        }

        [Fact]
        public void MarsPlateau_Shoud_Set_Initial_Coords_ByCommand()
        {
            // Arrange
            var marsPlateau = new MarsPlateau();

            // Act
            marsPlateau.SetInitialCoords("5 10");

            // Assert
            Assert.Equal(5, marsPlateau.Coordinate.X);
            Assert.Equal(10, marsPlateau.Coordinate.Y);
        }

        [Fact]
        public void MarsPlateau_Shoud_GivenCoordinates_ShoulBe_Inside_Plateau()
        {
            // Arrange
            var marsPlateau = new MarsPlateau();
            marsPlateau.SetInitialCoords("5 5");

            // Act
            var isInside = marsPlateau.IsInside(new Coordinate().SetCoords(3, 4));

            // Assert
            Assert.Equal(isInside, true);
        }
    }
}
