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
                Console.WriteLine("4. Schüler speichern");
                Console.WriteLine("5. Schüler laden");
                Console.WriteLine("6. Beenden");
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
                        SchuelerSpeichern();
                        Console.WriteLine("Schüler gespeichert!");
                        break;
                    case 5:
                        SchuelerLaden();
                        Console.WriteLine("Schüler geladen!");
                        break;
                    case 6:
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
            {
                Console.WriteLine("Ungültige Eingabe für Klasse!");
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

        static void SchuelerSpeichern()
        {
            using (StreamWriter writer = new StreamWriter("schueler.txt"))
            {
                foreach (var s in schuelerListe)
                {
                    // Schreibe die Daten in die Datei in Format von: name; alter; klasse
                    writer.WriteLine($"{s.name};{s.alter};{s.klasse}");
                }
            }
        }

        static void SchuelerLaden()
        {
            if (!File.Exists("Schueler.txt"))
            {
                Console.WriteLine("Keine Datei zum Laden vorhanden.");
                return;
            }

            string[] zeilen = File.ReadAllLines("Schueler.txt");

            schuelerListe.Clear(); // Liste leeren, bevor neue Schüler geladen werden

            foreach (string zeile in zeilen)
            {
                // Zerlege Zeile in Teile
                string[] teile = zeile.Split(';');
                if (teile.Length != 3) continue; // Ungültige Zeile überspringen

                string name = teile[0];
                int alter = int.Parse(teile[1]);
                string klasse = teile[2];

                Schueler s = new Schueler(name, alter, klasse);
                schuelerListe.Add(s);
            }

            Console.WriteLine("Schüler wurden aus der Datei geladen!");
        }
    }
}
