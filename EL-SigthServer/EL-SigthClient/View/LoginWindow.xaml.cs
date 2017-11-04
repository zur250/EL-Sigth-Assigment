using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EL_SigthClient.Model;
using EL_SigthClient.ViewModel;

namespace EL_SigthClient.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window,IChangeWindowsService
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.AssignWindow();
            //Model.ClientModel client = new ClientModel();
           // bool r = client.Login("zur", "123456");
            //client.StartStream();
           // client.StopStream();

        }

        public void AssignWindow()
        {
            var mainWindowVM = DataContext as LoginViewModel;
            mainWindowVM.ChangeWindowService = this;
        }

        public void CloseWindow()
        {
            Close();
        }

        public void OpenWindow(Strings.WindowType i_Type)
        {
            switch (i_Type)
            {
                case Strings.WindowType.Login:
                    // Do Nothing
                    break;
                case Strings.WindowType.Home:
                    //Login Successfull open next window
                    var homeWindow = new HomeWindow();
                    homeWindow.Show();
                    this.CloseWindow();
                    break;
                case Strings.WindowType.LoginError:
                    MessageBox.Show("Bad User Input, Check user name or password");
                    break;
                default:
                    break;
            }
        }
    }
}