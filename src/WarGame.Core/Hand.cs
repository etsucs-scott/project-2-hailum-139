namespace WarGame.Core;

public class Hand
{
    public Queue<Card> cards;

    public Hand()
    {
        cards = new Queue<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Enqueue(card);
    }
    public Card RemoveCard()
    {
       return cards.Dequeue();
    }
    public int Count()
    { 
        return cards.Count;
    }
    public void AddMultipleCards(List<Card> winnings)
    {
        foreach (var card in winnings)
        {
            cards.Enqueue(card);
        }
    }
}
