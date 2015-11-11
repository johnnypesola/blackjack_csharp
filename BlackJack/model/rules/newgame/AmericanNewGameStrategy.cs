using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : BaseNewGameStrategy
    {
        public override bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            ProcessCard(a_deck, a_player, true);
            ProcessCard(a_deck, a_dealer, true);
            ProcessCard(a_deck, a_player, true);
            ProcessCard(a_deck, a_dealer, false);

            return true;
        }
    }
}
