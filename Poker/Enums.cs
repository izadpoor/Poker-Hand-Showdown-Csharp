namespace Poker
{

    public enum RankType { One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace}
    public enum SuitType { Clubs=1, Diamond, Heart, Spades};
    public enum ErrorType{ NumberCardsAreInvalid=110, DuplicatedCardInOneHand = 111 , DuplicatedCardInAllHand =112, DuplicatedPlayer = 113, OnePlayer = 114 };


}
