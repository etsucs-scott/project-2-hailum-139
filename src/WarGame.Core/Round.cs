namespace WarGame.Core;

public class Round
{
    public PlayedCards CardsforRound;

    public Round()
    {
        CardsforRound = new PlayedCards();
    }

    public void RevealTopCard(string playername, Card card)//The methods used on the PlayedCards field are encapsulated in these methods to protect invariants
    {
        CardsforRound.PlayCard(playername, card);
    }

    public List<String> GetWinnerList()
    {
        return CardsforRound.GetWinnerList();
    }

    public List<Card> ClearPot()
    {
        return CardsforRound.ClearPot();
    }
}
