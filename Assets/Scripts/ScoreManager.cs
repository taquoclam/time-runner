using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int score;
	public Text scoreText;

	void Awake(){
		scoreText = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score + "";
	}

	public void addScore(int addValue){
		score += addValue;
	}
}
