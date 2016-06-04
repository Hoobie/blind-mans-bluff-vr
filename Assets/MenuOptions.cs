using UnityEngine;
using System.Collections;

public class MenuOptions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		Application.LoadLevel ("Main");
	}

	public void ShowHighscores() {
	}

	public void QuitApp() {
		Application.Quit();
	}
}
