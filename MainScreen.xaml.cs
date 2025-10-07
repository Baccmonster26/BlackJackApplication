using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackApplication
{
    public partial class MainScreen : ContentPage
    {
        public List<string> CardDeck { get; } = [ "ten_of_clubs", "ten_of_diamonds", "ten_of_hearts", "ten_of_spades", "two_of_clubs", "two_of_diamonds", "two_of_hearts", "two_of_spades",
            "three_of_clubs", "three_of_diamonds", "three_of_hearts", "three_of_spades", "four_of_clubs", "four_of_diamonds", "four_of_hearts", "four_of_spades",
            "five_of_clubs", "five_of_diamonds", "five_of_hearts", "five_of_spades", "six_of_clubs", "six_of_diamonds", "six_of_hearts", "six_of_spades",
            "seven_of_clubs", "seven_of_diamonds", "seven_of_hearts", "seven_of_spades", "eight_of_clubs", "eight_of_diamonds", "eight_of_hearts", "eight_of_spades",
            "nine_of_clubs", "nine_of_diamonds", "nine_of_hearts", "nine_of_spades", "ace_of_clubs", "ace_of_diamonds", "ace_of_hearts", "ace_of_spades",
            "jack_of_clubs", "jack_of_diamonds", "jack_of_hearts", "jack_of_spades", "king_of_clubs", "king_of_diamonds", "king_of_hearts", "king_of_spades",
            "queen_of_clubs", "queen_of_diamonds", "queen_of_hearts", "queen_of_spades"];
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
        public double ChipCnt = 1000;
        public int Bet = 0;
        public MainScreen()
        {
            InitializeComponent();
            _ = OnStartUp();
        }

        private async Task OnStartUp()
        {
            ChipsLabel.Text = ChipCnt.ToString();
            await TotalBet();
            ChipsLabel.Text = ChipCnt.ToString();

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
            if (DealerCount == 21) { _ = DealerBlackJack(); DealerSecondCard.IsVisible = true; }
            if (PlayerCount == 21) { _ = BlackJack(); }

        }

        private void OnRandomCard(object sender, EventArgs e)
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
            if (HitCount == 0)
            {
                ThirdCard.Source = PlayingCard + ".png";
                ThirdCard.IsVisible = true;
            }
            if (HitCount == 1)
            {
                FourthCard.Source = PlayingCard + ".png";
                FourthCard.IsVisible = true;
            }
            if (HitCount == 2)
            {
                FiveCard.Source = PlayingCard + ".png";
                FiveCard.IsVisible = true;
            }
            if (MaxAce && PlayerCount > 21)
            {
                PlayerCount -= 10;
            }
            else if (PlayerCount > 21) { _ = Over21(); }
            Debug.WriteLine("The Player Count: " + PlayerCount);
            HitCount++;
        }

        private void OnStand(object sender, EventArgs e)
        {
            DealerTurn();
        }

        private void DealerTurn()
        {
            Random random = new();

            DealerSecondCard.IsVisible = true;

            if (PlayerCount < 22 && PlayerCount == DealerCount && DealerCount < 22 && DealerCount >= 17) { _ = Draw(); }
            else if (PlayerCount < 22 && PlayerCount > DealerCount && DealerCount < 22 && DealerCount >= 17) { _ = PlayerWon(); }
            else if (PlayerCount < 22 && PlayerCount < DealerCount && DealerCount < 22 && DealerCount >= 17) { _ = DealerWon(); }
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
                }
                if (DealerHitCount == 1)
                {
                    DealerFourthCard.Source = PlayingCard + ".png";
                    DealerFourthCard.IsVisible = true;
                }
                if (DealerHitCount == 2)
                {
                    DealerFiveCard.Source = PlayingCard + ".png";
                    DealerFiveCard.IsVisible = true;
                }
                if (MaxAce && DealerCount > 21)
                {
                    DealerCount -= 10;
                }
                else if (DealerCount > 21) { _ = DealerOver21(); }
                else if (PlayerCount < 22 && PlayerCount == DealerCount && DealerCount < 22 && DealerCount >= 17) { _ = Draw(); }
                else if (PlayerCount < 22 && PlayerCount > DealerCount && DealerCount < 22 && DealerCount >= 17) { _ = PlayerWon(); }
                else if (PlayerCount < 22 && PlayerCount < DealerCount && DealerCount < 22 && DealerCount >= 17) { _ = DealerWon(); }
                DealerHitCount++;
            }
        }

        public async Task TotalBet()
        {
            string result = await DisplayPromptAsync("Bet", "What's your bet?");
            Bet = int.Parse(result);
            ChipCnt += -Bet;
        }
        public async Task BlackJack()
        {
            await DisplayAlert("BLACKJACK!!!!", "You have blackjack", "Ok");
            MaxAce = false;
            PlayerCount = 0;
            DealerCount = 0;
            ChipCnt += (Bet * 2.5);
            ThirdCard.IsVisible = false;
            FourthCard.IsVisible = false;
            FiveCard.IsVisible = false;
            DealerSecondCard.IsVisible = false;
            DealerThirdCard.IsVisible = false;
            DealerFourthCard.IsVisible = false;
            DealerFiveCard.IsVisible = false;
            await OnStartUp();
        }
        public async Task Over21()
        {
            await DisplayAlert("Game Over", "You went over 21 and lost the game", "OK");
            MaxAce = false;
            PlayerCount = 0;
            DealerCount = 0;
            ThirdCard.IsVisible = false;
            FourthCard.IsVisible = false;
            FiveCard.IsVisible = false;
            DealerSecondCard.IsVisible = false;
            DealerThirdCard.IsVisible = false;
            DealerFourthCard.IsVisible = false;
            DealerFiveCard.IsVisible = false;
            await OnStartUp();
        }
        public async Task DealerBlackJack()
        {
            await DisplayAlert("Dealer hit BlackJack", "You lose", "Ok");
            MaxAce = false;
            PlayerCount = 0;
            DealerCount = 0;
            ThirdCard.IsVisible = false;
            FourthCard.IsVisible = false;
            FiveCard.IsVisible = false;
            DealerSecondCard.IsVisible = false;
            DealerThirdCard.IsVisible = false;
            DealerFourthCard.IsVisible = false;
            DealerFiveCard.IsVisible = false;
            await OnStartUp();
        }
        public async Task DealerOver21()
        {
            await DisplayAlert("You Won!", "Dealer went over 21, you win!", "OK");
            MaxAce = false;
            PlayerCount = 0;
            DealerCount = 0;
            ChipCnt += (Bet * 2);
            ThirdCard.IsVisible = false;
            FourthCard.IsVisible = false;
            FiveCard.IsVisible = false;
            DealerSecondCard.IsVisible = false;
            DealerThirdCard.IsVisible = false;
            DealerFourthCard.IsVisible = false;
            DealerFiveCard.IsVisible = false;
            await OnStartUp();
        }
        public async Task DealerWon()
        {
            await DisplayAlert("Dealer Won", "Dealer had the closest number to 21 \nPlayer Count: " + PlayerCount + "\nDealer Count: " + DealerCount, "OK");
            MaxAce = false;
            PlayerCount = 0;
            DealerCount = 0;
            ThirdCard.IsVisible = false;
            FourthCard.IsVisible = false;
            FiveCard.IsVisible = false;
            DealerSecondCard.IsVisible = false;
            DealerThirdCard.IsVisible = false;
            DealerFourthCard.IsVisible = false;
            DealerFiveCard.IsVisible = false;
            await OnStartUp();
        }
        public async Task PlayerWon()
        {
            await DisplayAlert("You Won!", "You had the closest number to 21 \nPlayer Count: " + PlayerCount + "\nDealer Count: " + DealerCount, "OK");
            MaxAce = false;
            PlayerCount = 0;
            DealerCount = 0;
            ChipCnt += (Bet * 2);
            ThirdCard.IsVisible = false;
            FourthCard.IsVisible = false;
            FiveCard.IsVisible = false;
            DealerSecondCard.IsVisible = false;
            DealerThirdCard.IsVisible = false;
            DealerFourthCard.IsVisible = false;
            DealerFiveCard.IsVisible = false;
            await OnStartUp();
        }
        public async Task Draw()
        {
            await DisplayAlert("Draw!!", "Dealer and Player had the same number", "OK");
            MaxAce = false;
            PlayerCount = 0;
            DealerCount = 0;
            ChipCnt += Bet;
            ThirdCard.IsVisible = false;
            FourthCard.IsVisible = false;
            FiveCard.IsVisible = false;
            DealerSecondCard.IsVisible = false;
            DealerThirdCard.IsVisible = false;
            DealerFourthCard.IsVisible = false;
            DealerFiveCard.IsVisible = false;
            await OnStartUp();
        }
    }
}