using Poker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<IPlayer> allPlayers = new List<IPlayer>();
            List<ICard> cards = new List<ICard>();

            cards.Add(new Card() {  Rank = RankType.Three, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Four, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Seven, Suit = SuitType.Heart });
            IPlayer playerhand1 = new Player("Joe", cards);


            cards.Clear();
            cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Spades });
            cards.Add(new Card() { Rank = RankType.Seven, Suit = SuitType.Spades });
            cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Spades });
            cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Clubs });
            cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Spades });
            IPlayer playerhand2 = new Player("Jen", cards);

            cards.Clear();
            cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Diamond });
            cards.Add(new Card() { Rank = RankType.Seven, Suit = SuitType.Diamond });
            cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Diamond });
            cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Diamond });
            IPlayer playerhand3 = new Player("Bobe", cards);

            
            //IPlayer playerhand4 = new Player(cards);
            allPlayers.Add(playerhand1);
            allPlayers.Add(playerhand2);
            allPlayers.Add(playerhand3);
            //allPlayers.Add(playerhand4);

            var evaluator = new Evaluator(allPlayers);
            
            var winners= evaluator.GetWinners();



        }
    }
}

