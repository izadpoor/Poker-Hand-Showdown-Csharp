using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerUnitTests
{

    [TestClass]
    public class UnitTestPokerHand
    {
        [TestMethod]
        public void Test_Is_Player_Cards_Flush()
        {
            
            
            List<ICard> cards = new List<ICard>();
            IPlayer playerHand;
            cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand = new Player("Joe", cards);
            //playerhand1.


            //Assert
            Assert.AreEqual(playerHand.IsFlush, true);

        }

        [TestMethod]
        public void Test_Is_Player_Cards_ThreeOfAKind()
        {

            List<ICard> cards = new List<ICard>();
            IPlayer playerHand;

            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            playerHand = new Player("Joe", cards);
            


            //Assert
            Assert.AreEqual(playerHand.IsThreeOfaKind, true);

        }

        [TestMethod]
        public void Test_Is_Player_Cards_OnePair()
        {

            List<ICard> cards = new List<ICard>();
            IPlayer playerHand;

            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Diamond });
            playerHand = new Player("Joe", cards);



            //Assert
            Assert.AreEqual(playerHand.IsOnePair, true);

        }

        [TestMethod]
        public void Test_There_Are_More_Or_Less_Than_5_Cards_In_One_Player_Hand()

        {
            List<ICard> cards = new List<ICard>();
            IPlayer playerHand;

            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Diamond });
            cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Diamond });


            //Act
            try
            {
                playerHand = new Player("Joe", cards);

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "ErrorCode:" + (int)ErrorType.NumberCardsAreInvalid);
                return;
            }

            Assert.Fail("No exception was thrown.");

        }
        [TestMethod]
        public void Test_Is_Duplicate_Card_In_One_Player_Hand()

        {
            List<ICard> cards = new List<ICard>();
            IPlayer playerHand;

            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });


            //Act
            try
            {
                playerHand = new Player("Joe", cards);
                
            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "ErrorCode:" + (int)ErrorType.DuplicatedCardInOneHand);
                return;
            }

            Assert.Fail("No exception was thrown.");

        }

        [TestMethod]
        public void Test_Is_Duplicate_Card_In_All_Players_Hand()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Four, Suit = SuitType.Clubs });
            player1_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            playerHand2 = new Player("Bobe", player2_cards);


            
            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2 });

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "ErrorCode:" + (int)ErrorType.DuplicatedCardInAllHand);
                return;
            }

            Assert.Fail("No exception was thrown.");

        }

        [TestMethod]
        public void Test_Is_Duplicate_Player()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Four, Suit = SuitType.Clubs });
            player1_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            playerHand2 = new Player("Joe", player2_cards);



            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2 });

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "ErrorCode:" + (int)ErrorType.DuplicatedPlayer);
                return;
            }

            Assert.Fail("No exception was thrown.");

        }


        [TestMethod]
        public void Test_If_There_Is_Only_One_Winner_Player()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            List<ICard> player3_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IPlayer playerHand3;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Diamond });
            player2_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Spades });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Diamond });
            playerHand2 = new Player("Jen", player2_cards);

            player3_cards.Add(new Card() { Rank = RankType.Two, Suit = SuitType.Heart });
            player3_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Clubs });
            player3_cards.Add(new Card() { Rank = RankType.Seven, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Clubs });
            player3_cards.Add(new Card() { Rank = RankType.Ace, Suit = SuitType.Clubs });
            playerHand3 = new Player("Bob", player3_cards);

            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2, playerHand3 });
                var winners= evaluator.GetWinners();
                //Assert
                Assert.AreEqual(winners.Count, 1);

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.StartsWith(ex.Message.ToString(), "ErrorCode:");
                return;
            }


        }

        [TestMethod]
        public void Test_If_There_are_Two_Winner_Players()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            List<ICard> player3_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IPlayer playerHand3;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Diamond });
            player2_cards.Add(new Card() { Rank = RankType.Two, Suit = SuitType.Diamond });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Diamond });
            playerHand2 = new Player("Jen", player2_cards);

            player3_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Spades });
            playerHand3 = new Player("Bob", player3_cards);

            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2, playerHand3 });
                var winners = evaluator.GetWinners();
                //Assert
                Assert.AreEqual(winners.Count, 2);

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.StartsWith(ex.Message.ToString(), "ErrorCode:");
                return;
            }

            

        }


        [TestMethod]
        public void Test_Three_Players_Are_Flush_But_HighCard_Is_Winner()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            List<ICard> player3_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IPlayer playerHand3;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Four, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Six, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Clubs });
            playerHand2 = new Player("Jen", player2_cards);

            player3_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Spades });
            playerHand3 = new Player("Bob", player3_cards);

            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2, playerHand3 });
                var winners = evaluator.GetWinners();
                //Assert
                Assert.AreEqual(winners[0].PlayerName, "Bob");

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.StartsWith(ex.Message.ToString(), "ErrorCode:");
                return;
            }



        }

        [TestMethod]
        public void Test_Three_Players_Are_ThreeOfaKind_But_HighCard_Is_Winner()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            List<ICard> player3_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IPlayer playerHand3;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Diamond });
            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Clubs });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Diamond });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Clubs });
            playerHand2 = new Player("Jen", player2_cards);

            player3_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            player3_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Spades });
            playerHand3 = new Player("Bob", player3_cards);

            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2, playerHand3 });
                var winners = evaluator.GetWinners();
                //Assert
                Assert.AreEqual(winners[0].PlayerName, "Jen");

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.StartsWith(ex.Message.ToString(), "ErrorCode:");
                return;
            }



        }


        [TestMethod]
        public void Test_Three_Players_Are_OnePair_But_HighCard_Is_Winner()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            List<ICard> player3_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IPlayer playerHand3;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Diamond });
            player1_cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Clubs });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Two, Suit = SuitType.Diamond });
            player2_cards.Add(new Card() { Rank = RankType.Two, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Clubs });
            playerHand2 = new Player("Jen", player2_cards);

            player3_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            player3_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Spades });
            playerHand3 = new Player("Bob", player3_cards);

            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2, playerHand3 });
                var winners = evaluator.GetWinners();
                //Assert
                Assert.AreEqual(winners[0].PlayerName, "Joe");

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.StartsWith(ex.Message.ToString(), "ErrorCode:");
                return;
            }



        }


        [TestMethod]
        public void Test_Three_Players_Random_Cards_HighCard_Is_Winner()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            List<ICard> player3_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IPlayer playerHand3;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Two, Suit = SuitType.Diamond });
            player1_cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Clubs });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Two, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Seven, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Clubs });
            playerHand2 = new Player("Jen", player2_cards);

            player3_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            player3_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Spades });
            playerHand3 = new Player("Bob", player3_cards);

            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2, playerHand3 });
                var winners = evaluator.GetWinners();
                //Assert
                Assert.AreEqual(winners[0].PlayerName, "Joe");

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.StartsWith(ex.Message.ToString(), "ErrorCode:");
                return;
            }



        }

        [TestMethod]
        public void Test_Two_Pair__And_one_Random_Hand_Players_HighCard_In_two_Pair_Is_Winner()

        {
            List<ICard> player1_cards = new List<ICard>();
            List<ICard> player2_cards = new List<ICard>();
            List<ICard> player3_cards = new List<ICard>();
            IPlayer playerHand1;
            IPlayer playerHand2;
            IPlayer playerHand3;
            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Diamond });
            player1_cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Clubs });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);


            player2_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Heart });
            player2_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Queen, Suit = SuitType.Clubs });
            player2_cards.Add(new Card() { Rank = RankType.Ten, Suit = SuitType.Clubs });
            playerHand2 = new Player("Jen", player2_cards);

            player3_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Five, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.Eight, Suit = SuitType.Diamond });
            player3_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Spades });
            player3_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Spades });
            playerHand3 = new Player("Bob", player3_cards);

            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1, playerHand2, playerHand3 });
                var winners = evaluator.GetWinners();
                //Assert
                Assert.AreEqual(winners[0].PlayerName, "Jen");

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.StartsWith(ex.Message.ToString(), "ErrorCode:");
                return;
            }



        }

        [TestMethod]
        public void Test_Only_One_Players()

        {
            List<ICard> player1_cards = new List<ICard>();
    
            IPlayer playerHand1;

            IEvaluator evaluator;

            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.Three, Suit = SuitType.Diamond });
            player1_cards.Add(new Card() { Rank = RankType.Nine, Suit = SuitType.Clubs });
            player1_cards.Add(new Card() { Rank = RankType.Jack, Suit = SuitType.Heart });
            player1_cards.Add(new Card() { Rank = RankType.King, Suit = SuitType.Heart });
            playerHand1 = new Player("Joe", player1_cards);



            //Act
            try
            {
                evaluator = new Evaluator(new List<IPlayer> { playerHand1 });
                var winners = evaluator.GetWinners();

            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "ErrorCode:" + (int)ErrorType.OnePlayer);

                return;
            }



        }




    }
}
