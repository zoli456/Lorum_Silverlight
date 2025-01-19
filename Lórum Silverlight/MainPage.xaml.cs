using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Lorum_Silverlight;
using SilverlightMessageBoxes;

namespace Lórum_Silverlight
{
    public partial class MainPage : UserControl
    {
        public static bool CheckDealer;
        public static int AiTressHold = 25;
        public static int AiMathValue2 = 5;
        public static bool HaveLorum;
        public static int KezdőLap;
        public static int[] Player2_card_id = new int[9];
        public static int[] Player3_card_id = new int[9];
        public static int[] Player4_card_id = new int[9];
        public static int starting_player = 1;
        public static int Piros;
        public static int zöld;
        public static int makk;
        public static int tök;
        private static int játékos_kártyák_száma;
        public static int játékos2_maradék;
        public static int játékos3_maradék;
        public static int játékos4_maradék;

        private static int pontok1 = 100;
        private static int pontok2 = 100;
        private static int pontok3 = 100;
        private static int pontok4 = 100;

        private static bool lórum;
        public static bool lórum_piros;
        public static bool lórum_zöld;
        public static bool lórum_makk;
        public static bool lórum_tök;

        private static int dealer1;
        private static int dealer2;
        private static int dealer3;
        private static string kártyák_info;
        private static bool show_card_info;
        private static bool IsPlaying;
        private static bool LockedCards = true;
        public static int kezdőlap;
        public static int lórumcard_c1, lórumcard_c2, lórumcard_c3;

        private static int timer_ticks = 15;
        private readonly int[] Player1_card_id = new int[9];
        private readonly int[] kartyak = new int[34];
        private readonly int újra = RandomNumber(4, 5);
        private bool kezdes;
        private int kioszto;
        private int nexter;
        public static int Kezdőjátékos = 1;
        private int pointinfo;
        private bool újraosztás;

        public MainPage()
        {
            Loaded += MainPage_Loaded;
            InitializeComponent();
            Button3.Visibility = Visibility.Collapsed;
            Button4.Visibility = Visibility.Collapsed;
            Button5.Visibility = Visibility.Collapsed;
            Passz_Button.IsEnabled = false;
            Figyelmeztetések.Visibility = Visibility.Collapsed;
            Image25.Visibility = Visibility.Collapsed;
            Image26.Visibility = Visibility.Collapsed;
            Image27.Visibility = Visibility.Collapsed;
            Image28.Visibility = Visibility.Collapsed;
        }

