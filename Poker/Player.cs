using System;
using System.Collections.Generic;
using System.Linq;



namespace Poker
{
    public class Player : IPlayer
    {
        public Player(string playerName, List<ICard> cards)
        {

            Cards = cards.OrderByDescending(c => c.Rank).ToList();
            PlayerName = playerName;
            Score = 0;

            //validate player cards if there is any less/more card in hand and any duplicated card!
            validationHandCards();

            checkFlush();
            // if player hand is flush it does not need to check the rest rules ( threeofkind or onepair) this help to save cpu time
            if (!IsFlush)
            {
                checkPairCards();
                PairSortCards();
            }
            calculateScore();

        }
        /// <summary>
        /// This method will sort the list based on the pair situation to let the scoring algorithm work properly based on a mathematical formula
        /// </summary>
        private void PairSortCards()
        {
            //get list of cards which there is/are pair for that
            var pairList = Cards.GroupBy(c => c.Rank).Where(g => g.Count() > 1).ToList();
            //list of rest of cards which there are not pair/s
            var unpairList = Cards.GroupBy(c => c.Rank).Where(g => g.Count() == 1).OrderByDescending(cd => cd.Key).ToList();
            pairList.AddRange(unpairList);

            Cards.Clear();
            foreach (var item in pairList)
            {
                Cards.AddRange(item.ToList());
            }
        }

        /// <summary>
        /// Empowering the card postion based on the sort position, this is a simple mathematical formula
        /// for instance if Ace stay at position 0 ( in sorted list) there is chance the same card or one of other 12 cards comes after that in postion 1 and so on.
        /// Here I empower each card based on its position to make sure if the other cards in the list even after empowering will be less than that card score value, This helps to make a proper scoring model
        /// HandScore = (X0*13^4) + (X1*13^3) + (X2*13^2) + (X3*13) + X4 
        ///Then after calculating the cards total score,  empowering the total score by rule weight  (isflash = 13^7, IsThreeOfaKind=13^6, IsOnePair=13^5) 
        /// </summary>
        private void calculateScore()
        {
            for (int i = 4; i >= 0; --i)
            {
                Score += (int)((int)Cards[4-i].Rank * Math.Pow(13, i));
            }
            // Empowering card score by game rule weigh (ex. Flush has more value than ThreeOfaKind,...)
            if (IsOnePair)
                Score +=  (int)Math.Pow(13, 5);
            else if (IsThreeOfaKind)
                Score += (int)Math.Pow(13, 6);
            else if (IsFlush)
                Score += (int)Math.Pow(13, 7);


        }

        private void validationHandCards()
        {
            string errorMessage = null;

            if (Cards.Count() != 5)
                errorMessage += "ErrorCode:" + (int)ErrorType.NumberCardsAreInvalid + " Each hand must have exactly 5 cards not more or less\n";

            foreach (var item in Cards.GroupBy(c => (c.Rank, c.Suit)).Where(g => g.Count() > 1))
            {
                errorMessage += "ErrorCode:" + (int)ErrorType.DuplicatedCardInOneHand + " Card " + item.Key.Rank + " " + item.Key.Suit + " is duplicated " + item.Count() + " times \n";
            }
            if (errorMessage != null)
                throw new Exception(errorMessage);

        }

        public int Score { get; set; }
        public bool IsFlush { get; set; }

        public bool FourOfaKind { get; set; }
        public bool IsThreeOfaKind { get; set; }
        public bool IsTwoPair { get; set; }
        public bool IsOnePair { get; set; }

        /// <summary>
        /// This function validate the player cards to figure of if there is ThreeOfaKind or OnePair in hands and set the flag accordingly
        /// </summary>
        private void checkPairCards()
        {
            // how many pair category of cards are in hand  ( ex. say (Q,Q)(10)(4)(2)/ (Q,Q,Q)(10)(4)
            int pairCount = Cards.GroupBy(c => c.Rank).Count();
            //find the longest pair length (1,2,3,4)
            var longestGrouplength = Cards.GroupBy(c => c.Rank).Select(group => group.Count()).OrderByDescending(len => len).First();


            switch (pairCount)
            {
                case 2:
                    if (longestGrouplength == 4)
                    {
                        FourOfaKind = true;
                        IsThreeOfaKind = true;
                        IsTwoPair = false;
                        IsOnePair = false;
                    }
                    else
                    {
                        FourOfaKind = false;
                        IsThreeOfaKind = true;
                        IsTwoPair = true;
                        IsOnePair = false;

                    }
                    break;

                case 3: // there is chance to be 3,1,1 Or 2,2,1 so we have to make sure pick only one of them
                    FourOfaKind = false;
                    if (longestGrouplength == 3)
                        IsThreeOfaKind = true;
                    else
                        IsTwoPair = true;
                    IsOnePair = false;
                    break;
                case 4:
                    FourOfaKind = false;
                    IsThreeOfaKind = false;
                    IsTwoPair = false;
                    IsOnePair = true;
                    break;

                default:
                    FourOfaKind = false;
                    IsThreeOfaKind = false;
                    IsTwoPair = false;
                    IsOnePair = false;
                    break;
            }


        }

        private void checkFlush()
        {
            IsFlush= Cards.GroupBy(c => c.Suit).Count()==1;

        }
        
        public string PlayerName { get; set; }
        /// <summary>
        /// List of the cards that each player has in hand
        /// </summary>
        public List<ICard> Cards { get; set; }


    }


}
