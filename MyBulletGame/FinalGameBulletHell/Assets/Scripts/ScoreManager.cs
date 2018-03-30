using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreManager : MonoBehaviour {


	private static int score = 0; //Player's Score

	private Text text; // referentie naar het text component
	 

	void Awake()
	{
		//Set up voor de referentie
		text = GetComponent<Text>();
	}

	// Veranderd de text in de score
	private void Update()
	{
        text.text = "Score: " + score;
	}

	// voegt toe de op getelde punten op bij het score
	public static void UpScore(int value)
	{
		score += value;
	}

	// zorgt ervoor dat de code reset als je verliest
	public static void ResetScore()
	{
		score = 0;
	}

}
