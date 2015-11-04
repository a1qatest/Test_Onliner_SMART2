using System.Diagnostics;
using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework.Asserts
{
   internal class AssertCheckOfLogOut : BaseForm
    {
        //Убеждаемся что страница загрузилась 
       private static readonly By TitleLocator = By.CssSelector("[id='userbar']");
        public AssertCheckOfLogOut() : base(TitleLocator, "User bar is present") { } // в этом методе ничего не трогаем он просто ждет что страница загрузилась и эллемент появился
        public bool CheckOfLogOut(string text) // проверка что мы вылогенины
        {
            Browser.WaitForPageToLoad();
            Trace.WriteLine("Is the page contains the text '" + text + "'", "Document");

            try
            {
                return Browser.GetDriver().FindElement(By.XPath(".//*[@class='auth-bar__item auth-bar__item--text'][contains(text(),'" + text + "')]")).Displayed;
            }
            catch (WebDriverException)
            {
                Trace.WriteLine("The page is not contains the text '" + text + "'", "Document");
                return false;
            }
        }
    }
}
