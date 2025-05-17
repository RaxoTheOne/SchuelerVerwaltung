using System;

public class Schueler
{
	public string name;
	public int alter;
	public string klasse;
	public Schueler(string name, int alter, string klasse)
	{
		this.name = name;
		this.alter = alter;
		this.klasse = klasse;
	}

	public void Ausgabe()
	{
		Console.WriteLine($"Name: {name}, Alter: {alter}, Klasse: {klasse}");
	}
}
