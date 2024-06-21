using System;

class Program
{
    static void Main(string[] args)
    {
        ManagerZadan managerZadan = new ManagerZadan();
        string plikZadania = "zadania.xml";

        while (true)
        {
            Console.WriteLine("1. Dodaj zadanie");
            Console.WriteLine("2. Usuń zadanie");
            Console.WriteLine("3. Wyświetl zadania");
            Console.WriteLine("4. Zapisz zadania do pliku");
            Console.WriteLine("5. Wczytaj zadania z pliku");
            Console.WriteLine("6. Wyjście");
            Console.Write("Wybierz opcję: ");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    Console.Write("Podaj nazwę zadania: ");
                    string nazwa = Console.ReadLine();
                    Console.Write("Podaj opis zadania: ");
                    string opis = Console.ReadLine();
                    Console.Write("Podaj datę zakończenia (yyyy-mm-dd): ");
                    DateTime dataZakonczenia;
                    while (!DateTime.TryParse(Console.ReadLine(), out dataZakonczenia))
                    {
                        Console.Write("Nieprawidłowy format daty. Podaj datę zakończenia (yyyy-mm-dd): ");
                    }
                    Console.Write("Czy zadanie wykonane? (true/false): ");
                    bool czyWykonane;
                    while (!bool.TryParse(Console.ReadLine(), out czyWykonane))
                    {
                        Console.Write("Nieprawidłowa wartość. Czy zadanie wykonane? (true/false): ");
                    }
                    managerZadan.DodajZadanie(nazwa, opis, dataZakonczenia, czyWykonane);
                    break;

                case "2":
                    Console.Write("Podaj Id zadania do usunięcia: ");
                    int id;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.Write("Nieprawidłowa wartość. Podaj Id zadania do usunięcia: ");
                    }
                    managerZadan.UsunZadanie(id);
                    break;

                case "3":
                    managerZadan.WyswietlZadania();
                    break;

                case "4":
                    managerZadan.ZapiszDoPliku(plikZadania);
                    break;

                case "5":
                    managerZadan.WczytajZPliku(plikZadania);
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}
