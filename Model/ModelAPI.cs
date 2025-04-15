using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Logic.BallLogic;

namespace Model
{
    public class ModelAPI
    {
        // posredniczymy miedzy widokiem a logika, wiec przechowujemy dwei kolekcje
        // pierwsza przechowuje aktualny stan 
        Collection<IBallLogic> ballsLogic;

        // a druga przechowuje reprezentacje kuli do wyswietlenia
        //ObservableCollection<BallViewModel> ballsViewModels;

        public void MoveBalls(int width, int height)
        {
            foreach (var ball in ballsLogic)
            {
                // aktualizujemy pozycje kuli
                ball.MoveBall(width, height);
            }

            // sprawdzamy kazda kule z kazda
            for (int i = 0; i < ballsLogic.Count; i++)
            {
                for (int j = i + 1; j < ballsLogic.Count; j++)
                {
                    // sprawdzamy kolizje
                    ballsLogic[i].HandleCollision(ballsLogic[j].BallData);
                }
            }

        }

        public IEnumerable<IBallLogic> Start(int ballAmount, int width, int height)
        {
            // inicjalizujemy kolekcje
            ballsLogic = new Collection<IBallLogic>();
            //ballsViewModels = new ObservableCollection<BallViewModel>();
            // tworzymy kule
            for (int i = 0; i < ballAmount; i++)
            {
                var ballLogic = new BallLogic(width, height);
                ballsLogic.Add(ballLogic);
                //var ballViewModel = new BallViewModel(ballLogic.BallData.X, ballLogic.BallData.Y, ballLogic.BallData.Radius);
                //ballsViewModels.Add(ballViewModel);
            }
            
            return ballsLogic;
        }
    }
}