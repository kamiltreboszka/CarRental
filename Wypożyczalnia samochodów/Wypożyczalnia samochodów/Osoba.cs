using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wypożyczalnia_samochodów
{
    [XmlInclude(typeof(Klient)), XmlInclude(typeof(Pracownik))] 

    public class Osoba
    {
        public enum Plec
        {
            Mężczyzna,
            Kobieta,
            Nieznana
        }

        private string _Imie;
        private string _Nazwisko;
        private string _Pesel;

        public string Imie
        {
            get
            {
                return _Imie;
            }
            set
            {
                if (value.Length == 0)
                    Console.WriteLine("Pole nie może być puste!");

                _Imie = value;
            }
        }
        public string Nazwisko
        {
            get
            {
                return _Nazwisko;
            }
            set
            {
                if (value.Length == 0)
                    Console.WriteLine("Pole nie może być puste!");

                _Nazwisko = value;
            }
        }
        public Plec _Plec
        {
            get 
            {
                return _Plec;
            }
        }
        public string Pesel
        {
            get
            {
                return _Pesel;
            }
            set
            {
                int dlugosc = value.Length;
                if (dlugosc < 11)
                    Console.WriteLine("Twoj pesel jest za króki!");
                else if (dlugosc > 11)
                    Console.WriteLine("Twoj pesel jest za dlugi");

                _Pesel = value;
            }
        }

        public Osoba()
        {
            _Imie = string.Empty;
            _Nazwisko = string.Empty;
            _Pesel = string.Empty;
        }
        public Osoba(string I, string N, string P) : this()
        {
            Imie = I;
            Nazwisko = N;
            Pesel = P;
        }
        public virtual void WprowadzDane()
        {
            throw new Exception("Wprowadziłes błedne dane!");
        }
        public virtual void WyswietlDane()
        {
            throw new Exception("Błedne dane!");
        }

        public virtual void ObliczeniePesel()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Błedne obliczenie danych!");
            Console.ResetColor();
        }
    }
}
