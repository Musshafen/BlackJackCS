using System;
using System.Collections.Generic;






class Card
{

    public string Face { get; set; }
    public string Suit { get; set; }

    public int Value()
    {
        switch (Face)
        {
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
                return int.Parse(Face);
            case "Jack":
            case "Queen":
            case "King":
                return 10;
            case "Ace":
                return 11;
            default:
                return 0;

        }

    }

    public override string ToString()
    {
        return $"The {Face} of {Suit}";
    }

}

class Hand
{
    public List<Card> CurrentCards { get; set; } = new List<Card>();


    public int TotalValue()
    {
        var total = 0;

        foreach (var card in CurrentCards)
        {
            total = total + card.Value();
        }
        return total;

    }


    public void AddCard(Card cardToAdd)
    {
        CurrentCards.Add(cardToAdd);

    }

    public void PrintCardsAndTotal(string handName)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{handName}, your cards are: ");
        Console.WriteLine(String.Join(", ", CurrentCards));


        Console.WriteLine($"The total value of your hand is: {TotalValue()}");
        Console.WriteLine();
        Console.WriteLine();
    }

}





namespace BlackJackCS
{
    class Program
    {
        static void PlayTheGame()
        {
            var deck = new List<Card>();


            var suits = new List<string>() { "Spades", "Clubs", "Diamonds", "Hearts" };

            var faces = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };


            foreach (var suit in suits)

            {
                foreach (var face in faces)
                {
                    var newCard = new Card()
                    {
                        Suit = suit,
                        Face = face,

                    };

                    deck.Add(newCard);

                }

            }

            var numberOfCards = deck.Count;

            for (var rightIndex = numberOfCards - 1; rightIndex > 1; rightIndex--)
            {
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);

                var leftCard = deck[leftIndex];
                var rightCard = deck[rightIndex];
                deck[rightIndex] = leftCard;
                deck[leftIndex] = rightCard;
            }

            var player = new Hand();


            var dealer = new Hand();

            for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
            {
                var card = deck[0];

                deck.Remove(card);

                player.AddCard(card);

            }

            for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
            {
                var card = deck[0];

                deck.Remove(card);

                dealer.AddCard(card);

            }

            var answer = "";

            while (player.TotalValue() < 21 && answer != "STAND")
            {

                player.PrintCardsAndTotal("Player");

                Console.Write("Do you want to HIT or STAND? ");
                answer = Console.ReadLine().ToUpper();

                if (answer == "HIT")
                {
                    var newCard = deck[0];
                    deck.Remove(newCard);

                    player.AddCard(newCard);
                }

            }

            player.PrintCardsAndTotal("Player");

            while (player.TotalValue() <= 21 && dealer.TotalValue() <= 17)
            {
                var newCard = deck[0];
                deck.Remove(newCard);

                dealer.AddCard(newCard);


            }


            dealer.PrintCardsAndTotal("Dealer");

            if (player.TotalValue() > 21)
            {
                Console.WriteLine("Dealer WINS!");
            }
            else

            if (dealer.TotalValue() > 21)
            {
                Console.WriteLine("Player WINS!!");
            }
            else
            if (dealer.TotalValue() > player.TotalValue())
            {
                Console.WriteLine("Dealer WINS!");
            }
            else
            if (player.TotalValue() > dealer.TotalValue())
            {
                Console.WriteLine("Player WINS!!");
            }
            else
            {
                Console.WriteLine("Dealer WINS!");
            }
        }

        static void Main(string[] args)
        {

            while (true)
            {
                PlayTheGame();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Would you like to play again? ");
                var answer = Console.ReadLine().ToUpper();

                if (answer == "NO")
                {
                    break;
                }

            }

        }


    }
}


