using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Browser;
using Lórum_Silverlight;

namespace Lorum_Silverlight
{
    public partial class Computer : Application
    {
        public static int[] Player_card_ids = new int[9];
        private static readonly List<int> numbers = new List<int>();
        private static readonly List<int> lapok = new List<int>();
        private static readonly Random _generator = new Random();
        private static int i;
        public static bool LehetLórumPiros;
        public static bool LehetLórumZöld;
        public static bool LehetLórumMakk;
        public static bool LehetLórumTök;
        public static int LórumJelölt;
        private static int lap1;
        private static int lap2;
        private static int lap3;
        private static int lap4;
        public static int laptávolság1;
        public static int laptávolság2;
        public static int laptávolság3;
        public static int laptávolság4;
        public static int temp;
        private static int steps;
        private static int matches;
        public static int[] counter = new int[8];
        public static int Randomizer;
        public static bool Randomcard;
        public static int lórumcard;
        public static bool Loselórum;
        public int n;

        public Computer()
        {
            Startup += Application_Startup;
            Exit += Application_Exit;
            UnhandledException += Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
        }

        private void Application_Exit(object sender, EventArgs e)
        {
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!Debugger.IsAttached)
            {
                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg +
                                     "\");");
            }
            catch (Exception)
            {
            }
        }

        public static void DetectLorum(int pirosak, int zöldek, int makkok, int tökök, int Játékosszám)
        {
            int Kártyákszáma = 0;
            switch (Játékosszám)
            {
                case 2:
                    Kártyákszáma = MainPage.játékos2_maradék;
                    break;
                case 3:
                    Kártyákszáma = MainPage.játékos3_maradék;
                    break;
                case 4:
                    Kártyákszáma = MainPage.játékos4_maradék;
                    break;
            }
            if (MainPage.starting_player == 2 | Kártyákszáma < 8)
                return;
            if (MainPage.Kezdőjátékos == Játékosszám)
                return;
            if (MainPage.lórum_piros == false & MainPage.lórum_zöld == false & MainPage.lórum_makk == false &
                MainPage.lórum_tök == false)
                return;
            if (MainPage.KezdőLap <= 10 && MainPage.KezdőLap >= 17)
            {
                Detector1(MainPage.KezdőLap, pirosak, zöldek, makkok, tökök);
            }
            if (MainPage.KezdőLap <= 20 && MainPage.KezdőLap >= 27)
            {
                Detector2(MainPage.KezdőLap, pirosak, zöldek, makkok, tökök);
            }
            if (MainPage.KezdőLap <= 30 && MainPage.KezdőLap >= 37)
            {
                Detector3(MainPage.KezdőLap, pirosak, zöldek, makkok, tökök);
            }
            if (MainPage.KezdőLap <= 40 && MainPage.KezdőLap >= 47)
            {
                Detector4(MainPage.KezdőLap, pirosak, zöldek, makkok, tökök);
            }
        }

        public static void Detector1(int alany, int pirosak, int zöldek, int makkok, int tökök)
        {
            if (zöldek == 1)
            {
                for (i = 20; i <= 27; i++)
                {
                    if (Player_card_ids[i] == alany + 10)
                    {
                        LehetLórumZöld = true;
                        lórumcard = alany + 10;
                    }
                }
            }
            if (makkok == 1)
            {
                for (i = 20; i <= 27; i++)
                {
                    if (Player_card_ids[i] == alany + 20)
                    {
                        LehetLórumMakk = true;
                        lórumcard = alany + 20;
                    }
                }
            }
            if (tökök == 1)
            {
                for (i = 40; i <= 47; i++)
                {
                    if (Player_card_ids[i] == alany + 30)
                    {
                        LehetLórumTök = true;
                        lórumcard = alany + 30;
                    }
                }
            }
        }

        public static void Detector2(int alany, int pirosak, int zöldek, int makkok, int tökök)
        {
            if (pirosak == 1)
            {
                for (i = 10; i <= 17; i++)
                {
                    if (Player_card_ids[i] == alany - 10)
                    {
                        LehetLórumPiros = true;
                        lórumcard = alany - 10;
                    }
                }
            }
            if (makkok == 1)
            {
                for (i = 30; i <= 37; i++)
                {
                    if (Player_card_ids[i] == alany + 10)
                    {
                        LehetLórumMakk = true;
                        lórumcard = alany + 10;
                    }
                }
            }
            if (tökök == 1)
            {
                for (i = 40; i <= 47; i++)
                {
                    if (Player_card_ids[i] == alany + 20)
                    {
                        LehetLórumTök = true;
                        lórumcard = alany + 20;
                    }
                }
            }
        }

        public static void Detector3(int alany, int pirosak, int zöldek, int makkok, int tökök)
        {
            if (pirosak == 1)
            {
                for (i = 10; i <= 17; i++)
                {
                    if (Player_card_ids[i] == alany - 20)
                    {
                        LehetLórumPiros = true;
                        lórumcard = alany - 20;
                    }
                }
            }
            if (zöldek == 1)
            {
                for (i = 20; i <= 27; i++)
                {
                    if (Player_card_ids[i] == alany - 10)
                    {
                        LehetLórumZöld = true;
                        lórumcard = alany - 10;
                    }
                }
            }
            if (tökök == 1)
            {
                for (i = 40; i <= 47; i++)
                {
                    if (Player_card_ids[i] == alany + 10)
                    {
                        LehetLórumTök = true;
                        lórumcard = alany + 10;
                    }
                }
            }
        }

        public static void Detector4(int alany, int pirosak, int zöldek, int makkok, int tökök)
        {
            if (pirosak == 1)
            {
                for (i = 10; i <= 17; i++)
                {
                    if (Player_card_ids[i] == alany - 30)
                    {
                        LehetLórumPiros = true;
                        lórumcard = alany - 30;
                    }
                }
            }
            if (zöldek == 1)
            {
                for (i = 20; i <= 27; i++)
                {
                    if (Player_card_ids[i] == alany - 20)
                    {
                        LehetLórumZöld = true;
                        lórumcard = alany - 20;
                    }
                }
            }
            if (makkok == 1)
            {
                for (i = 30; i <= 37; i++)
                {
                    if (Player_card_ids[i] == alany - 10)
                    {
                        LehetLórumMakk = true;
                        lórumcard = alany - 10;
                    }
                }
            }
        }

        public static int JátékKezdés(int pirosak, int zöldek, int makkok, int tökök, int jelöltPiros, int jelöltZöld,
                                      int jelöltMakk, int jelöltTök)
        {
            LehetLórumPiros = false;
            LehetLórumZöld = false;
            LehetLórumMakk = false;
            LehetLórumTök = false;
            laptávolság1 = 0;
            laptávolság2 = 0;
            laptávolság3 = 0;
            laptávolság4 = 0;
            lap1 = 0;
            lap2 = 0;
            lap3 = 0;
            lap4 = 0;
            lórumcard = 0;
            LórumJelölt = 0;
            int s;
            int t;
            if (pirosak == 1)
            {
                for (s = 10; s <= 17; s++)
                {
                    if (jelöltPiros == s)
                    {
                        for (t = 1; t <= 8; t++)
                        {
                            if (Player_card_ids[t] == s + 10)
                            {
                                LehetLórumPiros = true;
                                LórumJelölt = s;
                                lap2 = jelöltPiros + 10;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s + 20)
                            {
                                LehetLórumPiros = true;
                                LórumJelölt = s;
                                lap3 = jelöltPiros + 20;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s + 30)
                            {
                                LehetLórumPiros = true;
                                LórumJelölt = s;
                                lap4 = jelöltPiros + 30;
                                lórumcard = LórumJelölt;
                            }
                        }
                    }
                }
            }
            if (zöldek == 1)
            {
                for (s = 20; s <= 27; s++)
                {
                    if (jelöltZöld == s)
                    {
                        for (t = 1; t <= 8; t++)
                        {
                            if (Player_card_ids[t] == s - 10)
                            {
                                LehetLórumZöld = true;
                                LórumJelölt = s;
                                lap1 = s - 10;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s + 10)
                            {
                                LehetLórumZöld = true;
                                LórumJelölt = s;
                                lap3 = s + 10;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s + 20)
                            {
                                LehetLórumZöld = true;
                                LórumJelölt = s;
                                lap4 = s + 20;
                                lórumcard = LórumJelölt;
                            }
                        }
                    }
                }
            }
            if (makkok == 1)
            {
                for (s = 30; s <= 37; s++)
                {
                    if (jelöltMakk == s)
                    {
                        for (t = 1; t <= 8; t++)
                        {
                            if (Player_card_ids[t] == s - 20)
                            {
                                LehetLórumMakk = true;
                                LórumJelölt = s;
                                lap1 = s - 20;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s - 10)
                            {
                                LehetLórumMakk = true;
                                LórumJelölt = s;
                                lap2 = s - 10;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s + 10)
                            {
                                LehetLórumMakk = true;
                                LórumJelölt = s;
                                lap4 = s + 10;
                                lórumcard = LórumJelölt;
                            }
                        }
                    }
                }
            }
            if (tökök == 1)
            {
                for (s = 40; s <= 47; s++)
                {
                    if (jelöltTök == s)
                    {
                        for (t = 1; t <= 8; t++)
                        {
                            if (Player_card_ids[t] == s - 30)
                            {
                                LehetLórumTök = true;
                                LórumJelölt = s;
                                lap1 = s - 30;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s - 20)
                            {
                                LehetLórumTök = true;
                                LórumJelölt = s;
                                lap2 = s - 20;
                                lórumcard = LórumJelölt;
                            }
                            if (Player_card_ids[t] == s - 10)
                            {
                                LehetLórumTök = true;
                                LórumJelölt = s;
                                lap3 = s - 10;
                                lórumcard = LórumJelölt;
                            }
                        }
                    }
                }
            }
            counter[0] = 0;
            counter[1] = 0;
            counter[2] = 0;
            counter[3] = 0;
            counter[4] = 0;
            counter[5] = 0;
            counter[6] = 0;
            counter[7] = 0;
            temp = 0;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, lap1);
            counter[0] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, lap2);
            counter[1] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, lap3);
            counter[2] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, lap4);
            counter[3] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            numbers.Clear();
            if (counter[0] != 0) numbers.Add(counter[0]);
            if (counter[1] != 0) numbers.Add(counter[1]);
            if (counter[2] != 0) numbers.Add(counter[2]);
            if (counter[3] != 0) numbers.Add(counter[3]);
            if (numbers.Count != 0)
                temp = numbers.Min();
            /*  if (temp != 0)
            MainPage.value += temp;
            else
                MainPage.omit += 1; 
            MainPage.reader.WriteLine("p2: " + lap1 + " " + lap2 + " " + lap3 + " " + lap4 + " ! " + counter[0] + " " + counter[1] + " " + counter[2] + " " + counter[3] + " - " + pirosak + " " + zöldek + " " + makkok + " " + tökök + " {} " + lórumcard);
            for (s = 1; s <= 8; s++)
                MainPage.reader.WriteLine(Player_card_ids[s] + " "); */
            //Ha Lórum lehetséges melyik lap legyen az első
            if (numbers.Count != 0)
            {
                if (temp == counter[0] & zöldek == 1 | makkok == 1 | tökök == 1)
                {
                    if (temp < MainPage.AiTressHold & lap1 != 0)
                    {
                        if (MainPage.CheckDealer)
                        {
                            MainPage.HaveLorum = true;
                            lórumcard = 0;
                            return temp;
                        }
                        return lap1;
                    }
                }
                if (temp == counter[1] & pirosak == 1 | makkok == 1 | tökök == 1)
                {
                    if (temp < MainPage.AiTressHold & lap2 != 0)
                    {
                        if (MainPage.CheckDealer)
                        {
                            MainPage.HaveLorum = true;
                            lórumcard = 0;
                            return temp;
                        }
                        return lap2;
                    }
                }
                if (temp == counter[2] & zöldek == 1 | pirosak == 1 | tökök == 1)
                {
                    if (temp < MainPage.AiTressHold & lap3 != 0)
                    {
                        if (MainPage.CheckDealer)
                        {
                            MainPage.HaveLorum = true;
                            lórumcard = 0;
                            return temp;
                        }
                        return lap3;
                    }
                }
                if (temp == counter[3] & zöldek == 1 | makkok == 1 | pirosak == 1)
                {
                    if (temp < MainPage.AiTressHold & lap4 != 0)
                    {
                        if (MainPage.CheckDealer)
                        {
                            lórumcard = 0;
                            return temp;
                        }
                        return lap4;
                    }
                }
            }
            lórumcard = 0;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[1]);
            counter[0] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[2]);
            counter[1] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[3]);
            counter[2] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[4]);
            counter[3] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[5]);
            counter[4] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[6]);
            counter[5] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[7]);
            counter[6] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            HezagokSzamitasKezdes(pirosak, zöldek, makkok, tökök, Player_card_ids[8]);
            counter[7] = laptávolság1 + laptávolság2 + laptávolság3 + laptávolság4;
            numbers.Clear();
            if (counter[0] != 0) numbers.Add(counter[0]);
            if (counter[1] != 0) numbers.Add(counter[1]);
            if (counter[2] != 0) numbers.Add(counter[2]);
            if (counter[3] != 0) numbers.Add(counter[3]);
            if (counter[4] != 0) numbers.Add(counter[4]);
            if (counter[5] != 0) numbers.Add(counter[5]);
            if (counter[6] != 0) numbers.Add(counter[6]);
            if (counter[7] != 0) numbers.Add(counter[7]);
            temp = numbers.Min();
            if (MainPage.CheckDealer)
            {
                return temp + MainPage.AiMathValue2;
            }
            if (MainPage.CheckDealer == false)
            {
                Randomcard = false;
                while (Randomcard == false)
                {
                    int randomizer = _generator.Next(1, 9);
                    if (temp == counter[0] & randomizer == 1)
                    {
                        Randomcard = true;
                        return Player_card_ids[1];
                    }
                    if (temp == counter[1] & randomizer == 2)
                    {
                        Randomcard = true;
                        return Player_card_ids[2];
                    }
                    if (temp == counter[2] & randomizer == 3)
                    {
                        Randomcard = true;
                        return Player_card_ids[3];
                    }
                    if (temp == counter[3] & randomizer == 4)
                    {
                        Randomcard = true;
                        return Player_card_ids[4];
                    }
                    if (temp == counter[4] & randomizer == 5)
                    {
                        Randomcard = true;
                        return Player_card_ids[5];
                    }
                    if (temp == counter[5] & randomizer == 6)
                    {
                        Randomcard = true;
                        return Player_card_ids[6];
                    }
                    if (temp == counter[6] & randomizer == 7)
                    {
                        Randomcard = true;
                        return Player_card_ids[7];
                    }
                    if (temp == counter[7] & randomizer == 8)
                    {
                        Randomcard = true;
                        return Player_card_ids[8];
                    }
                }
            }
            return 0;
        }

        public static int JátékGép(int pirosak, int zöldek, int makkok, int tökök, int jelöltPiros, int jelöltZöld,
                                   int jelöltMakk, int jelöltTök)
        {
            counter[0] = 0;
            counter[1] = 0;
            counter[2] = 0;
            counter[3] = 0;
            Loselórum = false;
            Randomcard = false;
            if (jelöltPiros == lórumcard & jelöltZöld == 0 & jelöltMakk == 0 & jelöltTök == 0)
            {
                Loselórum = true;
            }
            if (jelöltZöld == lórumcard & jelöltPiros == 0 & jelöltMakk == 0 & jelöltTök == 0)
            {
                Loselórum = true;
            }
            if (jelöltMakk == lórumcard & jelöltZöld == 0 & jelöltPiros == 0 & jelöltTök == 0)
            {
                Loselórum = true;
            }
            if (jelöltTök == lórumcard & jelöltZöld == 0 & jelöltMakk == 0 & jelöltPiros == 0)
            {
                Loselórum = true;
            }
            //ha van más lehetőség ------------------
            if (jelöltPiros != 0)
            {
                Hézag(pirosak, zöldek, makkok, tökök, jelöltPiros);
                counter[0] = laptávolság1;
            }
            if (jelöltZöld != 0)
            {
                Hézag(pirosak, zöldek, makkok, tökök, jelöltZöld);
                counter[1] = laptávolság1;
            }
            if (jelöltMakk != 0)
            {
                Hézag(pirosak, zöldek, makkok, tökök, jelöltMakk);
                counter[2] = laptávolság1;
            }
            if (jelöltTök != 0)
            {
                Hézag(pirosak, zöldek, makkok, tökök, jelöltTök);
                counter[3] = laptávolság1;
            }
            var ints = new[] {counter[0], counter[1], counter[2], counter[3]};
            temp = ints.Max();
            if (Loselórum == false)
            {
                while (Randomcard == false)
                {
                    Randomizer = _generator.Next(1, 5);
                    if (temp == counter[0] & jelöltPiros != lórumcard & Randomizer == 1 & jelöltPiros != 0)
                    {
                        Randomcard = true;
                        return jelöltPiros;
                    }
                    if (temp == counter[1] & jelöltZöld != lórumcard & Randomizer == 2 & jelöltZöld != 0)
                    {
                        Randomcard = true;
                        return jelöltZöld;
                    }
                    if (temp == counter[2] & jelöltMakk != lórumcard & Randomizer == 3 & jelöltMakk != 0)
                    {
                        Randomcard = true;
                        return jelöltMakk;
                    }
                    if (temp == counter[3] & jelöltTök != lórumcard & Randomizer == 4 & jelöltTök != 0)
                    {
                        Randomcard = true;
                        return jelöltTök;
                    }
                }
            }
            if (Loselórum)
            {
                return lórumcard;
            }
            return 0;
        }

        public static void HezagokSzamitasKezdes(int pirosak, int zöldek, int makkok, int tökök, int alany)
        {
            laptávolság1 = 0;
            laptávolság2 = 0;
            laptávolság3 = 0;
            laptávolság4 = 0;
            if (alany == 0) return;
            //Lap távolságok vizsgálat
            //piros lapok
            if (MainPage.KezdőLap <= 10 && MainPage.KezdőLap >= 17)
            {
                matches = 0;
                steps = alany;
                if (pirosak > 1)
                {
                    while (matches != pirosak)
                    {
                        steps++;
                        if (steps == 18)
                        {
                            steps = 10;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1 ++;
                    }
                }
                matches = 0;
                steps = alany + 10;
                if (zöldek > 0)
                {
                    while (matches != zöldek)
                    {
                        steps++;
                        if (steps == 28)
                        {
                            steps = 20;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság2 ++;
                    }
                }
                matches = 0;
                steps = alany + 20;
                if (makkok > 0)
                {
                    while (matches != makkok)
                    {
                        steps++;
                        if (steps == 38)
                        {
                            steps = 30;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság3++;
                    }
                }
                matches = 0;
                steps = alany + 30;
                if (tökök > 0)
                {
                    while (matches != tökök)
                    {
                        steps++;
                        if (steps == 48)
                        {
                            steps = 40;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság4++;
                    }
                }
                return;
            }
            //zöld lapok
            if (MainPage.KezdőLap <= 20 && MainPage.KezdőLap >= 27)
            {
                matches = 0;
                steps = alany - 10;
                if (pirosak > 0)
                {
                    while (matches != pirosak)
                    {
                        steps++;
                        if (steps == 28)
                        {
                            steps = 10;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1 ++;
                    }
                }
                matches = 0;
                steps = alany;
                if (zöldek > 1)
                {
                    while (matches != zöldek)
                    {
                        steps++;
                        if (steps == 28)
                        {
                            steps = 20;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság2++;
                    }
                }
                matches = 0;
                steps = alany + 10;
                if (makkok > 0)
                {
                    while (matches != makkok)
                    {
                        steps++;
                        if (steps == 38)
                        {
                            steps = 30;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság3++;
                    }
                }
                matches = 0;
                steps = alany + 20;
                if (tökök > 0)
                {
                    while (matches != tökök)
                    {
                        steps++;
                        if (steps == 48)
                        {
                            steps = 40;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság4++;
                    }
                }
                return;
            }
            //mak lapok
            if (MainPage.KezdőLap <= 30 && MainPage.KezdőLap >= 37)
            {
                matches = 0;
                steps = alany - 20;
                if (pirosak > 0)
                {
                    while (matches != pirosak)
                    {
                        steps++;
                        if (steps == 18)
                        {
                            steps = 10;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1 ++;
                    }
                }
                matches = 0;
                steps = alany - 10;
                if (zöldek > 0)
                {
                    while (matches != zöldek)
                    {
                        steps++;
                        if (steps == 28)
                        {
                            steps = 20;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság2 ++;
                    }
                }
                matches = 0;
                steps = alany;
                if (makkok > 1)
                {
                    while (matches != makkok)
                    {
                        steps++;
                        if (steps == 38)
                        {
                            steps = 30;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság3++;
                    }
                }
                matches = 0;
                steps = alany + 10;
                if (tökök > 0)
                {
                    while (matches != tökök)
                    {
                        steps++;
                        if (steps == 48)
                        {
                            steps = 40;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság4++;
                    }
                }
                return;
            }
            //tök lapok
            if (MainPage.KezdőLap <= 40 && MainPage.KezdőLap >= 47)
            {
                matches = 0;
                steps = alany - 30;
                if (pirosak > 0)
                {
                    while (matches != pirosak)
                    {
                        steps++;
                        if (steps == 9)
                        {
                            steps = 1;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1 ++;
                    }
                }
                matches = 0;
                steps = alany - 20;
                if (zöldek > 0)
                {
                    while (matches != zöldek)
                    {
                        steps++;
                        if (steps == 17)
                        {
                            steps = 9;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság2 ++;
                    }
                }
                matches = 0;
                steps = alany - 10;
                if (makkok > 0)
                {
                    while (matches != makkok)
                    {
                        steps++;
                        if (steps == 25)
                        {
                            steps = 17;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság3++;
                    }
                }
                matches = 0;
                steps = alany;
                if (tökök > 1)
                {
                    while (matches != tökök)
                    {
                        steps++;
                        if (steps == 33)
                        {
                            steps = 25;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság4++;
                    }
                }
            }
        }

        private static void Hézag(int pirosak, int zöldek, int makkok, int tökök, int alany)
        {
            laptávolság1 = 0;
            if (alany == 0) return;
            if (alany == 1 | alany == 2 | alany == 3 | alany == 4 | alany == 5 | alany == 6 | alany == 7 | alany == 8)
            {
                if (pirosak == 1)
                {
                    laptávolság1 = 0;
                    return;
                }
                matches = 0;
                steps = MainPage.Piros;
                if (pirosak > 1)
                {
                    while (matches != pirosak)
                    {
                        steps++;
                        if (steps == 9)
                        {
                            steps = 1;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1++;
                    }
                }
                return;
            }
            if (alany == 9 | alany == 10 | alany == 11 | alany == 12 | alany == 13 | alany == 14 | alany == 15 |
                alany == 16)
            {
                if (zöldek == 1)
                {
                    laptávolság1 = 0;
                    return;
                }
                matches = 0;
                steps = MainPage.zöld;
                if (zöldek > 1)
                {
                    while (matches != zöldek)
                    {
                        steps++;
                        if (steps == 17)
                        {
                            steps = 9;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1++;
                    }
                }
                return;
            }
            if (alany == 17 | alany == 18 | alany == 19 | alany == 20 | alany == 21 | alany == 22 | alany == 23 |
                alany == 24)
            {
                if (makkok == 1)
                {
                    laptávolság1 = 0;
                    return;
                }
                matches = 0;
                steps = MainPage.makk;
                if (makkok > 1)
                {
                    while (matches != makkok)
                    {
                        steps++;
                        if (steps == 25)
                        {
                            steps = 17;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1++;
                    }
                }
                return;
            }
            if (alany == 25 | alany == 26 | alany == 27 | alany == 28 | alany == 29 | alany == 30 | alany == 31 |
                alany == 32)
            {
                if (tökök == 1)
                {
                    laptávolság1 = 0;
                    return;
                }
                matches = 0;
                steps = MainPage.tök;
                if (tökök > 1)
                {
                    while (matches != tökök)
                    {
                        steps++;
                        if (steps == 33)
                        {
                            steps = 25;
                        }
                        if (Player_card_ids[1] == steps | Player_card_ids[2] == steps |
                            Player_card_ids[3] == steps | Player_card_ids[4] == steps |
                            Player_card_ids[5] == steps | Player_card_ids[6] == steps |
                            Player_card_ids[7] == steps | Player_card_ids[8] == steps)
                        {
                            matches++;
                        }
                        laptávolság1++;
                    }
                }
            }
        }
    }
}