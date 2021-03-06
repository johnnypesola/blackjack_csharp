﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWinStrategy
    {

        bool IsDealerWinner(Player a_dealer, Player a_player);

        int MaxScore
        {
            get;
        }

        bool IsDealerWinnerOnEqualScore(int dealerScore, int playerScore);
    }
}
