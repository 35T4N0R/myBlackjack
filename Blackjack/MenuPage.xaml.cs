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
        MainWindow mw = (MainWindow) Application.Current.MainWindow;

        Player player;
        string line;
        List<Player> ranking = new List<Player>();

        public MenuPage()
        {
            InitializeComponent();

            try
            {
                StreamReader sr = new StreamReader("player.txt");

                line = sr.ReadLine();
                string[] tmp = line.Split(' ');

                player = new Player();
                player.nickname = tmp[0];
                player.money = Convert.ToInt32(tmp[1]);

                sr.Close();

                continueButton.IsEnabled = true;
                nicknameLabel.Content += player.nickname;
                moneyLabel.Content += player.money.ToString();
            }
            catch( FileNotFoundException)
            {
                continueButton.IsEnabled = false;
            }
            catch (NullReferenceException)
            {
                continueButton.IsEnabled = false;
            }

            try
            {
                StreamReader sr = new StreamReader("ranking.txt");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] tmp = line.Split(' ');

                    player = new Player();
                    player.nickname = tmp[0];
                    player.money = Convert.ToInt32(tmp[1]);

                    ranking.Add(player);
                }
            }
            catch (FileNotFoundException)
            {
                rankingButton.IsEnabled = false;
            }
            

        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            mw.MainFrame.Content = new NickPage(ranking);
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
            mw.MainFrame.Content = new BettingPage(player, ranking);
        }

        private void rankingButton_Click(object sender, RoutedEventArgs e)
        {
            mw.MainFrame.Content = new RankingPage(ranking);
        }
    }
}
