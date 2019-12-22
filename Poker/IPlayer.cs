using System.Collections.Generic;


namespace Poker
{
    public interface IPlayer
    {
         string PlayerName{ get; set; }
         List<ICard> Cards { get; set; }
         int Score { get; set; }
         bool IsFlush { get; set; }
         bool IsThreeOfaKind { get; set; }
         bool IsOnePair { get; set; }


    }
    

}
