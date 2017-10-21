using System;
using System.Windows;
using WPF_HW1.Model;
using WPF_HW1.Utils;

namespace WPF_HW1
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            if (UserManager.GetCurrentUser() == null){
                registerUserControl.Visibility = Visibility.Hidden;
                mainUserControl.Visibility = Visibility.Hidden;
            }
            else{
                ShowMain();
            }
            registerUserControl.registerLoginButton.Click += RegisterLoginButton_Click;
            registerUserControl.registerButton.Click += RegisterButton_Click1;
            loginUserControl.loginRegisterButton.Click += RegisterButton_Click;
            loginUserControl.loginButton.Click += LoginButton_Click;
            mainUserControl.logoutButton.Click += LogoutButton_Click;
        }

        private void RegisterButton_Click1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(registerUserControl.name.Text) || String.IsNullOrEmpty(registerUserControl.surname.Text)
                || String.IsNullOrEmpty(registerUserControl.username.Text) || String.IsNullOrEmpty(registerUserControl.email.Text)
                || String.IsNullOrEmpty(registerUserControl.password.Text))
            {
                registerUserControl.registerError.Visibility = Visibility.Visible;
                LogManager.Log(Constants.EmptyRegister);
                return;
            }

            UserManager.SaveCurrentUser(new User(1, registerUserControl.name.Text, registerUserControl.surname.Text, registerUserControl.username.Text,
                registerUserControl.email.Text, "", null));
            ShowMain();
        }

        private void RegisterLoginButton_Click(object sender, RoutedEventArgs e){
            ClearRegister();
            ShowLogin();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e){
            ReadWriteManager.DeleteFile(Constants.ClientDataDirPath, "Data", ".txt");
            ShowLogin();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e){
            if (String.IsNullOrEmpty(loginUserControl.username.Text) || (String.IsNullOrEmpty(loginUserControl.password.Text))){
                LogManager.Log(Constants.EmptyLogin);
                loginUserControl.errorLogin.Visibility = Visibility.Visible;
            }
            else{
                ClearLogin();
                ShowMain();
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e){
            ShowRegister();
        }

        private void ClearRegister(){
            registerUserControl.name.Text = "";
            registerUserControl.surname.Text = "";
            registerUserControl.username.Text = "";
            registerUserControl.email.Text = "";
            registerUserControl.password.Text = "";
        }

        private void ClearLogin(){
            loginUserControl.username.Text = "";
            loginUserControl.password.Text = "";
        }

        private void ShowRegister(){
            this.Height = 500;
            registerUserControl.registerError.Visibility = Visibility.Hidden;
            registerUserControl.Visibility = Visibility.Visible;
            loginUserControl.Visibility = Visibility.Hidden;
        }

        private void ShowLogin(){
            this.Width = 300;
            this.Height = 400;
            mainUserControl.Visibility = Visibility.Hidden;
            registerUserControl.Visibility = Visibility.Hidden;
            loginUserControl.Visibility = Visibility.Visible;
            loginUserControl.errorLogin.Visibility = Visibility.Hidden;
        }

        private void ShowMain(){
            this.Width = 510;
            this.Height = 310;
            mainUserControl.Visibility = Visibility.Visible;
            registerUserControl.Visibility = Visibility.Hidden;
            loginUserControl.Visibility = Visibility.Hidden;
        }
    }
}
