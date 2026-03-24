namespace WarGame.Core;

public class Deck
{
    private readonly Stack<Card> StackofCards;

    public Deck()
    {
        List<Card> Cards = CreateStandardDeck();
        Card[] cardArray = Cards.ToArray();//Changing the initial list of cards into an array to be able to shuffle the cards
        Random.Shared.Shuffle(cardArray);
        StackofCards = new Stack<Card>(cardArray);//Then changes the array into a stack of cards 
    }

    private List<Card> CreateStandardDeck()// to ensure that each deck created is a proper deck with no inconsistencies
    {
        var list = new List<Card>();
        foreach (Suit s in Enum.GetValues<Suit>())//this is a loop to ensure that each suit gets the proper number of rank combinations
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
