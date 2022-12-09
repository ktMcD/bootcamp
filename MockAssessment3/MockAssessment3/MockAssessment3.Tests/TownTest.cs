namespace MockAssessment3.Tests
{
    public class TownTest
    {
        [Fact]
        public void TotalOfAllFarmMethods()
        {
            //Arrange
            Town sut = new Town();

            //Act
            int result = sut.Harvest();
            
            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void TotalOfAllHungerProperties()
        {
            //Arrange
            Town sut = new Town();

            //Act
            int result = sut.CalculateFoodConsumption();

            //Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void TrueIfFoodConsumptionIsLessThanHarvest()
        {
            //Arrange
            Town sut = new Town();

            //Act
            bool result = sut.SurviveTheWinter();

            //Assert
            Assert.False(result);
        }
    }
}