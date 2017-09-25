using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace autumncolour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> gridOne = new List<TextBox>();
            gridOne.Add(textBox);
            gridOne.Add(textBox_Copy);
            gridOne.Add(textBox_Copy1);
            gridOne.Add(textBox_Copy2);
            gridOne.Add(textBox_Copy3);
            gridOne.Add(textBox_Copy4);
            gridOne.Add(textBox_Copy5);
            gridOne.Add(textBox_Copy6);
            gridOne.Add(textBox_Copy7);
            gridOne.Add(textBox_Copy8);
            gridOne.Add(textBox_Copy9);
            gridOne.Add(textBox_Copy10);
            gridOne.Add(textBox_Copy11);
            gridOne.Add(textBox_Copy12);
            gridOne.Add(textBox_Copy13);
            gridOne.Add(textBox_Copy14);

            foreach (var tb in gridOne)
            {
                tb.Background = ColorChange(tb);
            }
        }

        public Brush ColorChange(TextBox textBox)
        {
            var currentLeafColour = new LeafColour() {Colour = textBox.Background, Probability = 1};
          
            Leaf leaf = new Leaf()
            {
                CurrentColour = currentLeafColour,
                PossibleColours = GetPossibleColours(((SolidColorBrush)textBox.Background).Color)
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

        private static List<LeafColour> GetPossibleColours(Color currentLeafColour)
        {
            List<LeafColour> possibles = new List<LeafColour>();

            if (currentLeafColour == Colors.ForestGreen)
            {
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(currentLeafColour),
                    Probability = 0.70
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.OrangeRed),
                    Probability = 0.10
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Red),
                    Probability = 0.05
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Orange),
                    Probability = 0.10
                });
                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Yellow
                    ),
                    Probability = 0.05
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
                    Probability = 0.50
                });

                possibles.Add(new LeafColour()
                {
                    Colour = new SolidColorBrush(Colors.Brown)
                ,
                    Probability = 0.50
                });

            }
            return possibles;
        }

        public class Leaf
        {
            public LeafColour CurrentColour { get; set; }
            public List<LeafColour> PossibleColours { get; set; }
        }

        public class LeafColour
        {
            public Brush Colour { get; set; }
            public double Probability { get; set; }
        }
    }
}
