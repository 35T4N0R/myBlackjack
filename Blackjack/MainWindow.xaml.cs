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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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

        public MainWindow()
        {
            InitializeComponent();
            Money.Content = "Your money : \n 69696";
            Bet.Content = " Your bet : \n 111";
            List<Image> PlayerImages = new List<Image>() { PlayerCard1, PlayerCard2, PlayerCard3, PlayerCard4, PlayerCard5, PlayerCard6 };
            List<Image> ComputerImages = new List<Image>() { ComputerCard1, ComputerCard2, ComputerCard3, ComputerCard4, ComputerCard5, ComputerCard6 };
            
            BitmapImage test = new BitmapImage();
            

            

            for (int i = 0; i < 2; i++)
            {
                int numer = rnd.Next(1, 13);
                int kolor = rnd.Next(0, 3);
            
                if(numer > 10)
                {
                    playerCounter += 10;
                }else
                {
                    playerCounter += numer;
                }
                _value = numer;
                _suit = kolory[kolor];
                test = new BitmapImage();
                
                test.BeginInit();
                test.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                test.EndInit();
                
                PlayerImages[i].Source = test;
                currentPlayer = i;
            }
            for (int i = 0; i < 2; i++)
            {
                test = new BitmapImage();
                

                int numer = rnd.Next(1, 13);
                int kolor = rnd.Next(0, 3);
                if (i == 0)
                {
                    
                    ukrytyNumer = numer;
                    ukrytyKolor = kolor;

                    test.BeginInit();
                    test.UriSource = new Uri("pack://siteoforigin:,,,/karty/computer.png");
                    test.EndInit();

                    ComputerImages[i].Source = test;
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
                

                test.BeginInit();
                test.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                test.EndInit();

                ComputerImages[i].Source = test;
                currentComputer = i;
            }

            PlayerValue.Content = $"Wartość kart : \n {playerCounter}";
            ComputerValue.Content = $"Wartość kart : \n {computerCounter}";

            if(playerCounter == 21 && !czyMessage)
            {
                Message.Content = "WYGRAŁEŚ !!! \nMasz Blackjack'a";
                czyMessage = true;
                czyStop = true;
            }

        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        { 
            if (currentPlayer + 1 <= 5 && !czyStand && !czyStop) { 

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


                BitmapImage test = new BitmapImage();
                test.BeginInit();
                test.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                test.EndInit();

                PlayerImages[currentPlayer].Source = test;

                PlayerValue.Content = $"Wartość kart : \n {playerCounter}";
                if(playerCounter > 21 && !czyMessage)
                {
                    Message.Content = "Przegrałeś ! \nWartość twoich kart przekroczyła 21";
                    czyStop = true;
                    czyMessage = true;
                }

                if(playerCounter == 21 && !czyMessage)
                {
                    Message.Content = "Gratulacje !!! Wygrałeś !!! \nMasz Balckjack'a";
                    czyStop = true;
                    czyMessage = true;
                }
            }
            else if(currentPlayer + 1 > 5 && !czyMessage)
            {
                Message.Content = "Przegrałeś !!! \nOsiągnąłeś limit kart do dobrania";
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
                    BitmapImage test = new BitmapImage();
                    test.BeginInit();
                    test.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + kolory[ukrytyKolor] + ukrytyNumer + ".png");
                    test.EndInit();

                    ComputerCard1.Source = test;

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


                        BitmapImage test = new BitmapImage();
                        test.BeginInit();
                        test.UriSource = new Uri("pack://siteoforigin:,,,/karty/" + _suit + _value + ".png");
                        test.EndInit();

                        ComputerImages[currentComputer].Source = test;

                        ComputerValue.Content = $"Wartość kart : \n {computerCounter}";
                    }
                    czyStop = true;

                }
                if(computerCounter == 21 && !czyMessage)
                {
                    Message.Content = "Przegrałeś !!! \nKrupier ma Blackjack'a";
                    czyStop = true;
                    czyMessage = true;
                }
                if(computerCounter > 21 && !czyMessage)
                {
                    Message.Content = "Wygrałeś !!! \nWartość kart krupiera przekroczyła 21";
                    czyStop = true;
                    czyMessage = true;
                }
                if(computerCounter > playerCounter && !czyMessage)
                {
                    Message.Content = "Przegrałeś!!! \nWartośc kart krupiera jest większa od twojej";
                    czyStop = true;
                    czyMessage = true;
                }
                if(computerCounter < playerCounter && !czyMessage)
                {
                    Message.Content = "Wygrałeś!!! \nWartość towich kart jest większa od kart krupiera";
                    czyStop = true;
                    czyMessage = true;
                }
                if(computerCounter == playerCounter && !czyMessage)
                {
                    Message.Content = "Remis !!! \n Odzyskujesz swoje pieniądze";
                    czyStop = true;
                    czyMessage = true;
                }
            }
            

        }

        private void Surrender_Click(object sender, RoutedEventArgs e)
        {
            if(!czyStop && !czyMessage)
            {
                czyStop = true;
                Message.Content = "Poddałeś się XDDDD!!!!";
                czyMessage = true;
            }
            
        }
    }
}
