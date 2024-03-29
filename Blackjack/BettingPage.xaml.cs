﻿using System;
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
        int bet = 0;
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        List<Player> ranking;
        Player player;

        public BettingPage(Player player, List<Player> ranking)
        {
            InitializeComponent();
            this.player = player;
            this.ranking = ranking;
            Money.Content += "\n" + player.money;
            betTextBox.Content = "0";
            if(player.money == 0)
            {
                noMoney.Content = "Skończyły ci się pieniądze. \nTo koniec twojej gry.\nJedyne co możesz teraz zrobić \nto wrócić do menu.";
                submitBetButton.IsEnabled = false;
                noMoneyButton.Visibility = Visibility.Visible;
            }
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
            if(this.bet + 100 <= player.money)
            {
                this.bet += 100;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private void pos500_Click(object sender, RoutedEventArgs e)
        {
            if (this.bet + 500 <= player.money)
            {
                this.bet += 500;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private void pos1000_Click(object sender, RoutedEventArgs e)
        {
            if (this.bet + 1000 <= player.money)
            {
                this.bet += 1000;
                betTextBox.Content = this.bet.ToString();
            }
        }

        private async void submitBetButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.bet == 0)
            {
                wrongBetLabel.Content = "";
                await Task.Delay(100);
                wrongBetLabel.Content = "Nie możesz grać za 0 zł.\nSpróbuj jeszcze raz.";
            }
            else
            {
                player.money = player.money - this.bet;
                mw.MainFrame.Content = new GamePage(player, this.bet, this.ranking);
            }
        }

        private void noMoneyButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mw.MainFrame.Content = new MenuPage();
        }
    }
}
