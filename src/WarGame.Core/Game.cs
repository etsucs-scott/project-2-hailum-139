namespace WarGame.Core;

public class Game
{
    public int PlayerNumber;
    public List<string> Names;
    public Deck GameDeck;
    public PlayerHands HandOrganizer;
    public Round CurrentRound;

    public Game()
    { 
        PlayerNumber = 0;
        Names = new List<string>();
        GameDeck = new Deck();
        HandOrganizer = new PlayerHands();
        CurrentRound = new Round();
    }

    public void StartGame()
    {
        int playernumber = 0;
        bool gamecanstart = false;
        while (!gamecanstart)//this loop ensures that the user inputs the appropriate number of player to start the game
        {
            Console.WriteLine("Enter the number of players(2-4): ");
            string word = Console.ReadLine();
            if (int.TryParse(word, out playernumber) && playernumber >=2 && playernumber <=4)
            {
                gamecanstart = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number from 2-4.");
                Console.Clear();

            }
        }
        this.PlayerNumber = playernumber;

        for ( int i = 1; i <= playernumber; i++)
        {
            string player = "Player" + i;
            this.Names.Add(player);
        }

    }
    public void DistributeDeck()
    {        
        while (this.GameDeck.Count() > 0)
        {
            foreach (string name in this.Names)
            {
                if (this.GameDeck.Count() == 0) break;//this ensures that the loop stops distributing cards if the deck reaches zero otherwise it might start giving out null cards

                Card card = this.GameDeck.Draw();
                this.HandOrganizer.AddCard(name, card);
            }
        }
    }
    public void Play()
    {
        int rounds = 0;
        const int maxRounds = 10000;

        while (HandOrganizer.GetActivePlayer().Count > 1 && rounds < maxRounds)//this loop ensures that the game only continues if there is more than 1 player still in the game or if the max round is reached
        {
            rounds++;
            ExecuteRound(rounds);
        }

        DetermineWinner(rounds >= maxRounds);
    }
    private void ExecuteRound(int roundNumber)
    {
        Console.Clear();
        Console.WriteLine($"Round {roundNumber}");
        //this is to ensure that there are no leaks incase of code changes in the future that might cause leaks or if the potclear method isn't used properly
        CurrentRound.CardsforRound.Pot.Clear();
        CurrentRound.CardsforRound.RoundCards.Clear();

        List<string> activeInRound = HandOrganizer.GetActivePlayer();
        bool isTie = false;

        while (activeInRound.Count > 1)//this is to ensure that round continues as long as there are players with the same highest rank
        {
            List<string> playernames = new List<string>();

            foreach (string name in activeInRound)
            {
                Card drawn = HandOrganizer.RemoveCard(name);
                if (drawn != null)
                {
                    CurrentRound.RevealTopCard(name, drawn);
                    playernames.Add($"{name}: {drawn.Rank}");
                }
            }

            Console.WriteLine((isTie ? "Tiebreaker: " : "") + string.Join(" | ", playernames));

            activeInRound = CurrentRound.GetWinnerList();

            if (activeInRound.Count > 1)//if there is more than one winner this tells the computer how to continue since there is going to be different ouput for a tiebreaker round than a regular round
            {
                isTie = true;
                Console.WriteLine($"Tie between {string.Join(" and ", activeInRound)}!");

                string potContents = string.Join(", ", CurrentRound.CardsforRound.Pot.Select(c => c.Rank));
                Console.WriteLine($"Pot includes: {potContents}");

                activeInRound = activeInRound.Where(n => HandOrganizer.Players[n].Count() > 0).ToList();
                if (activeInRound.Count <= 1) break;// this is to ensure that if a player where to run out of cards during a tiebreaker they get eliminated
            }
        }

        if (activeInRound.Count == 1)
        {
            string winner = activeInRound[0];
            List<Card> winnings = CurrentRound.ClearPot();
            HandOrganizer.AddMultipleCards(winner, winnings);

            List<string> countStrings = new List<string>();
            foreach (var entry in HandOrganizer.Players)
            {
                string shortName = entry.Key.Replace("Player ", "P");
                countStrings.Add($"{shortName}={entry.Value.Count()}");
            }

            Console.WriteLine($"Winner: {winner} (Cards: {string.Join(", ", countStrings)})");
        }

        HandOrganizer.EliminatePlayers();

        Console.WriteLine("[ Press any key for next round ]");
        Console.ReadKey(true);//these two statements are to have a clear output during each round
    }

    private void DetermineWinner(bool hitLimit)
    {
        Console.Clear();
        var survivors = HandOrganizer.GetActivePlayer();

        if (survivors.Count == 1)
        {
            Console.WriteLine($"GAME OVER! {survivors[0]} wins the game!");
        }
        else if (hitLimit)
        {
            Console.WriteLine("ROUND LIMIT REACHED!");
            string leader = survivors.OrderByDescending(n => HandOrganizer.Players[n].Count()).First();
            Console.WriteLine($"Winner by card count: {leader}");
        }
    }
}

    