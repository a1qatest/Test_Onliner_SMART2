using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    /// <summary>
    /// Класс описывает главную страницу Tut
    /// </summary>
    internal class MainForm : BaseForm 

    {
        //Убеждаемся что Main страница загрузилась 
        private static readonly By TitleLocator = By.CssSelector("a[href='http://www.onliner.by/']");
        public MainForm() : base(TitleLocator, "Main Form") { } // в этом методе ничего не трогаем он просто ждет что страница загрузилась и эллемент появился
        
        //переходим на форму логина 
        Link loginLink = new Link(By.CssSelector(".auth-bar__item.auth-bar__item--text"), "Login link");
        public void OpenLogInForm()
        {
            loginLink.Click();
        }
        //переходим с main страници к настройкам аккаунта  
        Link accountLink = new Link(By.CssSelector("[class='user-name']>a"), "Account Form link");
        public void OpenAccountForm()
        {
            accountLink.Click();
        }


        //разлогинимся
        Link logoutLink = new Link(By.CssSelector("a[class='exit']"), "Logout link"); 
        public void LogOutForm()
        {
            logoutLink.Click();
           
        }
        /*

        // Форма для ввода текста в поисковую область и нажатию кнопки "Найти"
        TextBox FindText = new TextBox(By.Id("search_from_str"), "Текстовое поле 'Поиск'");
        Button SearchButton = new Button(By.CssSelector("input[class='button big']"),"Кнопка найти");
        
        public void Search() 
        {
           FindText.SetText("специалист по тестированию");   
           SearchButton.Click();
           Browser.WaitForPageToLoad();
         //  CheckOfSearch ("Sorry, an error occurred processing your request. Error code: 3b7d6a44-acf7-4240-a482-d5e0aafabf0b Please provide our support team with this error code");
        }


        */
        



    }
}


