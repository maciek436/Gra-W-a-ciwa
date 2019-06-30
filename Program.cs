using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Maciej Bafia 11512
namespace ConsoleAppZgadywanka
{

    
    class Program
    {

        static int Losuj( int min = 1, int max = 100 )
        {
            if( min > max )
            {
                min = 1;
                max = 100;
            }
            Console.WriteLine($"Losuję liczbę od {min} do {max} \n odgadnij ją");
            return (new Random()).Next(min, max+1); 
        }

        static int WczytajLiczbe( string prompt )
        {
            bool poprawnie = false;
            int liczba = 0;

            while (!poprawnie)
            {
                string napis = "";
                Console.Write(prompt);
                try
                {
                    napis = Console.ReadLine();
                    if (napis.ToUpper() == "X")
                    {
                        Console.WriteLine("Aplikacja przerwana na życzenie uzytkownika!");
                        Environment.Exit(1);
                    }

                    liczba = Convert.ToInt32(napis);
                    poprawnie = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("podałeś zbyt dużą liczbę - spróbuj jeszcze raz");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("nie podałeś poprawnej liczby - spróbuj jeszcze raz");
                    continue;
                }
            }

            return liczba;
        }

        static void Main()
        {
            
            Console.WriteLine("Podaj zakres losowania liczby do odgadnięcia");
            
            int min = WczytajLiczbe("Podaj wartość od: ");
            int max = WczytajLiczbe("Podaj wartość do: ");

            int wylosowana = Losuj(min, max);
#if DEBUG
            Console.WriteLine("Tajne " + wylosowana);
#endif            

            Stopwatch stoper = Stopwatch.StartNew();
            int licznik = 0;
            bool trafiono = false;
            
            while (!trafiono)
            {
                
                int propozycja = WczytajLiczbe("Podaj swoją propozycję: ");

                
                if (propozycja < wylosowana)
                {
                    Console.WriteLine("ZA MAŁO");
                }
                else if (propozycja > wylosowana)
                {
                    Console.WriteLine("ZA DUŻO");
                }
                else
                {
                    Console.WriteLine("TRAFIONO");
                    trafiono = true;
                }

                licznik++;
            }
            stoper.Stop();


            
            Console.WriteLine("Koniec gry");
            Console.WriteLine($"wykonano {licznik} ruchów");
            Console.WriteLine($"Czas gry = {stoper.Elapsed}");
        }
    }
}
