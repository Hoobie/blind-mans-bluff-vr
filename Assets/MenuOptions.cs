using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuOptions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		ScoreManager.score = 0;
		Application.LoadLevel ("Main");
	}

	public void ShowHighscores() {
	}

	public void QuitApp() {
		Application.Quit();
	}

	public void ResumeGame() {
		Dictionary<string, string> parameters = new Dictionary<string, string> ();
		parameters.Add ("Score", Scenes.getParam ("Score"));
		parameters.Add ("Time", Scenes.getParam ("Time"));
		Scenes.Load("Main", parameters);
	}
}
