using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Evaluator : IEvaluator
    {
        private readonly List<ICard> _allPlayerCards = new List<ICard>();

        public List<IPlayer> Players { get; set; }

        public Evaluator(List<IPlayer> players)
        {
            Players = players;

            foreach (var player in players)
                _allPlayerCards.AddRange(player.Cards);

            validationPlayers();

        }

        private void validationPlayers()
        {

            string errorMessage = null;

            // check if only one player contribute 
            if (Players.Count == 1)
                errorMessage += "ErrorCode:" + (int)ErrorType.OnePlayer + " " + Players[0].PlayerName + " is the only player, at least need two players for the poker game\n";

            // check if there same player is duplicated 
            foreach (var item in Players.GroupBy(p => p.PlayerName).Where(c => c.Count() > 1))
            {
                errorMessage += "ErrorCode:" + (int)ErrorType.DuplicatedPlayer +" "+ item.Key+ " is duplicated player \n";

            }

            //check if there is duplicated same card in diffrent player hand ex. 2Heart in play1 hand and player2 hand
            foreach (var item in _allPlayerCards.GroupBy(c => (c.Rank, c.Suit)).Where(g => g.Count() > 1))
            {
                errorMessage += "ErrorCode:" + (int)ErrorType.DuplicatedCardInAllHand + " Card " + item.Key.Rank + " " + item.Key.Suit + " is duplicated " + item.Count() + " times in player hands\n";
            }
            if (errorMessage != null)
                throw new Exception(errorMessage);

        }


        public List<IPlayer> GetWinners()
        {

            List<IPlayer> winnerPlayer = new List<IPlayer>();
            foreach (var item in Players.GroupBy(p => p.Score).OrderByDescending(g => g.Key))
            {
                winnerPlayer.AddRange(item);
                break;
            }

            return winnerPlayer;

        }
    }
}
