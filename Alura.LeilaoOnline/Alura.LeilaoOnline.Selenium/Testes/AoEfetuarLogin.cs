using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver _driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            _driver = fixture.Driver; 
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //Arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("marcos.poo@gmail.com", "123");

            //Act
            loginPO.SubmeteFormulario();
            
            //Assert
            Assert.Contains("Dashboard", _driver.Title);
        }

        [Fact]
        public void DadoCredenciasInvalidasDeveContinuarLogin()
        {
            //Arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("marcos.poo@gmail.com", "");

            //Act
            loginPO.SubmeteFormulario();

            //Assert
            Assert.Contains("Login", _driver.PageSource);
        }

    }
}
