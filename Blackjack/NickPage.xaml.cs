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

namespace Blackjack
{
    /// <summary>
    /// Logika interakcji dla klasy NickPage.xaml
    /// </summary>
    public partial class NickPage : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        public NickPage()
        {
            InitializeComponent();
            nickTextBox.Focus();
        }
        
        private async void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(nickTextBox.Text) &&  !String.IsNullOrWhiteSpace(nickTextBox.Text))
            {

            }
            else
            {
                wrongNickname.Content = "";
                await Task.Delay(100);
                wrongNickname.Content = "Podany nickname jest nieprawdiłowy !\nSpróbuj jeszcze raz.";
                nickTextBox.Text = "";
                nickTextBox.Focus();
            }
        }
    }
}
