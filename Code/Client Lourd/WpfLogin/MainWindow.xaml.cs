using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using WpfFiles; 

namespace WpfLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] login = new string[3];
            controller ctrl = new controller() ;

            login[0] = usrTb.Text;
            login[1] = pwdTB.Password;

            waitLbl.Visibility = Visibility.Visible;
            //ctrl.checkAndSend(login);

            WpfFiles.MainWindow files = new WpfFiles.MainWindow();
            files.Show();

            this.Hide();
        }
    }
}
