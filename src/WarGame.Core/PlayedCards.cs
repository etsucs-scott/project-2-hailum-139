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

    public void PlayCard(string playername, Card card)
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
                WinnersList.Clear();
                WinnersList.Add(roundcard.Key);
            }
            else if (currentcard.CompareTo(highestcard) == 0)
            { 
                WinnersList.Add(roundcard.Key);            
            }
        }
        RoundCards.Clear();
        return WinnersList;
    }

    public List<Card> ClearPot()
    {
        var winnings = new List<Card>(Pot);
        Pot.Clear();
        RoundCards.Clear();
        return winnings;
    }
}
