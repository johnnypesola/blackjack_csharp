﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface IBlackJackObserver
    {
        void GotCard(Card card, String playerName);
    }
}
