using System;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
	void Start() {
		string score = Scenes.getParam ("score");
		GameObject scoreText = GameObject.Find ("Score");
		scoreText.GetComponent<UnityEngine.UI.Text> ().text += score;
	}
}