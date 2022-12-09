namespace MockAssessment3.Tests
{
    public class FarmerTest
    {
        [Fact]
        public void TotalInFarmethodMethod()
        {
            //Arrange
            Farmer sut = new Farmer();

            //Act
            int result = sut.Farm();

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void TotalInHungerProperty()
        {
            //Arrange
            Farmer sut = new Farmer();

            //Act
            int result = sut.Hunger;

            //Assert
            Assert.Equal(1, result);
        }
    }
}