using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfeturarRegistro
    {
        private IWebDriver _driver;

        public AoEfeturarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //Arrange - Dado chrme aberto.
            //dados de registro válidos informado
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = _driver.FindElement(By.Id("Nome"));

            //Email
            var inputEmail = _driver.FindElement(By.Id("Email"));

            //Password
            var inputPassword = _driver.FindElement(By.Id("Password"));

            //ConfirmPassword
            var inputConfirmPassword = _driver.FindElement(By.Id("ConfirmPassword"));

            //Botão de registro
            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Marcos Paulo");
            inputEmail.SendKeys("marcos@gmail.com");
            inputPassword.SendKeys("123");
            inputConfirmPassword.SendKeys("123");

            //Act - efetuo o registro
            botaoRegistro.Click();

            //Assert - devo ser direcionado para uma pagina de agradecimento.
            Assert.Contains("Obrigado", _driver.PageSource);
        }

        [Theory]
        [InlineData("", "marcos.poo@gmail.com", "123", "123")]
        [InlineData("Marcos Paulo", "marcos", "123", "123")]
        [InlineData("Marcos Paulo", "marcos.poo@gmail.com", "123", "456")]
        [InlineData("Marcos Paulo", "marcos.poo@gmail.com", "123", "")]
        public void DadoInfoInvalidasDeveContinuarNaHome(string nome, string email, string senha, string confirmSenha)
        {
            //Arrange - Dado chrme aberto.
            //dados de registro válidos informado
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = _driver.FindElement(By.Id("Nome"));

            //Email
            var inputEmail = _driver.FindElement(By.Id("Email"));

            //Password
            var inputPassword = _driver.FindElement(By.Id("Password"));

            //ConfirmPassword
            var inputConfirmPassword = _driver.FindElement(By.Id("ConfirmPassword"));

            //Botão de registro
            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputPassword.SendKeys(senha);
            inputConfirmPassword.SendKeys(confirmSenha);

            //Act - efetuo o registro
            botaoRegistro.Click();

            //Assert - devo ser direcionado para uma pagina de agradecimento.
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Botão de registro
            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            //Act
            botaoRegistro.Click();

            //Assert
            IWebElement elemento = _driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));

            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoEmailEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Email
            var inputEmail = _driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys("Marcos");

            //Botão de registro
            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            //Act
            botaoRegistro.Click();

            //Assert
            IWebElement elemento = _driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));

            Assert.Equal("Please enter a valid email address.", elemento.Text);
        }

    }
}
