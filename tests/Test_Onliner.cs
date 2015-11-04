using demo.framework;
using demo.framework.Asserts;
using demo.framework.forms;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;


namespace demo.tests
{

    public class OnlinerTestCase : BaseTest
    {
        
        [Test]
        public void OnlinercheckFoto() //Проверка на наличие ссылки "Фотоаппараты на странице"
        {
            int step = 1;
            
            var homePage = new MainForm();
            LogStep(step++, "Открытие main page www.onliner.by + переход на форму логина");
            homePage.OpenLogInForm();
          
            var logIn = new LogIn();
            LogStep(step++, "Логинимся под своими учетными данными");
            logIn.Login();
          
            var checkLogIn = new AssertSignIn();
            LogStep(step++, "Проверяем что логин успешен");
            Assert.IsTrue(checkLogIn.SignIn("Выйти"));
          
            var checkPhoto = new AssertCheckOfPhoto();
            LogStep(step++, "Проверяем что на странице есть ссылка 'Фотоаппараты'");
            Assert.IsTrue(checkPhoto.CheckOfPhoto("Фотоаппараты"));
        }

        [Test]
        public void OnlinerCheckLogOut() // Проверка что Logout работает
        {
            int step = 1;

            var homePage = new MainForm();
            LogStep(step++, "Открытие main page www.onliner.by+ переход на форму логина");
            homePage.OpenLogInForm();

            var login = new LogIn();
            LogStep(step++, "Логинимся под своими учетными данными");
            login.Login();

            var checkLogIn = new AssertSignIn();
            LogStep(step++, "Проверяем что логин успешен");
            Assert.IsTrue(checkLogIn.SignIn("Выйти"));

            var logOut = new MainForm();
            logOut.LogOutForm();
           
            LogStep(step++, "Проверяем что логаут успешен");
            var checkLogOut = new AssertCheckOfLogOut();
            Assert.IsTrue(checkLogOut.CheckOfLogOut("Вход"));
        }

        [Test]
        public void OnlinerCheckForgot_Negativ() // Проверка что забытый пароль не высылается на левый email
        {
            int step = 1;

            var homePage = new MainForm();
            LogStep(step++, "Открытие main page www.onliner.by+ переход на форму логина");
            homePage.OpenLogInForm();

            var forgot = new LogIn();
            LogStep(step++, "Переход по ссылке 'Не помню'");
            forgot.DoNotRemember();

            var doNotRemember = new DoNotRememberForm();
            LogStep(step++, "Ввод email для пересылки'");
            doNotRemember.SendEmailNegative();

            var checkDNR =new AssertCheckOfDoNotRemember();
            LogStep(step++, "Проверка на то что есть ошибка при вводе неверного email'");
            Assert.IsTrue(checkDNR.CheckOfDoNotRemember("Вы ввели неправильный ник или e-mail"));
        }

         [Test]
        public void OnlinerCheckForgot_Positive() // Проверка что забытый пароль высылается на верный email
        {
            int step = 1;

            var fomePage = new MainForm();
            LogStep(step++, "Открытие main page www.onliner.by+ переход на форму логина");
            fomePage.OpenLogInForm();

            var forgot = new LogIn();
            LogStep(step++, "Переход по ссылке 'Не помню'");
            forgot.DoNotRemember();

            var doNotRemember = new DoNotRememberForm();
            LogStep(step++, "Ввод email для пересылки'");
            doNotRemember.SendEmailPositive();

            var checkDNR = new AssertCheckOfDoNotRemember();
            LogStep(step++, "Инструкции успешно ртправлены на указанный email'");
            Assert.IsTrue(checkDNR.CheckOfDoNotRemember("Спасибо!"));
        }

         [Test]
         public void OnlinerCheckEditPassWithIncorrectOldPass() // Проверка что отображается верная ошибка при вводе неверного старого пароля
         {
             int step = 1;
             
             var homePage = new MainForm();
             LogStep(step++, "Открытие main page www.onliner.by+ переход на форму логина");
             homePage.OpenLogInForm();

             var logIn = new LogIn();
             LogStep(step++, "Логинимся под своими учетными данными");
             logIn.Login();

             var checkLogIn = new AssertSignIn();
             LogStep(step++, "Проверяем что логин успешен");
             Assert.IsTrue(checkLogIn.SignIn("Выйти"));

             var personalDataForm = new MainForm();
             LogStep(step++, "Переходим к учетным данным пользователя");
             personalDataForm.OpenAccountForm(); 

             var editUserDataForm = new UserAccountForm();
             LogStep(step++, "Переходим к редактированию данных пользователя");
             editUserDataForm.EditPersonalData();

             var openPassForm = new EditUserDataForm();
             LogStep(step++, "Переходим на форму изменения пароля пользователя");
             openPassForm.OpenPasswordForm();

             var editPassWithIncorrectOldPass = new PasswordForm();
             LogStep(step++, "Заполняем поля формы изменения пароля с вводом неверного старого пароля'");
             editPassWithIncorrectOldPass.EditPassIncorrectOldPass();

             var checkIncorrectOldPass = new AssertCheckIncorrectOldPass();
             LogStep(step++, "Проверяем что при вводе неправильного пароля отображается верная ошибка'");
             checkIncorrectOldPass.CheckIncorrectOldPass();
         }

