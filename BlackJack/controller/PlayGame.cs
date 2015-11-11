using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.IBlackJackObserver
    {
        view.IView m_view;
        model.Game m_game;

        public PlayGame(view.IView a_view, model.Game a_game)
        {
            m_view = a_view;
            m_game = a_game;

            // Subscribe to observer
            m_game.AddSubscribtionToCards(this);
        }
        public bool Play()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            model.Game.Status input = m_view.GetInput();

            if (input == model.Game.Status.NewGame)
            {
                m_game.NewGame();
            }
            else if (input == model.Game.Status.Hit)
            {
                m_game.Hit();
            }
            else if (input == model.Game.Status.Stand)
            {
                m_game.Stand();
            }

            return input != model.Game.Status.Quit;
        }
        public void NewCardDealt(IEnumerable<model.Card> a_hand, int a_score)
        {
            m_view.DisplayPlayerHand(a_hand, a_score);
        }

        // Observer listener method
        public void GotCard(model.Card card, String playerName)
        {
            m_view.DisplayCard(card, playerName);

            m_view.DoSleep();
        }

    }
}
