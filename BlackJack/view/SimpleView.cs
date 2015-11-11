using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.view
{
    class SimpleView : IView
    {
 
        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
        }

        public model.Game.Status GetInput()
        {
            string input = System.Console.ReadLine();

            System.Console.WriteLine();

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

            System.Console.WriteLine("{0}{1} of {2}", playerStr, a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }
    }
}
