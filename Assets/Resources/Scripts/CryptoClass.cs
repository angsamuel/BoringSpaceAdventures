using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoClass {
	Dictionary <int, int> scrambler; 
	public List<string> alphabets;
	string allChars = "abcdefghijklmnopqrstuvwxyz0123456789";
	public CryptoClass(){
		
		scrambler = new Dictionary<int,int> ();
		alphabets = new List<string> ();
		List<int> remainingPositions = new List<int> ();
		for (int i = 0; i < 8; i++) {
			remainingPositions.Add (i);
			alphabets.Add (StringMixer(allChars));
		}
		for (int i = 0; i < 8; i++) {
			int newPositionIndex = Random.Range (0, remainingPositions.Count);
			scrambler.Add (i, remainingPositions[newPositionIndex]);
			remainingPositions.RemoveAt (newPositionIndex);
		}
	
	}

	public string GetCode (int x, int y){
		string xString = (x + 5000).ToString ();
		string yString = (y+5000).ToString ();

		while (xString.Length < 4) {
			xString = "0" + xString;
		}
		while (yString.Length < 4) {
			yString = "0" + yString;
		}
			
		string locationString =xString + yString;
		List<string> code = new List<string>(new string[8]);
		string output = "";
		for (int i = 0; i < 8; i++) {

			code [scrambler [i]] = locationString [i].ToString();
		}

		for (int i = 0; i < 8; i++) {
			//Debug.Log (code[i] + ", " + int.Parse (code [i]).ToString());
			code [i] = alphabets [i] [int.Parse (code [i])].ToString ();
			output = output + code [i];
		}


		Debug.Log (output.ToUpper());
		return output.Substring(0,4).ToUpper() + "-" + output.Substring(4, 4).ToUpper();
	}



	static void Fisher_Yates(int[] array)
	{
		int arraysize = array.Length;
		int random;
		int temp;

		for (int i = 0; i < arraysize; i++)
		{
			random = i + (int)(Random.Range(0.0f,1.0f) * (arraysize - i)); //check for problems

			temp = array[random];
			array[random] = array[i];
			array[i] = temp;
		}
	}

	public static string StringMixer(string s)
	{
		string output = "";
		int arraysize = s.Length;
		int[] randomArray = new int[arraysize];

		for (int i = 0; i < arraysize; i++)
		{
			randomArray[i] = i;
		}

		Fisher_Yates(randomArray);

		for (int i = 0; i < arraysize; i++)
		{
			output += s[randomArray[i]];
		}
		return output;
	}
}
