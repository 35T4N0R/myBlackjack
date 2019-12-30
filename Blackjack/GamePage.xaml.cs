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
    /// Logika interakcji dla klasy GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {

        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        public string[] kolory = new string[] { "h", "d", "c", "s" };
        public int _value;
        public string _suit;
        int ukrytyNumer = 0;
        int ukrytyKolor = 0;
        int playerCounter = 0;
        int computerCounter = 0;
        Random rnd = new Random();
        int currentPlayer = 0;
        int currentComputer = 0;
        Boolean czyOdkryto = false;
        Boolean czyStand = false;
        Boolean czyStop = false;
        Boolean czyMessage = false;
        int money = 0;
        int bet = 0;
        string player;
        public GamePage(int money, int bet, string player)
        {
            InitializeComponent();

            this.money = money;
            this.bet = bet;
            this.player = player;

            Money.Content = "Twoje saldo : \n" + this.money;
            Bet.Content = "Twój zakład : \n" + this.bet;
            List<Image> PlayerImages = new List<Image>() { PlayerCard1, PlayerCard2, PlayerCard3, PlayerCard4, PlayerCard5, PlayerCard6 };
            List<Image> ComputerImages = new List<Image>() { ComputerCard1, ComputerCard2, ComputerCard3, ComputerCard4, ComputerCard5, ComputerCard6 };

            BitmapImage cardImage;

            for (int i = 0; i < 2; i++)
            {
                int numer = rnd.Next(1, 13);
                int kolor = rnd.Next(0, 3);

                if (numer > 10)
                {
                    playerCounter += 10;
                }
                else
                {
                    playerCounter += numer;
                }
                _value = numer;
                _suit = kolory[kolor];
                cardImage = new BitmapImage();

                cardImage.BeginInit();
                cardImage.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                cardImage.EndInit();

                PlayerImages[i].Source = cardImage;
                currentPlayer = i;
            }
            for (int i = 0; i < 2; i++)
            {
                cardImage = new BitmapImage();


                int numer = rnd.Next(1, 13);
                int kolor = rnd.Next(0, 3);
                if (i == 0)
                {

                    ukrytyNumer = numer;
                    ukrytyKolor = kolor;

                    cardImage.BeginInit();
                    cardImage.UriSource = new Uri("pack://siteoforigin:,,,/karty/computer.png");
                    cardImage.EndInit();

                    ComputerImages[i].Source = cardImage;
                    continue;
                }
                if (numer > 10)
                {
                    computerCounter += 10;
                }
                else
                {
                    computerCounter += numer;
                }

                _value = numer;
                _suit = kolory[kolor];


                cardImage.BeginInit();
                cardImage.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                cardImage.EndInit();

                ComputerImages[i].Source = cardImage;
                currentComputer = i;
            }

            PlayerValue.Content = $"Wartość kart : \n {playerCounter}";
            ComputerValue.Content = $"Wartość kart : \n {computerCounter}";

            if (playerCounter == 21 && !czyMessage)
            {
                Message.Content = "WYGRAŁEŚ !!! \nMasz Blackjack'a";
                resultMessage();
                this.money += this.bet * 3;
                czyMessage = true;
                czyStop = true;
            }
        }
        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            if (currentPlayer + 1 <= 5 && !czyStand && !czyStop)
            {

                List<Image> PlayerImages = new List<Image>() { PlayerCard1, PlayerCard2, PlayerCard3, PlayerCard4, PlayerCard5, PlayerCard6 };

                currentPlayer++;
                int numer = rnd.Next(1, 13);
                int kolor = rnd.Next(0, 3);

                if (numer > 10)
                {
                    playerCounter += 10;
                }
                else
                {
                    playerCounter += numer;
                }

                _value = numer;
                _suit = kolory[kolor];


                BitmapImage cardImage = new BitmapImage();
                cardImage.BeginInit();
                cardImage.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                cardImage.EndInit();

                PlayerImages[currentPlayer].Source = cardImage;

                PlayerValue.Content = $"Wartość kart : \n {playerCounter}";
                if (playerCounter > 21 && !czyMessage)
                {
                    Message.Content = "Przegrałeś ! \nWartość twoich kart przekroczyła 21";
                    resultMessage();
                    czyStop = true;
                    czyMessage = true;
                }

                if (playerCounter == 21 && !czyMessage)
                {
                    Message.Content = "Gratulacje !!! Wygrałeś !!! \nMasz Balckjack'a";
                    resultMessage();
                    this.money += this.bet * 3;
                    czyStop = true;
                    czyMessage = true;
                }
            }
            else if (currentPlayer + 1 > 5 && !czyMessage)
            {
                Message.Content = "Przegrałeś !!! \nOsiągnąłeś limit kart do dobrania";
                resultMessage();
                czyStop = true;
                czyMessage = true;
            }
        }

        private async void Stand_Click(object sender, RoutedEventArgs e)
        {
            if (!czyStop)
            {
                czyStop = true;
                czyStand = true;
                List<Image> ComputerImages = new List<Image>() { ComputerCard1, ComputerCard2, ComputerCard3, ComputerCard4, ComputerCard5, ComputerCard6 };
                if (!czyOdkryto)
                {
                    BitmapImage cardImage = new BitmapImage();
                    cardImage.BeginInit();
                    cardImage.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + kolory[ukrytyKolor] + ukrytyNumer + ".png");
                    cardImage.EndInit();

                    ComputerCard1.Source = cardImage;

                    if (ukrytyNumer > 10)
                    {
                        computerCounter += 10;
                    }
                    else
                    {
                        computerCounter += ukrytyNumer;
                    }
                    ComputerValue.Content = $"Wartość kart : \n {computerCounter}";
                    czyOdkryto = true;
                }


                if (czyOdkryto)
                {
                    while (computerCounter <= 16 && currentComputer <= 5)
                    {
                        currentComputer++;

                        await Task.Delay(2000);

                        int numer = rnd.Next(1, 13);
                        int kolor = rnd.Next(0, 3);

                        if (numer > 10)
                        {
                            computerCounter += 10;
                        }
                        else
                        {
                            computerCounter += numer;
                        }

                        _value = numer;
                        _suit = kolory[kolor];


                        BitmapImage cardImage = new BitmapImage();
                        cardImage.BeginInit();
                        cardImage.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                        cardImage.EndInit();

                        ComputerImages[currentComputer].Source = cardImage;

                        ComputerValue.Content = $"Wartość kart : \n {computerCounter}";
                    }
                    czyStop = true;

                }
                if (computerCounter == 21 && !czyMessage)
                {
                    Message.Content = "Przegrałeś !!! \nKrupier ma Blackjack'a";
                    resultMessage();
                    czyStop = true;
                    czyMessage = true;
                }
                if (computerCounter > 21 && !czyMessage)
                {
                    Message.Content = "Wygrałeś !!! \nWartość kart krupiera przekroczyła 21";
                    resultMessage();
                    this.money += this.bet * 2;
                    czyStop = true;
                    czyMessage = true;
                }
                if (computerCounter > playerCounter && !czyMessage)
                {
                    Message.Content = "Przegrałeś!!! \nWartośc kart krupiera jest większa od twojej";
                    resultMessage();
                    czyStop = true;
                    czyMessage = true;
                }
                if (computerCounter < playerCounter && !czyMessage)
                {
                    Message.Content = "Wygrałeś!!! \nWartość towich kart jest większa od kart krupiera";
                    resultMessage();
                    this.money += this.bet * 2;
                    czyStop = true;
                    czyMessage = true;
                }
                if (computerCounter == playerCounter && !czyMessage)
                {
                    Message.Content = "Remis !!! \nOdzyskujesz swoje pieniądze";
                    resultMessage();
                    this.money += this.bet;
                    czyStop = true;
                    czyMessage = true;
                }
            }
             

        }

        private void Surrender_Click(object sender, RoutedEventArgs e)
        {
            if (!czyStop && !czyMessage)
            {
                czyStop = true;
                Message.Content = "Przegrałeś !!! Poddałeś się !!!";
                resultMessage();
                czyMessage = true;
            }
        }

        private void resultMessage()
        {
            messageBorder.Visibility = Visibility.Visible;
            Message.Content += "\nCzy chcesz zagrać jeszcze raz ?";
            no.Visibility = Visibility.Visible;
            yes.Visibility = Visibility.Visible;
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            
            mw.MainFrame.Content = new BettingPage(this.money, this.player);
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(new FileStream("player.txt", FileMode.Open));
            sw.WriteLine(this.player + " " + this.money);
            sw.Close();
            mw.MainFrame.Content = new MenuPage();
        }
    }
}
