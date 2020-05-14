using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wypożyczalnia_samochodów
{
    [XmlInclude(typeof(Samochod)), XmlInclude(typeof(Osoba))]
    [Serializable]
    public class Termin
    {
        private DateTime _DataWypozyczenia;
        private DateTime _DataOddania;
        private double _DniWypozyczenia;
        private string _Pesel;
        private string _KlientImie;
        private string _KlientNazwisko;
        private string _Marka;
        private string _Model;
        private string _TablicaRejestracyjna;
        private float _Cena;
        private float _Kaucja;

        public DateTime DataWypozyczenia
        {
            get
            {
                return _DataWypozyczenia;
            }
            set
            {
                _DataWypozyczenia = value;
            }
        }
        public DateTime DataOddania
        {
            get
            {
                return _DataOddania;
            }
            set
            {
                _DataOddania = value;
            }
        }
        public double DniWypozyczenia
        {
            get
            {
                return _DniWypozyczenia;
            }
            set
            {
                _DniWypozyczenia = value;
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
                if (value.Length == 0)
                    Console.WriteLine("Pole nie może być puste!");

                _Pesel = value;
            }
        }
        public string KlientImie
        {
            get
            {
                return _KlientImie;
            }
            set
            {
                _KlientImie = value;
            }
        }
        public string KlientNazwisko
        {
            get
            {
                return _KlientNazwisko;
            }
            set
            {
                _KlientNazwisko = value;
            }
        }
        public string Marka
        {
            get
            {
                return _Marka;
            }
            set
            {
                _Marka = value;
            }
        }
        public string Model
        {
            get
            {
                return _Model;
            }
            set
            {
                _Model = value;
            }
        }
        public string TablicaRejestracyjna
        {
            get
            {
                return _TablicaRejestracyjna;
            }
            set
            {
                _TablicaRejestracyjna = value;
            }
        }
        public float Cena
        {
            get
            {
                return _Cena;
            }
            set
            {
                _Cena = value;
            }
        }
        public float Kaucja
        {
            get
            {
                return _Kaucja;
            }
            set
            {
                _Kaucja = value;
            }
        }
        public Termin()
        {
            _DataWypozyczenia = DateTime.UtcNow.ToLocalTime();
            _DataOddania = DateTime.UtcNow.ToLocalTime();
            _Pesel = string.Empty;
            _KlientImie = string.Empty;
            _KlientNazwisko = string.Empty;
            _Model = string.Empty;

    }
        public void Dane()
        {
            {
                int Dzien, Miesiac, Rok;

                Console.WriteLine("\nPODAJ DANE WYNAJMU SAMOCHODU: ");
                Console.WriteLine("WYPOZYCZENIE");
                Console.Write("Dzien: "); Dzien = int.Parse(Console.ReadLine());
                Console.Write("Miesiac: "); Miesiac = int.Parse(Console.ReadLine());
                Console.Write("Rok: "); Rok = int.Parse(Console.ReadLine());

                    _DataWypozyczenia = new DateTime(1, 1, 1);
                    _DataWypozyczenia = _DataWypozyczenia.AddDays(Dzien - 1);
                    _DataWypozyczenia = _DataWypozyczenia.AddMonths(Miesiac - 1);
                    _DataWypozyczenia = _DataWypozyczenia.AddYears(Rok - 1);

                Console.WriteLine("\nODDANIE");
                Console.Write("Dzien: "); Dzien = int.Parse(Console.ReadLine());
                Console.Write("Miesiac: "); Miesiac = int.Parse(Console.ReadLine());
                Console.Write("Rok: "); Rok = int.Parse(Console.ReadLine());

                    _DataOddania = new DateTime(1, 1, 1);
                    _DataOddania = _DataOddania.AddDays(Dzien - 1);
                    _DataOddania = _DataOddania.AddMonths(Miesiac - 1);
                    _DataOddania = _DataOddania.AddYears(Rok - 1);

            }
        }
        public void DodajTermin(string _pesel, string _klientImie, string _klientNazwisko, string _marka, string _model, string tablica, float _cena, float _kaucja)
        {
            _DataWypozyczenia.ToString();
            _DataWypozyczenia.ToString();
            DniWypozyczenia = ((DataOddania-DataWypozyczenia).TotalDays)+1;
            _KlientImie = _klientImie;
            _KlientNazwisko = _klientNazwisko;
            _Pesel = _pesel;
            _Marka = _marka;
            _Model = _model;
            _TablicaRejestracyjna = tablica;
            _Cena = _cena;
            _Kaucja = _kaucja;

        }

        public void TerminWynajmu()
        {
            Console.WriteLine($"Klient: {KlientImie} {KlientNazwisko} PESEL: {Pesel} \nPojazd: {Marka} {Model} {TablicaRejestracyjna}");
            Console.WriteLine($"Od: {DataWypozyczenia.ToString("dd/MM/yyyy")} do: {DataOddania.ToString("dd/MM/yyyy")} \nIlość dni: {DniWypozyczenia}");
            Console.WriteLine($"Koszt dobowy: {Cena}\t|\tKwota do zapłaty: {DniWypozyczenia * Cena + Kaucja} (w tym kaucja równa: {Kaucja} )");
        }
    }
}
