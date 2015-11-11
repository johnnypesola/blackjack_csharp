using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.view
{
    abstract class BaseView : IView
    {

        abstract public void DisplayWelcomeMessage();

        abstract public void DisplayCard(model.Card a_card, string playerName);

        abstract public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score);

        abstract public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score);

        abstract public void DisplayGameOver(bool a_dealerIsWinner);

        public void DoSleep()
        {
            Thread.Sleep(1000);
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
    }
}
