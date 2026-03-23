namespace WarGame.Core;

public class Deck
{
    private readonly Stack<Card> StackofCards;

    public Deck()
    {
        List<Card> Cards = CreateStandardDeck();
        Card[] cardArray = Cards.ToArray();
        Random.Shared.Shuffle(cardArray);
        StackofCards = new Stack<Card>(cardArray);
    }

    private List<Card> CreateStandardDeck()
    {
        var list = new List<Card>();
        foreach (Suit s in Enum.GetValues<Suit>())
        {
            foreach (Rank r in Enum.GetValues<Rank>())
            {
                list.Add(new Card(r, s));
            }
        }
        return list;   
    }
    public Card Draw()
    { 
        return StackofCards.Pop();
    }
    public int Count()
    { 
        return StackofCards.Count;
    }
}
