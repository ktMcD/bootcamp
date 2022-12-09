namespace MockAssessment3.Tests
{
    public class SlackerTest
    {
        [Fact]
        public void TotalInFarmMethod()
        {
            //Arrange
            Slacker sut = new Slacker();

            //Act
            int result = sut.Farm();

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void TotalInHungerProperty()
        {
            //Arrange
            Slacker sut = new Slacker();

            //Act
            int result = sut.Hunger;

            //Assert
            Assert.Equal(3, result);
        }
    }
}