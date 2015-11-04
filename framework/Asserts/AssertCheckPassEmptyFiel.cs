using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework.Asserts
{
   internal class AssertCheckPassEmptyFiel : BaseForm
    {
         private static readonly By TitleLocator = By.CssSelector("[id='password_confirm']");// проверили что мы на форме изменения паролля
         public AssertCheckPassEmptyFiel() : base(TitleLocator, "Edit Password Form") { }
        public bool CheckPassEmptyFiel() // проверка что отображаются ошибки при попытке сохранить пароль с пустыми полями
        {
            Browser.WaitForPageToLoad();
            bool checkEmptyPass = false;

            try
            {
                bool oldPass = Browser.GetDriver().FindElement(By.XPath(".//*[contains(text(),'Введите старый пароль')]")).Displayed;
                bool newPass = Browser.GetDriver().FindElement(By.XPath(".//*[contains(text(),'Введите новый пароль')]")).Displayed;
                if (oldPass && newPass)
                {
                    return checkEmptyPass = true;
                }
            }
            catch (WebDriverException)
            {
                return checkEmptyPass;
            }
            return checkEmptyPass;
        }
    }
}
