using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text scoreText;
	private string scoreString; 
	private int scoreValue;

	// Use this for initialization
	private void Start () {
		scoreString = "Score: ";
		scoreValue = 0;
		scoreText = GetComponent<Text> ();
	}

	public void villagerHit () {
		scoreValue += 15;
		scoreText.text = scoreString + scoreValue;
	}

	public void villageWipeout () {
		scoreValue += 80;
		scoreText.text = scoreString + scoreValue;
	}
	
	// Update is called once per frame
	private void Update () {
	}
}
