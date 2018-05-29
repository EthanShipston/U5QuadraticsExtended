/* Ethan Shipston
 * U5QuadraticExtended
 * 5/29/2018
 * The program tells you the roots of a quadratic formula and then draws the parabola
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U5Quadratic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //draw grid
            Line xLine = new Line();
            xLine.Stroke = Brushes.Black;
            xLine.X1 = 0;
            xLine.Y1 = canvas.Height / 2;
            xLine.X2 = canvas.Width;
            xLine.Y2 = canvas.Height / 2;
            canvas.Children.Add(xLine);
            Line yLine = new Line();
            yLine.Stroke = Brushes.Black;
            yLine.X1 = canvas.Width / 2;
            yLine.Y1 = 0;
            yLine.X2 = canvas.Width / 2;
            yLine.Y2 = canvas.Height;
            canvas.Children.Add(yLine);
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            //get zeros
            txtOutput.Text = "";
            double.TryParse(txtA.Text, out double a);
            txtOutput.Text += "a Value: " + a.ToString() + "\n";
            double.TryParse(txtB.Text, out double b);
            txtOutput.Text += "b Value: " + b.ToString() + "\n";
            double.TryParse(txtC.Text, out double c);
            txtOutput.Text += "c Value: " + c.ToString() + "\n";
            double[] intercepts = new double[2];
            intercepts[0] = ((-1 * b) + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            intercepts[1] = ((-1 * b) - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            txtOutput.Text += "x Intercept(s): " + intercepts[0] + " and " + intercepts[1];

            //draw parabola
            double yIntercept = c;
            Ellipse parabola = new Ellipse();
            parabola.Height = 5;
            parabola.Width = 5;
            parabola.Stroke = Brushes.Red;
            parabola.StrokeThickness = 5;
            parabola.Margin = new Thickness( 0, 0, 0, 0);
            canvas.Children.Add(parabola);

            //draw zeros
            int gridStretch = 10;
            Ellipse zero1 = new Ellipse();
            zero1.Height = 5;
            zero1.Width = 5;
            zero1.Stroke = Brushes.Red;
            zero1.StrokeThickness = 5;
            zero1.Margin = new Thickness(((canvas.Width / 2) + (intercepts[0] * gridStretch) - 2.5), ((canvas.Height / 2) - 2.5), 0, 0);
            canvas.Children.Add(zero1);
            Ellipse zero2 = new Ellipse();
            zero2.Height = 5;
            zero2.Width = 5;
            zero2.Stroke = Brushes.Red;
            zero2.StrokeThickness = 5;
            zero2.Margin = new Thickness(((canvas.Width / 2) + (intercepts[1] * gridStretch) - 2.5), ((canvas.Height / 2) - 2.5), 0, 0);
            canvas.Children.Add(zero2);

        }
    }
}
