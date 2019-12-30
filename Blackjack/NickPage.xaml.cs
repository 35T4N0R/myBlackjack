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
using System.IO;

namespace Blackjack
{
    /// <summary>
    /// Logika interakcji dla klasy NickPage.xaml
    /// </summary>
    public partial class NickPage : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        List<Player> ranking;
        public NickPage(List<Player> ranking)
        {
            InitializeComponent();
            this.ranking = ranking;
            nickTextBox.Focus();
        }
        
        private async void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(nickTextBox.Text) &&  !String.IsNullOrWhiteSpace(nickTextBox.Text) && !nickTextBox.Text.Contains(" "))
            {
                StreamWriter sw = new StreamWriter(new FileStream("player.txt", FileMode.OpenOrCreate));
                sw.WriteLine(nickTextBox.Text + " 6000");
                sw.Close();
                Player player = new Player();
                player.nickname = nickTextBox.Text;
                player.money = 6000;
                mw.MainFrame.Content = new BettingPage(player, this.ranking);
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
