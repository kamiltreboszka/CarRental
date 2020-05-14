using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_samochodów
{
    [Serializable]
    public class Klient : Osoba
    {
        public Klient() : base()
        { 
        }

        public Klient(string Imie, string Nazwisko, string Pesel) : base(Imie, Nazwisko, Pesel)
        {
        }

        public override void WprowadzDane()
        {
            while (true)
            {
                Console.WriteLine("Podaj dane klienta: ");
                try
                {
                    Console.Write("Imie: ");
                    Imie = Console.ReadLine().ToUpper();

                    Console.Write("Nazwisko: ");
                    Nazwisko = Console.ReadLine().ToUpper();

                    Console.Write("Pesel: ");
                    Pesel = Console.ReadLine();
                    break;
                }
                catch
                {
                    Console.WriteLine("Wprowadziłeś błedne dane klienta!");
                }
            }
        }

        public override void WyswietlDane()
        {
            Console.WriteLine(Imie + " " + Nazwisko);
            Console.WriteLine("PESEL: " + Pesel);
            ObliczeniePesel();
        }

        public override void ObliczeniePesel()
        {
            DateTime RokUrodzenia = new DateTime(1900,1,1);
            int rok1 = Convert.ToInt32(Pesel.Substring(0,1));
            int rok2 = Convert.ToInt32(Pesel.Substring(1,1));
            int msc1 = Convert.ToInt32(Pesel.Substring(2,1));
            int msc2 = Convert.ToInt32(Pesel.Substring(3,1));
            int dzien1 = Convert.ToInt32(Pesel.Substring(4,1));
            int dzien2 = Convert.ToInt32(Pesel.Substring(5,1));
            int plec = Convert.ToInt32(Pesel.Substring(9,1));

            int Dzien = 0, Miesiac = 0, Rok = 0;
            Dzien = dzien1 * 10 + dzien2 - 1;
            Miesiac = msc1 * 10 + msc2 - 1;
            Rok = rok1 * 10 + rok2;

            RokUrodzenia = RokUrodzenia.AddDays(Dzien);
            RokUrodzenia = RokUrodzenia.AddMonths(Miesiac);
            RokUrodzenia = RokUrodzenia.AddYears(Rok);

            DateTime ObecnyCzas = DateTime.UtcNow.ToLocalTime();
            int Wiek = (ObecnyCzas.Year - RokUrodzenia.Year);
            string _plec;
            if (plec % 2 == 0)
            {
                 _plec= "Kobieta";
            }
            else
            {
                _plec = "Mężczyzna";
            }

            Console.WriteLine("Data urodzenia: " + RokUrodzenia.ToString("dd-MM-yyyy"));
            Console.WriteLine("Lat: " + Wiek.ToString());
            Console.WriteLine("Plec: " + _plec);

        }
    }
}
