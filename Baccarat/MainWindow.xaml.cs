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
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;

namespace Baccarat
{

    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;

        public List<Score> MyScores;
        public MainWindow()
        {
            InitializeComponent();
            using (ScoreDbContext _context = new ScoreDbContext())
            {
                MyScores = _context.Scores.ToList();
            }
            DataGridScore.ItemsSource = MyScores;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1.5);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }
        public string name;
        public int totalbetmoney;
        public int totalwinmoney;
        public int playedgames;
        public int tienumberofwins;
        public int playernumberofwins;
        public int bankernumberofwins;
        public int cardnumber = 1;
        public int placard1score;
        public int placard2score;
        public int bacard1score;
        public int bacard2score;
        public int placard3score;
        public int bacard3score;
        public int playertotalscoreshow;
        public int bankertotalscoreshow;
        public int bankmoney = 1000;
        public int betamount;
        public bool playerbeted;//var place bet kad strada spele tad tas ir false 
        public bool bankerbeted;
        public bool playercanwin;//var win var win tikai kurs place bet
        public bool bankercanwin;
        public int allbets;
        public int player1card;
        public int player1cardchoose;

        public int banker1card;
        public int banker1cardchoose;
        public int player2card;
        public int player2cardchoose;
        public int banker2card;
        public int banker2cardchoose;

        public int player3card;
        public int player3cardchoose;

        public int banker3card;
        public int banker3cardchoose;

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random rand1 = new Random();

            player1card = rand1.Next(1, 13);
            player1cardchoose = rand1.Next(1, 4);
            banker1card = rand1.Next(1, 13);
            banker1cardchoose = rand1.Next(1, 4);
            player2card = rand1.Next(1, 13);
            player2cardchoose = rand1.Next(1, 4);
            banker2card = rand1.Next(1, 13);
            banker2cardchoose = rand1.Next(1, 4);

            player3card = rand1.Next(1, 13);
            player3cardchoose = rand1.Next(1, 4);

            banker3card = rand1.Next(1, 13);
            banker3cardchoose = rand1.Next(1, 4);


            playerbeted = true;
            bankerbeted = true;




            if (cardnumber == 1)
            {
                placard1score = player1card + 1;
                playercardno1();
                if (player1card == 9 || player1card > 10)
                {
                    playercardno1();
                    placard1score = 0;
                }
                if (player1card == 10)
                {
                    playercardno1();
                    placard1score = 1;
                }

                cardnumber++;
            }

            /*1 BANKER CARD*/

            else if (cardnumber == 2)
            {

                bacard1score = banker1card + 1;
                bankercardno1();
                if (banker1card == 9 || banker1card > 10)
                {
                    bankercardno1();
                    bacard1score = 0;
                }
                if (banker1card == 10)
                {
                    bankercardno1();
                    bacard1score = 1;
                }

                cardnumber++;
            }

            /*player 2 card*/
            else if (cardnumber == 3)
            {
                placard2score = player2card + 1;
                playercardno2();
                if (player2card == 9 || player2card > 10)
                {
                    playercardno2();
                    placard2score = 0;
                }
                if (player2card == 10)
                {
                    playercardno2();
                    placard2score = 1;
                }

                cardnumber++;
            }
            /*banker 2 card*/
            else if (cardnumber == 4)
            {
                bacard2score = banker2card + 1;
                bankercardno2();
                if (banker2card == 9 || banker2card > 10)
                {
                    bankercardno2();
                    bacard2score = 0;
                }
                if (banker2card == 10)
                {
                    bankercardno2();
                    bacard2score = 1;
                }

                cardnumber++;
            }


            /*COD AFTER CARDS 4 cards*/
            playertotalscoreshow = placard1score + placard2score;

            if (playertotalscoreshow >= 10)
            {
                playertotalscoreshow = playertotalscoreshow - 10;
                pscore.Text = playertotalscoreshow.ToString();

            }
            if (playertotalscoreshow >= 20)
            {
                playertotalscoreshow = playertotalscoreshow - 20;
                pscore.Text = playertotalscoreshow.ToString();

            }

            pscore.Text = playertotalscoreshow.ToString();


            if (playertotalscoreshow <= 5 && cardnumber > 4)
            {


                placard3score = player3card + 1;
                playercardno3();

                if (player3card == 9 || player3card > 10)
                {
                    playercardno3();
                    placard3score = 0;
                }
                if (player3card == 10)
                {
                    playercardno3();
                    placard3score = 1;
                }


            }



            /*3 banker card!!*/

            bankertotalscoreshow = bacard1score + bacard2score;

            if (bankertotalscoreshow >= 10)
            {
                bankertotalscoreshow = bankertotalscoreshow - 10;
                bscore.Text = bankertotalscoreshow.ToString();

            }
            if (bankertotalscoreshow >= 20)
            {
                bankertotalscoreshow = bankertotalscoreshow - 20;
                bscore.Text = bankertotalscoreshow.ToString();

            }
            bscore.Text = bankertotalscoreshow.ToString();

            if (bankertotalscoreshow <= 5 && cardnumber > 4)
            {

                bacard3score = banker3card + 1;
                bankercardno3();

                if (banker3card == 9 || banker3card > 10)
                {
                    bankercardno3();
                    bacard3score = 0;
                }
                if (banker3card == 10)
                {
                    bankercardno3();
                    bacard3score = 1;
                }


            }


            bankertotalscoreshow = bacard1score + bacard2score + bacard3score;
            if (bankertotalscoreshow >= 10 && bankertotalscoreshow < 20)
            {
                bankertotalscoreshow = bankertotalscoreshow - 10;
                bscore.Text = bankertotalscoreshow.ToString();
            }
            if (bankertotalscoreshow >= 20)
            {
                bankertotalscoreshow = bankertotalscoreshow - 20;
                bscore.Text = bankertotalscoreshow.ToString();

            }

            bscore.Text = bankertotalscoreshow.ToString();






            playertotalscoreshow = placard1score + placard2score + placard3score;
            if (playertotalscoreshow >= 10 && playertotalscoreshow < 20)
            {
                playertotalscoreshow = playertotalscoreshow - 10;

                pscore.Text = playertotalscoreshow.ToString();

            }
            if (playertotalscoreshow >= 20)
            {
                playertotalscoreshow = playertotalscoreshow - 20;
                pscore.Text = playertotalscoreshow.ToString();
            }

            pscore.Text = playertotalscoreshow.ToString();



            if (playertotalscoreshow > bankertotalscoreshow && cardnumber > 4)
            {

                winner.Text = "Player WIN";
                playernumberofwins++;
                if (playercanwin == true)
                {
                    winerrbet();
                }
                clean();


            }

            if (bankertotalscoreshow > playertotalscoreshow && cardnumber > 4)
            {

                winner.Text = "Banker WIN";
                bankernumberofwins++;
                if (bankercanwin == true)
                {
                    winerrbet();
                }
                clean();
            }
            if (bankertotalscoreshow == playertotalscoreshow && cardnumber > 4)
            {
                winner.Text = "TIE";
                tienumberofwins++;
                clean();
            }


            if (bankmoney < 0)
            {
                MessageBoxResult result = MessageBox.Show("You lose", "Bad news", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    closeapp();
                }

            }

            /*stop timer*/
            if (cardnumber == 5)
            {
                dispatcherTimer.Stop();
            }

        }
        private void bankerbet_Click(object sender, RoutedEventArgs e)
        {

            if (playerbeted == false)
            {
                bankerbeted = true;

                try
                {
                    betamount = Convert.ToInt32(bet.Text);
                }
                catch (Exception)
                {
                    MessageBoxResult result = MessageBox.Show("This is not a number", "Do you place letters?", MessageBoxButton.OK);
                    bankerbeted = false;
                }
                if (betamount < 0)
                {
                    MessageBoxResult result = MessageBox.Show("Bet can't be <0", "Ouch", MessageBoxButton.OK);
                    betamount = 0;
                    bankerbeted = false;
                }
                if (betamount <= bankmoney)
                {
                    bets();
                    bankercanwin = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Not enought money", "Ouch", MessageBoxButton.OK);
                    betamount = 0;
                    bankerbeted = false;

                }
             


            }
            if (bankmoney < 0)
            {
                MessageBoxResult result = MessageBox.Show("You lose", "Bad news", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    closeapp();
                }

            }
        }


        public void play_Click(object sender, RoutedEventArgs e)
        {
            
            pc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/backgr1.png"));
            pc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/backgr1.png"));
            pc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/backgr1.png"));
            bc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/backgr1.png"));
            bc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/backgr1.png"));
            bc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/backgr1.png"));
            playertotalscoreshow = 0;
            pscore.Text = playertotalscoreshow.ToString();
            bankertotalscoreshow = 0;
            bscore.Text = playertotalscoreshow.ToString();
            placard1score = 0;
            placard2score = 0;
            bacard1score = 0;
            bacard2score = 0;
            placard3score = 0;
            bacard3score = 0;
            winner.Text = "";
            cardnumber = 1;
            playedgames++;
            if (bankmoney < 0)
            {
                MessageBoxResult result = MessageBox.Show("You lose", "Bad news", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    closeapp();
                }

            }

            dispatcherTimer.Start();

        }

        private void playerbet_Click(object sender, RoutedEventArgs e)
        {
            if (bankerbeted == false)
            {

                playerbeted = true;
                try
                {
                    betamount = Convert.ToInt32(bet.Text);
                }
                catch (Exception)
                {
                    MessageBoxResult result = MessageBox.Show("This is not a number", "do you place letters?", MessageBoxButton.OK);
                    playerbeted = false;
                }
                if (betamount < 0)
                {
                    MessageBoxResult result = MessageBox.Show("Bet can't be <0", "Ouch", MessageBoxButton.OK);
                    betamount = 0;
                    playerbeted = false;
                }
                if (betamount <= bankmoney)
                {
                    bets();
                    playercanwin = true;

                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Not enought money", "Ouch", MessageBoxButton.OK);
                    betamount = 0;
                    playerbeted = false;
                }

            }
            if (bankmoney < 0)
            {
                MessageBoxResult result = MessageBox.Show("You lose", "Bad news", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    closeapp();
                }

            }

        

        }
        public void clean()
        {
            playerbeted = false;
            bankerbeted = false;
            playercanwin = false;
            bankercanwin = false;
            allbets = 0;
            checkbet.Text = "Your bet: " + allbets.ToString();
        }
        public void bets()
        {
            allbets = allbets + betamount;
            bankmoney = bankmoney - betamount;
            bank.Text = "Your bank:" + bankmoney.ToString();
            checkbet.Text = "Your bet: " + allbets.ToString();
            totalbetmoney = totalbetmoney + betamount;
        }
        public void winerrbet()
        {
            bankmoney = bankmoney + allbets * 2;
            bank.Text = "Your bank:" + bankmoney.ToString();
            totalwinmoney = allbets * 2;
        }

        public void playercardno1()
        {
            int s = player1card + 1;

            switch (player1cardchoose)
            {
                case 1:
                    pc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_clubs.png"));
                    break;
                case 2:
                    pc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_diamonds.png"));
                    break;
                case 3:
                    pc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_hearts.png"));
                    break;
                case 4:
                    pc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_spades.png"));
                    break;
            }
        }
        public void bankercardno1()
        {
            int s = banker1card + 1;

            switch (banker1cardchoose)
            {

                case 1:
                    bc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_clubs.png"));
                    break;
                case 2:
                    bc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_diamonds.png"));
                    break;
                case 3:
                    bc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_hearts.png"));
                    break;
                case 4:
                    bc1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_spades.png"));
                    break;
            }
        }
        public void playercardno2()
        {

            int s = player2card + 1;

            switch (player2cardchoose)
            {
                case 1:
                    pc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_clubs.png"));
                    break;
                case 2:
                    pc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_diamonds.png"));
                    break;
                case 3:
                    pc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_hearts.png"));
                    break;
                case 4:
                    pc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_spades.png"));
                    break;
            }
        }
        public void bankercardno2()
        {

            int s = banker2card + 1;

            switch (banker2cardchoose)
            {
                case 1:
                    bc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_clubs.png"));
                    break;
                case 2:
                    bc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_diamonds.png"));
                    break;
                case 3:
                    bc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_hearts.png"));
                    break;
                case 4:
                    bc2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_spades.png"));
                    break;
            }
        }
        public void playercardno3()
        {

            int s = player3card + 1;

            switch (player3cardchoose)
            {
                case 1:
                    pc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_clubs.png"));
                    break;
                case 2:
                    pc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_diamonds.png"));
                    break;
                case 3:
                    pc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_hearts.png"));
                    break;
                case 4:
                    pc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_spades.png"));
                    break;
            }
        }
        public void bankercardno3()
        {

            int s = banker3card + 1;
            switch (banker3cardchoose)
            {
                case 1:
                    bc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_clubs.png"));
                    break;
                case 2:
                    bc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_diamonds.png"));
                    break;
                case 3:
                    bc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_hearts.png"));
                    break;
                case 4:
                    bc3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + s + "_of_spades.png"));
                    break;

            }
      
        }

        public void AddToScore_Click(object sender, RoutedEventArgs e)
        {



            InputBoxDialog inputBoxDialog = new InputBoxDialog("Enter your name", "Please enter your name:");
            inputBoxDialog.Input = "Name";
            bool? result = inputBoxDialog.ShowDialog();

            if (result == true)
            {
                 name = inputBoxDialog.Input;
            }

            if (name!=null)
            {
                DateTime datetimenow = DateTime.Now;
                var newData = new Score
                {
                    Name = name,
                    Bankerwins = bankernumberofwins,
                    Playerwins = playernumberofwins,
                    Tiewins = tienumberofwins,
                    TotalGames = playedgames,

                    TotalWinMoney = totalwinmoney,
                    TotalbetedMoney = totalbetmoney,
                    DateTime = datetimenow
                };
                using (var db = new ScoreDbContext())
                {
                    db.Scores.Add(newData);

                    db.SaveChanges();
                }
            }
            
            using (ScoreDbContext _context = new ScoreDbContext())
            {
                MyScores = _context.Scores.ToList();
            }
            DataGridScore.ItemsSource = MyScores;

        }
        public void closeapp()
        {
            MainWindow wd1 = new MainWindow();
            Application.Current.Windows[0].Close();
            wd1.ShowDialog();
        }


        public class InputBoxDialog : Window
        {
            private TextBox _inputBox;

            public InputBoxDialog(string title, string prompt)
            {
                Title = title;
                Width = 300;
                Height = 150;
                WindowStartupLocation = WindowStartupLocation.CenterScreen;

                Label promptLabel = new Label
                {
                    Content = prompt,
                    Margin = new Thickness(10),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                _inputBox = new TextBox
                {
                    Margin = new Thickness(10),
                    Width = 200,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                Button okButton = new Button
                {
                    Content = "OK",
                    Margin = new Thickness(10),
                    Width = 75,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                okButton.Click += OkButton_Click;

              
                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(promptLabel);
                stackPanel.Children.Add(_inputBox);
                stackPanel.Children.Add(okButton);

                Content = stackPanel;
            }

            private void OkButton_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
            }

           
            public string Input
            {
                get { return _inputBox.Text; }
                set { _inputBox.Text = value; }
            }
        }

    }
} 
