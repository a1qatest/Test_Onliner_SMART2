using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework.Asserts
{
    internal class AssertCheckIncorrectConfPass : BaseForm
    {
       private static readonly By TitleLocator = By.CssSelector("[id='password_confirm']");// проверили что мы на форме изменения паролля
       public AssertCheckIncorrectConfPass() : base(TitleLocator, "Edit Password Form") { }
        public bool CheckIncorrectConfPass() // роверка что отображается ошибка при вводе неверного подтверждения пароля 
        {
            Browser.WaitForPageToLoad();
            bool checkIncorrectPass = false;

            try
            {
                return Browser.GetDriver().FindElement(By.XPath(".//*[contains(text(),'Пароли не совпадают')]")).Displayed;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    }
}
