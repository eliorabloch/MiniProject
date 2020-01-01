using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PL
{
    /// <summary>
    /// Interaction logic for BootingPage.xaml
    /// </summary>
    public partial class BootingPage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer(); // timer object
        private Vector speed = new Vector(0, 0); // movement in pixels/second, initially zero

        int offsetX = -300;
        int offsetY = -300;
        double currentY = 0;
        double currentX = 0;
        public BootingPage()
        {
            InitializeComponent();


            currentY = Canvas.GetTop(MyImg) + offsetY;
            currentX = Canvas.GetLeft(MyImg) + offsetX;
            timer.Interval = TimeSpan.FromMilliseconds(50); // update 20 times/second
            timer.Tick += TimerTick;
            timer.Start();
            //Timer moveTheAirPlainTimer = new Timer(MoveTo, null, 100, 100);
            //MoveTo(MyImg, -20, 20, 1);
            //MoveTo(MyImg, -20, -20, 1);
            //MoveTo(MyImg, 20, 30, 1);
            //MoveTo(MyImg, 30, 50, 1);
            //MoveTo(MyImg, 500, 300, 2);
        }
        //Image target, double newX, double newY, double duration

        int timeOver = 0;
        private void TimerTick(object sender, EventArgs e)
        {
            timeOver += 50;
            int newY = 50;
            int newX = -10;
            if(timeOver > 100)
            {
                newY = 50;
                newX = 0;
            }
            else if (timeOver > 200)
            {
                newY = 50;
                newX = -50;
            }
            else if (timeOver > 300)
            {
                newY = 50;
                newX = -50;
            }
            else if (timeOver > 400)
            {
                newY = 50;
                newX = -50;
            }
            else if (timeOver > 400)
            {
                newY = 50;
                newX = 0;
            }
            else if (timeOver > 400)
            {
                newY = -50;
                newX = 50;
            }

            TranslateTransform trans = new TranslateTransform();
            MyImg.RenderTransform = trans;
            
            DoubleAnimation xMove = new DoubleAnimation(currentY, currentY + newY , TimeSpan.FromMilliseconds(50));
            DoubleAnimation yMove = new DoubleAnimation(currentX, currentX + newX, TimeSpan.FromMilliseconds(50));
            trans.BeginAnimation(TranslateTransform.XProperty, xMove);
            trans.BeginAnimation(TranslateTransform.YProperty, yMove);

            currentY += newY;
            currentX += newX;
            //// movement in one interval
            //double dx = state;
            //double dy = state;
            //// update position
            //Canvas.SetLeft(MyImg, currentX + newX);
            //Canvas.SetTop(MyImg, currentY + newY);

        }

     
    }
}
