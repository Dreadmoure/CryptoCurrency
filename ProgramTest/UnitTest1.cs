using CryptoCurrency;

namespace ProgramTest
{
    public class UnitTest1
    {
        [Fact]
        public void SetPricePerUnit_NegativePrice_ThrowsArgumentException()
        {
            //Arrange
            Converter converter = new Converter();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => converter.SetPricePerUnit("Bitcoin", -1));
        }

        [Fact]
        public void SetPricePerUnit_ValidPrice_SetsPrice()
        {
            //Arrange
            Converter converter = new Converter();

            //Act
            converter.SetPricePerUnit("Bitcoin", 0);

            //Assert
            Assert.Equal(0, converter.GetPricePerUnit("Bitcoin"));
        }

        [Fact]
        public void SetPricePerUnit_ExistingCurrency_OverwritePrice()
        {
            //Arrange
            Converter converter = new Converter();
            converter.SetPricePerUnit("Bitcoin", 0);

            //Act
            double newPrice = 1;
            converter.SetPricePerUnit("Bitcoin", newPrice);

            //Assert
            Assert.Equal(newPrice, converter.GetPricePerUnit("Bitcoin"));
        }

        [Fact]
        public void ConvertCurrency_ValidCurrencies_ReturnsConvertedAmount()
        {
            //Arrange
            Converter converter = new Converter();
            converter.SetPricePerUnit("Bitcoin", 100);
            converter.SetPricePerUnit("Ethereum", 50);

            //Act
            double convertedAmount = converter.Convert("Bitcoin", "Ethereum", 2);

            //Assert
            Assert.Equal(4, convertedAmount);
        }

        [Fact]
        public void ConvertCurrency_InvalidFromCurrency_ThrowsArgumentException()
        {
            //Arrange
            Converter converter = new Converter();
            converter.SetPricePerUnit("Ethereum", 50);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => converter.Convert("Bitcoin", "Ethereum", 2));
        }

        [Fact]
        public void ConvertCurrency_InvalidToCurrency_ThrowsArgumentException()
        {
            //Arrange
            Converter converter = new Converter();
            converter.SetPricePerUnit("Bitcoin", 100);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => converter.Convert("Bitcoin", "Ethereum", 2));
        }
    }
}
