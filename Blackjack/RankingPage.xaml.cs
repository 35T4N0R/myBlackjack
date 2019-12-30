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
    /// Logika interakcji dla klasy RankingPage.xaml
    /// </summary>
    public partial class RankingPage : Page
    {
        List<Player> ranking;

        public RankingPage(List<Player> ranking)
        {
            InitializeComponent();
            this.ranking = ranking;
            int i = 1;
            rankingTextBlock.Text = "";
            foreach (Player p in ranking)
            {
                rankingTextBlock.Text += i + ". " + p.nickname + " - " + p.money + "\n";
                i++;
            }
        }
        private void backButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
