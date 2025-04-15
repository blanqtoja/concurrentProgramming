using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    // klasa reprezentujaca tylko dane do wyswietlenia
    public class BallViewModel : ViewModelBase
    {
        private double x;
        private double y;
        private double radius;

        // konstruktor przyjmujacy dane kuli
        public BallViewModel(double x, double y, double r)
        {
            X = x;
            Y = y;
            Radius = r;
        }

        // udostepnienei do bindingow
        public double X
        {
            get => x;
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public double Y
        {
            get => y;
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public double Radius
        {
            get => radius;
            set
            {
                if (radius != value)
                {
                    radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
            }
        }

    }
}
