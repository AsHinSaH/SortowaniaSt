
using System.Diagnostics;



namespace proje2 
{
    internal class Program
    {
        static void QuickSort(int[] tab)
        {
            int a = 0;
            int b = 0;
            int dod = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                a = tab[i];

                for (int j = 0; j < tab.Length; j++)
                {
                    b = tab[j];

                    if (b > a)
                    {
                        dod = a;
                        a = b;
                        b = dod;
                    }
                    tab[j] = b;
                }
                tab[i] = a;
            }
            //for (int i = 0; i < tab.Length; i++)
            //{
            //    Console.Write(tab[i] + " ");
            //}
        }

        static void Wstaw(int[] tab)
        {
            int p = 0;
            int t = 0;

            for (int i = 0; i < tab.Length; i++)
            {
                p = tab[i];
                t = i - 1;
                while (t >= 0 && tab[t] > p)
                {
                    tab[t + 1] = tab[t];
                    t = t - 1;
                }
                tab[t + 1] = p;

            }
            //for (int i = 0; i < tab.Length; i++)
            //{
            //    Console.Write(tab[i] + " ");
            //}
        }

        static void Bombelek(int[] tab)
        {
            int d = 0;
            for (int j = tab.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        d = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = d;
                    }
                }
            }
            //for (int i = 0; i < tab.Length; i++)
            //{
            //    Console.Write(tab[i] + " ");
            //}
        }

        static int[] wygenerujTabliceRandomowo(int ile)
        {
            int[] tablica = new int[ile];

            Random random = new Random();
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = random.Next(1, ile);
            }
            return tablica;
        }

        static int[] wygenerujTabliceStala(int ile)
        {
            int[] tablica = new int[ile];
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = 6;
            }
            return tablica;
        }

        static int[] wygenerujTabliceMalejaca(int ile)
        {
            int[] tablica = new int[ile];
            int pom = tablica.Length;
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = pom;
                pom -= 1;
            }
            return tablica;
        }

        static int[] wygenerujTabliceRosnaca(int ile)
        {
            int[] tablica = new int[ile];
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = i;
            }
            return tablica;
        }

        static int[] wygenerujTabliceV(int ile)
        {
            int[] tablica = new int[ile];

            for (int i = 0; i < (tablica.Length / 2); i++)
            {
                tablica[i] = i;
            }
            for (int i = tablica.Length; i < (tablica.Length / 2); i--)
            {
                tablica[i] = i;
            }


            return tablica;
        }


        enum TypTablicy
        {
            RANDOMOWA,
            ROSNOCA,
            STALA,
            MALEJACA,
            VKSZTALTNA
        }

        static void SorotwanieBabelkowe(TypTablicy typ)
        {
            for (int rozmiarTablicy = 10_000; rozmiarTablicy <= 100_000; rozmiarTablicy += 10_000)
            {

                double min = double.MaxValue, max = 0, suma = 0;

                for (int g = 0; g < 12; g++)
                {

                    int[] tab = typ switch
                    {
                        TypTablicy.RANDOMOWA => wygenerujTabliceRandomowo(rozmiarTablicy),
                        TypTablicy.VKSZTALTNA => wygenerujTabliceV(rozmiarTablicy),
                        TypTablicy.ROSNOCA => wygenerujTabliceRosnaca(rozmiarTablicy),
                        TypTablicy.MALEJACA => wygenerujTabliceMalejaca(rozmiarTablicy),
                        TypTablicy.STALA => wygenerujTabliceStala(rozmiarTablicy),
                        _ => throw new NotImplementedException()
                    };

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Bombelek(tab);
                    sw.Stop();
                    double elapsed = sw.Elapsed.TotalMilliseconds;

                    suma += elapsed;
                    if (min > elapsed)
                        min = elapsed;
                    if (max < elapsed)
                        max = elapsed;
                }
                Console.WriteLine($"Bublesort rozmiar:{rozmiarTablicy}. czas:{(double)(((suma) - min - max) / 10)}. ");
            }
        }

        static void SortowaniaPrzezWstawianie(TypTablicy typ)
        {
            for (int rozmiarTablicy = 10_000; rozmiarTablicy <= 100_000; rozmiarTablicy += 10_000)
            {

                double min = double.MaxValue, max = 0, suma = 0;

                for (int g = 0; g < 12; g++)
                {

                    int[] tab = typ switch
                    {
                        TypTablicy.RANDOMOWA => wygenerujTabliceStala(rozmiarTablicy),
                        TypTablicy.VKSZTALTNA => wygenerujTabliceV(rozmiarTablicy),
                        TypTablicy.ROSNOCA => wygenerujTabliceRosnaca(rozmiarTablicy),
                        TypTablicy.MALEJACA => wygenerujTabliceMalejaca(rozmiarTablicy),
                        TypTablicy.STALA => wygenerujTabliceStala(rozmiarTablicy),
                        _ => throw new NotImplementedException()
                    };

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Wstaw(tab);
                    sw.Stop();
                    double elapsed = sw.Elapsed.TotalMilliseconds;

                    suma += elapsed;
                    if (min > elapsed)
                        min = elapsed;
                    if (max < elapsed)
                        max = elapsed;
                }
                Console.WriteLine($"Wstawianie rozmiar:{rozmiarTablicy}. czas:{(double)(((suma) - min - max) / 10)}. ");
            }
        }

        static void SortowanieQuicSort(TypTablicy typ)
        {
            for (int rozmiarTablicy = 10_000; rozmiarTablicy <= 100_000; rozmiarTablicy += 10_000)
            {

                double min = double.MaxValue, max = 0, suma = 0;

                for (int g = 0; g < 12; g++)
                {

                    int[] tab = typ switch
                    {
                        TypTablicy.RANDOMOWA => wygenerujTabliceStala(rozmiarTablicy),
                        TypTablicy.VKSZTALTNA => wygenerujTabliceV(rozmiarTablicy),
                        TypTablicy.ROSNOCA => wygenerujTabliceRosnaca(rozmiarTablicy),
                        TypTablicy.MALEJACA => wygenerujTabliceMalejaca(rozmiarTablicy),
                        TypTablicy.STALA => wygenerujTabliceStala(rozmiarTablicy),
                        _ => throw new NotImplementedException()
                    };

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    QuickSort(tab);
                    sw.Stop();
                    double elapsed = sw.Elapsed.TotalMilliseconds;

                    suma += elapsed;
                    if (min > elapsed)
                        min = elapsed;
                    if (max < elapsed)
                        max = elapsed;
                }
                Console.WriteLine($"Wstawianie rozmiar:{rozmiarTablicy}. czas:{(double)(((suma) - min - max) / 10)}. ");
            }
        }



        static void Main(string[] args)
        {
            TypTablicy typ = new TypTablicy();

            Console.WriteLine("rosnąca");
            typ = TypTablicy.ROSNOCA;
            SortowaniaPrzezWstawianie(typ);

            Console.WriteLine("Malejąca");
            typ = TypTablicy.MALEJACA;
            SortowaniaPrzezWstawianie(typ);


            Console.WriteLine("Vksztautna");
            typ = TypTablicy.VKSZTALTNA;
            SortowaniaPrzezWstawianie(typ);


            Console.WriteLine("Randomowa");
            typ = TypTablicy.RANDOMOWA;
            SortowaniaPrzezWstawianie(typ);


            Console.WriteLine("Stala");
            typ = TypTablicy.STALA;
            SortowaniaPrzezWstawianie(typ);

            //==================================================

            Console.WriteLine("rosnąca");
            typ = TypTablicy.ROSNOCA;
            SortowanieQuicSort(typ);

            Console.WriteLine("Malejąca");
            typ = TypTablicy.MALEJACA;
            SortowanieQuicSort(typ);


            Console.WriteLine("Vksztautna");
            typ = TypTablicy.VKSZTALTNA;
            SortowanieQuicSort(typ);


            Console.WriteLine("Randomowa");
            typ = TypTablicy.RANDOMOWA;
            SortowanieQuicSort(typ);


            Console.WriteLine("Stala");
            typ = TypTablicy.STALA;
            SortowanieQuicSort(typ);

            //==================================================

            Console.WriteLine("rosnąca");
            typ = TypTablicy.ROSNOCA;
            SorotwanieBabelkowe(typ);

            Console.WriteLine("Malejąca");
            typ = TypTablicy.MALEJACA;
            SorotwanieBabelkowe(typ);


            Console.WriteLine("Vksztautna");
            typ = TypTablicy.VKSZTALTNA;
            SorotwanieBabelkowe(typ);


            Console.WriteLine("Randomowa");
            typ = TypTablicy.RANDOMOWA;
            SorotwanieBabelkowe(typ);


            Console.WriteLine("Stala");
            typ = TypTablicy.STALA;
            SorotwanieBabelkowe(typ);


        }
    }

    
}




















