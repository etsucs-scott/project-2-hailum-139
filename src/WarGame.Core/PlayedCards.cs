namespace WarGame.Core;

public class PlayedCards
{
    public Dictionary<string, Card> RoundCards;
    public List<Card> Pot;

    public PlayedCards()
    {
        RoundCards = new Dictionary<string, Card>();
        Pot = new List<Card>();
    }

    public void PlayCard(string playername, Card card) //this method is to create add the card a player plays to the pot and the dictionary that matches their name to that card
    {
        RoundCards[playername] = card;
        this.Pot.Add(card);
    }

    public List<string> GetWinnerList()
    {
        List<string> WinnersList = new List<string>();
        Card highestcard = null;

        foreach (var roundcard in RoundCards)
        {
            Card currentcard = roundcard.Value;
            if (highestcard == null || currentcard.CompareTo(highestcard) > 0)
            {
                highestcard = currentcard;
                WinnersList.Clear();//if a card is higher then it clears the whole list before adding the new winner
                WinnersList.Add(roundcard.Key);
            }
            else if (currentcard.CompareTo(highestcard) == 0)
            { 
                WinnersList.Add(roundcard.Key);//but when both cards are equal then we dont clear the list because players are winners of that round            
            }
        }
        RoundCards.Clear();
        return WinnersList;
    }

    public List<Card> ClearPot()//since the pot is used over and over again we use this method to ensure that there are no leaks during rounds
    {
        var winnings = new List<Card>(Pot);
        Pot.Clear();
        RoundCards.Clear();
        return winnings;
    }
}
