using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game
    {
        public enum Status
        {
            NewGame,
            Hit,
            Stand,
            Quit,
            Undefined
        }

        // Init variables
        private Dealer m_dealer;
        private Player m_player;

        // Constructor
        public Game(view.IView view)
        {
            m_dealer = new Dealer(new rules.RulesFactory());
            m_player = new Player();
        }

        // Public methods
        public void AddSubscribtionToCards(IBlackJackObserver a_sub)
        {
            m_dealer.AddSubscriber(a_sub);
            m_player.AddSubscriber(a_sub);
        }

        public void RemoveSubscriptionToCards(IBlackJackObserver a_sub)
        {
            m_dealer.RemoveSubscriber(a_sub);
            m_player.RemoveSubscriber(a_sub);
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            return m_dealer.Hit(m_player);
        }

        public bool Stand()
        {
            m_dealer.Stand();
            return true;
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }
    }
}
