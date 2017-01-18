using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NameGenerator {

	private static List<string> firstNamesDict;

	private static List<string> lastNamesDict;

	public static string firstName() {
		if (firstNamesDict == null) {
			firstNamesDict = new List<string>();

			firstNamesDict.Add ("Torin");
			firstNamesDict.Add ("Fili");
			firstNamesDict.Add ("Kili");
			firstNamesDict.Add ("Balin");
			firstNamesDict.Add ("Dwalin");
			firstNamesDict.Add ("Oin");
			firstNamesDict.Add ("Gloin");
			firstNamesDict.Add ("Dori");
			firstNamesDict.Add ("Nori");
			firstNamesDict.Add ("Ori");
			firstNamesDict.Add ("Bifur");
			firstNamesDict.Add ("Bofur");
			firstNamesDict.Add ("Bombur");
		}

		return firstNamesDict[Random.Range (0,firstNamesDict.Count)];
	}

	public static string lastName() {
		if (lastNamesDict == null) {
			lastNamesDict = new List<string>();

			lastNamesDict.Add ("Oakenshield");
			lastNamesDict.Add ("Gundabad");
			lastNamesDict.Add ("Belegost");
			lastNamesDict.Add ("Nogrod");
			lastNamesDict.Add ("Hithaeglir");
		}

		return lastNamesDict[Random.Range (0,lastNamesDict.Count)];
	}

	public static string fullName() {
		return NameGenerator.firstName () + ' ' + NameGenerator.lastName ();
	}
}
