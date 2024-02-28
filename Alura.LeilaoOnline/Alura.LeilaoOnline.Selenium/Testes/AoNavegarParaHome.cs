using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver _driver;

        //Setup
        public AoNavegarParaHome(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //Arrange

            //Act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Leil�es", _driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //Arrange

            //Act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Pr�ximos Leil�es", _driver.PageSource);
        }

    }
}