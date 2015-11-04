using demo.framework.forms;
using OpenQA.Selenium;


namespace demo.framework.Asserts
{
    internal class AssertCheckIncorrectOldPass :BaseForm
    {
       private static readonly By TitleLocator = By.CssSelector("[id='password_confirm']");// проверили что мы на форме изменения паролля
       public AssertCheckIncorrectOldPass() : base(TitleLocator, "Edit Password Form") { }
       public bool CheckIncorrectOldPass() // проверка что отображается ошибка при вводе неверного старого пароля 
        {
            Browser.WaitForPageToLoad();
           
            try
            {
                return Browser.GetDriver().FindElement(By.XPath(".//*[contains(text(),'Неверный текущий пароль')]")).Displayed;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    
    }
}
