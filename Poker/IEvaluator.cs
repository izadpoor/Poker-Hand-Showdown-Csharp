using System.Collections.Generic;


namespace Poker
{
    public interface IEvaluator
    {
        List<IPlayer> Players{ get; set; }

        List<IPlayer> GetWinners();
    }
}