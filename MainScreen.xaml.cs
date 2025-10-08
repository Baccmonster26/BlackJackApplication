using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlackJackApplication
{
    public partial class MainScreen : ContentPage
    {
        public List<string> PlayedCardDeck { get; set; } = [ "ten_of_clubs", "ten_of_diamonds", "ten_of_hearts", "ten_of_spades", "two_of_clubs", "two_of_diamonds", "two_of_hearts", "two_of_spades",
            "three_of_clubs", "three_of_diamonds", "three_of_hearts", "three_of_spades", "four_of_clubs", "four_of_diamonds", "four_of_hearts", "four_of_spades",
            "five_of_clubs", "five_of_diamonds", "five_of_hearts", "five_of_spades", "six_of_clubs", "six_of_diamonds", "six_of_hearts", "six_of_spades",
            "seven_of_clubs", "seven_of_diamonds", "seven_of_hearts", "seven_of_spades", "eight_of_clubs", "eight_of_diamonds", "eight_of_hearts", "eight_of_spades",
            "nine_of_clubs", "nine_of_diamonds", "nine_of_hearts", "nine_of_spades", "ace_of_clubs", "ace_of_diamonds", "ace_of_hearts", "ace_of_spades",
            "jack_of_clubs", "jack_of_diamonds", "jack_of_hearts", "jack_of_spades", "king_of_clubs", "king_of_diamonds", "king_of_hearts", "king_of_spades",
            "queen_of_clubs", "queen_of_diamonds", "queen_of_hearts", "queen_of_spades"];

        public int PlayerCount = 0;
        public int DealerCount = 0;
        public string PlayerString = "";
        public bool MaxAce = false;
        public int HitCount = 0;
        public int DealerHitCount = 0;
        public string strChipCnt = Preferences.Default.Get("ChipCnt", "-1");
        public double ChipCnt = 0;
        public int Bet = 0;
        public int TurnCnt = 0;
        public MainScreen()
        {
            InitializeComponent();
            _ = OnStartUp();
        }

        private async Task OnStartUp()
        {
            //this.MaxAce = false;
            //this.PlayerCount = 0;
            //this.DealerCount = 0;
            //this.HitCount = 0;
            //this.DealerHitCount = 0;
            //this.ThirdCard.IsVisible = false;
            //this.FourthCard.IsVisible = false;
            //this.FiveCard.IsVisible = false;
            //this.DealerSecondCard.IsVisible = false;
            //this.DealerThirdCard.IsVisible = false;
            //this.DealerFourthCard.IsVisible = false;
            //this.DealerFiveCard.IsVisible = false;
            ChipCnt = int.Parse(strChipCnt);
            ChipsLabel.Text = "Chips: " + ChipCnt.ToString();
            await TotalBet();
            ChipsLabel.Text = "Chips: " + ChipCnt.ToString();

            Random random = new();

            // Players First Face Up Card

            int index = random.Next(PlayedCardDeck.Count);
            var PlayingCard = PlayedCardDeck[index];
            PlayedCardDeck.RemoveAt(index);
            Debug.WriteLine(PlayingCard);
            Debug.WriteLine(PlayedCardDeck.Count);
            Debug.WriteLine(index);
            int underscoreIndex = PlayingCard.IndexOf('_');
            if (underscoreIndex != -1) { PlayerString = PlayingCard[..underscoreIndex]; }
            if (PlayerString == "ten" || PlayerString == "queen" || PlayerString == "king" || PlayerString == "jack") { PlayerCount += 10; }
            if (PlayerString == "two") { PlayerCount += 2; }
            if (PlayerString == "three") { PlayerCount += 3; }
            if (PlayerString == "four") { PlayerCount += 4; }
            if (PlayerString == "five") { PlayerCount += 5; }
            if (PlayerString == "six") { PlayerCount += 6; }
            if (PlayerString == "seven") { PlayerCount += 7; }
            if (PlayerString == "eight") { PlayerCount += 8; }
            if (PlayerString == "nine") { PlayerCount += 9; }
            if (PlayerString == "ace" && MaxAce == false && PlayerCount <= 10) { PlayerCount += 11; MaxAce = true; } else if (PlayerString == "ace") { PlayerCount += 1; }
            Debug.WriteLine("The Player Count: " + PlayerCount);
            FirstCard.Source = PlayingCard + ".png";



            // Players Second Face Up Card

            index = random.Next(PlayedCardDeck.Count);
            PlayingCard = PlayedCardDeck[index];
            PlayedCardDeck.RemoveAt(index);
            Debug.WriteLine(PlayingCard);
            Debug.WriteLine(PlayedCardDeck.Count);
            Debug.WriteLine(index);
            underscoreIndex = PlayingCard.IndexOf('_');
            if (underscoreIndex != -1) { PlayerString = PlayingCard[..underscoreIndex]; }
            if (PlayerString == "ten" || PlayerString == "queen" || PlayerString == "king" || PlayerString == "jack") { PlayerCount += 10; }
            if (PlayerString == "two") { PlayerCount += 2; }
            if (PlayerString == "three") { PlayerCount += 3; }
            if (PlayerString == "four") { PlayerCount += 4; }
            if (PlayerString == "five") { PlayerCount += 5; }
            if (PlayerString == "six") { PlayerCount += 6; }
            if (PlayerString == "seven") { PlayerCount += 7; }
            if (PlayerString == "eight") { PlayerCount += 8; }
            if (PlayerString == "nine") { PlayerCount += 9; }
            if (PlayerString == "ace" && MaxAce == false && PlayerCount <= 10) { PlayerCount += 11; MaxAce = true; } else if (PlayerString == "ace") { PlayerCount += 1; }
            Debug.WriteLine("The Player Count: " + PlayerCount);
            SecondCard.Source = PlayingCard + ".png";
            PlayerCntLabel.Text = "Player Count: " + PlayerCount;


            // Dealer First Face Up Card

            index = random.Next(PlayedCardDeck.Count);
            PlayingCard = PlayedCardDeck[index];
            PlayedCardDeck.RemoveAt(index);
            Debug.WriteLine(PlayingCard);
            Debug.WriteLine(PlayedCardDeck.Count);
            Debug.WriteLine(index);
            underscoreIndex = PlayingCard.IndexOf('_');
            if (underscoreIndex != -1) { PlayerString = PlayingCard[..underscoreIndex]; }
            if (PlayerString == "ten" || PlayerString == "queen" || PlayerString == "king" || PlayerString == "jack") { DealerCount += 10; }
            if (PlayerString == "two") { DealerCount += 2; }
            if (PlayerString == "three") { DealerCount += 3; }
            if (PlayerString == "four") { DealerCount += 4; }
            if (PlayerString == "five") { DealerCount += 5; }
            if (PlayerString == "six") { DealerCount += 6; }
            if (PlayerString == "seven") { DealerCount += 7; }
            if (PlayerString == "eight") { DealerCount += 8; }
            if (PlayerString == "nine") { DealerCount += 9; }
            if (PlayerString == "ace" && MaxAce == false && DealerCount <= 10) { DealerCount += 11; MaxAce = true; } else if (PlayerString == "ace") { DealerCount += 1; }
            Debug.WriteLine("The Dealer Count: " + DealerCount);
            DealerFirstCard.Source = PlayingCard + ".png";
            DealerCntLabel.Text = "Dealer Count: " + DealerCount;

            // Dealer Second Card

            index = random.Next(PlayedCardDeck.Count);
            PlayingCard = PlayedCardDeck[index];
            PlayedCardDeck.RemoveAt(index);
            Debug.WriteLine(PlayingCard);
            Debug.WriteLine(PlayedCardDeck.Count);
            Debug.WriteLine(index);
            underscoreIndex = PlayingCard.IndexOf('_');
            if (underscoreIndex != -1) { PlayerString = PlayingCard[..underscoreIndex]; }
            if (PlayerString == "ten" || PlayerString == "queen" || PlayerString == "king" || PlayerString == "jack") { DealerCount += 10; }
            if (PlayerString == "two") { DealerCount += 2; }
            if (PlayerString == "three") { DealerCount += 3; }
            if (PlayerString == "four") { DealerCount += 4; }
            if (PlayerString == "five") { DealerCount += 5; }
            if (PlayerString == "six") { DealerCount += 6; }
            if (PlayerString == "seven") { DealerCount += 7; }
            if (PlayerString == "eight") { DealerCount += 8; }
            if (PlayerString == "nine") { DealerCount += 9; }
            if (PlayerString == "ace" && MaxAce == false && DealerCount <= 10) { DealerCount += 11; MaxAce = true; } else if (PlayerString == "ace") { DealerCount += 1; }
            Debug.WriteLine("The Dealer Count: " + DealerCount);
            DealerSecondCard.Source = PlayingCard + ".png";
            if (DealerCount == 21) { DealerSecondCard.IsVisible = true; await DealerBlackJack(); }
            else if (PlayerCount == 21) { await BlackJack(); }

        }

        // Hit Button

        private async void OnRandomCard(object sender, EventArgs e)
        {
            Random random = new();
            TurnCnt += 1;

            int index = random.Next(PlayedCardDeck.Count);
            var PlayingCard = PlayedCardDeck[index];
            PlayedCardDeck.RemoveAt(index);
            Debug.WriteLine(PlayingCard);
            Debug.WriteLine(PlayedCardDeck.Count);
            Debug.WriteLine(index);
            int underscoreIndex = PlayingCard.IndexOf('_');
            if (underscoreIndex != -1) { PlayerString = PlayingCard[..underscoreIndex]; }
            if (PlayerString == "ten" || PlayerString == "queen" || PlayerString == "king" || PlayerString == "jack") { PlayerCount += 10; }
            if (PlayerString == "two") { PlayerCount += 2; }
            if (PlayerString == "three") { PlayerCount += 3; }
            if (PlayerString == "four") { PlayerCount += 4; }
            if (PlayerString == "five") { PlayerCount += 5; }
            if (PlayerString == "six") { PlayerCount += 6; }
            if (PlayerString == "seven") { PlayerCount += 7; }
            if (PlayerString == "eight") { PlayerCount += 8; }
            if (PlayerString == "nine") { PlayerCount += 9; }
            if (PlayerString == "ace" && MaxAce == false && PlayerCount <= 10) { PlayerCount += 11; MaxAce = true; } else if (PlayerString == "ace") { PlayerCount += 1; }
            PlayerCntLabel.Text = "Player Count: " + PlayerCount;
            if (HitCount == 0)
            {
                ThirdCard.Source = PlayingCard + ".png";
                ThirdCard.IsVisible = true;
                HitCount++;
            }
            else if (HitCount == 1)
            {
                FourthCard.Source = PlayingCard + ".png";
                FourthCard.IsVisible = true;
                HitCount++;
            }
            else if (HitCount == 2)
            {
                FiveCard.Source = PlayingCard + ".png";
                FiveCard.IsVisible = true;
                HitCount++;
            }
            else if (HitCount == 3)
            {
                SixthCard.Source = PlayingCard + ".png";
                SixthCard.IsVisible = true;
                HitCount++;
            }
            else if (HitCount == 4)
            {
                SeventhCard.Source = PlayingCard + ".png";
                SeventhCard.IsVisible = true;
                HitCount++;
            }
            if (MaxAce && PlayerCount > 21)
            {
                PlayerCount -= 10;
                MaxAce = false;
                PlayerCntLabel.Text = "Player Count: " + PlayerCount;
            }
            else if (PlayerCount > 21) { PlayerCntLabel.Text = "Player Count: " + PlayerCount; await Over21(); }
        }

        private async void OnDoubleDown(object sender, EventArgs e)
        {
            if (TurnCnt != 0)
            {
                await DisplayAlert("Invalid Action", "You can't double down if you already hit", "Ok");
            }
            else
            {
                Random random = new();

                int index = random.Next(PlayedCardDeck.Count);
                var PlayingCard = PlayedCardDeck[index];
                PlayedCardDeck.RemoveAt(index);
                Debug.WriteLine(PlayingCard);
                Debug.WriteLine(PlayedCardDeck.Count);
                Debug.WriteLine(index);
                int underscoreIndex = PlayingCard.IndexOf('_');
                if (underscoreIndex != -1) { PlayerString = PlayingCard[..underscoreIndex]; }
                if (PlayerString == "ten" || PlayerString == "queen" || PlayerString == "king" || PlayerString == "jack") { PlayerCount += 10; }
                if (PlayerString == "two") { PlayerCount += 2; }
                if (PlayerString == "three") { PlayerCount += 3; }
                if (PlayerString == "four") { PlayerCount += 4; }
                if (PlayerString == "five") { PlayerCount += 5; }
                if (PlayerString == "six") { PlayerCount += 6; }
                if (PlayerString == "seven") { PlayerCount += 7; }
                if (PlayerString == "eight") { PlayerCount += 8; }
                if (PlayerString == "nine") { PlayerCount += 9; }
                if (PlayerString == "ace" && MaxAce == false && PlayerCount <= 10) { PlayerCount += 11; MaxAce = true; } else if (PlayerString == "ace") { PlayerCount += 1; }
                ThirdCard.Source = PlayingCard + ".png";
                ThirdCard.IsVisible = true;
                PlayerCntLabel.Text = "Player Count: " + PlayerCount;
                if (MaxAce && PlayerCount > 21)
                {
                    PlayerCount -= 10;
                    MaxAce = false;
                    PlayerCntLabel.Text = "Player Count: " + PlayerCount;
                }
                else if (PlayerCount > 21) { PlayerCntLabel.Text = "Player Count: " + PlayerCount; ChipCnt -= Bet; await Over21(); }
                else { PlayerCntLabel.Text = "Player Count: " + PlayerCount; ChipCnt -= Bet; Bet += Bet; await DealerTurn(); }
            }
        }

        private async void OnStand(object sender, EventArgs e)
        {
            await DealerTurn();
        }

        private async Task DealerTurn()
        {
            Random random = new();

            DealerSecondCard.IsVisible = true;
            if (DealerCount < 17)
            { 
                while (DealerCount < 17)
                {
                    int index = random.Next(PlayedCardDeck.Count);
                    var PlayingCard = PlayedCardDeck[index];
                    PlayedCardDeck.RemoveAt(index);
                    Debug.WriteLine(PlayingCard);
                    Debug.WriteLine(PlayedCardDeck.Count);
                    Debug.WriteLine(index);
                    int underscoreIndex = PlayingCard.IndexOf('_');
                    if (underscoreIndex != -1) { PlayerString = PlayingCard[..underscoreIndex]; }
                    if (PlayerString == "ten" || PlayerString == "queen" || PlayerString == "king" || PlayerString == "jack") { DealerCount += 10; }
                    if (PlayerString == "two") { DealerCount += 2; }
                    if (PlayerString == "three") { DealerCount += 3; }
                    if (PlayerString == "four") { DealerCount += 4; }
                    if (PlayerString == "five") { DealerCount += 5; }
                    if (PlayerString == "six") { DealerCount += 6; }
                    if (PlayerString == "seven") { DealerCount += 7; }
                    if (PlayerString == "eight") { DealerCount += 8; }
                    if (PlayerString == "nine") { DealerCount += 9; }
                    if (PlayerString == "ace" && MaxAce == false && DealerCount <= 10) { DealerCount += 11; MaxAce = true; } else if (PlayerString == "ace") { DealerCount += 1; }
                    Debug.WriteLine("The Dealer Count: " + DealerCount);
                    if (DealerHitCount == 0)
                    {
                        DealerThirdCard.Source = PlayingCard + ".png";
                        DealerThirdCard.IsVisible = true;
                        DealerHitCount++;
                    }
                    else if (DealerHitCount == 1)
                    {
                        DealerFourthCard.Source = PlayingCard + ".png";
                        DealerFourthCard.IsVisible = true;
                        DealerHitCount++;
                    }
                    else if (DealerHitCount == 2)
                    {
                        DealerFiveCard.Source = PlayingCard + ".png";
                        DealerFiveCard.IsVisible = true;
                        DealerHitCount++;
                    }
                    else if (HitCount == 3)
                    {
                        SixthCard.Source = PlayingCard + ".png";
                        SixthCard.IsVisible = true;
                        HitCount++;
                    }
                    else if (HitCount == 4)
                    {
                        SeventhCard.Source = PlayingCard + ".png";
                        SeventhCard.IsVisible = true;
                        HitCount++;
                    }
                    if (MaxAce && DealerCount > 21)
                    {
                        DealerCount -= 10;
                        MaxAce = false;
                    }
                    else if (DealerCount > 21) { await DealerOver21(); }
                    else if (PlayerCount < 22 && PlayerCount == DealerCount && DealerCount < 22 && DealerCount >= 17) { await Draw(); }
                    else if (PlayerCount < 22 && PlayerCount > DealerCount && DealerCount < 22 && DealerCount >= 17) { await PlayerWon(); }
                    else if (PlayerCount < 22 && PlayerCount < DealerCount && DealerCount < 22 && DealerCount >= 17) { await DealerWon(); }
                }
            }
            else 
            {
                if (PlayerCount < 22 && PlayerCount == DealerCount && DealerCount < 22 && DealerCount >= 17) { await Draw(); }
                else if (PlayerCount < 22 && PlayerCount > DealerCount && DealerCount < 22 && DealerCount >= 17) { await PlayerWon(); }
                else if (PlayerCount < 22 && PlayerCount < DealerCount && DealerCount < 22 && DealerCount >= 17) { await DealerWon(); }
            }
        }

        public async Task TotalBet()
        {
            if (ChipCnt > 0)
            {
                string result = await DisplayPromptAsync("Bet", "What's your bet?", "Bet", "Cancel");
                if (string.IsNullOrWhiteSpace(result) )
                {
                    await DisplayAlert("Invalid", "Please enter how many chips you are going to bet!", "Ok");
                    await TotalBet();
                }
                else if (!result.All(char.IsDigit))
                {
                    await DisplayAlert("Invalid", "Please submit only numbers!", "Ok");
                    await TotalBet();
                }
                else if (int.Parse(result) > ChipCnt)
                {
                    await DisplayAlert("Invalid", "You don't have that many chips, please only enter in chips you have!", "Ok");
                    await TotalBet();
                }
                else if (result != null)
                {
                    Bet = int.Parse(result);
                    ChipCnt -= Bet;
                }
                else
                {
                    await DisplayAlert("Invalid", "Please enter how many chips you are going to bet!", "Ok");
                    await TotalBet();
                }
            }
            else
            {
                await DisplayAlert("You Ran Out Chips", "Out of Luck", "Quit");
                Application.Current?.Quit();
            }
        }
        public async Task BlackJack()
        {
            await DisplayAlert("BLACKJACK!!!!", "You have blackjack", "Ok");
            this.ChipCnt += (Bet * 2.5);
            Preferences.Default.Set("ChipCnt", this.ChipCnt);
            await Navigation.PushAsync(new MainScreen());
        }
        public async Task Over21()
        {
            await DisplayAlert("Game Over", "You went over 21 and lost the game", "OK");
            Preferences.Default.Set("ChipCnt", this.ChipCnt);
            await Navigation.PushAsync(new MainScreen());
        }
        public async Task DealerBlackJack()
        {
            await DisplayAlert("Dealer hit BlackJack", "You lose", "Ok");
            Preferences.Default.Set("ChipCnt", this.ChipCnt);
            await Navigation.PushAsync(new MainScreen());
        }
        public async Task DealerOver21()
        {
            await DisplayAlert("You Won!", "Dealer went over 21, you win!", "OK");
            this.ChipCnt += (Bet * 2);
            Preferences.Default.Set("ChipCnt", this.ChipCnt);
            await Navigation.PushAsync(new MainScreen());
        }
        public async Task DealerWon()
        {
            await DisplayAlert("Dealer Won", "Dealer had the closest number to 21 \nPlayer Count: " + PlayerCount + "\nDealer Count: " + DealerCount, "OK");
            Preferences.Default.Set("ChipCnt", this.ChipCnt);
            await Navigation.PushAsync(new MainScreen());
        }
        public async Task PlayerWon()
        {
            await DisplayAlert("You Won!", "You had the closest number to 21 \nPlayer Count: " + PlayerCount + "\nDealer Count: " + DealerCount, "OK");
            this.ChipCnt += (Bet * 2);
            Preferences.Default.Set("ChipCnt", this.ChipCnt);
            await Navigation.PushAsync(new MainScreen());
        }
        public async Task Draw()
        {
            await DisplayAlert("Draw!!", "Dealer and Player had the same number", "OK");
            this.ChipCnt += Bet;
            Preferences.Default.Set("ChipCnt", this.ChipCnt);
            await Navigation.PushAsync(new MainScreen());
        }
    }
}