using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://cursos.alura.com.br/dashboard");

            Assert.Contains("Alura", driver.Title);
        }
    }
}
