namespace WarGame.Core;

public class Round
{
    public PlayedCards CardsforRound;

    public Round()
    {
        CardsforRound = new PlayedCards();
    }

    public void RevealTopCard(string playername, Card card)
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
