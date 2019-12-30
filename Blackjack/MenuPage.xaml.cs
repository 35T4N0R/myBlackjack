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
    /// Logika interakcji dla klasy MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        MainWindow mw =(MainWindow) Application.Current.MainWindow;

        string player;
        int money = 0;
        string line;

        public MenuPage()
        {
            InitializeComponent();
            try
            {
                StreamReader sr = new StreamReader("player.txt");

                line = sr.ReadLine();
                string[] tmp = line.Split(' ');

                player = tmp[0];
                money = Convert.ToInt32(tmp[1]);

                sr.Close();

                continueButton.IsEnabled = true;
                nicknameLabel.Content += player;
                moneyLabel.Content += money.ToString();
            }
            catch( FileNotFoundException)
            {
                continueButton.IsEnabled = false;
            }
            

        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            mw.MainFrame.Content = new NickPage();
        }


        private void rulesButton_Click(object sender, RoutedEventArgs e)
        {
            mw.MainFrame.Content = new RulesPage();
        }

        private void authorButton_Click(object sender, RoutedEventArgs e)
        {
            mw.MainFrame.Content = new AuthorPage();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            mw.MainFrame.Content = new BettingPage(this.money, this.player);
        }
    }
}
