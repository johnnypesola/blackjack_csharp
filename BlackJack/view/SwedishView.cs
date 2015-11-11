using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.view
{
    class SwedishView : IView 
    {
        List<model.IBlackJackObserver> m_observers;
        public void AddSubscribers(model.IBlackJackObserver a_sub)
        {
            if (m_observers == null)
            {
                m_observers = new List<model.IBlackJackObserver>();
            }
            m_observers.Add(a_sub);
        }

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hej Black Jack Världen");
            System.Console.WriteLine("Skriv 'p' för att Spela, 'h' för nytt kort, 's' för att stanna 'q' för avsluta\n");
        }


        public model.Game.Status GetInput()
        {
            //int input = System.Console.In.Read();
            string input = System.Console.ReadLine();

            switch (input)
            {
                case "p":
                    return model.Game.Status.NewGame;
                case "s":
                    return model.Game.Status.Stand;
                case "h":
                    return model.Game.Status.Hit;
                case "q":
                    return model.Game.Status.Quit;
                default:
                    return model.Game.Status.Undefined;
            }
        }

        public void DisplayCard(model.Card a_card, String playerStr = "")
        {
            playerStr = (playerStr == "" ? "" : String.Format("{0} got ", playerStr));

            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Spelare", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealern", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} har: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Poäng: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealern vann!");
            }
            else
            {
                System.Console.WriteLine("Du vann!");
            }

        }
    }
}
