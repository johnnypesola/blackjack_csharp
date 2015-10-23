using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface BlackJackObserver
    {
        void NewCardDealt(IEnumerable<Card> a_hand, int a_score);
    }
}
