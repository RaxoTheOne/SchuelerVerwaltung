using System;
using System.Collections.Generic;

namespace SchuelerVerwaltung
{
    class Program
    {
        static List<Schueler> schuelerListe = new List<Schueler>();

        static void Main(string[] args)
        {
            int auswahl;

            do
            {
                Console.WriteLine("\n==== Schuelerverwaltung ====");
                Console.WriteLine("1. Schüler hinzufügen");
                Console.WriteLine("2. Schüler anzeigen");
                Console.WriteLine(("3. Schüler nach Name sortieren"));
                Console.WriteLine("4. Beenden");
                Console.Write("Auswahl: ");

                if (!int.TryParse(Console.ReadLine(), out auswahl))
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    continue;
                }

                switch (auswahl)
                {
                    case 1:
                        SchuelerHinzufuegen();
                        break;
                    case 2:
                        SchuelerAnzeigen();
                        break;
                    case 3:
                        SchuelerSortieren();
                        break;
                    case 4:
                        Console.WriteLine("Programm beendet.");
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl!");
                        break;
                }
            } while (auswahl != 4);
        }

        static void SchuelerHinzufuegen()
        {
            Console.WriteLine("Name: ");
            string? eingabeName = Console.ReadLine();
            if (eingabeName == null)
            {
                Console.WriteLine("Ungültige Eingabe für Name!");
                return;
            }
            string name = eingabeName;

            Console.WriteLine("Alter: ");
            if (!int.TryParse(Console.ReadLine(), out int alter))
            {
                Console.WriteLine("Ungültige Eingabe für Alter!");
                return;
            }

            Console.WriteLine("Klasse: ");
            string? eingabeKlasse = Console.ReadLine();
            if (eingabeKlasse == null)
            { Console.WriteLine("Ungültige Eingabe für Klasse!");
                return;
            }
            string klasse = eingabeKlasse;

            Schueler s = new Schueler(name, alter, klasse);
            schuelerListe.Add(s);
            Console.WriteLine("Schüler hinzugefügt!");
        }

        static void SchuelerAnzeigen()
        {
            if (schuelerListe.Count == 0)
            {
                Console.WriteLine("Keine Schüler vorhanden.");
                return;
            }

            foreach (var s in schuelerListe)
            {
                s.Ausgabe();
            }
        }

        static void SchuelerSortieren()
        {
            schuelerListe.Sort((a, b) => a.name.CompareTo(b.name));
            Console.WriteLine("\nSchüler wurden Alphabetisch nach Name sortiert.");

            // Jetzt die Schüler anzeigen
            foreach (var s in schuelerListe)
            {
                s.Ausgabe();
            }
        }
    }
}
