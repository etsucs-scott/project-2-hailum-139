namespace WarGame.Core;

public class PlayerHands
{
    public Dictionary<string, Hand> Players;

    public PlayerHands()
    {
        Players = new Dictionary<string, Hand>();
    }

    public void AddCard(string playername, Card card)
    {
        if (!Players.TryGetValue(playername, out Hand playerhand))
        {
            playerhand = new Hand();
            this.Players.Add(playername, playerhand);
        }
        playerhand.AddCard(card);
    }
    public void AddMultipleCards(string playername, List<Card> cards)
    {
        Players[playername].AddMultipleCards(cards);
    }
    public List<string> GetActivePlayer()
    {
        List<string> activePlayers = new List<string>();
        foreach (var playername in Players)
        {
            if (playername.Value.Count() > 0)
            {
                activePlayers.Add(playername.Key);
            }
        }
        return activePlayers;
    }
    public Card RemoveCard(string playername)
    {
        if (Players.ContainsKey(playername))
        {
            return Players[playername].RemoveCard();
        }
        return null;
    }
    public void EliminatePlayers()
    {
        List<string> EliminatedPlayers = new List<string>();
        foreach (var playername in Players)
        {
            if (playername.Value.Count() == 0)
            {
                EliminatedPlayers.Add(playername.Key);
            }
        }
        foreach (var playername in EliminatedPlayers)
        {
            this.Players.Remove(playername);
        }
    }
}