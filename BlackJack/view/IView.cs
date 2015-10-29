﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    interface IView
    {
        void AddSubscribers(model.BlackJackObserver a_sub);
        void DisplayWelcomeMessage();
        model.Game.Status GetInput();
        void DisplayCard(model.Card a_card);

        void DisplayHands();

        void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayGameOver(bool a_dealerIsWinner);
    }
}
