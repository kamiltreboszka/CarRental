using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Wypożyczalnia_samochodów
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Osoba> ListaPracownikow = new List<Osoba>();
            List<Osoba> ListaKlientow = new List<Osoba>();
            List<Samochod> ListaSamochodow = new List<Samochod>();
            List<Termin> ListaTerminow = new List<Termin>();

            Program program = new Program();
            
            StreamReader stream5 = new StreamReader("Pracownik.xml");
            XmlSerializer serializer5 = new XmlSerializer(typeof(List<Osoba>));
            ListaPracownikow = (List<Osoba>)serializer5.Deserialize(stream5);
            stream5.Close();
            
            int w = 0;
            //logowanie
            while (w<3)
            {
                Console.WriteLine("\n\tLOGOWANIE PRACOWNIKA \t|\tPROBA NR."+(w+1)+"\n");
                Console.Write("IMIE: "); string Imie = Console.ReadLine();
                Console.Write("NAZWISKO: "); string Nazwisko = Console.ReadLine();
                Console.Write("PESEL: "); string Pesel = Console.ReadLine();
                w++;

                for (int s = 0; s < ListaPracownikow.Count; s++)
                {
                    if (Imie.ToUpper() == ListaPracownikow[s].Imie && Nazwisko.ToUpper() == ListaPracownikow[s].Nazwisko && Pesel == ListaPracownikow[s].Pesel)
                    {
                        Console.WriteLine($"LOGOWANIE UDANE! WITAJ {ListaPracownikow[s].Imie} {ListaPracownikow[s].Nazwisko}");
                        Thread.Sleep(2000);
                        w = 4;
                    }
                }
                    if(w==3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("NIE JESTES PRACOWNIKIEM... PROGRAM ZA CHWILKĘ SIĘ ZAMKNIE!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
            }
            Console.Clear();
            
            while (true)
            {
                int opcja = 10;
                program.Menu();

                try
                {
                    Console.Write("Co chcesz zrobic: ");
                    opcja = int.Parse(Console.ReadLine());
                }
                catch
                {
                    if (opcja > 9)
                        Console.WriteLine("Nie ma takiej opcji!");
                    else
                        Console.WriteLine("Wprowadz liczbę!");
                }

                Osoba klient = null;
                Osoba pracownik = null;
                Samochod samochod = null;
                Termin termin = null;

                switch (opcja)
                {
                    case 1:
                        {
                            pracownik = new Pracownik();
                            pracownik.WprowadzDane();
                            if (program.Sprawdz(pracownik.Imie, pracownik.Nazwisko, pracownik.Pesel))
                                ListaPracownikow.Add(pracownik);
                            else
                                Console.WriteLine("Coś poszło nie tak! Pracownik nie został dodany!");

                            break;
                        }
                    case 2:
                        {
                            klient = new Klient();
                            klient.WprowadzDane();
                            if (program.Sprawdz(klient.Imie, klient.Nazwisko, klient.Pesel))
                                ListaKlientow.Add(klient);
                            else
                                Console.WriteLine("Coś poszło nie tak! Klient nie został dodany!");

                            break;
                        }
                    case 3:
                        {
                            samochod = new Samochod();
                            samochod.WprowadzDaneAuta();
                            if (program.Sprawdz(samochod.Marka, samochod.Model, samochod.Kolor))
                                ListaSamochodow.Add(samochod);
                            else
                                Console.WriteLine("Coś poszło nie tak! Samochód nie został dodany!");

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Kogo liste chcesz wyświetlić?\n1.Pracowników\n2.Klientów\n3.Samochodow\n4.COFNIJ");
                            int wybor = 0, id = 1;
                            Console.Write("WYBÓR: ");
                            wybor = int.Parse(Console.ReadLine());
                            if(wybor == 1)
                            {
                                Console.WriteLine("PRACOWNICY: ");
                                Console.WriteLine("--------------------------------");
                                foreach(Osoba _osoba in ListaPracownikow)
                                {
                                    if(_osoba != null)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("ID: "+id);
                                        _osoba.WyswietlDane();
                                        Console.ResetColor();
                                        Console.WriteLine("--------------------------------");
                                        id++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("LISTA JEST PUSTA!");
                                    }
                                }
                            }
                            else if(wybor == 2)
                            {
                                Console.WriteLine("KLIENCI: ");
                                Console.WriteLine("--------------------------------");
                                foreach (Osoba _osoba in ListaKlientow)
                                {
                                    if (_osoba != null)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("ID: " + id);
                                        _osoba.WyswietlDane();
                                        Console.ResetColor();
                                        Console.WriteLine("--------------------------------");
                                        id++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("LISTA JEST PUSTA!");
                                    }
                                }
                            }
                            else if(wybor == 3)
                            {
                                Console.WriteLine("SAMOCHODY: ");
                                Console.WriteLine("--------------------------------");
                                foreach (Samochod _pojazd in ListaSamochodow)
                                {
                                    if (_pojazd != null)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("ID: " + id);
                                        _pojazd.WyswietlDane();
                                        Console.ResetColor();
                                        Console.WriteLine("--------------------------------");
                                        id++;
                                    }
                                    else //(ListaSamochodow.Count == 0)
                                    {
                                        Console.WriteLine("LISTA JEST PUSTA!");
                                    }
                                }
                            }
                            else if(wybor==4)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Coś poszło nie tak! Spróbuj jeszcze raz!");
                            }
                            break;
                        }
                    case 5:
                        {
                            DateTime data_wypozyczenia = DateTime.UtcNow.ToLocalTime();
                            //DateTime data_oddania = DateTime.UtcNow;
                            int nr_klient = 0, nr_samochod = 0;

                            termin = new Termin();

                            Console.WriteLine("\tUmawiasz wynajem samochodu\n");
                            Console.WriteLine("LISTA KLIENTOW");
                            for (int i = 0; i < ListaKlientow.Count; i++)
                            {
                                Console.WriteLine("ID: " + (i + 1) + $" | Klient: {ListaKlientow[i].Imie} {ListaKlientow[i].Nazwisko} {ListaKlientow[i].Pesel}");
                                Console.WriteLine("----------------------------------------------------------------------------------");
                            }

                            Console.Write("Podaj numer klienta: ");
                            nr_klient = int.Parse(Console.ReadLine());
                            nr_klient = (nr_klient - 1);

                            Console.WriteLine($"Dodajesz wynaje samochodu U: {ListaKlientow[nr_klient].Imie} {ListaKlientow[nr_klient].Nazwisko} {ListaKlientow[nr_klient].Pesel}");

                            klient = ListaKlientow[nr_klient];

                            Console.WriteLine("\n\tDzisiaj jest: " + data_wypozyczenia.ToString("dd-MM-yyyy"));
                            termin.Dane();

                            Console.WriteLine("\nLISTA SAMOCHODÓW: ");
                            Console.WriteLine("------------------------------------");
                            for (int i = 0; i < ListaSamochodow.Count; i++)
                            {
                                Console.WriteLine($"ID: {i + 1}\t| SAMOCHÓD: {ListaSamochodow[i].Marka} {ListaSamochodow[i].Model} \n\tKolor: {ListaSamochodow[i].Kolor}");
                                Console.WriteLine($"\t| Rocznik: {ListaSamochodow[i].Rocznik} \n\t| Cena: {ListaSamochodow[i].Cena}");
                                Console.WriteLine("------------------------------------");
                            }
                            Console.Write("Podaj numer samochodu: ");
                            nr_samochod = int.Parse(Console.ReadLine());
                            nr_samochod = (nr_samochod - 1);
                            samochod = ListaSamochodow[nr_samochod];

                            termin.DodajTermin(ListaKlientow[nr_klient].Pesel, ListaKlientow[nr_klient].Imie, ListaKlientow[nr_klient].Nazwisko, ListaSamochodow[nr_samochod].Marka, ListaSamochodow[nr_samochod].Model, ListaSamochodow[nr_samochod].TablicaRejestracyjna, ListaSamochodow[nr_samochod].Cena, ListaSamochodow[nr_samochod].Kaucja);
                            ListaTerminow.Add(termin);

                            break;
                        }
                    case 6:
                        {
                            int id = 1;
                            Console.WriteLine("TERMINY WYNAJMU:");
                            Console.WriteLine("----------------");
                            if (ListaTerminow.Count == 0)
                            {
                                Console.WriteLine("Lista jest pusta");
                                break;
                            }
                            else
                            {
                                foreach (Termin _termin in ListaTerminow)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\tID WYPOZYCZNIA: " + id);
                                    Console.ResetColor();
                                    _termin.TerminWynajmu();
                                    Console.WriteLine("----------------");
                                    id++;
                                }
                                Console.Write("Podaj który termin chcesz anulować: ");
                                int usun = int.Parse(Console.ReadLine());
                                usun = usun - 1;
                                ListaTerminow.Remove(ListaTerminow[usun]);
                                break;
                            }
                        }
                    case 7:
                        {
                            int id = 1;
                            Console.WriteLine("TERMINY WYNAJMU:");
                            Console.WriteLine("----------------");
                            foreach (Termin _termin in ListaTerminow)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\tID WYPOZYCZNIA: " + id);
                                Console.ResetColor();
                                _termin.TerminWynajmu();
                                Console.WriteLine("----------------");
                                id++;
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Kogo chcesz usunąć:\n1.Pracownika\n2.Klienta\n3.Samochód\n4.COFNIJ\n");
                            Console.Write("WYBÓR: ");
                            int _opcja = int.Parse(Console.ReadLine());


                            if (_opcja == 1)
                            {
                                if (ListaPracownikow.Count == 0)
                                {
                                    Console.WriteLine("Lista jest pusta!");
                                    break;
                                }
                                else
                                {
                                    int nr_pracownika;
                                    Console.WriteLine("LISTA KLIENTOW");
                                    for (int i = 0; i < ListaPracownikow.Count; i++)
                                    {
                                        Console.WriteLine("ID: " + (i + 1) + $" | Klient: {ListaPracownikow[i].Imie} {ListaPracownikow[i].Nazwisko} {ListaPracownikow[i].Pesel}");
                                        Console.WriteLine("----------------------------------------------------------------------------------");
                                    }

                                    Console.Write("Podaj numer klienta: ");
                                    nr_pracownika = int.Parse(Console.ReadLine());
                                    nr_pracownika = (nr_pracownika - 1);

                                    ListaPracownikow.Remove(ListaPracownikow[nr_pracownika]);
                                }
                            }
                            else if (_opcja == 2)
                            {
                                if (ListaKlientow.Count == 0)
                                {
                                    Console.WriteLine("Lista jest pusta!");
                                    break;
                                }
                                else
                                {
                                    int nr_klient;
                                    Console.WriteLine("LISTA KLIENTOW");
                                    for (int i = 0; i < ListaKlientow.Count; i++)
                                    {
                                        Console.WriteLine("ID: " + (i + 1) + $" | Klient: {ListaKlientow[i].Imie} {ListaKlientow[i].Nazwisko} {ListaKlientow[i].Pesel}");
                                        Console.WriteLine("----------------------------------------------------------------------------------");
                                    }

                                    Console.Write("Podaj numer klienta: ");
                                    nr_klient = int.Parse(Console.ReadLine());
                                    nr_klient = (nr_klient - 1);

                                    for (int j = 0; j < ListaTerminow.Count; j++)
                                    {
                                        if (ListaTerminow[j].Pesel == ListaKlientow[nr_klient].Pesel)
                                            ListaTerminow.Remove(ListaTerminow[j]);
                                    }

                                    ListaKlientow.Remove(ListaKlientow[nr_klient]);
                                }
                            }
                            else if (_opcja == 3)
                            {
                                if (ListaSamochodow.Count == 0)
                                {
                                    Console.WriteLine("Lista jest pusta!");
                                    break;
                                }
                                else
                                {
                                    int nr_samochodu;
                                    Console.WriteLine("LISTA SAMOCHODOW");
                                    for (int i = 0; i < ListaSamochodow.Count; i++)
                                    {
                                        Console.WriteLine("ID: " + (i + 1) + $" | Samochód: {ListaSamochodow[i].Marka} {ListaSamochodow[i].Model} {ListaSamochodow[i].TablicaRejestracyjna}");
                                        Console.WriteLine("---------------------------------------------------------------------------------------");
                                    }

                                    Console.WriteLine("Podaj ID samochodu: ");
                                    nr_samochodu = int.Parse(Console.ReadLine());
                                    nr_samochodu = (nr_samochodu - 1);

                                    for (int j = 0; j < ListaTerminow.Count; j++)
                                    {
                                        if (ListaTerminow[j].TablicaRejestracyjna == ListaSamochodow[nr_samochodu].TablicaRejestracyjna)
                                            ListaTerminow.Remove(ListaTerminow[j]);
                                    }

                                    ListaSamochodow.Remove(ListaSamochodow[nr_samochodu]);
                                }
                            }
                            else if(_opcja == 4)
                            {
                                break;
                            }
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            string klienci = "Klient.xml";
                            string pracownicy = "Pracownik.xml";
                            string samochody = "Samochod.xml";
                            string terminy = "Termin.xml";
                            int _wybor;

                            Console.WriteLine("Co chcesz zrobic:\n1.Zapisac\n2.Wczytać\n3.COFNIJ\n");
                            Console.Write("OPCJA: ");
                            _wybor = int.Parse(Console.ReadLine());

                            if (_wybor == 1)
                            {
                                Console.WriteLine("\tZAPISUJESZ DANE...");
                                try
                                {
                                    
                                    StreamWriter stream1 = new StreamWriter(klienci);
                                    XmlSerializer serializer1 = new XmlSerializer(typeof(List<Osoba>));
                                    serializer1.Serialize(stream1, ListaKlientow);
                                    stream1.Close();
                                    
                                    StreamWriter stream2 = new StreamWriter(pracownicy);
                                    XmlSerializer serializer2 = new XmlSerializer(typeof(List<Osoba>));
                                    serializer2.Serialize(stream2, ListaPracownikow);
                                    stream2.Close();
                                    
                                    StreamWriter stream3 = new StreamWriter(samochody);
                                    XmlSerializer serializer3 = new XmlSerializer(typeof(List<Samochod>));
                                    serializer3.Serialize(stream3, ListaSamochodow);
                                    stream3.Close();

                                    StreamWriter stream4 = new StreamWriter(terminy);
                                    XmlSerializer serializer4 = new XmlSerializer(typeof(List<Termin>));
                                    serializer4.Serialize(stream4, ListaTerminow);
                                    stream4.Close();
                                    
                                }
                                catch
                                {
                                    Console.WriteLine("Coś poszlo nie tak!");
                                }
                                }
                            
                            else if (_wybor == 2)
                            {
                                Console.WriteLine("\tWCZYTUJESZ DANE..");
                                try
                                {
                                   
                                    XmlSerializer serializer1 = new XmlSerializer(typeof(List<Osoba>));
                                    StreamReader stream1 = new StreamReader(klienci);
                                    ListaKlientow = (List<Osoba>)serializer1.Deserialize(stream1);
                                    stream1.Close();

                                    StreamReader stream3 = new StreamReader(samochody);
                                    XmlSerializer serializer3 = new XmlSerializer(typeof(List<Samochod>));
                                    ListaSamochodow = (List<Samochod>)serializer3.Deserialize(stream3);
                                    stream3.Close();

                                    StreamReader stream4 = new StreamReader(terminy);
                                    XmlSerializer serializer4 = new XmlSerializer(typeof(List<Termin>));
                                    ListaTerminow = (List<Termin>)serializer4.Deserialize(stream4);
                                    stream4.Close();
                                    
                                }
                                catch
                                {
                                    Console.WriteLine("Coś poszlo nie tak");
                                }
                            }
                            else if(_wybor == 3)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Coś podałes źle!");
                            }
                            Thread.Sleep(1000); Console.Clear();
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

                program.Czyszczenie();
            }
        }

        void Menu()
        {
            Console.WriteLine("----------- MENU -----------");
            Console.WriteLine("1. Dodaj pracownika");
            Console.WriteLine("2. Dodaj klienta");
            Console.WriteLine("3. Dodaj nowy samochód");
            Console.WriteLine("4. Wyswietl baze pracowników / klientów / samochodow");
            Console.WriteLine("5. Wynajem samochodu");
            Console.WriteLine("6. Odwołanie wynajmu");
            Console.WriteLine("7. Wszystkie terminy wynajmów");
            Console.WriteLine("8. Usuniecie pracownika / klienta / samochodu");
            Console.WriteLine("9. Zapis/Odczyt");
            Console.WriteLine("0. ZAMKNIECIE");
            Console.WriteLine("----------------------------");
        }
        bool Sprawdz(string I, string N, string P)
        {
            if (I.Length > 1 && N.Length > 1 && P.Length > 1)
                return true;
            else
                return false;
        }

        void Czyszczenie()
        {
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tWcisnij <ENTER> aby przejsc dalej...");
            Console.ResetColor();
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter))
            {
                Task.Delay(10);
            }
            Console.Clear();
        }
    }
}
