using System;
using System.Collections.Generic;






class Card
{

    public string Face { get; set; }
    public string Suit { get; set; }

    public override string ToString()
    {
        return $"The {Face} of {Suit}";
    }

}

class Hand
{
    public List<Card> CurrentCards { get; set; } = new List<Card>();


    public void AddCard(Card cardToAdd)
    {
        CurrentCards.Add(cardToAdd);

    }

}





namespace BlackJackCS
{
    class Program
    {
        static void Main(string[] args)
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

            var firstPlayerCard = deck[0];

            deck.Remove(firstPlayerCard);

            player.AddCard(firstPlayerCard);

            var secondPlayerCard = deck[0];

            deck.Remove(secondPlayerCard);

            Console.WriteLine(player.CurrentCards.Count);




        }
    }
}
