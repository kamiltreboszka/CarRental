using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_samochodów
{
    [Serializable]
    public class Samochod
    {
        private string _Marka;
        private string _Model;
        private string _Kolor;
        private string _TabRej;
        private string _Paliwo;
        private int _Rocznik;
        private float _Cena;
        private float _Kaucja;

        public string Marka
        {
            get 
            {
                return _Marka;
            }
            set
            {
                if (value.Length == 0)
                    Console.WriteLine("Pole nie może być puste!");

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
                if (value.Length == 0)
                    Console.WriteLine("Pole nie może być puste!");

                _Model = value;
            }
        }
        public string Kolor
        {
            get
            {
                return _Kolor;
            }
            set
            {
                if (value.Length == 0)
                    Console.WriteLine("Pole nie może być puste!");

                _Kolor = value;
            }
        }

        public string TablicaRejestracyjna
        {
            get
            {
                return _TabRej;
            }
            set
            {
                if (value.Length != 7)
                    Console.WriteLine("Liczba znaków tablicy rejestracyjnej jest błędna");

                _TabRej = value;
            }
        }
        public string Paliwo
        {
            get
            {
                return _Paliwo;
            }
            set
            {
                _Paliwo = value;
            }
        }
        public int Rocznik
        {
            get 
            {
                return _Rocznik;
            }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Rocznik nie może istnieć!");

                _Rocznik = value;
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
                if (value < 0)
                    Console.WriteLine("Ta cena jest za niska!");

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
                if (value <= 0)
                    Console.WriteLine("Ta kaucja jest za niska!");

                _Kaucja = value;
            }
        }

        public Samochod()
        {
            _Marka = string.Empty;
            _Model = string.Empty;
            _Kolor = string.Empty;
            _TabRej = string.Empty;
            _Paliwo = string.Empty;
            _Rocznik = 0;
            _Cena = 0;
            _Kaucja = 0;
        }

        public void WprowadzDaneAuta()
        {
                Console.WriteLine("Podaj następujące dane samochodu");
                try 
                {
                    Console.Write("Marka: ");
                    Marka = Console.ReadLine().ToUpper();

                    Console.Write("Model: ");
                    Model = Console.ReadLine().ToUpper();

                    Console.Write("Paliwo: ");
                    Paliwo = Console.ReadLine().ToUpper();

                    Console.Write("Tablica rejestracyjna pojazdu: ");
                    TablicaRejestracyjna = Console.ReadLine().ToUpper();

                    Console.Write("Kolor: ");
                    Kolor = Console.ReadLine().ToUpper();

                    Console.Write("Rocznik: ");
                    Rocznik = int.Parse(Console.ReadLine());

                    Console.Write("Cena: ");
                    Cena = float.Parse(Console.ReadLine());

                    Console.Write("Kaucja: ");
                    Kaucja = float.Parse(Console.ReadLine());
            }
                catch 
                {
                    Console.WriteLine("Wprowadziłeś niepoprawne dane!");
                }
            
        }

        public void WyswietlDane()
        {
            Console.WriteLine($"{Marka} {Model} \nKolor: {Kolor} \nRocznik: {Rocznik}");
            Console.WriteLine("Paliwo: " + Paliwo);
            Console.WriteLine("Tablica rejestracyjna: " + TablicaRejestracyjna);
            Console.WriteLine("Cena wypozyczenia: " + Cena);
            Console.WriteLine("Kaucja: " + Kaucja);
            
        }
    }
}
