namespace WarGame.Core;

public enum Suit 
{
    Clubs,
    Diamonds, 
    Hearts, 
    Spades
}
public enum Rank 
{
    // assign underlying value to the enum values so you can compare the Card class using Rank
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen, 
    King,
    Ace
}
// using Icomparable interface is what makes comparision of cards possible
public class Card : IComparable<Card> 
{
    public Suit Suit { get; set; }
    public Rank Rank { get; set; }

    public Card(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public int CompareTo(Card othercard)
    {
        if (othercard == null) return -1;// precaution for when the card in the parameter might be null
        else return this.Rank.CompareTo(othercard.Rank);
    }
}
