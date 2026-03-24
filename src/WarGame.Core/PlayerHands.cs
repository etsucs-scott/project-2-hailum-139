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
        if (!Players.TryGetValue(playername, out Hand playerhand))// this is to ensure that the name listed in the parameter is actually a key inside the dictionary 
        {
            playerhand = new Hand();
            this.Players.Add(playername, playerhand);//if it isn't a key of the dictionary yet it makes it one 
        }
        playerhand.AddCard(card);//writing this statement after the first if statement ensures that the card is added to a player's hand even if the player wasn't in the dictionary at first
    }
    public void AddMultipleCards(string playername, List<Card> cards)
    {
        Players[playername].AddMultipleCards(cards);
    }
    public List<string> GetActivePlayer()//this method is to create a list of the names of the players that are eligible to play in the round
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
    public void EliminatePlayers()//if a player doesn't have any cards left to play they should be eliminated
    {
        List<string> EliminatedPlayers = new List<string>();
        foreach (var playername in Players)//this loop checks whether each player has atleast one card and if they don't it adds them to a list of players that are about to be eliminated
        {
            if (playername.Value.Count() == 0)
            {
                EliminatedPlayers.Add(playername.Key);
            }
        }
        foreach (var playername in EliminatedPlayers)//this loop eliminates all of the players in said list
        {
            this.Players.Remove(playername);
        }
    }
}