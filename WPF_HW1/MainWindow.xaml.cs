using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_HW1.UserControls;

namespace WPF_HW1
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            registerUserControl.Visibility = Visibility.Hidden;
            mainUserControl.Visibility = Visibility.Hidden;
            registerUserControl.registerLoginButton.Click += RegisterLoginButton_Click;
            registerUserControl.registerButton.Click += RegisterButton_Click1;
            loginUserControl.loginRegisterButton.Click += RegisterButton_Click;
            loginUserControl.loginButton.Click += LoginButton_Click;
            mainUserControl.logoutButton.Click += LogoutButton_Click;
            

        }

        private void RegisterButton_Click1(object sender, RoutedEventArgs e)
        {
            this.Width = 460;
            this.Height = 310;
            mainUserControl.Visibility = Visibility.Visible;
            registerUserControl.Visibility = Visibility.Hidden;
            loginUserControl.Visibility = Visibility.Hidden;
        }

        private void RegisterLoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 300;
            this.Height = 400;
            mainUserControl.Visibility = Visibility.Hidden;
            registerUserControl.Visibility = Visibility.Hidden;
            loginUserControl.Visibility = Visibility.Visible;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 300;
            this.Height = 400;
            mainUserControl.Visibility = Visibility.Hidden;
            registerUserControl.Visibility = Visibility.Hidden;
            loginUserControl.Visibility = Visibility.Visible;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(loginUserControl.username.Text) || (String.IsNullOrEmpty(loginUserControl.password.Text))){
                //Вывести ошибку
            }
            else
            {
                loginUserControl.username.Text = "";
                loginUserControl.password.Text = "";
                this.Width = 460;
                this.Height = 310;
                mainUserControl.Visibility = Visibility.Visible;
                registerUserControl.Visibility = Visibility.Hidden;
                loginUserControl.Visibility = Visibility.Hidden;
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Height = 500;
            registerUserControl.Visibility = Visibility.Visible;
            loginUserControl.Visibility = Visibility.Hidden;
        }
    }
}
