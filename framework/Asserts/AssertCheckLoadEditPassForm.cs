using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework.Asserts
{
    internal class AssertCheckLoadEditPassForm : BaseForm
    {
       private static readonly By TitleLocator = By.CssSelector("[id='password_confirm']");// проверили что мы на форме изменения паролля
       public AssertCheckLoadEditPassForm() : base(TitleLocator, "Edit Password Form") { }
        public bool CheckLoadEditPassForm() // проверка что форма изменения пароля загрузилась
        {
            Browser.WaitForPageToLoad();

            try
            {
                return Browser.GetDriver().FindElement(By.CssSelector("input[name='old_password']")).Displayed;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    }
}
