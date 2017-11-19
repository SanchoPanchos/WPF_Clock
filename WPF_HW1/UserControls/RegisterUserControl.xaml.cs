using System;
using System.Windows;
using System.Windows.Controls;
using WPF_HW1.Model;
using WPF_HW1.Utils;

namespace WPF_HW1.UserControls
{

    public partial class RegisterUserControl : UserControl
    {
        private MainWindow parentWindow;

        public RegisterUserControl()
        {
            InitializeComponent();
            registerError.Visibility = Visibility.Hidden;
            registerLoginButton.Click += RegisterLoginButton_Click;
            registerButton.Click += RegisterButton_Click1;
            parentWindow = Application.Current.MainWindow as MainWindow;
        }

        private void RegisterButton_Click1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(surname.Text)
                || String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(email.Text)
                || String.IsNullOrEmpty(password.Text))
            {
                registerError.Visibility = Visibility.Visible;
                LogManager.Log(Constants.EmptyRegister);
                return;
            }
            RegisterLoader.Visibility = Visibility.Visible;
            RegisterGrid.IsEnabled = false;
            User temp = new User(name.Text, surname.Text, username.Text,
                email.Text, password.Password, null);
            using (MyContext db = new MyContext())
            {
                db.Users.Add(temp);
                db.SaveChanges();
            }
            UserManager.SaveCurrentUserID(temp.Guid);
            RegisterLoader.Visibility = Visibility.Hidden;
            RegisterGrid.IsEnabled = true;
            parentWindow.ShowMain();
        }

        private void RegisterLoginButton_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ShowLogin();
        }
    }
}
