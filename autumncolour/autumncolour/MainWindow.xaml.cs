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
                tb.Background = Utilities.ColorChange(((SolidColorBrush)tb.Background).Color);
            }
        }


        private void triangles_Click(object sender, RoutedEventArgs e)
        {
           triangles tri = new triangles();
            tri.Show();
        }
    }
}