        private static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max+1);
        }

        private void NewGame_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Válasz = default(MessageBoxResult);
            if (újraosztás)
            {
                Válasz = MessageBox.Show("Kérhetsz újraosztást " + újra + " pontért. Szeretnéd?", "Kérdés",
                                         MessageBoxButton.OKCancel);
                if (Válasz == MessageBoxResult.Cancel)
                {
                    return;
                }
                else
                {
                    pontok1 -= újra;
                    Label1.Content = "Pontok: " + pontok1;
                }
            }
            újraosztás = true;
            lórumcard_c1 = 0;
            lórumcard_c2 = 0;
            lórumcard_c3 = 0;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Visible;
            Image4.Visibility = Visibility.Visible;
            Image5.Visibility = Visibility.Visible;
            Image6.Visibility = Visibility.Visible;
            Image7.Visibility = Visibility.Visible;
            Image8.Visibility = Visibility.Visible;
            Image9.Visibility = Visibility.Visible;
            Image11.Visibility = Visibility.Visible;
            Image10.Visibility = Visibility.Visible;
            Image12.Visibility = Visibility.Visible;
            Image13.Visibility = Visibility.Visible;
            Image14.Visibility = Visibility.Visible;
            Image15.Visibility = Visibility.Visible;
            Image16.Visibility = Visibility.Visible;
            Image17.Visibility = Visibility.Visible;
            Image18.Visibility = Visibility.Visible;
            Image19.Visibility = Visibility.Visible;
            Image20.Visibility = Visibility.Visible;
            Image21.Visibility = Visibility.Visible;
            Image22.Visibility = Visibility.Visible;
            Image23.Visibility = Visibility.Visible;
            Image24.Visibility = Visibility.Visible;
            Tábla.Source = null;
            pointinfo = 0;
            LockedCards = false;
            Figyelmeztetések.Content = null;
            Figyelmeztetések.Visibility = Visibility.Collapsed;
            if (pontok1 < 0)
            {
                pontok1 = 100;
                Label1.Content = "Pontok: " + pontok1;
                Message.InfoMessage("Sajnos elfogyodt a pontod.");
            }
            if (pontok2 < 0)
            {
                pontok2 = 100;
                label2.Content = "Pontok: " + pontok2;
                Message.InfoMessage("2.játékosnak elfogyodt a pontja.");
            }
            if (pontok3 < 0)
            {
                pontok3 = 100;
                label3.Content = "Pontok: " + pontok3;
                Message.InfoMessage("3.játékosnak elfogyodt a pontja.");
            }
            if (pontok4 < 0)
            {
                pontok4 = 100;
                label4.Content = "Pontok: & " + pontok4;
                Message.InfoMessage("4.játékosnak elfogyodt a pontja.");
            }
            if (starting_player == 5)
                starting_player = 1;
            show_card_info = false;
            játékos2_maradék = 8;
            játékos3_maradék = 8;
            játékos4_maradék = 8;
            játékos_kártyák_száma = 8;
            Passz_Button.IsEnabled = true;
            Piros_Hely.Source = null;
            Zöld_hely.Source = null;
            Makk_Hely.Source = null;
            Tök_hely.Source = null;
            Piros = 0;
            zöld = 0;
            makk = 0;
            tök = 0;
            Kartya_kiosztas();
            Image30.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[1]), UriKind.Relative));
            image31.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[2]), UriKind.Relative));
            image32.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[3]), UriKind.Relative));
            image33.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[4]), UriKind.Relative));
            image34.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[5]), UriKind.Relative));
            image35.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[6]), UriKind.Relative));
            image36.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[7]), UriKind.Relative));
            image37.Source = new BitmapImage(new Uri((string) Kép_keresés(Player1_card_id[8]), UriKind.Relative));
            dealer1 = RandomNumber(2, 10);
            dealer2 = RandomNumber(2, 10);
            dealer3 = RandomNumber(2, 10);
            Image30.Visibility = Visibility.Visible;
            image31.Visibility = Visibility.Visible;
            image32.Visibility = Visibility.Visible;
            image33.Visibility = Visibility.Visible;
            image34.Visibility = Visibility.Visible;
            image35.Visibility = Visibility.Visible;
            image36.Visibility = Visibility.Visible;
            image37.Visibility = Visibility.Visible;
            //kezdés
            switch (starting_player)
            {
                case 1:
                    if (dealer1 == 11)
                    {
                        Button3.Content = ("Nem veszi meg");
                    }
                    else
                    {
                        Button3.Content = ("Eladni " + dealer1 + "p-ért");
                    }
                    if (dealer2 == 11)
                    {
                        Button4.Content = ("Nem veszi meg");
                    }
                    else
                    {
                        Button4.Content = ("Eladni " + dealer2 + "p-ért");
                    }
                    if (dealer3 == 11)
                    {
                        Button5.Content = ("Nem veszi meg");
                    }
                    else
                    {
                        Button5.Content = ("Eladni " + dealer3 + "p-ért");
                    }
                    Button3.Visibility = Visibility.Visible;
                    Button4.Visibility = Visibility.Visible;
                    Button5.Visibility = Visibility.Visible;
                    Image25.Visibility = Visibility.Visible;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    if (dealer1 == 11)
                    {
                        Button3.Content = ("Nem adja el");
                    }
                    else
                    {
                        Button3.Content = ("Venni " + dealer1 + "p-ért");
                    }
                    Button3.Visibility = Visibility.Visible;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Visible;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    if (dealer2 == 11)
                    {
                        Button4.Content = ("Nem adja el");
                    }
                    else
                    {
                        Button4.Content = ("Venni " + dealer2 + "p-ért");
                    }
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Visible;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Visible;
                    Image28.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    if (dealer3 == 11)
                    {
                        Button5.Content = ("Nem adja el");
                    }
                    else
                    {
                        Button5.Content = ("Venni " + dealer3 + "p-ért");
                    }
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Visible;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Visible;
                    break;
            }
            lórum = true;
            lórum_piros = true;
            lórum_zöld = true;
            lórum_makk = true;
            lórum_tök = true;
        }

        private void Passz_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Piros == 0 & zöld == 0 & makk == 0 & tök == 0 & starting_player != 1)
            {
                //más kezd
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                switch (starting_player)
                {
                    case 2:
                        timer_ticks = 1;
                        Button3.Visibility = Visibility.Collapsed;
                        break;
                    case 3:
                        timer_ticks = 3;
                        Button4.Visibility = Visibility.Collapsed;
                        break;
                    case 4:
                        timer_ticks = 6;
                        Button5.Visibility = Visibility.Collapsed;
                        break;
                }
                return;
            }
            if (Piros == 0)
            {
                Message.InfoMessage("Szerintem pirosból tudsz kitenni.");
                return;
            }
            if (zöld == 0)
            {
                Message.InfoMessage("Szerintem zöldből tudsz kitenni.");
                return;
            }
            if (makk == 0)
            {
                Message.InfoMessage("Szerintem makkból tudsz kitenni.");
                return;
            }
            if (tök == 0)
            {
                Message.InfoMessage("Szerintem tökből tudsz kitenni.");
                return;
            }
            int lehetőség = 0;
            lehetőség = 0;
            int i = 8;
            int n = 0;
            int lehet_seges_kartyak = 0;
            lehet_seges_kartyak = 0;
            for (n = 1; n <= i; n++)
            {
                if (Next_card_player(Player1_card_id[n]))
                {
                    lehet_seges_kartyak = lehet_seges_kartyak + 1;
                    lehetőség = Player1_card_id[n];
                }
            }
            if (lehet_seges_kartyak == 0)
            {
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                timer_ticks = 1;
                return;
            }
            else
            {
                if (lehetőség == 40 | lehetőség == 41 | lehetőség == 42 | lehetőség == 43 | lehetőség == 44 |
                    lehetőség == 45 | lehetőség == 46 | lehetőség == 47)
                {
                    Message.InfoMessage("Szerintem tökből tudsz kitenni.");
                    return;
                }
                if (lehetőség == 10 | lehetőség == 11 | lehetőség == 12 | lehetőség == 13 | lehetőség == 14 |
                    lehetőség == 15 | lehetőség == 16 | lehetőség == 17)
                {
                    Message.InfoMessage("Szerintem pirosból tudsz kitenni.");
                    return;
                }
                if (lehetőség == 20 | lehetőség == 21 | lehetőség == 22 | lehetőség == 23 | lehetőség == 24 |
                    lehetőség == 25 | lehetőség == 26 | lehetőség == 27)
                {
                    Message.InfoMessage("Szerintem zöldből tudsz kitenni.");
                    return;
                }
                if (lehetőség == 30 | lehetőség == 31 | lehetőség == 32 | lehetőség == 33 | lehetőség == 34 |
                    lehetőség == 35 | lehetőség == 36 | lehetőség == 37)
                {
                    Message.InfoMessage("Szerintem makkból tudsz kitenni.");
                }
            }
        }

        public void Kartya_kiosztas()
        {
            //Kártyák kiosztása
            kartyak[1] = 10;
            kartyak[2] = 11;
            kartyak[3] = 12;
            kartyak[4] = 13;
            kartyak[5] = 14;
            kartyak[6] = 15;
            kartyak[7] = 16;
            kartyak[8] = 17;
            kartyak[9] = 20;
            kartyak[10] = 21;
            kartyak[11] = 22;
            kartyak[12] = 23;
            kartyak[13] = 24;
            kartyak[14] = 25;
            kartyak[15] = 26;
            kartyak[16] = 27;
            kartyak[17] = 30;
            kartyak[18] = 31;
            kartyak[19] = 32;
            kartyak[20] = 33;
            kartyak[21] = 34;
            kartyak[22] = 35;
            kartyak[23] = 36;
            kartyak[24] = 37;
            kartyak[25] = 40;
            kartyak[26] = 41;
            kartyak[27] = 42;
            kartyak[28] = 43;
            kartyak[29] = 44;
            kartyak[30] = 45;
            kartyak[31] = 46;
            kartyak[32] = 47;
            Kartyak_handler();
            Sorbarendezés(Player1_card_id);
            Sorbarendezés(Player2_card_id);
            Sorbarendezés(Player3_card_id);
            Sorbarendezés(Player4_card_id);
        }

        public void Kartyak_handler()
        {
            //Véletlenszerű kiosztás
            int i = 0;
            int n = 8;
            for (i = 1; i <= n; i++)
            {
                kioszto = RandomNumber(1, 32);
                while (kartyak[kioszto] == 0)
                {
                    kioszto = RandomNumber(1, 32);
                }
                Player1_card_id[i] = kartyak[kioszto];
                kartyak[kioszto] = 0;
            }
            for (i = 1; i <= n; i++)
            {
                kioszto = RandomNumber(1, 32);
                while (kartyak[kioszto] == 0)
                {
                    kioszto = RandomNumber(1, 32);
                }
                Player2_card_id[i] = kartyak[kioszto];
                kartyak[kioszto] = 0;
            }
            for (i = 1; i <= n; i++)
            {
                kioszto = RandomNumber(1, 32);
                while (kartyak[kioszto] == 0)
                {
                    kioszto = RandomNumber(1, 32);
                }
                Player3_card_id[i] = kartyak[kioszto];
                kartyak[kioszto] = 0;
            }
            for (i = 1; i <= n; i++)
            {
                kioszto = RandomNumber(1, 32);
                while (kartyak[kioszto] == 0)
                {
                    kioszto = RandomNumber(1, 32);
                }
                Player4_card_id[i] = kartyak[kioszto];
                kartyak[kioszto] = 0;
            }
        }

        private static void Sorbarendezés(int[] array) //Növekvő sorrendbe rendezés
        {
            long rightBorder = array.Length - 1;
            do
            {
                long lastExchange = 0;

                for (long index0 = 0; index0 < rightBorder; index0++)
                {
                    if (array[index0] <= array[index0 + 1]) continue;
                    int temp = array[index0];
                    array[index0] = array[index0 + 1];
                    array[index0 + 1] = temp;
                    lastExchange = index0;
                }
                rightBorder = lastExchange;
            } while (rightBorder > 0);
        }

        public object Kép_keresés(int number)
        {
            switch (number)
            {
                case 10:
                    return ("Images/piros hetes_146x240.jpg");
                case 11:
                    return ("Images/piros nyolcas_144x240.jpg");
                case 12:
                    return ("Images/piros kilences_146x240.jpg");
                case 13:
                    return ("Images/piros tizes_152x240.jpg");
                case 14:
                    return ("Images/piros alsó_145x240.jpg");
                case 15:
                    return ("Images/piros felső_145x240.jpg");
                case 16:
                    return ("Images/piros csikó_145x240.jpg");
                case 17:
                    return ("Images/piros ász_145x240.jpg");
                case 20:
                    return ("Images/zöld hetes_146x240.jpg");
                case 21:
                    return ("Images/zöld nyolcas_147x240.jpg");
                case 22:
                    return ("Images/zöld kilences_147x240.jpg");
                case 23:
                    return ("Images/zöld tizes_145x240.jpg");
                case 24:
                    return ("Images/zöld alsó_145x240.jpg");
                case 25:
                    return ("Images/zöld felső_145x240.jpg");
                case 26:
                    return ("Images/zöld csikó_145x240.jpg");
                case 27:
                    return ("Images/zöld ász_147x240.jpg");
                case 30:
                    return ("Images/makk hetes_148x240.jpg");
                case 31:
                    return ("Images/makk nyolcas_148x240.jpg");
                case 32:
                    return ("Images/makk kilences_148x240.jpg");
                case 33:
                    return ("Images/makk tizes_148x240.jpg");
                case 34:
                    return ("Images/makk alsó_148x240.jpg");
                case 35:
                    return ("Images/makk felső_148x240.jpg");
                case 36:
                    return ("Images/makk csikó_147x240.jpg");
                case 37:
                    return ("Images/makk ász_147x240.jpg");
                case 40:
                    return ("Images/tök hetes_147x240.jpg");
                case 41:
                    return ("Images/tök nyolcas_147x240.jpg");
                case 42:
                    return ("Images/tök kilences_147x240.jpg");
                case 43:
                    return ("Images/tök tizes_147x240.jpg");
                case 44:
                    return ("Images/tök alsó_147x240.jpg");
                case 45:
                    return ("Images/tök felső_147x240.jpg");
                case 46:
                    return ("Images/tök csikó_147x240.jpg");
                case 47:
                    return ("Images/tök ász_148x240.jpg");
            }
            //Vége
            return null;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Button3.Visibility = Visibility.Collapsed;
            switch (starting_player)
            {
                case 1:
                    if (dealer1 == 11)
                    {
                        Figyelmeztetések.Content = "2. Játékos nem szeretné megvenni a kezdést";
                        Figyelmeztetések.Visibility = Visibility.Visible;
                        return;
                    }
                    pontok1 += dealer1;
                    pontok2 -= dealer1;
                    Label1.Content = "Pontok: " + pontok1;
                    label2.Content = "Pontok: " + pontok2;
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Visible;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Collapsed;
                    Figyelmeztetések.Visibility = Visibility.Collapsed;
                    LockedCards = true;
                    timer_ticks = 1;
                    break;
                case 2:
                    if (dealer1 == 11)
                    {
                        Figyelmeztetések.Content = "2. Játékos nem szeretné eladni a kezdést";
                        Figyelmeztetések.Visibility = Visibility.Visible;
                        return;
                    }
                    pontok1 -= dealer1;
                    pontok2 += dealer1;
                    Label1.Content = "Pontok: " + pontok1;
                    label2.Content = "Pontok: " + pontok2;
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Visible;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Collapsed;
                    Figyelmeztetések.Visibility = Visibility.Collapsed;
                    LockedCards = false;
                    break;
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Button4.Visibility = Visibility.Collapsed;
            switch (starting_player)
            {
                case 1:
                    if (dealer2 == 11)
                    {
                        Figyelmeztetések.Content = "3. Játékos nem szeretné megvenni a kezdést";
                        Figyelmeztetések.Visibility = Visibility.Visible;
                        return;
                    }
                    pontok1 += dealer2;
                    pontok3 -= dealer2;
                    Label1.Content = "Pontok: " + pontok1;
                    label3.Content = "Pontok: " + pontok3;
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Visible;
                    Image28.Visibility = Visibility.Collapsed;
                    Figyelmeztetések.Visibility = Visibility.Collapsed;
                    LockedCards = true;
                    timer_ticks = 3;
                    break;
                case 3:
                    if (dealer2 == 11)
                    {
                        Figyelmeztetések.Content = "3. Játékos nem szeretné eladni a kezdést";
                        Figyelmeztetések.Visibility = Visibility.Visible;
                        return;
                    }
                    pontok1 -= dealer2;
                    pontok3 += dealer2;
                    Label1.Content = "Pontok: " + pontok1;
                    label3.Content = "Pontok: " + pontok3;
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Visible;
                    Image28.Visibility = Visibility.Collapsed;
                    Figyelmeztetések.Visibility = Visibility.Collapsed;
                    LockedCards = false;
                    break;
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Button5.Visibility = Visibility.Collapsed;
            switch (starting_player)
            {
                case 1:
                    if (dealer3 == 11)
                    {
                        Figyelmeztetések.Content = "4. Játékos nem szeretné megvenni a kezdést";
                        Figyelmeztetések.Visibility = Visibility.Visible;
                        return;
                    }
                    pontok1 += dealer3;
                    pontok4 -= dealer3;
                    Label1.Content = "Pontok: " + pontok1;
                    label4.Content = "Pontok: " + pontok4;
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Visible;
                    Figyelmeztetések.Visibility = Visibility.Collapsed;
                    LockedCards = true;
                    timer_ticks = 6;
                    break;
                case 4:
                    if (dealer3 == 11)
                    {
                        Figyelmeztetések.Content = "4. Játékos nem szeretné eladni a kezdést";
                        Figyelmeztetések.Visibility = Visibility.Visible;
                        return;
                    }
                    pontok1 -= dealer3;
                    pontok4 += dealer3;
                    Label1.Content = "Pontok: " + pontok1;
                    label4.Content = "Pontok: " + pontok4;
                    Button3.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Visible;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Collapsed;
                    Figyelmeztetések.Visibility = Visibility.Collapsed;
                    LockedCards = false;
                    break;
            }
        }

        public void card_placer(int Card_number)
        {
            if (Card_number == 10 | Card_number == 11 | Card_number == 12 | Card_number == 13 | Card_number == 14 |
                Card_number == 15 | Card_number == 16 | Card_number == 17)
            {
                Piros_Hely.Source = new BitmapImage(new Uri(Kép_keresés(Card_number) as string, UriKind.Relative));
                return;
            }
            if (Card_number == 20 | Card_number == 21 | Card_number == 22 | Card_number == 23 | Card_number == 24 |
                Card_number == 25 | Card_number == 26 | Card_number == 27)
            {
                Zöld_hely.Source = new BitmapImage(new Uri(Kép_keresés(Card_number) as string, UriKind.Relative));
                return;
            }
            if (Card_number == 30 | Card_number == 31 | Card_number == 32 | Card_number == 33 | Card_number == 34 |
                Card_number == 35 | Card_number == 36 | Card_number == 37)
            {
                Makk_Hely.Source = new BitmapImage(new Uri(Kép_keresés(Card_number) as string, UriKind.Relative));
                return;
            }
            if (Card_number == 40 | Card_number == 41 | Card_number == 42 | Card_number == 43 | Card_number == 44 |
                Card_number == 45 | Card_number == 46 | Card_number == 47)
            {
                Tök_hely.Source = new BitmapImage(new Uri(Kép_keresés(Card_number) as string, UriKind.Relative));
            }
        }

        public bool Next_card_player(int card_number)
        {
            //következő kártya vizsgálat
            if (card_number == 10 | card_number == 11 | card_number == 12 | card_number == 13 | card_number == 14 |
                card_number == 15 | card_number == 16 | card_number == 17)
            {
                if (Piros == 0)
                {
                    return true;
                }
                if (Piros + 1 == card_number & card_number != 17)
                {
                    return true;
                }
                if (card_number == 10 & Piros == 17)
                {
                    return true;
                }
                if (Piros == 16 & card_number == 17)
                {
                    return true;
                }
            }
            if (card_number == 20 | card_number == 21 | card_number == 22 | card_number == 23 | card_number == 24 |
                card_number == 25 | card_number == 26 | card_number == 27)
            {
                if (zöld == 0)
                {
                    return true;
                }
                if (zöld + 1 == card_number & card_number != 27)
                {
                    return true;
                }
                if (card_number == 20 & zöld == 27)
                {
                    return true;
                }
                if (zöld == 26 & card_number == 27)
                {
                    return true;
                }
            }
            if (card_number == 30 | card_number == 31 | card_number == 32 | card_number == 33 | card_number == 34 |
                card_number == 35 | card_number == 36 | card_number == 37)
            {
                if (makk == 0)
                {
                    kezdes = true;
                    return true;
                }
                if (makk + 1 == card_number & card_number != 7)
                {
                    return true;
                }
                if (card_number == 30 & makk == 37)
                {
                    return true;
                }
                if (makk == 36 & card_number == 37)
                {
                    return true;
                }
            }
            if (card_number == 40 | card_number == 41 | card_number == 42 | card_number == 43 | card_number == 44 |
                card_number == 45 | card_number == 46 | card_number == 47)
            {
                if (tök == 0)
                {
                    kezdes = true;
                    return true;
                }
                if (tök + 1 == card_number & card_number != 47)
                {
                    return true;
                }
                if (card_number == 40 & tök == 47)
                {
                    return true;
                }
                if (tök == 46 & card_number == 47)
                {
                    return true;
                }
            }
            return false;
        }

        public void Computer_players()
        {
            var myDispatcherTimer = new DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            myDispatcherTimer.Tick += Each_Tick;
            myDispatcherTimer.Start();
        }

        public void Each_Tick(object o, EventArgs sender)
        {
            switch (timer_ticks)
            {
                case 1:
                    NewGame.IsEnabled = false;
                    Passz_Button.IsEnabled = false;
                    LockedCards = true;
                    Image25.Visibility = Visibility.Collapsed;
                    Image26.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Computer1_Card_Select();
                    break;
                case 4:
                    NewGame.IsEnabled = false;
                    Passz_Button.IsEnabled = false;
                    Image26.Visibility = Visibility.Collapsed;
                    Image27.Visibility = Visibility.Visible;
                    break;
                case 5:
                    Computer2_Card_Select();
                    break;
                case 7:
                    NewGame.IsEnabled = false;
                    Passz_Button.IsEnabled = false;
                    Image27.Visibility = Visibility.Collapsed;
                    Image28.Visibility = Visibility.Visible;
                    break;
                case 8:
                    Computer3_Card_Select();
                    break;
                case 10:
                    Image28.Visibility = Visibility.Collapsed;
                    Image25.Visibility = Visibility.Visible;
                    LockedCards = false;
                    NewGame.IsEnabled = true;
                    Passz_Button.IsEnabled = true;
                    break;
            }
            timer_ticks += 1;
        }

        public void Kezdés_Megálapítás(int Kezdő_lap)
        {
            switch (Kezdő_lap)
            {
                case 10:
                    zöld = 27;
                    makk = 37;
                    tök = 47;
                    break;
                case 11:
                    zöld = 20;
                    makk = 30;
                    tök = 40;
                    break;
                case 12:
                    zöld = 21;
                    makk = 31;
                    tök = 41;
                    break;
                case 13:
                    zöld = 22;
                    makk = 32;
                    tök = 42;
                    break;
                case 14:
                    zöld = 23;
                    makk = 33;
                    tök = 43;
                    break;
                case 15:
                    zöld = 24;
                    makk = 34;
                    tök = 44;
                    break;
                case 16:
                    zöld = 25;
                    makk = 35;
                    tök = 45;
                    break;
                case 17:
                    zöld = 26;
                    makk = 36;
                    tök = 46;
                    break;
                case 20:
                    Piros = 17;
                    makk = 37;
                    tök = 47;
                    break;
                case 21:
                    Piros = 10;
                    makk = 30;
                    tök = 40;
                    break;
                case 22:
                    Piros = 11;
                    makk = 31;
                    tök = 41;
                    break;
                case 23:
                    Piros = 12;
                    makk = 32;
                    tök = 42;
                    break;
                case 24:
                    Piros = 13;
                    makk = 33;
                    tök = 43;
                    break;
                case 25:
                    Piros = 14;
                    makk = 34;
                    tök = 44;
                    break;
                case 26:
                    Piros = 15;
                    makk = 35;
                    tök = 45;
                    break;
                case 27:
                    Piros = 16;
                    makk = 36;
                    tök = 46;
                    break;
                case 30:
                    Piros = 17;
                    zöld = 27;
                    tök = 47;
                    break;
                case 31:
                    Piros = 10;
                    zöld = 20;
                    tök = 40;
                    break;
                case 32:
                    Piros = 11;
                    zöld = 21;
                    tök = 41;
                    break;
                case 33:
                    Piros = 12;
                    zöld = 22;
                    tök = 42;
                    break;
                case 34:
                    Piros = 13;
                    zöld = 23;
                    tök = 43;
                    break;
                case 35:
                    Piros = 14;
                    zöld = 24;
                    tök = 44;
                    break;
                case 36:
                    Piros = 15;
                    zöld = 25;
                    tök = 45;
                    break;
                case 37:
                    Piros = 16;
                    zöld = 26;
                    tök = 46;
                    break;
                case 40:
                    Piros = 17;
                    zöld = 27;
                    makk = 37;
                    break;
                case 41:
                    Piros = 10;
                    zöld = 20;
                    makk = 30;
                    break;
                case 42:
                    Piros = 11;
                    zöld = 21;
                    makk = 31;
                    break;
                case 43:
                    Piros = 13;
                    zöld = 23;
                    makk = 33;
                    break;
                case 44:
                    Piros = 12;
                    zöld = 22;
                    makk = 32;
                    break;
                case 45:
                    Piros = 14;
                    zöld = 24;
                    makk = 34;
                    break;
                case 46:
                    Piros = 15;
                    zöld = 25;
                    makk = 35;
                    break;
                case 47:
                    Piros = 16;
                    zöld = 26;
                    makk = 36;
                    break;
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var inputMessage = new CustomMessage("Kérlek add meg a nevedett", CustomMessage.MessageType.TextInput);

            inputMessage.OKButton.Click +=
                (obj, args) => { Message.InfoMessage("Köszöntelek " + inputMessage.Input + "!"); };

            inputMessage.Show();
            Computer_players();
        }

        private void Image30_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[1]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                Image30.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[1]);
                if (Player1_card_id[1] == 10 | Player1_card_id[1] == 11 | Player1_card_id[1] == 12 |
                    Player1_card_id[1] == 13 | Player1_card_id[1] == 14 | Player1_card_id[1] == 15 |
                    Player1_card_id[1] == 16 | Player1_card_id[1] == 17)
                {
                    Piros = Player1_card_id[1];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[1]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[1];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        timer_ticks = 15;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        show_card_info = true;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                }
                lórum_piros = false;
                if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                    lórum = false;
                if (Player1_card_id[1] == 20 | Player1_card_id[1] == 21 | Player1_card_id[1] == 22 |
                    Player1_card_id[1] == 23 | Player1_card_id[1] == 24 | Player1_card_id[1] == 25 |
                    Player1_card_id[1] == 26 | Player1_card_id[1] == 27)
                {
                    zöld = Player1_card_id[1];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[1]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[1];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[1] == 30 | Player1_card_id[1] == 31 | Player1_card_id[1] == 32 |
                    Player1_card_id[1] == 33 | Player1_card_id[1] == 34 | Player1_card_id[1] == 35 |
                    Player1_card_id[1] == 36 | Player1_card_id[1] == 37)
                {
                    makk = Player1_card_id[1];
                    card_placer(Player1_card_id[1]);
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[1]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[1];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[1] == 40 | Player1_card_id[1] == 41 | Player1_card_id[1] == 42 |
                    Player1_card_id[1] == 43 | Player1_card_id[1] == 44 | Player1_card_id[1] == 45 |
                    Player1_card_id[1] == 46 | Player1_card_id[1] == 47)
                {
                    tök = Player1_card_id[1];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[1]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[1];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                timer_ticks = 1;
                Player1_card_id[1] = 0;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void image31_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[2]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                image31.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[2]);
                if (Player1_card_id[2] == 10 | Player1_card_id[2] == 11 | Player1_card_id[2] == 12 |
                    Player1_card_id[2] == 13 | Player1_card_id[2] == 14 | Player1_card_id[2] == 15 |
                    Player1_card_id[1] == 16 | Player1_card_id[1] == 17)
                {
                    Piros = Player1_card_id[2];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[2]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[2];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                    lórum_piros = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[2] == 20 | Player1_card_id[2] == 21 | Player1_card_id[2] == 22 |
                    Player1_card_id[2] == 23 | Player1_card_id[2] == 24 | Player1_card_id[2] == 25 |
                    Player1_card_id[2] == 26 | Player1_card_id[2] == 27)
                {
                    zöld = Player1_card_id[2];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[2]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[2];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[2] == 30 | Player1_card_id[2] == 31 | Player1_card_id[2] == 32 |
                    Player1_card_id[2] == 33 | Player1_card_id[2] == 34 | Player1_card_id[2] == 35 |
                    Player1_card_id[2] == 36 | Player1_card_id[2] == 37)
                {
                    makk = Player1_card_id[2];
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[2]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[2];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[2] == 40 | Player1_card_id[2] == 41 | Player1_card_id[2] == 42 |
                    Player1_card_id[2] == 43 | Player1_card_id[2] == 44 | Player1_card_id[2] == 45 |
                    Player1_card_id[2] == 46 | Player1_card_id[2] == 47)
                {
                    tök = Player1_card_id[2];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[2]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[2];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            újraosztás = false;
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                Player1_card_id[2] = 0;
                timer_ticks = 1;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void image32_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[3]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                image32.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[3]);
                if (Player1_card_id[3] == 10 | Player1_card_id[3] == 11 | Player1_card_id[3] == 12 |
                    Player1_card_id[3] == 13 | Player1_card_id[3] == 14 | Player1_card_id[3] == 15 |
                    Player1_card_id[3] == 16 | Player1_card_id[3] == 17)
                {
                    Piros = Player1_card_id[3];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[3]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[3];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        újraosztás = false;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_piros = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[3] == 20 | Player1_card_id[3] == 21 | Player1_card_id[3] == 22 |
                    Player1_card_id[3] == 23 | Player1_card_id[3] == 24 | Player1_card_id[3] == 25 |
                    Player1_card_id[3] == 26 | Player1_card_id[3] == 27)
                {
                    zöld = Player1_card_id[3];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[3]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[3];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[3] == 30 | Player1_card_id[3] == 31 | Player1_card_id[3] == 32 |
                    Player1_card_id[3] == 33 | Player1_card_id[3] == 34 | Player1_card_id[3] == 35 |
                    Player1_card_id[3] == 36 | Player1_card_id[3] == 37)
                {
                    makk = Player1_card_id[3];
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[3]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[3];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[3] == 40 | Player1_card_id[3] == 41 | Player1_card_id[3] == 42 |
                    Player1_card_id[3] == 43 | Player1_card_id[3] == 44 | Player1_card_id[3] == 45 |
                    Player1_card_id[3] == 46 | Player1_card_id[3] == 47)
                {
                    tök = Player1_card_id[3];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[3]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[3];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        újraosztás = false;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                Player1_card_id[3] = 0;
                timer_ticks = 1;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void image33_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[4]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                image33.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[4]);
                if (Player1_card_id[4] == 10 | Player1_card_id[4] == 11 | Player1_card_id[4] == 12 |
                    Player1_card_id[4] == 13 | Player1_card_id[4] == 14 | Player1_card_id[4] == 15 |
                    Player1_card_id[4] == 16 | Player1_card_id[4] == 17)
                {
                    Piros = Player1_card_id[4];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[4]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[4];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        újraosztás = false;
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_piros = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[4] == 20 | Player1_card_id[4] == 21 | Player1_card_id[4] == 22 |
                    Player1_card_id[4] == 23 | Player1_card_id[4] == 24 | Player1_card_id[4] == 25 |
                    Player1_card_id[4] == 26 | Player1_card_id[4] == 27)
                {
                    zöld = Player1_card_id[4];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[4]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[4];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        timer_ticks = 15;
                        újraosztás = false;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[4] == 30 | Player1_card_id[4] == 31 | Player1_card_id[4] == 32 |
                    Player1_card_id[4] == 33 | Player1_card_id[4] == 34 | Player1_card_id[4] == 35 |
                    Player1_card_id[4] == 36 | Player1_card_id[4] == 37)
                {
                    makk = Player1_card_id[4];
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[4]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[4];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[4] == 40 | Player1_card_id[4] == 41 | Player1_card_id[4] == 42 |
                    Player1_card_id[4] == 43 | Player1_card_id[4] == 44 | Player1_card_id[4] == 45 |
                    Player1_card_id[4] == 46 | Player1_card_id[4] == 47)
                {
                    tök = Player1_card_id[4];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[4]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[4];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                Player1_card_id[4] = 0;
                timer_ticks = 1;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void image34_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[5]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                image34.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[5]);
                if (Player1_card_id[5] == 10 | Player1_card_id[5] == 11 | Player1_card_id[5] == 12 |
                    Player1_card_id[5] == 13 | Player1_card_id[5] == 14 | Player1_card_id[5] == 15 |
                    Player1_card_id[5] == 16 | Player1_card_id[5] == 17)
                {
                    Piros = Player1_card_id[5];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[5]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[5];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_piros = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[5] == 20 | Player1_card_id[5] == 21 | Player1_card_id[5] == 22 |
                    Player1_card_id[5] == 23 | Player1_card_id[5] == 24 | Player1_card_id[5] == 25 |
                    Player1_card_id[5] == 26 | Player1_card_id[5] == 27)
                {
                    zöld = Player1_card_id[5];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[5]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[5];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[5] == 30 | Player1_card_id[5] == 31 | Player1_card_id[5] == 32 |
                    Player1_card_id[5] == 33 | Player1_card_id[5] == 34 | Player1_card_id[5] == 35 |
                    Player1_card_id[5] == 36 | Player1_card_id[5] == 37)
                {
                    makk = Player1_card_id[5];
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[5]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[5];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[5] == 40 | Player1_card_id[5] == 41 | Player1_card_id[5] == 42 |
                    Player1_card_id[5] == 43 | Player1_card_id[5] == 44 | Player1_card_id[5] == 45 |
                    Player1_card_id[5] == 46 | Player1_card_id[5] == 47)
                {
                    tök = Player1_card_id[5];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[5]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[5];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                Player1_card_id[5] = 0;
                timer_ticks = 1;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void image35_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[6]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                image35.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[6]);
                if (Player1_card_id[6] == 10 | Player1_card_id[6] == 11 | Player1_card_id[6] == 12 |
                    Player1_card_id[6] == 13 | Player1_card_id[6] == 14 | Player1_card_id[6] == 15 |
                    Player1_card_id[6] == 16 | Player1_card_id[6] == 17)
                {
                    Piros = Player1_card_id[6];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[6]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[6];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_piros = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[6] == 20 | Player1_card_id[6] == 21 | Player1_card_id[6] == 22 |
                    Player1_card_id[6] == 23 | Player1_card_id[6] == 24 | Player1_card_id[6] == 25 |
                    Player1_card_id[6] == 26 | Player1_card_id[6] == 27)
                {
                    zöld = Player1_card_id[6];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[6]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[6];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[6] == 30 | Player1_card_id[6] == 31 | Player1_card_id[6] == 32 |
                    Player1_card_id[6] == 33 | Player1_card_id[6] == 34 | Player1_card_id[6] == 35 |
                    Player1_card_id[6] == 36 | Player1_card_id[6] == 37)
                {
                    makk = Player1_card_id[6];
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[6]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[6];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[6] == 40 | Player1_card_id[6] == 41 | Player1_card_id[6] == 42 |
                    Player1_card_id[6] == 43 | Player1_card_id[6] == 44 | Player1_card_id[6] == 45 |
                    Player1_card_id[6] == 46 | Player1_card_id[6] == 47)
                {
                    tök = Player1_card_id[6];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[6]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[6];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                Player1_card_id[6] = 0;
                timer_ticks = 1;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void image36_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[7]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                image36.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[7]);
                if (Player1_card_id[7] == 10 | Player1_card_id[7] == 11 | Player1_card_id[7] == 12 |
                    Player1_card_id[7] == 13 | Player1_card_id[7] == 14 | Player1_card_id[7] == 15 |
                    Player1_card_id[7] == 16 | Player1_card_id[7] == 17)
                {
                    Piros = Player1_card_id[7];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[7]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[7];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = true;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_piros = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[7] == 20 | Player1_card_id[7] == 21 | Player1_card_id[7] == 22 |
                    Player1_card_id[7] == 23 | Player1_card_id[7] == 24 | Player1_card_id[7] == 25 |
                    Player1_card_id[7] == 26 | Player1_card_id[7] == 27)
                {
                    zöld = Player1_card_id[7];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[7]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[7];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[7] == 30 | Player1_card_id[7] == 31 | Player1_card_id[7] == 32 |
                    Player1_card_id[7] == 33 | Player1_card_id[7] == 34 | Player1_card_id[7] == 35 |
                    Player1_card_id[7] == 36 | Player1_card_id[7] == 37)
                {
                    makk = Player1_card_id[7];
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[7]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[7];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[7] == 40 | Player1_card_id[7] == 41 | Player1_card_id[7] == 42 |
                    Player1_card_id[7] == 43 | Player1_card_id[7] == 44 | Player1_card_id[7] == 45 |
                    Player1_card_id[7] == 46 | Player1_card_id[7] == 47)
                {
                    tök = Player1_card_id[7];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[7]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[7];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                Player1_card_id[7] = 0;
                timer_ticks = 1;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void image37_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Figyelmeztetések.Content = null;
            if (LockedCards)
                return;
            if (Next_card_player(Player1_card_id[8]))
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                LockedCards = true;
                image37.Visibility = Visibility.Collapsed;
                NewGame.IsEnabled = false;
                Passz_Button.IsEnabled = false;
                játékos_kártyák_száma --;
                card_placer(Player1_card_id[8]);
                if (Player1_card_id[8] == 10 | Player1_card_id[8] == 11 | Player1_card_id[8] == 12 |
                    Player1_card_id[8] == 13 | Player1_card_id[8] == 14 | Player1_card_id[8] == 15 |
                    Player1_card_id[8] == 16 | Player1_card_id[5] == 17)
                {
                    Piros = Player1_card_id[8];
                    if (zöld == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[8]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[8];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_piros = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[8] == 20 | Player1_card_id[8] == 21 | Player1_card_id[8] == 22 |
                    Player1_card_id[8] == 23 | Player1_card_id[8] == 24 | Player1_card_id[8] == 25 |
                    Player1_card_id[8] == 26 | Player1_card_id[8] == 27)
                {
                    zöld = Player1_card_id[8];
                    if (Piros == 0 & makk == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[8]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[8];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_zöld = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[8] == 30 | Player1_card_id[8] == 31 | Player1_card_id[8] == 32 |
                    Player1_card_id[8] == 33 | Player1_card_id[8] == 34 | Player1_card_id[8] == 35 |
                    Player1_card_id[8] == 36 | Player1_card_id[8] == 37)
                {
                    makk = Player1_card_id[8];
                    if (Piros == 0 & zöld == 0 & tök == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[8]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[8];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_makk = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                if (Player1_card_id[8] == 40 | Player1_card_id[8] == 41 | Player1_card_id[8] == 42 |
                    Player1_card_id[8] == 43 | Player1_card_id[8] == 44 | Player1_card_id[8] == 45 |
                    Player1_card_id[8] == 46 | Player1_card_id[8] == 47)
                {
                    tök = Player1_card_id[8];
                    if (Piros == 0 & zöld == 0 & makk == 0)
                    {
                        Kezdés_Megálapítás(Player1_card_id[8]);
                        Kezdőjátékos = 1;
                        kezdőlap = Player1_card_id[8];
                    }
                    if (játékos_kártyák_száma == 0)
                    {
                        show_card_info = true;
                        NewGame.IsEnabled = true;
                        Passz_Button.IsEnabled = false;
                        újraosztás = false;
                        timer_ticks = 15;
                        if (lórum)
                        {
                            starting_player++;
                            pontok1 = pontok1 + (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - (2*játékos2_maradék);
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - (2*játékos3_maradék);
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - (2*játékos4_maradék);
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/Lórum jó.png", UriKind.Relative));
                            pointinfo = (2*(játékos2_maradék + játékos3_maradék + játékos4_maradék));
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                        else
                        {
                            starting_player++;
                            pontok1 = pontok1 + játékos2_maradék + játékos3_maradék + játékos4_maradék;
                            Label1.Content = "Pontok: " + pontok1;
                            pontok2 = pontok2 - játékos2_maradék;
                            label2.Content = "Pontok: " + pontok2;
                            pontok3 = pontok3 - játékos3_maradék;
                            label3.Content = "Pontok: " + pontok3;
                            pontok4 = pontok4 - játékos4_maradék;
                            label4.Content = "Pontok: " + pontok4;
                            Tábla.Source =
                                new BitmapImage(new Uri("Images/győzelem.png", UriKind.Relative));
                            pointinfo = (játékos2_maradék + játékos3_maradék + játékos4_maradék);
                            Message.InfoMessage("Gratulálok! Nyertél " + pointinfo + " pontot.");
                            return;
                        }
                    }
                    lórum_tök = false;
                    if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                        lórum = false;
                }
                Player1_card_id[8] = 0;
                timer_ticks = 1;
            }
            else
            {
                Message.ErrorMessage("Nem ez a kártya következik.");
            }
        }

        private void Computer1_Card_Select()
        {
            int lehet_seges_kartyak = 0;
            lehet_seges_kartyak = 0;
            long i1 = 8;
            long n1 = 0;
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Next_card_player(Player2_card_id[n1]))
                    lehet_seges_kartyak += 1;
            }
            if (lehet_seges_kartyak == 0)
            {
                timer_ticks = 3;
                return;
            }
            int pirosak = 0;
            int zöldek = 0;
            int makkok = 0;
            int tökök = 0;
            bool lehetseges_piros = false;
            bool lehetseges_zöld = false;
            bool lehetseges_makk = false;
            bool lehetseges_tök = false;
            int jelölt_piros = 0;
            int jelölt_zöld = 0;
            int jelölt_makk = 0;
            int jelölt_tök = 0;
            lehetseges_piros = false;
            lehetseges_zöld = false;
            lehetseges_makk = false;
            lehetseges_tök = false;
            jelölt_makk = 0;
            jelölt_piros = 0;
            jelölt_tök = 0;
            jelölt_zöld = 0;
            pirosak = 0;
            zöldek = 0;
            makkok = 0;
            tökök = 0;
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Player2_card_id[n1] == 10 | Player2_card_id[n1] == 11 | Player2_card_id[n1] == 12 |
                    Player2_card_id[n1] == 13 | Player2_card_id[n1] == 14 | Player2_card_id[n1] == 15 |
                    Player2_card_id[n1] == 16 | Player2_card_id[n1] == 17)
                {
                    pirosak += 1;
                }
                if (Player2_card_id[n1] == 20 | Player2_card_id[n1] == 21 | Player2_card_id[n1] == 22 |
                    Player2_card_id[n1] == 23 | Player2_card_id[n1] == 24 | Player2_card_id[n1] == 25 |
                    Player2_card_id[n1] == 26 | Player2_card_id[n1] == 27)
                {
                    zöldek += 1;
                }
                if (Player2_card_id[n1] == 30 | Player2_card_id[n1] == 31 | Player2_card_id[n1] == 32 |
                    Player2_card_id[n1] == 33 | Player2_card_id[n1] == 34 | Player2_card_id[n1] == 35 |
                    Player2_card_id[n1] == 36 | Player2_card_id[n1] == 37)
                {
                    makkok += 1;
                }
                if (Player2_card_id[n1] == 40 | Player2_card_id[n1] == 41 | Player2_card_id[n1] == 42 |
                    Player2_card_id[n1] == 43 | Player2_card_id[n1] == 44 | Player2_card_id[n1] == 45 |
                    Player2_card_id[n1] == 46 | Player2_card_id[n1] == 47)
                {
                    tökök += 1;
                }
            }
            //Lehetőségek felmértése
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Next_card_player(Player2_card_id[n1]))
                {
                    if (Player2_card_id[n1] == 10 | Player2_card_id[n1] == 11 | Player2_card_id[n1] == 12 |
                        Player2_card_id[n1] == 13 | Player2_card_id[n1] == 14 | Player2_card_id[n1] == 15 |
                        Player2_card_id[n1] == 16 | Player2_card_id[n1] == 17)
                    {
                        lehetseges_piros = true;
                        jelölt_piros = Player2_card_id[n1];
                    }
                    if (Player2_card_id[n1] == 20 | Player2_card_id[n1] == 21 | Player2_card_id[n1] == 22 |
                        Player2_card_id[n1] == 23 | Player2_card_id[n1] == 24 | Player2_card_id[n1] == 25 |
                        Player2_card_id[n1] == 26 | Player2_card_id[n1] == 27)
                    {
                        lehetseges_zöld = true;
                        jelölt_zöld = Player2_card_id[n1];
                    }
                    if (Player2_card_id[n1] == 30 | Player2_card_id[n1] == 31 | Player2_card_id[n1] == 32 |
                        Player2_card_id[n1] == 33 | Player2_card_id[n1] == 34 | Player2_card_id[n1] == 35 |
                        Player2_card_id[n1] == 36 | Player2_card_id[n1] == 37)
                    {
                        lehetseges_makk = true;
                        jelölt_makk = Player2_card_id[n1];
                    }
                    if (Player2_card_id[n1] == 40 | Player2_card_id[n1] == 41 | Player2_card_id[n1] == 42 |
                        Player2_card_id[n1] == 43 | Player2_card_id[n1] == 44 | Player2_card_id[n1] == 45 |
                        Player2_card_id[n1] == 46 | Player2_card_id[n1] == 47)
                    {
                        lehetseges_tök = true;
                        jelölt_tök = Player2_card_id[n1];
                    }
                }
            }
            int calculatork = 0;
            //Kezdés Játékos 2 
            if (Piros == 0 & zöld == 0 & makk == 0 & tök == 0)
            {
                calculatork = 0;
                calculatork =
                    (Computer.JátékKezdés(pirosak, zöldek, makkok, tökök, jelölt_piros, jelölt_zöld, jelölt_makk,
                                          jelölt_tök));
                KezdőLap = calculatork;
                if (calculatork == 10 | calculatork == 11 | calculatork == 12 | calculatork == 13 | calculatork == 14 |
                    calculatork == 15 | calculatork == 16 | calculatork == 17)
                {
                    lórum_piros = false;
                    Image16.Visibility = Visibility.Collapsed;
                    játékos2_maradék --;
                    Piros = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player2_card_id[n1] == calculatork)
                        {
                            Player2_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 20 | calculatork == 21 | calculatork == 22 | calculatork == 23 | calculatork == 24 |
                    calculatork == 25 | calculatork == 26 | calculatork == 27)
                {
                    lórum_zöld = false;
                    Image16.Visibility = Visibility.Collapsed;
                    játékos2_maradék --;
                    zöld = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player2_card_id[n1] == calculatork)
                        {
                            Player2_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 30 | calculatork == 31 | calculatork == 32 | calculatork == 33 | calculatork == 34 |
                    calculatork == 35 | calculatork == 36 | calculatork == 37)
                {
                    lórum_makk = false;
                    Image16.Visibility = Visibility.Collapsed;
                    játékos2_maradék --;
                    makk = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player2_card_id[n1] == calculatork)
                        {
                            Player2_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 40 | calculatork == 41 | calculatork == 42 | calculatork == 43 | calculatork == 44 |
                    calculatork == 45 | calculatork == 46 | calculatork == 47)
                {
                    lórum_tök = false;
                    Image16.Visibility = Visibility.Collapsed;
                    játékos2_maradék --;
                    tök = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player2_card_id[n1] == calculatork)
                        {
                            Player2_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                return;
            }
            calculatork = 0;
            calculatork =
                (Computer.JátékGép(pirosak, zöldek, makkok, tökök, jelölt_piros, jelölt_zöld, jelölt_makk, jelölt_tök));
            if (calculatork == 10 | calculatork == 11 | calculatork == 12 | calculatork == 13 | calculatork == 14 |
                calculatork == 15 | calculatork == 16 | calculatork == 17)
            {
                lórum_piros = false;
                Piros = calculatork;
            }
            if (calculatork == 20 | calculatork == 21 | calculatork == 22 | calculatork == 23 | calculatork == 24 |
                calculatork == 25 | calculatork == 26 | calculatork == 27)
            {
                lórum_zöld = false;
                zöld = calculatork;
            }
            if (calculatork == 30 | calculatork == 31 | calculatork == 32 | calculatork == 33 | calculatork == 34 |
                calculatork == 35 | calculatork == 36 | calculatork == 37)
            {
                lórum_makk = false;
                makk = calculatork;
            }
            if (calculatork == 40 | calculatork == 41 | calculatork == 42 | calculatork == 43 | calculatork == 44 |
                calculatork == 45 | calculatork == 46 | calculatork == 47)
            {
                lórum_tök = false;
                tök = calculatork;
            }
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Player2_card_id[n1] == calculatork)
                {
                    Player2_card_id[n1] = 0;
                }
            }
            card_placer(calculatork);
            játékos2_maradék --;
            if (játékos2_maradék == 7)
            {
                Image16.Visibility = Visibility.Collapsed;
            }
            if (játékos2_maradék == 6)
            {
                Image15.Visibility = Visibility.Collapsed;
            }
            if (játékos2_maradék == 5)
            {
                Image14.Visibility = Visibility.Collapsed;
            }
            if (játékos2_maradék == 4)
            {
                Image13.Visibility = Visibility.Collapsed;
            }
            if (játékos2_maradék == 3)
            {
                Image12.Visibility = Visibility.Collapsed;
            }
            if (játékos2_maradék == 2)
            {
                Image11.Visibility = Visibility.Collapsed;
            }
            if (játékos2_maradék == 1)
            {
                Image10.Visibility = Visibility.Collapsed;
            }
            if (játékos2_maradék == 0)
            {
                Image9.Visibility = Visibility.Collapsed;
                show_card_info = true;
                LockedCards = true;
                NewGame.IsEnabled = true;
                Passz_Button.IsEnabled = false;
                if (lórum)
                {
                    Tábla.Source = new BitmapImage(new Uri("Images/Lórum rossz.png", UriKind.Relative));
                    starting_player++;
                    pontok2 = pontok2 + (2*(játékos_kártyák_száma + játékos3_maradék + játékos4_maradék));
                    label2.Content = "Pontok: " + pontok2;
                    pontok1 = pontok1 - (2*játékos_kártyák_száma);
                    Label1.Content = "Pontok: " + pontok1;
                    pontok3 = pontok3 - (2*játékos3_maradék);
                    label3.Content = "Pontok: " + pontok3;
                    pontok4 = pontok4 - (2*játékos4_maradék);
                    label4.Content = "Pontok: " + pontok4;
                    timer_ticks = 15;
                    újraosztás = false;
                    Message.InfoMessage("2. Játékos győzött. Vesztettél " + (játékos_kártyák_száma*2) + " pontot.");
                    return;
                }
                else
                {
                    show_card_info = true;
                    Tábla.Source = new BitmapImage(new Uri("Images/Vereség.png", UriKind.Relative));
                    starting_player++;
                    pontok2 += játékos_kártyák_száma + játékos3_maradék + játékos4_maradék;
                    label2.Content = "Pontok: " + pontok2;
                    pontok1 = pontok1 - játékos_kártyák_száma;
                    Label1.Content = "Pontok: " + pontok1;
                    pontok3 = pontok3 - játékos3_maradék;
                    label3.Content = "Pontok: " + pontok3;
                    pontok4 = pontok4 - játékos4_maradék;
                    label4.Content = "Pontok: " + pontok4;
                    timer_ticks = 15;
                    Message.InfoMessage("2. Játékos győzött. Vesztettél " + játékos_kártyák_száma + " pontot.");
                    újraosztás = false;
                    return;
                }
            }
            timer_ticks = 3;
            if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                lórum = false;
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox1.SelectedIndex)
            {
                case 0:
                    image29.Source =
                        new BitmapImage(new Uri("Images/bellas-praderas-1474_1024x576.jpg",
                                                UriKind.Relative));
                    break;
                case 3:
                    image29.Source =
                        new BitmapImage(new Uri("Images/02001_resistance_1024x768.jpg",
                                                UriKind.Relative));
                    break;
                case 1:
                    image29.Source =
                        new BitmapImage(new Uri("Images/DSC05463_1024x576.JPG", UriKind.Relative));
                    break;
                case 2:
                    image29.Source =
                        new BitmapImage(new Uri("Images/Let-it-Fly-vector-1024x576.jpg",
                                                UriKind.Relative));
                    break;
            }
        }

        private void Computer2_Card_Select()
        {
            int lehet_seges_kartyak = 0;
            lehet_seges_kartyak = 0;
            long i1 = 8;
            long n1 = 0;
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Next_card_player(Player3_card_id[n1]))
                {
                    lehet_seges_kartyak += 1;
                }
            }
            if (lehet_seges_kartyak == 0)
            {
                timer_ticks = 6;
                return;
            }
            int pirosak = 0;
            int zöldek = 0;
            int makkok = 0;
            int tökök = 0;
            bool lehetseges_piros = false;
            bool lehetseges_zöld = false;
            bool lehetseges_makk = false;
            bool lehetseges_tök = false;
            int jelölt_piros = 0;
            int jelölt_zöld = 0;
            int jelölt_makk = 0;
            int jelölt_tök = 0;
            lehetseges_piros = false;
            lehetseges_zöld = false;
            lehetseges_makk = false;
            lehetseges_tök = false;
            jelölt_makk = 0;
            jelölt_piros = 0;
            jelölt_tök = 0;
            jelölt_zöld = 0;
            pirosak = 0;
            zöldek = 0;
            makkok = 0;
            tökök = 0;
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Player3_card_id[n1] == 10 | Player3_card_id[n1] == 11 | Player3_card_id[n1] == 12 |
                    Player3_card_id[n1] == 13 | Player3_card_id[n1] == 14 | Player3_card_id[n1] == 15 |
                    Player3_card_id[n1] == 16 | Player3_card_id[n1] == 17)
                {
                    pirosak += 1;
                }
                if (Player3_card_id[n1] == 20 | Player3_card_id[n1] == 21 | Player3_card_id[n1] == 22 |
                    Player3_card_id[n1] == 23 | Player3_card_id[n1] == 24 | Player3_card_id[n1] == 25 |
                    Player3_card_id[n1] == 26 | Player3_card_id[n1] == 27)
                {
                    zöldek += 1;
                }
                if (Player3_card_id[n1] == 30 | Player3_card_id[n1] == 31 | Player3_card_id[n1] == 32 |
                    Player3_card_id[n1] == 33 | Player3_card_id[n1] == 34 | Player3_card_id[n1] == 35 |
                    Player3_card_id[n1] == 36 | Player3_card_id[n1] == 37)
                {
                    makkok += 1;
                }
                if (Player3_card_id[n1] == 40 | Player3_card_id[n1] == 41 | Player3_card_id[n1] == 42 |
                    Player3_card_id[n1] == 43 | Player3_card_id[n1] == 44 | Player3_card_id[n1] == 45 |
                    Player3_card_id[n1] == 46 | Player3_card_id[n1] == 47)
                {
                    tökök += 1;
                }
            }
            //Lehetőségek felmértése
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Next_card_player(Player3_card_id[n1]))
                {
                    if (Player3_card_id[n1] == 10 | Player3_card_id[n1] == 11 | Player3_card_id[n1] == 12 |
                        Player3_card_id[n1] == 13 | Player3_card_id[n1] == 14 | Player3_card_id[n1] == 15 |
                        Player3_card_id[n1] == 16 | Player3_card_id[n1] == 17)
                    {
                        lehetseges_piros = true;
                        jelölt_piros = Player3_card_id[n1];
                    }
                    if (Player3_card_id[n1] == 20 | Player3_card_id[n1] == 21 | Player3_card_id[n1] == 22 |
                        Player3_card_id[n1] == 23 | Player3_card_id[n1] == 24 | Player3_card_id[n1] == 25 |
                        Player3_card_id[n1] == 26 | Player3_card_id[n1] == 27)
                    {
                        lehetseges_zöld = true;
                        jelölt_zöld = Player3_card_id[n1];
                    }
                    if (Player3_card_id[n1] == 30 | Player3_card_id[n1] == 31 | Player3_card_id[n1] == 32 |
                        Player3_card_id[n1] == 33 | Player3_card_id[n1] == 34 | Player3_card_id[n1] == 35 |
                        Player3_card_id[n1] == 36 | Player3_card_id[n1] == 37)
                    {
                        lehetseges_makk = true;
                        jelölt_makk = Player3_card_id[n1];
                    }
                    if (Player3_card_id[n1] == 40 | Player3_card_id[n1] == 41 | Player3_card_id[n1] == 42 |
                        Player3_card_id[n1] == 43 | Player3_card_id[n1] == 44 | Player3_card_id[n1] == 45 |
                        Player3_card_id[n1] == 46 | Player3_card_id[n1] == 47)
                    {
                        lehetseges_tök = true;
                        jelölt_tök = Player3_card_id[n1];
                    }
                }
            }
            int calculatork;
            //Kezdés Játékos 3
            if (Piros == 0 & zöld == 0 & makk == 0 & tök == 0)
            {
                calculatork =
                    (Computer.JátékKezdés(pirosak, zöldek, makkok, tökök, jelölt_piros, jelölt_zöld, jelölt_makk,
                                              jelölt_tök));
                KezdőLap = calculatork;
                if (calculatork == 10 | calculatork == 11 | calculatork == 12 | calculatork == 13 | calculatork == 14 |
                    calculatork == 15 | calculatork == 16 | calculatork == 17)
                {
                    lórum_piros = false;
                    Image8.Visibility = Visibility.Collapsed;
                    játékos3_maradék --;
                    Piros = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player3_card_id[n1] == calculatork)
                        {
                            Player3_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 20 | calculatork == 21 | calculatork == 22 | calculatork == 23 | calculatork == 24 |
                    calculatork == 25 | calculatork == 26 | calculatork == 27)
                {
                    lórum_zöld = false;
                    Image8.Visibility = Visibility.Collapsed;
                    játékos3_maradék --;
                    zöld = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player3_card_id[n1] == calculatork)
                        {
                            Player3_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 30 | calculatork == 31 | calculatork == 32 | calculatork == 33 | calculatork == 34 |
                    calculatork == 35 | calculatork == 36 | calculatork == 37)
                {
                    lórum_makk = false;
                    Image8.Visibility = Visibility.Collapsed;
                    játékos3_maradék --;
                    makk = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player3_card_id[n1] == calculatork)
                        {
                            Player3_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 40 | calculatork == 41 | calculatork == 42 | calculatork == 43 | calculatork == 44 |
                    calculatork == 45 | calculatork == 46 | calculatork == 47)
                {
                    lórum_tök = false;
                    Image8.Visibility = Visibility.Collapsed;
                    játékos3_maradék --;
                    tök = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player3_card_id[n1] == calculatork)
                        {
                            Player3_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                return;
            }
            calculatork =
                (Computer.JátékGép(pirosak, zöldek, makkok, tökök, jelölt_piros, jelölt_zöld, jelölt_makk, jelölt_tök));
            if (calculatork == 10 | calculatork == 11 | calculatork == 12 | calculatork == 13 | calculatork == 14 |
                calculatork == 15 | calculatork == 16 | calculatork == 17)
            {
                lórum_piros = false;
                Piros = calculatork;
            }
            if (calculatork == 20 | calculatork == 21 | calculatork == 22 | calculatork == 23 | calculatork == 24 |
                calculatork == 25 | calculatork == 26 | calculatork == 27)
            {
                lórum_zöld = false;
                zöld = calculatork;
            }
            if (calculatork == 30 | calculatork == 31 | calculatork == 32 | calculatork == 33 | calculatork == 34 |
                calculatork == 35 | calculatork == 36 | calculatork == 37)
            {
                lórum_makk = false;
                makk = calculatork;
            }
            if (calculatork == 40 | calculatork == 41 | calculatork == 42 | calculatork == 43 | calculatork == 44 |
                calculatork == 45 | calculatork == 46 | calculatork == 47)
            {
                lórum_tök = false;
                tök = calculatork;
            }
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Player3_card_id[n1] == calculatork)
                {
                    Player3_card_id[n1] = 0;
                }
            }
            card_placer(calculatork);
            játékos3_maradék --;
            if (játékos3_maradék == 7)
            {
                Image8.Visibility = Visibility.Collapsed;
            }
            if (játékos3_maradék == 6)
            {
                Image7.Visibility = Visibility.Collapsed;
            }
            if (játékos3_maradék == 5)
            {
                Image6.Visibility = Visibility.Collapsed;
            }
            if (játékos3_maradék == 4)
            {
                Image5.Visibility = Visibility.Collapsed;
            }
            if (játékos3_maradék == 3)
            {
                Image4.Visibility = Visibility.Collapsed;
            }
            if (játékos3_maradék == 2)
            {
                Image3.Visibility = Visibility.Collapsed;
            }
            if (játékos3_maradék == 1)
            {
                Image2.Visibility = Visibility.Collapsed;
            }
            if (játékos3_maradék == 0)
            {
                NewGame.IsEnabled = true;
                Passz_Button.IsEnabled = false;
                Image1.Visibility = Visibility.Collapsed;
                show_card_info = true;
                LockedCards = true;
                if (lórum)
                {
                    Tábla.Source = new BitmapImage(new Uri("Images/Lórum rossz.png", UriKind.Relative));
                    starting_player++;
                    pontok3 = pontok3 + (2*(játékos_kártyák_száma + játékos2_maradék + játékos4_maradék));
                    label3.Content = "Pontok: " + pontok3;
                    pontok1 = pontok1 - (2*játékos_kártyák_száma);
                    Label1.Content = "Pontok: " + pontok1;
                    pontok2 = pontok2 - (2*játékos2_maradék);
                    label2.Content = "Pontok: " + pontok2;
                    pontok4 = pontok4 - (2*játékos4_maradék);
                    label4.Content = "Pontok: " + pontok4;
                    újraosztás = false;
                    timer_ticks = 15;
                    Message.InfoMessage("3. Játékos győzött. Vesztettél " + (játékos_kártyák_száma*2) + " pontot.");
                    return;
                }
                else
                {
                    Tábla.Source = new BitmapImage(new Uri("Images/Vereség.png", UriKind.Relative));
                    starting_player++;
                    pontok3 = pontok3 + játékos_kártyák_száma + játékos2_maradék + játékos4_maradék;
                    label3.Content = "Pontok: " + pontok3;
                    pontok1 = pontok1 - játékos_kártyák_száma;
                    Label1.Content = "Pontok: " + pontok1;
                    pontok2 = pontok2 - játékos2_maradék;
                    label2.Content = "Pontok: " + pontok2;
                    pontok4 = pontok4 - játékos4_maradék;
                    label4.Content = "Pontok: " + pontok4;
                    újraosztás = false;
                    timer_ticks = 15;
                    Message.InfoMessage("3. Játékos győzött. Vesztettél " + játékos_kártyák_száma + " pontot.");
                    return;
                }
            }
            timer_ticks = 6;
            if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                lórum = false;
        }

        private void Computer3_Card_Select()
        {
            int lehet_seges_kartyak = 0;
            lehet_seges_kartyak = 0;
            long i1 = 8;
            long n1 = 0;
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Next_card_player(Player4_card_id[n1]))
                {
                    lehet_seges_kartyak += 1;
                }
            }
            if (lehet_seges_kartyak == 0)
            {
                timer_ticks = 9;
                return;
            }
            int pirosak = 0;
            int zöldek = 0;
            int makkok = 0;
            int tökök = 0;
            bool lehetseges_piros = false;
            bool lehetseges_zöld = false;
            bool lehetseges_makk = false;
            bool lehetseges_tök = false;
            int jelölt_piros = 0;
            int jelölt_zöld = 0;
            int jelölt_makk = 0;
            int jelölt_tök = 0;
            lehetseges_piros = false;
            lehetseges_zöld = false;
            lehetseges_makk = false;
            lehetseges_tök = false;
            jelölt_makk = 0;
            jelölt_piros = 0;
            jelölt_tök = 0;
            jelölt_zöld = 0;
            pirosak = 0;
            zöldek = 0;
            makkok = 0;
            tökök = 0;
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Player4_card_id[n1] == 10 | Player4_card_id[n1] == 11 | Player4_card_id[n1] == 12 |
                    Player4_card_id[n1] == 13 | Player4_card_id[n1] == 14 | Player4_card_id[n1] == 15 |
                    Player4_card_id[n1] == 16 | Player4_card_id[n1] == 17)
                {
                    pirosak += 1;
                }
                if (Player4_card_id[n1] == 20 | Player4_card_id[n1] == 21 | Player4_card_id[n1] == 22 |
                    Player4_card_id[n1] == 23 | Player4_card_id[n1] == 24 | Player4_card_id[n1] == 25 |
                    Player4_card_id[n1] == 26 | Player4_card_id[n1] == 27)
                {
                    zöldek += 1;
                }
                if (Player4_card_id[n1] == 30 | Player4_card_id[n1] == 31 | Player4_card_id[n1] == 32 |
                    Player4_card_id[n1] == 33 | Player4_card_id[n1] == 34 | Player4_card_id[n1] == 35 |
                    Player4_card_id[n1] == 36 | Player4_card_id[n1] == 37)
                {
                    makkok += 1;
                }
                if (Player4_card_id[n1] == 40 | Player4_card_id[n1] == 41 | Player4_card_id[n1] == 42 |
                    Player4_card_id[n1] == 43 | Player4_card_id[n1] == 44 | Player4_card_id[n1] == 45 |
                    Player4_card_id[n1] == 46 | Player4_card_id[n1] == 47)
                {
                    tökök += 1;
                }
            }
            //Lehetőségek felmértése
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Next_card_player(Player4_card_id[n1]))
                {
                    if (Player4_card_id[n1] == 10 | Player4_card_id[n1] == 11 | Player4_card_id[n1] == 12 |
                        Player4_card_id[n1] == 13 | Player4_card_id[n1] == 14 | Player4_card_id[n1] == 15 |
                        Player4_card_id[n1] == 16 | Player4_card_id[n1] == 17)
                    {
                        lehetseges_piros = true;
                        jelölt_piros = Player4_card_id[n1];
                    }
                    if (Player4_card_id[n1] == 20 | Player4_card_id[n1] == 21 | Player4_card_id[n1] == 22 |
                        Player4_card_id[n1] == 23 | Player4_card_id[n1] == 24 | Player4_card_id[n1] == 25 |
                        Player4_card_id[n1] == 26 | Player4_card_id[n1] == 27)
                    {
                        lehetseges_zöld = true;
                        jelölt_zöld = Player4_card_id[n1];
                    }
                    if (Player4_card_id[n1] == 30 | Player4_card_id[n1] == 31 | Player4_card_id[n1] == 32 |
                        Player4_card_id[n1] == 33 | Player4_card_id[n1] == 34 | Player4_card_id[n1] == 35 |
                        Player4_card_id[n1] == 36 | Player4_card_id[n1] == 37)
                    {
                        lehetseges_makk = true;
                        jelölt_makk = Player4_card_id[n1];
                    }
                    if (Player4_card_id[n1] == 40 | Player4_card_id[n1] == 41 | Player4_card_id[n1] == 42 |
                        Player4_card_id[n1] == 43 | Player4_card_id[n1] == 44 | Player4_card_id[n1] == 45 |
                        Player4_card_id[n1] == 46 | Player4_card_id[n1] == 47)
                    {
                        lehetseges_tök = true;
                        jelölt_tök = Player4_card_id[n1];
                    }
                }
            }
            int calculatork;
            //Kezdés Játékos 3
            if (Piros == 0 & zöld == 0 & makk == 0 & tök == 0)
            {
                calculatork =
                    (Computer.JátékKezdés(pirosak, zöldek, makkok, tökök, jelölt_piros, jelölt_zöld, jelölt_makk,
                                              jelölt_tök));
                KezdőLap = calculatork;
                if (calculatork == 10 | calculatork == 11 | calculatork == 12 | calculatork == 13 | calculatork == 14 |
                    calculatork == 15 | calculatork == 16 | calculatork == 17)
                {
                    lórum_piros = false;
                    Image17.Visibility = Visibility.Collapsed;
                    játékos4_maradék --;
                    Piros = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player4_card_id[n1] == calculatork)
                        {
                            Player4_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 20 | calculatork == 21 | calculatork == 22 | calculatork == 23 | calculatork == 24 |
                    calculatork == 25 | calculatork == 26 | calculatork == 27)
                {
                    lórum_zöld = false;
                    Image17.Visibility = Visibility.Collapsed;
                    játékos4_maradék --;
                    zöld = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player4_card_id[n1] == calculatork)
                        {
                            Player4_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 30 | calculatork == 31 | calculatork == 32 | calculatork == 33 | calculatork == 34 |
                    calculatork == 35 | calculatork == 36 | calculatork == 37)
                {
                    lórum_makk = false;
                    Image17.Visibility = Visibility.Collapsed;
                    játékos4_maradék --;
                    makk = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player4_card_id[n1] == calculatork)
                        {
                            Player4_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                if (calculatork == 40 | calculatork == 41 | calculatork == 42 | calculatork == 43 | calculatork == 44 |
                    calculatork == 45 | calculatork == 46 | calculatork == 47)
                {
                    lórum_tök = false;
                    Image17.Visibility = Visibility.Collapsed;
                    játékos4_maradék --;
                    tök = calculatork;
                    card_placer(calculatork);
                    Kezdés_Megálapítás(calculatork);
                    for (n1 = 1; n1 <= i1; n1++)
                    {
                        if (Player4_card_id[n1] == calculatork)
                        {
                            Player4_card_id[n1] = 0;
                        }
                    }
                    return;
                }
                return;
            }
            calculatork =
                (Computer.JátékGép(pirosak, zöldek, makkok, tökök, jelölt_piros, jelölt_zöld, jelölt_makk, jelölt_tök));
            if (calculatork <= 10 && calculatork >= 17)
            {
                lórum_piros = false;
                Piros = calculatork;
            }
            if (calculatork <= 20 && calculatork >= 27)
            {
                lórum_zöld = false;
                zöld = calculatork;
            }
            if (calculatork <= 30 && calculatork >= 37)
            {
                lórum_makk = false;
                makk = calculatork;
            }
            if (calculatork <= 40 && calculatork >= 47)
            {
                lórum_tök = false;
                tök = calculatork;
            }
            for (n1 = 1; n1 <= i1; n1++)
            {
                if (Player4_card_id[n1] == calculatork)
                {
                    Player4_card_id[n1] = 0;
                }
            }
            card_placer(calculatork);
            játékos4_maradék --;
            if (játékos4_maradék == 7)
            {
                Image17.Visibility = Visibility.Collapsed;
            }
            if (játékos4_maradék == 6)
            {
                Image18.Visibility = Visibility.Collapsed;
            }
            if (játékos4_maradék == 5)
            {
                Image19.Visibility = Visibility.Collapsed;
            }
            if (játékos4_maradék == 4)
            {
                Image20.Visibility = Visibility.Collapsed;
            }
            if (játékos4_maradék == 3)
            {
                Image21.Visibility = Visibility.Collapsed;
            }
            if (játékos4_maradék == 2)
            {
                Image22.Visibility = Visibility.Collapsed;
            }
            if (játékos4_maradék == 1)
            {
                Image23.Visibility = Visibility.Collapsed;
            }
            if (játékos4_maradék == 0)
            {
                Image24.Visibility = Visibility.Collapsed;
                show_card_info = true;
                LockedCards = true;
                NewGame.IsEnabled = true;
                Passz_Button.IsEnabled = false;
                if (lórum)
                {
                    Tábla.Source = new BitmapImage(new Uri("Images/Lórum rossz.png", UriKind.Relative));
                    starting_player++;
                    pontok4 = pontok4 + (2*(játékos_kártyák_száma + játékos2_maradék + játékos3_maradék));
                    label4.Content = "Pontok: " + pontok4;
                    pontok1 = pontok1 - (2*játékos_kártyák_száma);
                    Label1.Content = "Pontok: " + pontok1;
                    pontok2 = pontok2 - (2*játékos2_maradék);
                    label2.Content = "Pontok: " + pontok2;
                    pontok3 = pontok3 - (2*játékos3_maradék);
                    label3.Content = "Pontok: " + pontok3;
                    újraosztás = false;
                    timer_ticks = 15;
                    Message.InfoMessage("4. Játékos győzött. Vesztettél " + (játékos_kártyák_száma*2) + " pontot.");
                    return;
                }
                else
                {
                    Tábla.Source = new BitmapImage(new Uri("Images/Vereség.png", UriKind.Relative));
                    starting_player++;
                    pontok4 = pontok4 + játékos_kártyák_száma + játékos2_maradék + játékos3_maradék;
                    label4.Content = "Pontok: " + pontok4;
                    pontok1 = pontok1 - játékos_kártyák_száma;
                    Label1.Content = "Pontok: " + pontok1;
                    pontok2 = pontok2 - játékos2_maradék;
                    label2.Content = "Pontok: " + pontok2;
                    pontok3 = pontok3 - játékos3_maradék;
                    label3.Content = "Pontok: " + pontok3;
                    újraosztás = false;
                    timer_ticks = 15;
                    Message.InfoMessage("4. Játékos győzött. Vesztettél " + játékos_kártyák_száma + " pontot.");
                    return;
                }
            }
            timer_ticks = 9;
            if (lórum_piros == false & lórum_zöld == false & lórum_makk == false & lórum_tök == false)
                lórum = false;
        }

        private void label6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (show_card_info)
            {
                Message.InfoMessage("2.játékos kártyái:" + Enemy_card(Player2_card_id[1]) + "," +
                                    Enemy_card(Player2_card_id[2]) + "," + Enemy_card(Player2_card_id[3]) + "," +
                                    Enemy_card(Player2_card_id[4]) + "," + Enemy_card(Player2_card_id[5]) + "," +
                                    Enemy_card(Player2_card_id[6]) + "," + Enemy_card(Player2_card_id[7]) + "," +
                                    Enemy_card(Player2_card_id[8]));
            }
        }

        private void label7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (show_card_info)
            {
                Message.InfoMessage("3.játékos kártyái:" + Enemy_card(Player3_card_id[1]) + "," +
                                    Enemy_card(Player3_card_id[2]) + "," + Enemy_card(Player3_card_id[3]) + "," +
                                    Enemy_card(Player3_card_id[4]) + "," + Enemy_card(Player3_card_id[5]) + "," +
                                    Enemy_card(Player3_card_id[6]) + "," + Enemy_card(Player3_card_id[7]) + "," +
                                    Enemy_card(Player3_card_id[8]));
            }
        }

        private void label8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (show_card_info)
            {
                Message.InfoMessage("4.játékos kártyái:" + Enemy_card(Player4_card_id[1]) + "," +
                                    Enemy_card(Player4_card_id[2]) + "," + Enemy_card(Player4_card_id[3]) + "," +
                                    Enemy_card(Player4_card_id[4]) + "," + Enemy_card(Player4_card_id[5]) + "," +
                                    Enemy_card(Player4_card_id[6]) + "," + Enemy_card(Player4_card_id[7]) + "," +
                                    Enemy_card(Player4_card_id[8]));
            }
        }

        private void Passz_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Image30_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        public object Enemy_card(int Card_number)
        {
            switch (Card_number)
            {
                case 10:
                    return "Piros Hetes";
                case 11:
                    return "Piros Nyolcas";
                case 12:
                    return "Piros Kilences";
                case 13:
                    return "Piros Tízes";
                case 14:
                    return "Piros Alsó";
                case 15:
                    return "Piros Felső";
                case 16:
                    return "Piros Csikó";
                case 17:
                    return "Piros Ász";
                case 20:
                    return "Zöld Hetes";
                case 21:
                    return "Zöld Nyolcas";
                case 22:
                    return "Zöld Kilences";
                case 23:
                    return "Zöld Tízes";
                case 24:
                    return "Zöld Alsó";
                case 25:
                    return "Zöld Felső";
                case 26:
                    return "Zöld Csikó";
                case 27:
                    return "Zöld Ász";
                case 30:
                    return "Makk Hetes";
                case 31:
                    return "Makk Nyolcas";
                case 32:
                    return "Makk Kilences";
                case 33:
                    return "Makk Tízes";
                case 34:
                    return "Makk Alsó";
                case 35:
                    return "Makk Felső";
                case 36:
                    return "Makk Csikó";
                case 37:
                    return "Makk Ász";
                case 40:
                    return "Tök Hetes";
                case 41:
                    return "Tök Nyolcas";
                case 42:
                    return "Tök Kilences";
                case 43:
                    return "Tök Tízes";
                case 44:
                    return "Tök Alsó";
                case 45:
                    return "Tök Felső";
                case 46:
                    return "Tök Csikó";
                case 47:
                    return "Tök Ász";
                case 0:
                    return "------";
            }
            throw new ArgumentException("Parameter cannot be null", "original");
        }

        private void Label5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Message.InfoMessage("Copyright © Zoli Software 2011" + Environment.NewLine + "Készítette: zoli456" +
                                Environment.NewLine + "E-mail: Zoli456@hotmail.com");
        }

    }
}