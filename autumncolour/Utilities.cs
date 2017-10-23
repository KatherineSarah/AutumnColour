using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace autumncolour
{
    public static class Utilities
    {

        public static List<LeafColour> GetPossibleColours(Color currentLeafColour)
        {
            List<LeafColour> possibles = new List<LeafColour>();

            if (currentLeafColour == Colors.ForestGreen)
            {
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(currentLeafColour),
                    Probability = 0.84
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.OrangeRed),
                    Probability = 0.05
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Red),
                    Probability = 0.05
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.DarkOrange),
                    Probability = 0.05
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Yellow
                    ),
                    Probability = 0.01
                });
            }
            else if (currentLeafColour == Colors.OrangeRed)
            {
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(currentLeafColour),
                    Probability = 0.50
                });

                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Red),
                    Probability = 0.2
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Orange),
                    Probability = 0.20
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Yellow
                ),
                    Probability = 0.10
                });

            }


            else if (currentLeafColour == Colors.Red)
            {
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(currentLeafColour),
                    Probability = 0.50
                });

                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.OrangeRed),
                    Probability = 0.2
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Orange),
                    Probability = 0.20
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Yellow
                ),
                    Probability = 0.10
                });

            }
            else if (currentLeafColour == Colors.Orange)
            {
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(currentLeafColour),
                    Probability = 0.50
                });

                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Yellow
                ),
                    Probability = 0.50
                });

            }
            else if (currentLeafColour == Colors.Yellow)
            {
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(currentLeafColour),
                    Probability = 0.90
                });

                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Brown)
                ,
                    Probability = 0.10
                });

            }
            else
            {
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(currentLeafColour),
                    Probability = 1
                });
            }
            return possibles;
        }


        public  static Brush ColorChange(Color colour)
        {
            var currentLeafColour = new LeafColour() { Colour = new SolidColorBrush(colour), Probability = 1 };

            Leaf leaf = new Leaf()
            {
                CurrentColour = currentLeafColour,
                PossibleColours = Utilities.GetPossibleColours(colour)
            };
            Brush selectedColour = new SolidColorBrush();
            Random r = new Random();
            double diceRoll = r.NextDouble();
            Debug.Print(diceRoll.ToString());
            double cumulative = 0.0;
            for (int i = 0; i < leaf.PossibleColours.Count; i++)
            {
                cumulative += leaf.PossibleColours[i].Probability;
                if (diceRoll < cumulative)
                {
                    selectedColour = leaf.PossibleColours[i].Colour;
                    break;
                }
            }
            Thread.Sleep(10);
            return selectedColour;
        }
    }


}
