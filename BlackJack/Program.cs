using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //view.IView v = new view.SwedishView();
            view.IView v = new view.SimpleView(); 
            model.Game g = new model.Game(v);
            controller.PlayGame ctrl = new controller.PlayGame(v, g);

            while (ctrl.Play());
        }
    }
}
