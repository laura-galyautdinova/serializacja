using System;

[Serializable]
public class Zadanie
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public DateTime DataZakonczenia { get; set; }
    public bool CzyWykonane { get; set; }

    public Zadanie() { }

    public Zadanie(int id, string nazwa, string opis, DateTime dataZakonczenia, bool czyWykonane)
    {
        Id = id;
        Nazwa = nazwa;
        Opis = opis;
        DataZakonczenia = dataZakonczenia;
        CzyWykonane = czyWykonane;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nazwa: {Nazwa}, Opis: {Opis}, Data Zakonczenia: {DataZakonczenia}, Czy Wykonane: {CzyWykonane}";
    }
}
