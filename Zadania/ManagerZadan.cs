using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class ManagerZadan
{
    private List<Zadanie> zadania;
    private int nextId = 1;

    public ManagerZadan()
    {
        zadania = new List<Zadanie>();
    }

    public void DodajZadanie(string nazwa, string opis, DateTime dataZakonczenia, bool czyWykonane)
    {
        Zadanie zadanie = new Zadanie(nextId++, nazwa, opis, dataZakonczenia, czyWykonane);
        zadania.Add(zadanie);
        Console.WriteLine("Dodano zadanie.");
    }

    public void UsunZadanie(int id)
    {
        Zadanie zadanie = zadania.Find(z => z.Id == id);
        if (zadanie != null)
        {
            zadania.Remove(zadanie);
            Console.WriteLine("Usunięto zadanie.");
        }
        else
        {
            Console.WriteLine("Zadanie o podanym Id nie istnieje.");
        }
    }

    public void WyswietlZadania()
    {
        foreach (var zadanie in zadania)
        {
            Console.WriteLine(zadanie);
        }
    }

    public void ZapiszDoPliku(string sciezka)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
        using (StreamWriter writer = new StreamWriter(sciezka))
        {
            serializer.Serialize(writer, zadania);
        }
        Console.WriteLine("Zapisano zadania do pliku.");
    }

    public void WczytajZPliku(string sciezka)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
        using (StreamReader reader = new StreamReader(sciezka))
        {
            zadania = (List<Zadanie>)serializer.Deserialize(reader);
            nextId = zadania.Count > 0 ? zadania[^1].Id + 1 : 1;
        }
        Console.WriteLine("Wczytano zadania z pliku.");
    }
}
