using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPF_Keyboard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int StopClick = 0;
        int ShiftFlag = 0;
        int CapsLockFlag = 0;
        char[] lettersLA = " abcdefghsjklmnopqrstuvwxyz -.?,/ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()".ToCharArray();
        char[] lettersUA = " абвгдеєжзиіїїйклмнопрстуфхцчшщьюя '-.,/АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЮЯ1234567890".ToCharArray();
        char[] sourceText1;
        int cntChar = 0;
        int right = 0;
        int sfortunato = 0;       
        long tick;
        DispatcherTimer watch = new DispatcherTimer();
        DateTime dt; // = DateTime.Now;        

        public MainWindow()
        {
            InitializeComponent();
            comboBox1.Text = "Language";
            DispatcherTimer timer = new DispatcherTimer(); // це просто годинник
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            watch.Interval = TimeSpan.FromMilliseconds(1); // секундомір
            watch.Tick += new EventHandler(Timer_Tick);
        }

        private void textBox1_PreviewKeyDown(object sender, KeyEventArgs e) { }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            dt = DateTime.Now;
            int ind = 0;            
            StopClick = 0;
            textBox1.Clear();
            textBox3.Clear();
            try
            {
                switch (comboBox1.Text)
                {
                    case "ENG":
                        {
                            for (int i = 0; i <= int.Parse(textBox2.Text); i++)
                            {
                                if (checkBox1.IsChecked == true)
                                {
                                    ind = rnd.Next(0, lettersLA.Length);
                                    textBox1.Text += lettersLA[ind].ToString();
                                }
                                else
                                {
                                    ind = rnd.Next(0, 33);
                                    textBox1.Text += lettersLA[ind].ToString();
                                }
                            }
                            watch.Start();
                            break;
                        }
                    case "УКР":
                        {
                            for (int i = 0; i <= int.Parse(textBox2.Text); i++)
                            {
                                if (checkBox1.IsChecked == true)
                                {
                                    ind = rnd.Next(0, lettersUA.Length);
                                    textBox1.Text += lettersUA[ind].ToString();
                                }
                                else
                                {
                                    ind = rnd.Next(0, 40);
                                    textBox1.Text += lettersUA[ind].ToString();
                                }
                            }
                            watch.Start();
                            break;
                        }
                    case "Language": { textBox1.Text = "Оберіть мову вводу натиснувши на \"Language\""; break; }
                }
                textBox3.Focus();
                SlidNumber.Visibility = Visibility.Collapsed;
                sourceText1 = textBox1.Text.ToCharArray();
            }
            catch { }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopClick++;
            cntChar = 0;
            switch (StopClick)
            {
                case 1: { SlidNumber.Visibility = Visibility.Visible; watch.Stop(); break; }
                case 2: { speedLabel.Content = "0"; luckyLabel.Content = "0"; stopWatch1.Content = "00:00:00"; break; }
            }
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                char[] temp = textBox3.Text.ToCharArray();
                if (sourceText1[cntChar] == temp[temp.Length - 1])
                {
                    speedLabel.Content = "";
                    textBox3.Background = Brushes.Transparent;
                    right++;
                    speedLabel.Content += right.ToString();
                }
                else { textBox3.Background = Brushes.OrangeRed; luckyLabel.Content = (++sfortunato).ToString(); }
                cntChar++;
                if (textBox3.Text.Length == textBox1.Text.Length) watch.Stop();
            }catch{ }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Ttime.Content = DateTime.Now.ToLongTimeString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tick = DateTime.Now.Ticks - dt.Ticks;
            DateTime stwatch = new DateTime();
            stwatch = stwatch.AddTicks(tick);
            stopWatch1.Content = stwatch.ToString("mm:ss:ff");
        }

        private void Button_Click(object sender, RoutedEventArgs e)  { }

        async private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key.ToString())
                {
                    case "D1": { _1.Visibility = Visibility.Hidden; await Task.Delay(500); _1.Visibility = Visibility.Visible; break; }
                    case "D2": { _2.Visibility = Visibility.Hidden; await Task.Delay(500); _2.Visibility = Visibility.Visible; break; }
                    case "D3": { _3.Visibility = Visibility.Hidden; await Task.Delay(500); _3.Visibility = Visibility.Visible; break; }
                    case "D4": { _4.Visibility = Visibility.Hidden; await Task.Delay(500); _4.Visibility = Visibility.Visible; break; }
                    case "D5": { _5.Visibility = Visibility.Hidden; await Task.Delay(500); _5.Visibility = Visibility.Visible; break; }
                    case "D6": { _6.Visibility = Visibility.Hidden; await Task.Delay(500); _6.Visibility = Visibility.Visible; break; }
                    case "D7": { _7.Visibility = Visibility.Hidden; await Task.Delay(500); _7.Visibility = Visibility.Visible; break; }
                    case "D8": { _8.Visibility = Visibility.Hidden; await Task.Delay(500); _8.Visibility = Visibility.Visible; break; }
                    case "D9": { _9.Visibility = Visibility.Hidden; await Task.Delay(500); _9.Visibility = Visibility.Visible; break; }
                    case "D0": { _0.Visibility = Visibility.Hidden; await Task.Delay(500); _0.Visibility = Visibility.Visible; break; }
                    case "Q": { Q.Visibility = Visibility.Hidden; await Task.Delay(500); Q.Visibility = Visibility.Visible; break; }
                    case "W": { W.Visibility = Visibility.Hidden; await Task.Delay(500); W.Visibility = Visibility.Visible; break; }
                    case "E": { E.Visibility = Visibility.Hidden; await Task.Delay(500); E.Visibility = Visibility.Visible; break; }
                    case "R": { R.Visibility = Visibility.Hidden; await Task.Delay(500); R.Visibility = Visibility.Visible; break; }
                    case "T": { T.Visibility = Visibility.Hidden; await Task.Delay(500); T.Visibility = Visibility.Visible; break; }
                    case "Y": { Y.Visibility = Visibility.Hidden; await Task.Delay(500); Y.Visibility = Visibility.Visible; break; }
                    case "U": { U.Visibility = Visibility.Hidden; await Task.Delay(500); U.Visibility = Visibility.Visible; break; }
                    case "I": { I.Visibility = Visibility.Hidden; await Task.Delay(500); I.Visibility = Visibility.Visible; break; }
                    case "O": { O.Visibility = Visibility.Hidden; await Task.Delay(500); O.Visibility = Visibility.Visible; break; }
                    case "P": { P.Visibility = Visibility.Hidden; await Task.Delay(500); P.Visibility = Visibility.Visible; break; }
                    case "A": { A.Visibility = Visibility.Hidden; await Task.Delay(500); A.Visibility = Visibility.Visible; break; }
                    case "S": { S.Visibility = Visibility.Hidden; await Task.Delay(500); S.Visibility = Visibility.Visible; break; }
                    case "D": { D.Visibility = Visibility.Hidden; await Task.Delay(500); D.Visibility = Visibility.Visible; break; }
                    case "F": { F.Visibility = Visibility.Hidden; await Task.Delay(500); F.Visibility = Visibility.Visible; break; }
                    case "G": { G.Visibility = Visibility.Hidden; await Task.Delay(500); G.Visibility = Visibility.Visible; break; }
                    case "H": { H.Visibility = Visibility.Hidden; await Task.Delay(500); H.Visibility = Visibility.Visible; break; }
                    case "J": { J.Visibility = Visibility.Hidden; await Task.Delay(500); J.Visibility = Visibility.Visible; break; }
                    case "K": { K.Visibility = Visibility.Hidden; await Task.Delay(500); K.Visibility = Visibility.Visible; break; }
                    case "L": { L.Visibility = Visibility.Hidden; await Task.Delay(500); L.Visibility = Visibility.Visible; break; }
                    case "Z": { Z.Visibility = Visibility.Hidden; await Task.Delay(500); Z.Visibility = Visibility.Visible; break; }
                    case "X": { X.Visibility = Visibility.Hidden; await Task.Delay(500); X.Visibility = Visibility.Visible; break; }
                    case "C": { C.Visibility = Visibility.Hidden; await Task.Delay(500); C.Visibility = Visibility.Visible; break; }
                    case "V": { V.Visibility = Visibility.Hidden; await Task.Delay(500); V.Visibility = Visibility.Visible; break; }
                    case "B": { B.Visibility = Visibility.Hidden; await Task.Delay(500); B.Visibility = Visibility.Visible; break; }
                    case "N": { N.Visibility = Visibility.Hidden; await Task.Delay(500); N.Visibility = Visibility.Visible; break; }
                    case "M": { M.Visibility = Visibility.Hidden; await Task.Delay(500); M.Visibility = Visibility.Visible; break; }
                }
            }
            catch { }
        }
        void En()
        {
            Q.Content = "Qq";
            W.Content = "Ww";
            E.Content = "Ee";
            R.Content = "Rr";
            T.Content = "Tt";
            Y.Content = "Yy";
            U.Content = "Uu";
            I.Content = "Ii";
            O.Content = "Oo";
            P.Content = "Pp";
            A.Content = "Aa";
            S.Content = "Ss";
            D.Content = "Dd";
            F.Content = "Ff";
            G.Content = "Gg";
            H.Content = "Hh";
            J.Content = "Jj";
            K.Content = "Kk";
            L.Content = "Ll";
            Z.Content = "Zz";
            X.Content = "Xx";
            C.Content = "Cc";
            V.Content = "Vv";
            B.Content = "Bb";
            N.Content = "Nn";
            M.Content = "Mm";
            L_SQ_BR.Content = "[{";
            R_SQ_BR.Content = "]}";
            SEMICOLON.Content = ": ;";
            QUOT_MARKS.Content = "\" \'";
            COMMA.Content = "< ,";
            POINT.Content = ". >";
            QUESTION.Content = "/ ?";
        }
        void Ua()
        {
            Q.Content = "Йй";
            W.Content = "Цц";
            E.Content = "Уу";
            R.Content = "Кк";
            T.Content = "Ее";
            Y.Content = "Нн";
            U.Content = "Гг";
            I.Content = "Шш";
            O.Content = "Щщ";
            P.Content = "Зз";
            A.Content = "Фф";
            S.Content = "Іі";
            D.Content = "Вв";
            F.Content = "Аа";
            G.Content = "Пп";
            H.Content = "Рр";
            J.Content = "Оо";
            K.Content = "Лл";
            L.Content = "Дд";
            Z.Content = "Яя";
            X.Content = "Чч";
            C.Content = "Сс";
            V.Content = "Мм";
            B.Content = "Ии";
            N.Content = "Тт";
            M.Content = "ь";
            L_SQ_BR.Content = "Хх";
            R_SQ_BR.Content = "Її";
            SEMICOLON.Content = "Жж";
            QUOT_MARKS.Content = "Єє";
            COMMA.Content = "Бб";
            POINT.Content = "Юю";
            QUESTION.Content = ". ,";
        }
        void CpLockFalse()
        {
            _1.Content = "1";
            _2.Content = "2";
            _3.Content = "3";
            _4.Content = "4";
            _5.Content = "5";
            _6.Content = "6";
            _7.Content = "7";
            _8.Content = "8";
            _9.Content = "9";
            _0.Content = "0";
            Minus.Content = "-";
            Equality.Content = "=";
        }
        void CpLockTrue()
        {
            _1.Content = "!";
            _2.Content = "@";
            _3.Content = "#";
            _4.Content = "$";
            _5.Content = "%";
            _6.Content = "^";
            _7.Content = "&";
            _8.Content = "*";
            _9.Content = "(";
            _0.Content = ")";
            Minus.Content = "_";
            Equality.Content = "+";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key.ToString())
                {
                    case ("LeftShift"):
                        {
                            if (ShiftFlag == 0) ShiftFlag = 1;
                            else ShiftFlag = 0;
                            break;
                        }
                    case ("RightShift"):
                        {
                            if (ShiftFlag == 0) ShiftFlag = 1;
                            else ShiftFlag = 0;
                            break;
                        }
                    case "Capital":
                        {
                            if (CapsLockFlag == 0) CapsLockFlag = 1;
                            else CapsLockFlag = 0;
                            break;
                        }
                }
                if (ShiftFlag == 0 && CapsLockFlag == 0) CpLockFalse();
                if (ShiftFlag == 1 && CapsLockFlag == 1) CpLockTrue();
            }
            catch { }
        }                   

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "ENG": { En(); break; }
                case "УКР": { Ua(); break; }
            }
        }
    }
}