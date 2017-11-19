using System.Windows;
using WPF_HW1.UserControls;
using WPF_HW1.Utils;

namespace WPF_HW1
{
    public partial class MainWindow : Window
    {

        //TODO
        //пофиксить, когда при добавлении нового пояса и тут же удалении кнопка неактивна

        public MainWindow()
        {
            InitializeComponent();
            MainControl.Content = new LoginUserControl();
            if (UserManager.GetCurrentUser() != null){
                ShowMain();
                MainControl.Content = new MainUserControl();
            }
            else{
                ShowLogin();
            }
        }

        public void ShowRegister(){
            this.Height = 500;
            MainControl.Content = new RegisterUserControl();
        }

        public void ShowLogin(){
            this.Width = 300;
            this.Height = 400;
            MainControl.Content = new LoginUserControl();
        }

        public void ShowMain(){
            this.Width = 510;
            this.Height = 310;
            MainControl.Content = new MainUserControl();
        }
    }
}