         [Test]
         public void OnlinerCheckEditPassWithIncorrectConfPass() // Проверка что отображается верная ошибка при вводе неверного подтверждения нового пароля
         {
             int step = 1;

             var homePage = new MainForm();
             LogStep(step++, "Открытие main page www.onliner.by+ переход на форму логина");
             homePage.OpenLogInForm();

             var logIn = new LogIn();
             LogStep(step++, "Логинимся под своими учетными данными");
             logIn.Login();

             var checkLogIn = new AssertSignIn();
             LogStep(step++, "Проверяем что логин успешен");
             Assert.IsTrue(checkLogIn.SignIn("Выйти"));

             var personalDataForm = new MainForm();
             LogStep(step++, "Переходим к учетным данным пользователя");
             personalDataForm.OpenAccountForm();

             var editUserDataForm = new UserAccountForm();
             LogStep(step++, "Переходим к редактированию данных пользователя");
             editUserDataForm.EditPersonalData();

             var openPassForm = new EditUserDataForm();
             LogStep(step++, "Переходим на форму изменения пароля пользователя");
             openPassForm.OpenPasswordForm();

             var editPassWithIncorrectConfPass = new PasswordForm();
             LogStep(step++, "Заполняем поля формы изменения пароля с вводом неверного подтверждения нового пароля'");
             editPassWithIncorrectConfPass.EditPassIncorrectConfPass();

             var checkIncorrectConfPass = new AssertCheckIncorrectConfPass();
             LogStep(step++, "Проверяем что при вводе неправильного подтверждения пароля отображается верная ошибка'");
             checkIncorrectConfPass.CheckIncorrectConfPass();
         }

         [Test]
         public void OnlinerCheckEmptyPass() // Проверка что нельзя сохранить пустой пароль
         {
             int step = 1;

             var homePage = new MainForm();
             LogStep(step++, "Открытие main page www.onliner.by+ переход на форму логина");
             homePage.OpenLogInForm();

             var logIn = new LogIn();
             LogStep(step++, "Логинимся под своими учетными данными");
             logIn.Login();

             var checkLogIn = new AssertSignIn();
             LogStep(step++, "Проверяем что логин успешен");
             Assert.IsTrue(checkLogIn.SignIn("Выйти"));

             var personalDataForm = new MainForm();
             LogStep(step++, "Переходим к учетным данным пользователя");
             personalDataForm.OpenAccountForm();

             var editUserDataForm = new UserAccountForm();
             LogStep(step++, "Переходим к редактированию данных пользователя");
             editUserDataForm.EditPersonalData();

             var openPassForm = new EditUserDataForm();
             LogStep(step++, "Переходим на форму изменения пароля пользователя");
             openPassForm.OpenPasswordForm();

             var editPassWithEmptyField = new PasswordForm();
             LogStep(step++, "Подтверждаем сохранение пустой формы изменения пароля");
             editPassWithEmptyField.EditPassEmptyField();

             var checkEditPassNegative = new AssertCheckPassEmptyFiel();
             LogStep(step++, "Проверяем что при вводе неправильного подтверждения пароля отображается верная ошибка'");
             checkEditPassNegative.CheckPassEmptyFiel();
         }


         [Test]
         public void OnlinerCheckEditPass() // Проверка что пароль меняется
         {
             int step = 1;

             var homePage = new MainForm();
             LogStep(step++, "Открытие main page www.onliner.by+ переход на форму логина");
             homePage.OpenLogInForm();

             var logIn = new LogIn();
             LogStep(step++, "Логинимся под своими учетными данными");
             logIn.Login();

             var checkLogIn = new AssertSignIn();
             LogStep(step++, "Проверяем что логин успешен");
             Assert.IsTrue(checkLogIn.SignIn("Выйти"));

             var personalDataForm = new MainForm();
             LogStep(step++, "Переходим к учетным данным пользователя");
             personalDataForm.OpenAccountForm();

             var editUserDataForm = new UserAccountForm();
             LogStep(step++, "Переходим к редактированию данных пользователя");
             editUserDataForm.EditPersonalData();

             var openPassForm = new EditUserDataForm();
             LogStep(step++, "Переходим на форму изменения пароля пользователя");
             openPassForm.OpenPasswordForm();

             var editPass = new PasswordForm();
             LogStep(step++, "Подтверждаем сохранение пароля");
             editPass.EditPass();

             var checkEditPass = new AssertEditPass();
             LogStep(step++, "Проверяем что пароль применился");
             Assert.True(checkEditPass.CheckEditPass());
         }
    }
}
