using System.Diagnostics;
using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework.Asserts
{
    internal class AssertCheckOfPhoto : BaseForm
    {
         //Убеждаемся что страница загрузилась 
        private static readonly By TitleLocator = By.CssSelector("ul[class='catalog-bar__list']");
        public AssertCheckOfPhoto() : base(TitleLocator, "Catalog bar list") { } // в этом методе ничего не трогаем он просто ждет что страница загрузилась и эллемент появился
        public bool CheckOfPhoto(string text) // проверка что присутствует текст "Фотоаппараты"
        {

            Browser.WaitForPageToLoad();
            Trace.WriteLine("Is the page contains the text '" + text + "'", "Document");

            try
            {
                return Browser.GetDriver().FindElement(By.XPath(".//*[@class='catalog-bar__item']/a[contains(text(),'" + text + "')]")).Displayed;
            }
            catch (WebDriverException)
            {
                Trace.WriteLine("The page is not contains the text '" + text + "'", "Document");
                return false;
            }

        }
    
    }
}
