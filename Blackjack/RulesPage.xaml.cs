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
    /// Logika interakcji dla klasy RulesPage.xaml
    /// </summary>
    public partial class RulesPage : Page
    {
        public RulesPage()
        {
            InitializeComponent();
            rulesTextBlock.Text = @"
1.Aby wygrac musisz spelnic jeden z ponizszych warunkow: 
    a) wartosc twoich kart musi wynosic dokladnie 21 
    b) wartosc twoich kart musi byc wieksza od wartosci kart krupiera
        ale nie przekraczajaca 21
2.Wygrywasz również jeżeli krupier będzie chciał dobrać siódmą kartę
3.Przegrywasz w nastepujacych przypadkach:
    a) gdy wartosc twoich kart przekroczy 21 
    b) gdy wartosc kart krupiera wynosi 21
    c) gdy sie poddasz
    d) gdy będziesz chciał dobrać siódmą kartę";
        }

        private void backButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
