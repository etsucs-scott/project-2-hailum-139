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
        if (othercard == null) return -1;
        else return this.Rank.CompareTo(othercard.Rank);
    }
}
