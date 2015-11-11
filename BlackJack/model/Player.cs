﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.model
{
    class Player : model.IBlackJackObserver
    {
        protected List<Card> m_hand = new List<Card>(20);

        virtual protected String name
        {
            get
            {
                return "Player";
            }
        }

        public void DealCard(Card a_card)
        {
            m_hand.Add(a_card);
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public bool HasAce()
        {
            foreach (Card c in GetHand())
            {
                if(c.GetValue() == Card.Value.Ace)
                {
                    return true;
                }
            }

            return false;
        }

        public int CalcScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }
        public string GetName()
        {
            return name;
        }
        public int GetScore()
        {
            return CalcScore();
        }
    }
}
