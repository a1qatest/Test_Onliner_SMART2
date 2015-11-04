using System.Diagnostics;
using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework.Asserts
{
    internal class AssertSignIn : BaseForm
    {
         //Убеждаемся что страница загрузилась 
        private static readonly By TitleLocator = By.CssSelector("[class='exit']");
        public AssertSignIn() : base(TitleLocator, "SignIn Form") { } // в этом методе ничего не трогаем он просто ждет что страница загрузилась и эллемент появился
       
        public bool SignIn(string text) // проверка что мы залогинены 
        {
            Browser.WaitForPageToLoad();
            Trace.WriteLine("Is the page contains the text '" + text + "'", "Document");

            try
            {
                return Browser.GetDriver().FindElement(By.XPath(".//*[@class='exit'][contains(text(),'" + text + "')]")).Displayed;
            }
            catch (WebDriverException)
            {
                Trace.WriteLine("The page is not contains the text '" + text + "'", "Document");
                return false;
            }

        }

    }
}
