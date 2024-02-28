using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
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
            //Arrange
            var registroPO = new RegistroPO(_driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "Marcos Paulo",
                email: "marcos.poo@gmail.com",
                senha: "123",
                confirmSenha: "123"
            );

            //Act
            registroPO.SubmeteFormulario();

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
            //Arrange
            var registroPO = new RegistroPO(_driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: nome,
                email: email,
                senha: senha,
                confirmSenha: confirmSenha
            );

            //Act
            registroPO.SubmeteFormulario();

            //Assert - devo ser direcionado para uma pagina de agradecimento.
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(_driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "",
                senha: "",
                confirmSenha: ""
            );

            //Act
            registroPO.SubmeteFormulario();

            //Assert
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(_driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "Marcos",
                senha: "",
                confirmSenha: ""
            );

            //Act
            registroPO.SubmeteFormulario();

            //Assert

            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }

    }
}
