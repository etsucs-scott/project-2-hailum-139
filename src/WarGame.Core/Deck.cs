namespace WarGame.Core;

public class Deck
{
    private readonly Stack<Card> StackofCards;

    public Deck()
    { 
        List<Card> Cards = CreateStandardDeck();

        Random.Shared.Shuffle(Cards);

        StackofCards = new Stack<Card>(Cards)
    }

    private List<Card> CreateStandardDeck()
    { 
        var list = new List<Card>
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
}
