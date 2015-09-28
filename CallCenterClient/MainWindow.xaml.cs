using System.Windows;
using CallCenter.Client.Communication;
using CallCenter.Common;
using CallCenter.Common.Entities;

namespace CallCenter.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private bool isLogged;
        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            IConnection connection = new Connection("", 0);
            connection.Connect();
            if (!this.isLogged)
            {
                IOperator @operator = connection.LoginService.Login("3001");
                this.Title = @operator.Name;
                this.isLogged = true;
                return;
            }
            connection.LoginService.LogOut(this.Title);
            this.isLogged = false;
        }
    }
}
