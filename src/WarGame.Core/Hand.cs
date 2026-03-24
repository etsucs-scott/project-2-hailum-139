namespace WarGame.Core;

public class Hand
{
    public Queue<Card> cards;

    public Hand()
    {
        cards = new Queue<Card>();
    }

    public void AddCard(Card card)//creating shield methods 
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
    public void AddMultipleCards(List<Card> winnings)//whenever a player wins the cards in the pot having this method will make it easier to adda number of cards to the hand
    {
        foreach (var card in winnings)
        {
            cards.Enqueue(card);
        }
    }
}
