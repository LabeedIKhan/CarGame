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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CarGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        DispatcherTimer dispatcherTimer;
        DispatcherTimer dispatcherTimer1;
        DispatcherTimer dispatcherTimer2;

        Dispatcher dispatch;
        Dispatcher dispatch2;
        Dispatcher dispatch3;

        GameManager gmanager =  new GameManager();

        Random coinr = new Random();
        int cx;
        Random r = new Random();
        int x;

        bool IsPause = false;
        bool IsRunning = true;

        public MainWindow()
        {
            InitializeComponent();

            RunLinesAnimation();
            RunEnemyMovements();
            RunCoins();
            gmanager.RunBackGroundMusic();

            InitialDesign();
        }

        void InitialDesign()
        {
            Crash.Visibility = Visibility.Collapsed;
            SpeedBox.Text = gmanager.Speed.ToString();
            GameOver.Visibility = Visibility.Hidden;
        }

        void RunLinesAnimation()
        { 
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 600);
            dispatcherTimer.Start();

           // Loaded += (x, y) => Keyboard.Focus(Canvas);
        }

        void RunEnemyMovements()
        {
            dispatcherTimer1 = new DispatcherTimer();
            dispatcherTimer1.Tick += dispatcherTimer_Tick1;
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 600);
            dispatcherTimer1.Start();
        }

        void RunCoins()
        {
            dispatcherTimer2 = new DispatcherTimer();
            dispatcherTimer2.Tick += dispatcherTimer_Tick2;
            dispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 0, 600);
            dispatcherTimer2.Start();
        }

        private void dispatcherTimer_Tick1(object sender, EventArgs e)
        {
            RunEnemyCars();
            GameOverFunc();
        }

        private void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            AddCoins();
            CarScored();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            MoveLines();
          
        }
        
        void MoveLines()
        {
            if (Canvas.GetTop(Mark1) > 793)
            {
                Canvas.SetTop(Mark1, -85);
            }
            else
            {
                Canvas.SetTop(Mark1, Canvas.GetTop(Mark1) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark2) > 793)
            {
                Canvas.SetTop(Mark2, -85);
            }
            else
            {
                Canvas.SetTop(Mark2, Canvas.GetTop(Mark2) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark3) > 793)
            {
                Canvas.SetTop(Mark3, -85);
            }
            else
            {
                Canvas.SetTop(Mark3, Canvas.GetTop(Mark3) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark4) > 793)
            {
                Canvas.SetTop(Mark4, -85);
            }
            else
            {
                Canvas.SetTop(Mark4, Canvas.GetTop(Mark4) + gmanager.Speed);
            }


            if (Canvas.GetTop(Mark5) > 793)
            {
                Canvas.SetTop(Mark5, -85);
            }
            else
            {
                Canvas.SetTop(Mark5, Canvas.GetTop(Mark5) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark6) > 793)
            {
                Canvas.SetTop(Mark6, -85);
            }
            else
            {
                Canvas.SetTop(Mark6, Canvas.GetTop(Mark6) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark7) > 793)
            {
                Canvas.SetTop(Mark7, -85);
            }
            else
            {
                Canvas.SetTop(Mark7, Canvas.GetTop(Mark7) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark8) > 793)
            {
                Canvas.SetTop(Mark8, -85);
            }
            else
            {
                Canvas.SetTop(Mark8, Canvas.GetTop(Mark8) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark9) > 793)
            {
                Canvas.SetTop(Mark9, -85);
            }
            else
            {
                Canvas.SetTop(Mark9, Canvas.GetTop(Mark9) + gmanager.Speed);
            }

            if (Canvas.GetTop(Mark10) > 793)
            {
                Canvas.SetTop(Mark10, -85);
            }
            else
            {
                Canvas.SetTop(Mark10, Canvas.GetTop(Mark10) + gmanager.Speed);
            }
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsPause && IsRunning)
            {
                double pos = Canvas.GetLeft(Car1);

                if (e.Key == Key.Left)
                {
                    if (Canvas.GetLeft(Car1) > 1)
                    {
                        pos -= 7;
                        Canvas.SetLeft(Car1, pos);
                    }
                }

                if (e.Key == Key.Right)
                {
                    if (Canvas.GetLeft(Car1) < 665)
                    {
                        pos += 7;
                        Canvas.SetLeft(Car1, pos);
                    }
                }

                if (e.Key == Key.Up)
                {
                    if(Canvas.GetTop(Car1) > 200)
                    {
                      //  gmanager.Speed += 10;
                        Canvas.SetTop(Car1, Canvas.GetTop(Car1) - 10);
                    }

                    SpeedBox.Text = gmanager.Speed.ToString();
                }

                if (e.Key == Key.Down)
                {
                    if (Canvas.GetTop(Car1) < 650)
                    {
                     //   gmanager.Speed -= 10;
                        Canvas.SetTop(Car1, Canvas.GetTop(Car1) + 10);
                    }
                    SpeedBox.Text = gmanager.Speed.ToString();
                }
            }
        }
        
        private void RunEnemyCars()
        {
            if (Canvas.GetTop(EnemyType1No1) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(EnemyType1No1, -85);
                    x = r.Next(2, 400);
                    Canvas.SetLeft(EnemyType1No1, x);

                    if (CheckConflict(EnemyType1No1)) { break; }

                }
            }
            else
            {
                if (CheckConflict(EnemyType1No1))
                {
                    Canvas.SetTop(EnemyType1No1, Canvas.GetTop(EnemyType1No1) + gmanager.Speed + 10);
                }
                else
                {
                    Canvas.SetTop(EnemyType1No1, Canvas.GetTop(EnemyType1No1) + gmanager.Speed - 10);
                }
            }


            if (Canvas.GetTop(EnemyType1No2) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(EnemyType1No2, -85);
                    x = r.Next(2, 500);
                    Canvas.SetLeft(EnemyType1No2, x);

                    if (CheckConflict(EnemyType1No2)) { break; }

                }
            }
            else
            {
                if (CheckConflict(EnemyType1No2))
                {
                    Canvas.SetTop(EnemyType1No2, Canvas.GetTop(EnemyType1No2) + gmanager.Speed - 10);
                }
                else
                {
                    Canvas.SetTop(EnemyType1No2, Canvas.GetTop(EnemyType1No2) + gmanager.Speed + 10);
                }
            }

            if (Canvas.GetTop(EnemyType1No3) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(EnemyType1No3, -85);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(EnemyType1No3, x);

                    if (CheckConflict(EnemyType1No3)) { break; }
                }
            }
            else
            {
                if (CheckConflict(EnemyType1No3))
                {
                    Canvas.SetTop(EnemyType1No3, Canvas.GetTop(EnemyType1No3) + gmanager.Speed + 20);
                }
                else
                {
                    Canvas.SetTop(EnemyType1No3, Canvas.GetTop(EnemyType1No3) + gmanager.Speed -20);
                }

            }

            if (Canvas.GetTop(EnemyType1No4) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(EnemyType1No4, -85);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(EnemyType1No4, x);

                    if (CheckConflict(EnemyType1No4)) { break; }
                }
            }
            else
            {
                if (CheckConflict(EnemyType1No4))
                {
                    Canvas.SetTop(EnemyType1No4, Canvas.GetTop(EnemyType1No4) + gmanager.Speed - 20);
                }
                else
                {
                    Canvas.SetTop(EnemyType1No4, Canvas.GetTop(EnemyType1No4) + gmanager.Speed +20);
                }
            }

            if (Canvas.GetTop(EnemyType1No5) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(EnemyType1No5, -85);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(EnemyType1No5, x);

                    if (CheckConflict(EnemyType1No5)) { break; }
                }
            }
            else
            {

                Canvas.SetTop(EnemyType1No5, Canvas.GetTop(EnemyType1No5) + gmanager.Speed);
            }

            if (Canvas.GetTop(EnemyType2No1) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(EnemyType2No1, -85);
                    x = r.Next(5, 500);
                    Canvas.SetLeft(EnemyType2No1, x);

                    if (CheckConflict(EnemyType2No1)) { break; }

                }
            }
            else
            {
               
                Canvas.SetTop(EnemyType2No1, Canvas.GetTop(EnemyType2No1) + gmanager.Speed);
            }

            if (Canvas.GetTop(EnemyType2No2) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(EnemyType2No2, -85);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(EnemyType2No2, x);

                    if (CheckConflict(EnemyType2No2)) { break; }
                }
            }
            else
            {
                Canvas.SetTop(EnemyType2No2, Canvas.GetTop(EnemyType2No2) + gmanager.Speed);
            }

            if (Canvas.GetTop(Truck1) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(Truck1, -85);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(Truck1, x);

                    if (CheckConflict(Truck1)) { break; }
                }
            }
            else
            {
                Canvas.SetTop(Truck1, Canvas.GetTop(Truck1) + gmanager.Speed);
            }

            if (Canvas.GetTop(Truck2) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(Truck2, -85);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(Truck2, x);

                    if (CheckConflict(Truck2)) { break; }
                }
                 
            }
            else
            {
                if (CheckConflict(Truck2))
                {
                    Canvas.SetTop(Truck2, Canvas.GetTop(Truck2) + gmanager.Speed +20);
                }
                else
                {
                    Canvas.SetTop(Truck2, Canvas.GetTop(Truck2) + gmanager.Speed - 50);
                }
               
            }

            if(Canvas.GetTop(Stop1) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(Stop1, -10);
                    x = r.Next(6, 650);
                    Canvas.SetLeft(Stop1, x);

                    if (CheckConflict(Stop1)) { break; }
                }
            }
            else
            {
                if (CheckConflict(Stop1))
                {
                    Canvas.SetTop(Stop1, Canvas.GetTop(Stop1) + gmanager.Speed - 20);
                }
                else
                {
                    Canvas.SetTop(Stop1, Canvas.GetTop(Stop1) + gmanager.Speed);
                }
            }

            if (Canvas.GetTop(Stop2) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(Stop2, -10);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(Stop2, x);

                    if (CheckConflict(Stop2)) { break; }
                }
            }
            else
            {
                if (CheckConflict(Stop2))
                {
                    Canvas.SetTop(Stop2, Canvas.GetTop(Stop2) + gmanager.Speed - 20);
                }
                else
                {
                    Canvas.SetTop(Stop2, Canvas.GetTop(Stop2) + gmanager.Speed);
                }
            }

            if (Canvas.GetTop(Stop3) >= 800)
            {
                while (true)
                {
                    Canvas.SetTop(Stop3, -10);
                    x = r.Next(5, 650);
                    Canvas.SetLeft(Stop3, x);

                    if (CheckConflict(Stop3)) { break; }
                }
            }
            else
            {
                if (CheckConflict(Stop3))
                {
                    Canvas.SetTop(Stop3, Canvas.GetTop(Stop3) + gmanager.Speed - 20);
                }
                else
                {
                    Canvas.SetTop(Stop3, Canvas.GetTop(Stop3) + gmanager.Speed);
                }
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (IsPause)
            {
                dispatcherTimer.Start();
                dispatcherTimer1.Start();
                dispatcherTimer2.Start();
                gmanager.RunBackGroundMusic();
                IsPause = false;
                IsRunning = true;
                
            }
           
        }

        private void ReStart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            gmanager.StopBackGroundMusic();
            dispatcherTimer.Stop();
            dispatcherTimer1.Stop();
            dispatcherTimer2.Stop();
            IsPause = true;
            IsRunning = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void GameOverFunc()
        {
            Rect rect10 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect20 = new Rect(Canvas.GetLeft(EnemyType1No1), Canvas.GetTop(EnemyType1No1), EnemyType1No1.Width, EnemyType1No1.Height);
            if (rect10.IntersectsWith(rect20))
            {
                CollisionRect(rect10, rect20);
            }


            Rect rect11 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect21 = new Rect(Canvas.GetLeft(EnemyType1No2), Canvas.GetTop(EnemyType1No2), EnemyType1No2.Width, EnemyType1No2.Height);
            if (rect11.IntersectsWith(rect21))
            {
                CollisionRect(rect11, rect21);
            }

            Rect rect12 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect22 = new Rect(Canvas.GetLeft(EnemyType1No3), Canvas.GetTop(EnemyType1No3), EnemyType1No3.Width, EnemyType1No3.Height);
            if (rect12.IntersectsWith(rect22))
            {
                CollisionRect(rect12, rect22);
            }

            Rect rect13 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect23 = new Rect(Canvas.GetLeft(EnemyType1No4), Canvas.GetTop(EnemyType1No4), EnemyType1No4.Width, EnemyType1No4.Height);
            if (rect13.IntersectsWith(rect23))
            {
                CollisionRect(rect13, rect23);
            }

            Rect rect14 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect24 = new Rect(Canvas.GetLeft(EnemyType1No5), Canvas.GetTop(EnemyType1No5), EnemyType1No5.Width, EnemyType1No5.Height);
            if (rect14.IntersectsWith(rect24))
            {
                CollisionRect(rect14, rect24);
            }

            Rect rect15 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect25 = new Rect(Canvas.GetLeft(EnemyType2No1), Canvas.GetTop(EnemyType2No1), EnemyType2No1.Width, EnemyType2No1.Height);
            if (rect15.IntersectsWith(rect25))
            {
                CollisionRect(rect15, rect25);
            }

            Rect rect16 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect26 = new Rect(Canvas.GetLeft(EnemyType2No2), Canvas.GetTop(EnemyType2No2), EnemyType2No2.Width, EnemyType2No2.Height);
            if (rect16.IntersectsWith(rect26))
            {
                CollisionRect(rect16, rect26);
            }

            Rect rect17 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect27 = new Rect(Canvas.GetLeft(Truck1), Canvas.GetTop(Truck1), Truck1.Width, Truck1.Height);
            if (rect17.IntersectsWith(rect27))
            {
                CollisionRect(rect17, rect27);
            }

            Rect rect18 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect28 = new Rect(Canvas.GetLeft(Truck2), Canvas.GetTop(Truck2), Truck2.Width, Truck2.Height);
            if (rect18.IntersectsWith(rect28))
            {
                CollisionRect(rect18, rect28);
            }

            Rect rect19 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect29 = new Rect(Canvas.GetLeft(Stop1), Canvas.GetTop(Stop1), Stop1.Width, Stop1.Height);
            if (rect19.IntersectsWith(rect29))
            {
                CollisionRect(rect19, rect29);
            }

            Rect rect201 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect30 = new Rect(Canvas.GetLeft(Stop2), Canvas.GetTop(Stop2), Stop2.Width, Stop2.Height);
            if (rect201.IntersectsWith(rect30))
            {
                CollisionRect(rect201, rect30);
            }

            Rect rect212 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect31 = new Rect(Canvas.GetLeft(Stop3), Canvas.GetTop(Stop3), Stop3.Width, Stop3.Height);
            if (rect212.IntersectsWith(rect31))
            {
                CollisionRect(rect212, rect31);
            }

        }


        public bool CheckConflict(Image elem)
        {

            if (!(elem == EnemyType1No1))
            {
                Rect rect10 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect20 = new Rect(Canvas.GetLeft(EnemyType1No1), Canvas.GetTop(EnemyType1No1), EnemyType1No1.Width, EnemyType1No1.Height);
                if (rect10.IntersectsWith(rect20))
                {

                    return false;
                }
            }

            if (!(elem == EnemyType1No2))
            {
                Rect rect11 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect21 = new Rect(Canvas.GetLeft(EnemyType1No2), Canvas.GetTop(EnemyType1No2), EnemyType1No2.Width, EnemyType1No2.Height);
                if (rect11.IntersectsWith(rect21))
                {

                    return false;

                }
            }

            if (!(elem == EnemyType1No3))
            {
                Rect rect12 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect22 = new Rect(Canvas.GetLeft(EnemyType1No3), Canvas.GetTop(EnemyType1No3), EnemyType1No3.Width, EnemyType1No3.Height);
                if (rect12.IntersectsWith(rect22))
                {

                    return false;
                }
            }

            if (!(elem == EnemyType1No4))
            {
                Rect rect13 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect23 = new Rect(Canvas.GetLeft(EnemyType1No4), Canvas.GetTop(EnemyType1No4), EnemyType1No4.Width, EnemyType1No4.Height);
                if (rect13.IntersectsWith(rect23))
                {

                    return false;

                }
            }

            if (!(elem == EnemyType1No5))
            {
                Rect rect14 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect24 = new Rect(Canvas.GetLeft(EnemyType1No5), Canvas.GetTop(EnemyType1No5), EnemyType1No5.Width, EnemyType1No5.Height);
                if (rect14.IntersectsWith(rect24))
                {

                    return false;

                }
            }

            if (!(elem == EnemyType2No1))
            {
                Rect rect15 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect25 = new Rect(Canvas.GetLeft(EnemyType2No1), Canvas.GetTop(EnemyType2No1), EnemyType2No1.Width, EnemyType2No1.Height);
                if (rect15.IntersectsWith(rect25))
                {

                    return false;

                }
            }

            if (!(elem == EnemyType2No2))
            {
                Rect rect16 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect26 = new Rect(Canvas.GetLeft(EnemyType2No2), Canvas.GetTop(EnemyType2No2), EnemyType2No2.Width, EnemyType2No2.Height);
                if (rect16.IntersectsWith(rect26))
                {
                    return false;

                }
            }

            if (!(elem == Truck1))
            {
                Rect rect17 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect27 = new Rect(Canvas.GetLeft(Truck1), Canvas.GetTop(Truck1), Truck1.Width, Truck1.Height);
                if (rect17.IntersectsWith(rect27))
                {

                    return false;
                }
            }

            if (!(elem == Truck2))
            {
                Rect rect18 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect28 = new Rect(Canvas.GetLeft(Truck2), Canvas.GetTop(Truck2), Truck2.Width, Truck2.Height);
                if (rect18.IntersectsWith(rect28))
                {

                    return false;
                }
            }

            if (!(elem == Stop1))
            {
                Rect rect19 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect29 = new Rect(Canvas.GetLeft(Stop1), Canvas.GetTop(Stop1), Stop1.Width, Stop1.Height);
                if (rect19.IntersectsWith(rect29))
                {

                    return false;
                }
            }

            if (!(elem == Stop2))
            {
                Rect rect20 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect30 = new Rect(Canvas.GetLeft(Stop2), Canvas.GetTop(Stop2), Stop2.Width, Stop2.Height);
                if (rect20.IntersectsWith(rect30))
                {

                    return false;
                }
            }

            if (!(elem == Stop3))
            {
                Rect rect21 = new Rect(Canvas.GetLeft(elem), Canvas.GetTop(elem), elem.Width, elem.Height);
                Rect rect31 = new Rect(Canvas.GetLeft(Stop3), Canvas.GetTop(Stop3), Stop3.Width, Stop3.Height);
                if (rect21.IntersectsWith(rect31))
                {

                    return false;
                }
            }


            return true;
        }

        public void CollisionRect(Rect rect1, Rect rect2)
        {
            gmanager.StopBackGroundMusic();
            dispatcherTimer.Stop();
            dispatcherTimer1.Stop();
            dispatcherTimer2.Stop();
            IsRunning = false;
            Rect rect = Rect.Intersect(rect1, rect2);
            CrashDisplay(rect);
            GameOver.Visibility = Visibility.Visible;
        }


        public void CrashDisplay(Rect rectangle)
        {
            if (rectangle.Width < 30)
            {
                Crash.Width = 30;
                Crash.Height = 30;
            }
            else
            {
                Crash.Width = rectangle.Width;
                Crash.Height = rectangle.Height;
            }
            Canvas.SetTop(Crash, rectangle.Top);
            Canvas.SetLeft(Crash, rectangle.Left);
            Crash.Visibility = Visibility.Visible;
        }

        public void AddCoins()
        {
           
            if (Canvas.GetTop(Coins) >= 800)
            {
                Coins.Visibility = Visibility.Visible;
                while (true)
                {
                    Canvas.SetTop(Coins, -85);
                    cx = coinr.Next(50, 650);
                    Canvas.SetLeft(Coins, cx);

                    if (CheckConflict(Coins)) { break; }
                }
            }
            else
            {

                Canvas.SetTop(Coins, Canvas.GetTop(Coins) + gmanager.Speed);
            }

            if (Canvas.GetTop(Coins1) >= 800)
            {
                Coins1.Visibility = Visibility.Visible;
                while (true)
                {
                    Canvas.SetTop(Coins1, -85);
                    cx = coinr.Next(50, 650);
                    Canvas.SetLeft(Coins1, cx);

                    if (CheckConflict(Coins1)) { break; }
                }
            }
            else
            {

                Canvas.SetTop(Coins1, Canvas.GetTop(Coins1) + gmanager.Speed);
            }

            if (Canvas.GetTop(Coins2) >= 800)
            {
                Coins2.Visibility = Visibility.Visible;
                while (true)
                {
                    Canvas.SetTop(Coins2, -85);
                    cx = coinr.Next(50, 650);
                    Canvas.SetLeft(Coins2, cx);

                    if (CheckConflict(Coins2)) { break; }
                }
            }
            else
            {

                Canvas.SetTop(Coins2, Canvas.GetTop(Coins2) + gmanager.Speed);
            }

            if (Canvas.GetTop(Coins3) >= 800)
            {
                Coins3.Visibility = Visibility.Visible;
                while (true)
                {
                    Canvas.SetTop(Coins3, -85);
                    cx = coinr.Next(50, 650);
                    Canvas.SetLeft(Coins3, cx);

                    if (CheckConflict(Coins3)) { break; }
                }
            }
            else
            {

                Canvas.SetTop(Coins3, Canvas.GetTop(Coins3) + gmanager.Speed);
            }

            if (Canvas.GetTop(Coins4) >= 800)
            {
                Coins4.Visibility = Visibility.Visible;
                while (true)
                {
                    Canvas.SetTop(Coins4, -85);
                    cx = coinr.Next(50, 650);
                    Canvas.SetLeft(Coins4, cx);

                    if (CheckConflict(Coins4)) { break; }
                }
            }
            else
            {

                Canvas.SetTop(Coins4, Canvas.GetTop(Coins4) + gmanager.Speed);
            }
            
        }

        public void CarScored()
        {
            Rect rect10 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect20 = new Rect(Canvas.GetLeft(Coins), Canvas.GetTop(Coins), Coins.Width, Coins.Height);
            if (rect10.IntersectsWith(rect20))
            {
                gmanager.Score += 10;
                Coins.Visibility = Visibility.Collapsed;
                ScoreBox.Text = gmanager.Score.ToString();
            }


            Rect rect11 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect21 = new Rect(Canvas.GetLeft(Coins1), Canvas.GetTop(Coins1), Coins1.Width, Coins1.Height);
            if (rect11.IntersectsWith(rect21))
            {
                gmanager.Score += 10;
                Coins1.Visibility = Visibility.Collapsed;
                ScoreBox.Text = gmanager.Score.ToString();
            }

            Rect rect12 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect22 = new Rect(Canvas.GetLeft(Coins2), Canvas.GetTop(Coins2), Coins2.Width, Coins2.Height);
            if (rect12.IntersectsWith(rect22))
            {
                gmanager.Score += 10;
                Coins2.Visibility = Visibility.Collapsed;
                ScoreBox.Text = gmanager.Score.ToString();
            }

            Rect rect13 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect23 = new Rect(Canvas.GetLeft(Coins3), Canvas.GetTop(Coins3), Coins3.Width, Coins3.Height);
            if (rect13.IntersectsWith(rect23))
            {
                gmanager.Score += 10;
                Coins3.Visibility = Visibility.Collapsed;
                ScoreBox.Text = gmanager.Score.ToString();
            }

            Rect rect14 = new Rect(Canvas.GetLeft(Car1), Canvas.GetTop(Car1), Car1.Width, Car1.Height);
            Rect rect24 = new Rect(Canvas.GetLeft(Coins4), Canvas.GetTop(Coins4), Coins4.Width, Coins4.Height);
            if (rect14.IntersectsWith(rect24))
            {
                gmanager.Score += 10;
                Coins4.Visibility = Visibility.Collapsed;
                ScoreBox.Text = gmanager.Score.ToString();
            }
        }
    }
}
