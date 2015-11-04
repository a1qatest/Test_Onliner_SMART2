using System.Diagnostics;
using demo.framework.forms;
using OpenQA.Selenium;
namespace demo.framework.Asserts
{
   internal class AssertCheckOfDoNotRemember : BaseForm
    {
         //Убеждаемся что страница загрузилась 
       private static readonly By TitleLocator = By.CssSelector("[id='username']");
       public AssertCheckOfDoNotRemember() : base(TitleLocator, " Forgot form was loaded") { } // в этом методе ничего не трогаем он просто ждет что страница загрузилась и эллемент появился
       public bool CheckOfDoNotRemember(string text) // проверка что что "не помню работает"
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
               return Browser.GetDriver().FindElement(By.XPath(".//*[contains(text(),'" + text + "')]")).Displayed; ;
           }
       }
   }
}
