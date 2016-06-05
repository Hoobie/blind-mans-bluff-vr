using System;
using UnityEngine;

public class ScoreAndTimeUpdate : MonoBehaviour
{
	void Start() {
		string score = Scenes.getParam ("Score");
		string time = Scenes.getParam ("Time");
		GameObject scoreText = GameObject.Find ("Score");
		GameObject timeText = GameObject.Find ("Time");

		if (score == null || time == null)
			return;

		scoreText.GetComponent<UnityEngine.UI.Text> ().text += score;		
		timeText.GetComponent<UnityEngine.UI.Text> ().text += Timer.ParseTime(Convert.ToInt64(time));
	}
}