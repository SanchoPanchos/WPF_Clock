using System;
using System.Windows;
using System.Windows.Controls;
using WPF_HW1.Model;
using WPF_HW1.Utils;

namespace WPF_HW1.UserControls
{
    
    public partial class LoginUserControl : UserControl
    {
        private MainWindow parentWindow;

        public LoginUserControl()
        {
            InitializeComponent();
            loginRegisterButton.Click += RegisterButton_Click;
            loginButton.Click += LoginButton_Click;
            parentWindow = Application.Current.MainWindow as MainWindow;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(username.Text) || (String.IsNullOrEmpty(password.Text)))
            {
                LogManager.Log(Constants.EmptyLogin);
                errorLogin.Visibility = Visibility.Visible;
            }
            else
            {
                LoginLoader.Visibility = Visibility.Visible;
                LoginGrid.IsEnabled = false;
                if (EntityWrapper.GetUserByLoginAndPassword(username.Text, password.Password) == null)
                {
                    errorLogin.Text = "Wrong username or password!";
                    errorLogin.Visibility = Visibility.Visible;
                    LoginLoader.Visibility = Visibility.Hidden;
                    LoginGrid.IsEnabled = true;
                }
                else
                {
                    UserManager.SaveCurrentUserID(EntityWrapper.GetUserByLoginAndPassword(username.Text, password.Password).Guid);
                    LoginLoader.Visibility = Visibility.Hidden;
                    LoginGrid.IsEnabled = true;
                    parentWindow.ShowMain();
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ShowRegister();
        }

    }
}
