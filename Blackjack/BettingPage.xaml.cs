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
    /// Logika interakcji dla klasy BettingPage.xaml
    /// </summary>
    public partial class BettingPage : Page
    {
        int money = 0;
        int bet = 0;
        public BettingPage(int money)
        {
            InitializeComponent();
            this.money = money;
            Money.Content += "\n" + this.money;
            betTextBox.Content = "0";
        }

        private void neg1000_Click(object sender, RoutedEventArgs e)
        {
            if(this.bet - 1000 >= 0)
            {
                this.bet -= 1000;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private void neg500_Click(object sender, RoutedEventArgs e)
        {
            if (this.bet - 500 >= 0)
            {
                this.bet -= 500;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private void neg100_Click(object sender, RoutedEventArgs e)
        {
            if (this.bet - 100 >= 0)
            {
                this.bet -= 100;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            this.bet = 0;
            betTextBox.Content = this.bet.ToString();
        }

        private void pos100_Click(object sender, RoutedEventArgs e)
        {
            if(this.bet + 100 <= this.money)
            {
                this.bet += 100;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private void pos500_Click(object sender, RoutedEventArgs e)
        {
            if (this.bet + 500 <= this.money)
            {
                this.bet += 500;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private void pos1000_Click(object sender, RoutedEventArgs e)
        {
            if (this.bet + 1000 <= this.money)
            {
                this.bet += 1000;
                betTextBox.Content = this.bet.ToString();
            }
        }

    }
}
