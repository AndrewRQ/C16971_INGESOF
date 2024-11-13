using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            // Arrange
            var url = "http://localhost:8080/";

            // Act
            _driver.Navigate().GoToUrl(url);

            // Assert
            Assert.IsNotNull(_driver);
        }

        [Test]
        public void Click_Add_Country_Button_And_Fill_Form()
        {
            // Arrange
            var url = "http://localhost:8080/";
            _driver.Navigate().GoToUrl(url);

            // Act
            var addCountryButton = _driver.FindElement(By.Id("agregar"));
            addCountryButton.Click();

            // Verifica que la URL actual sea la de la página de formulario
            Assert.AreEqual("http://localhost:8080/pais", _driver.Url);

            // LLenando formulario
            _driver.FindElement(By.Id("name")).SendKeys("Brasil");
            _driver.FindElement(By.Id("continente")).SendKeys("Asia");
            _driver.FindElement(By.Id("idioma")).SendKeys("Portugués");

            // Encuentra y haz clic en el botón "Guardar"
            var saveButton = _driver.FindElement(By.Id("guardar"));
            saveButton.Click();

            // Verifica que la URL actual sea la de la lista
            Assert.AreEqual("http://localhost:8080/", _driver.Url);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
