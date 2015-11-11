using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsEqualScoreStrategy : BaseWinsEqualScoreStrategy
    {
        public override bool IsDealerWinnerOnEqualScore(int dealerScore, int playerScore)
        {
            return dealerScore >= playerScore;
        }
    }
}
