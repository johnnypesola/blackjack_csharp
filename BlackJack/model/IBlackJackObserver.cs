using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface IBlackJackObserver
    {
        /*
        string GetName();
        int GetScore();
        IEnumerable<Card> GetHand();
        */

        void GotCard(Card card, String playerName);
    }
}
